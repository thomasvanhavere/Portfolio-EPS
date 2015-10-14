package com.trigg.alarmclock;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.ComponentName;
import android.content.ServiceConnection;
import android.media.MediaScannerConnection;
import android.os.IBinder;
import android.support.v7.app.ActionBarActivity;
import android.app.ActionBar;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.hardware.SensorEventListener;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.os.Message;
import android.os.PowerManager;
import android.os.Vibrator;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.Window;
import android.widget.ListAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TabHost;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import org.w3c.dom.Text;

import com.trigg.alarmclock.ReadAndSaveAccelerometerdata.MyLocalBinder;

import com.jjoe64.graphview.GraphView;
import com.jjoe64.graphview.series.DataPoint;
import com.jjoe64.graphview.series.LineGraphSeries;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Random;


public class MainActivity extends ListActivity {

    private AlarmListAdapter mAdapter;
    private AlarmDBHelper dbHelper = new AlarmDBHelper(this);
    private Context mContext;

    private Context context;
    boolean on;

    double temp = 0;

   private PendingIntent pendingIntent;

    TextView RMSaccData;

    int index = 0, numberOfWrites = 0, counter = 0;

    Button BtnStartService;
    Button BtnStopService;

    ReadAndSaveAccelerometerdata ReadandShowDataService;
    boolean isBound = false;

    PowerManager powerManager;
    PowerManager.WakeLock mWakeLock;

    String fileName = "RMS-values.txt";

    private LineGraphSeries<DataPoint> mSeries1;

    RelativeLayout mLayout;
    public LineGraphSeries<DataPoint> mseries;

    private static final Random RANDOM = new Random();
    private int lastx = 0;
    public Double[] displayvalues;

    File RMSFile;

    @Override
    public void onResume() {
        super.onResume();  // Always call the superclass method first


    }
    @Override
    public void onPause() {
        super.onPause();  // Always call the superclass method first
        //wakeLock.release();

    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        requestWindowFeature(Window.FEATURE_ACTION_BAR);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mContext = this;

        mAdapter = new AlarmListAdapter(this, dbHelper.getAlarms());

        setListAdapter(mAdapter);

        TabHost tabHost = (TabHost) findViewById(R.id.tabHost);
        tabHost.setup();

        TabHost.TabSpec spec1 = tabHost.newTabSpec("Tab 1");
        spec1.setContent(R.id.Alarm);
        spec1.setIndicator("Alarm");

        TabHost.TabSpec spec2 = tabHost.newTabSpec("Tab 2");
        spec2.setIndicator("Graphs");
        spec2.setContent(R.id.Graphs);

        TabHost.TabSpec spec3 = tabHost.newTabSpec("Tab 3");
        spec3.setIndicator("About");
        spec3.setContent(R.id.Settings);

        tabHost.addTab(spec1);
        tabHost.addTab(spec2);
        tabHost.addTab(spec3);

        Intent i = new Intent(this, ReadAndSaveAccelerometerdata.class);
        bindService(i, myconnection, Context.BIND_AUTO_CREATE);

        RMSaccData = (TextView) findViewById(R.id.XYZacceleration);
        BtnStartService = (Button) findViewById(R.id.BtnStartservice);
        BtnStopService = (Button) findViewById(R.id.BtnStopService);
        final GraphView graph = (GraphView) findViewById(R.id.graph);
        mseries = new LineGraphSeries<DataPoint>();
        graph.addSeries(mseries);
        graph.getViewport().setYAxisBoundsManual(true);
        graph.getViewport().setXAxisBoundsManual(true);
        graph.getViewport().setMinY(0.0);
        graph.getViewport().setMaxY(10.0);
        graph.getViewport().setScrollable(true);
        graph.getViewport().setMinX(0.0);
        graph.getViewport().setMaxX(200.0);

        RMSFile = new File(((Context)this).getExternalFilesDir(null), fileName);


        BtnStartService.setOnClickListener(new View.OnClickListener() {

            public void onClick(View v) {
                stopService(new Intent(MainActivity.this,ReadAndSaveAccelerometerdata.class));

                graph.removeAllSeries();

                try {
                    if (RMSFile.exists()){

                        RMSFile.delete();
                        //deleteFile(fileName);

                    }

                }
                catch (Exception e){
                    e.printStackTrace();
                }

                startService(new Intent(MainActivity.this, ReadAndSaveAccelerometerdata.class));
                BtnStopService.setEnabled(true);
                BtnStartService.setEnabled(false);
            }
        });
        BtnStopService.setOnClickListener(new View.OnClickListener() {

            public void onClick(View v) {
                BtnStartService.setEnabled(true);
                BtnStopService.setEnabled(false);
                stopService(new Intent(MainActivity.this, ReadAndSaveAccelerometerdata.class));
                Toast.makeText(getApplicationContext(), "The service is stopped", Toast.LENGTH_LONG).show();
                displayvalues = graphData();
                new Thread(new Runnable() {
                    @Override
                    public void run() {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                graph.getViewport().setMaxX(displayvalues.length);
                                for(int i= 1; i <= (displayvalues.length-1);i++)
                                    try {
                                        mseries.appendData(new DataPoint(i,displayvalues[i]),false, (displayvalues.length-1));
                                        if (temp < displayvalues[i]){
                                            temp = displayvalues[i];
                                        }
                                    }
                                    catch(NullPointerException e)
                                    {

                                    }
                                graph.getViewport().setMaxY(temp + 1);
                            }

                        });


                    }

                }).start();
            }
        });

    }

    public Double[] graphData() {

        Double sum = 0.0;
        String data = "";
        int counter = 0;

        try {

            RMSFile = new File(((Context)this).getExternalFilesDir(null), fileName);
            FileInputStream inputStream = new FileInputStream(RMSFile);

            if (inputStream != null) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";

                while ((receiveString = bufferedReader.readLine()) != null) {

                    data += receiveString + "\t";
                }
                inputStream.close();

                String[] RMStemp = data.split("\t");
                Double[] RMSdoubles = new Double[RMStemp.length];
                for (int i = 0; i <= (RMSdoubles.length-1); i++) {
                    try {
                        RMSdoubles[i] = Double.parseDouble(RMStemp[i]);
                    } catch (NumberFormatException e) {
                        Log.e("Message", "An error occurred");
                    }
                }
                Double[]RMSsum = new Double[RMSdoubles.length / 3];
                int posinarray = 0;
                for (int i = 0; i <= (RMSdoubles.length-1); i++) {
                    sum += RMSdoubles[i];
                    counter++;
                    if (counter == 3) {
                        RMSsum[posinarray] = sum;
                        posinarray++;
                        sum = 0.0;
                        counter = 0;
                    }
                }
                double avg = 0.0;
                posinarray = 0;
                int  i, counter2 = 195;
                Double[]graphValues = new Double[RMSsum.length];
                for (i = 0; i <= (RMSsum.length-1); i++) {
                    avg += RMSsum[i];

                    if (i== counter2 && posinarray <= (RMSsum.length-196+1)) {
                        avg /= 196;
                        graphValues[posinarray] = avg;
                        avg = 0.0;
                        i-=194;
                        posinarray++;
                        counter2++;

                    }
                }
                return graphValues;

            }
        } catch (FileNotFoundException e) {
            Log.e("Message", "File not found: " + e.toString());
        } catch (IOException e) {
            Log.e("Message", "Can not read file: " + e.toString());
        }


        return new Double[0];
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.

        switch (item.getItemId()) {
            case R.id.action_add_new_alarm: {
                startAlarmDetailsActivity(-1);
                break;
            }
        }

        return super.onOptionsItemSelected(item);
    }

    private ServiceConnection myconnection = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName name, IBinder service) {
            MyLocalBinder binder = (MyLocalBinder) service;
            ReadandShowDataService = binder.getService();
            isBound = true;

        }

        @Override
        public void onServiceDisconnected(ComponentName name) {
            isBound = false;
        }
    };

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (resultCode == RESULT_OK) {
            mAdapter.setAlarms(dbHelper.getAlarms());
            mAdapter.notifyDataSetChanged();
        }
    }

    public void setAlarmEnabled(long id, boolean isEnabled) {
        AlarmManagerHelper.cancelAlarms(this);

        AlarmModel model = dbHelper.getAlarm(id);
        model.isEnabled = isEnabled;
        dbHelper.updateAlarm(model);

        AlarmManagerHelper.setAlarms(this);
    }

    public void startAlarmDetailsActivity(long id) {
        Intent intent = new Intent(this, AlarmDetailsActivity.class);
        intent.putExtra("id", id);
        startActivityForResult(intent, 0);
    }

    public void deleteAlarm(long id) {
        final long alarmId = id;
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage("Please confirm")
                .setTitle("Delete set?")
                .setCancelable(true)
                .setNegativeButton("Cancel", null)
                .setPositiveButton("Ok", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {

                        try {
                            //Cancel Alarms
                            AlarmManagerHelper.cancelAlarms(mContext);
                            //Delete alarm from DB by id
                            dbHelper.deleteAlarm(alarmId);
                            //Refresh the list of the alarms in the adaptor
                            mAdapter.setAlarms(dbHelper.getAlarms());
                            //Notify the adapter the data has changed
                            mAdapter.notifyDataSetChanged();
                            //Set the alarms
                            AlarmManagerHelper.setAlarms(mContext);
                        } catch (Exception ex) {
                            ex.getMessage();
                        }


                    }
                }).show();
    }

}

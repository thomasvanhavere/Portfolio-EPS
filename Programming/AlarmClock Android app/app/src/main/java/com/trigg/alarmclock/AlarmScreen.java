package com.trigg.alarmclock;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.PowerManager;
import android.os.PowerManager.WakeLock;
import android.os.Vibrator;
import android.util.Log;
import android.view.View;
import android.view.WindowManager;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.jjoe64.graphview.GraphView;
import com.jjoe64.graphview.series.DataPoint;
import com.jjoe64.graphview.series.LineGraphSeries;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;

public class AlarmScreen extends Activity {
	
	public final String TAG = this.getClass().getSimpleName();

	private WakeLock mWakeLock;
	private MediaPlayer mPlayer;

    double temp = 0;

    private LineGraphSeries<DataPoint> mseries;
    public Double[] displayvalues;

    String fileName = "RMS-values.txt";

    File RMSFile;

	private static final int WAKELOCK_TIMEOUT = 60 * 1000;

    private Vibrator mVibrator;

    int vibrate = 1000; // Length of a Morse Code "vibrate" in milliseconds
    int gap = 1000; // Length of Gap Between Letters

    long[] pattern = {0, // Start immediately
            vibrate, gap, vibrate, gap, vibrate,
            gap, vibrate, gap, vibrate, gap, vibrate,
            gap, vibrate, gap, vibrate, gap, vibrate,
            gap};
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		
		//Setup layout
		this.setContentView(R.layout.activity_alarm_screen);

        mVibrator = (Vibrator) getSystemService(Context.VIBRATOR_SERVICE);

        //final GraphView graph = (GraphView) findViewById(R.id.graph);

		String name = getIntent().getStringExtra(AlarmManagerHelper.NAME);
		int timeHour = getIntent().getIntExtra(AlarmManagerHelper.TIME_HOUR, 0);
		int timeMinute = getIntent().getIntExtra(AlarmManagerHelper.TIME_MINUTE, 0);
		String tone = getIntent().getStringExtra(AlarmManagerHelper.TONE);
		
		TextView tvName = (TextView) findViewById(R.id.alarm_screen_name);
		tvName.setText(name);
		
		TextView tvTime = (TextView) findViewById(R.id.alarm_screen_time);
		tvTime.setText(String.format("%02d : %02d", timeHour, timeMinute));


		Button dismissButton = (Button) findViewById(R.id.alarm_screen_button);
		dismissButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View view) {
                //graph.removeAllSeries();
                stopService(new Intent(AlarmScreen.this, ReadAndSaveAccelerometerdata.class));
                Toast.makeText(getApplicationContext(), "The service is stopped", Toast.LENGTH_LONG).show();
                displayvalues = graphData();
                new Thread(new Runnable() {
                    @Override
                    public void run() {
                        runOnUiThread(new Runnable() {
                            @Override
                            public void run() {
                                //graph.getViewport().setMaxX(displayvalues.length);
                                for(int i= 1; i <= (displayvalues.length-1);i++)
                                    try {
                                        mseries.appendData(new DataPoint(i,displayvalues[i]),false, (displayvalues.length-1));
                                        /*if (temp < displayvalues[i]){
                                            temp = displayvalues[i];
                                        }*/
                                    }
                                    catch(NullPointerException e)
                                    {

                                    }
                                //graph.getViewport().setMaxY(temp + 1);
                            }

                        });

                    }

                }).start();

				mPlayer.stop();
                mVibrator.cancel();

				finish();
			}
		});

		//Play alarm tone
		mPlayer = new MediaPlayer();
		try {
			if (tone != null && !tone.equals("")) {
				Uri toneUri = Uri.parse(tone);
				if (toneUri != null) {
					mPlayer.setDataSource(this, toneUri);
					mPlayer.setAudioStreamType(AudioManager.STREAM_ALARM);
					mPlayer.setLooping(true);
					mPlayer.prepare();
					mPlayer.start();
                    mVibrator.vibrate(pattern,0);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		//Ensure wakelock release
		Runnable releaseWakelock = new Runnable() {

			@Override
			public void run() {
				getWindow().clearFlags(WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);
				getWindow().clearFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
				getWindow().clearFlags(WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED);
				getWindow().clearFlags(WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD);

				if (mWakeLock != null && mWakeLock.isHeld()) {
					mWakeLock.release();
				}
			}
		};

		new Handler().postDelayed(releaseWakelock, WAKELOCK_TIMEOUT);
	}
	
	@SuppressWarnings("deprecation")
	@Override
	protected void onResume() {
		super.onResume();

		// Set the window to keep screen on
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_TURN_SCREEN_ON);
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_KEEP_SCREEN_ON);
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_SHOW_WHEN_LOCKED);
		getWindow().addFlags(WindowManager.LayoutParams.FLAG_DISMISS_KEYGUARD);

		// Acquire wakelock
		PowerManager pm = (PowerManager) getApplicationContext().getSystemService(Context.POWER_SERVICE);
		if (mWakeLock == null) {
			mWakeLock = pm.newWakeLock((PowerManager.FULL_WAKE_LOCK | PowerManager.SCREEN_BRIGHT_WAKE_LOCK | PowerManager.ACQUIRE_CAUSES_WAKEUP), TAG);
		}

		if (!mWakeLock.isHeld()) {
			mWakeLock.acquire();
			Log.i(TAG, "Wakelock aquired!!");
		}

	}

	@Override
	protected void onPause() {
		super.onPause();

		if (mWakeLock != null && mWakeLock.isHeld()) {
			mWakeLock.release();
		}
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

}

package com.trigg.alarmclock;

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.media.MediaScannerConnection;
import android.os.Binder;
import android.os.IBinder;
import android.os.PowerManager;
import android.widget.Toast;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;


public class ReadAndSaveAccelerometerdata extends Service implements SensorEventListener {
    public ReadAndSaveAccelerometerdata() {
    }
    private final IBinder myBinder = new MyLocalBinder();


    Sensor accelerometer;

    float RMS_X = 0;
    float RMS_Y = 0;
    float RMS_Z = 0;
    float X = 0;
    float Y = 0;
    float Z = 0;
    float average_old_x = 0;
    float average_old_y = 0;
    float average_old_z = 0;
    float average_new_x = 0;
    float average_new_y = 0;
    float average_new_z = 0;

    int index = 0, numberOfWrites = 0;

    File RMSFile;

    ArrayList<Float> RMS_X_data = new ArrayList<Float>();

    String fileName = "RMS-values.txt";


    Intent  intent;
    String  sendData;


    PowerManager powerManager;
    PowerManager.WakeLock wakeLock;

    @Override
    public IBinder onBind(Intent intent) {
        return myBinder;
    }

    @Override
    public void onCreate(){
        super.onCreate();
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId)
    {
        SensorManager sm = (SensorManager) getSystemService(SENSOR_SERVICE);
        accelerometer = sm.getDefaultSensor(Sensor.TYPE_ACCELEROMETER);
        sm.registerListener((SensorEventListener) this, accelerometer, SensorManager.SENSOR_DELAY_NORMAL);

        RMSFile = new File(((Context)this).getExternalFilesDir(null), fileName);

        Toast.makeText(getApplicationContext(), "The service is running",Toast.LENGTH_LONG).show();


        powerManager = (PowerManager) getApplicationContext().getSystemService(POWER_SERVICE);
        wakeLock = powerManager.newWakeLock((PowerManager.FULL_WAKE_LOCK     | PowerManager.ACQUIRE_CAUSES_WAKEUP),
                "MyWakelockTag");
        wakeLock.acquire();

        return START_STICKY;
    }

    public void onAccuracyChanged(Sensor sensor, int accuracy)
    {

    }
    public void onSensorChanged(SensorEvent event)
    {

        X = (float) 0.1453 * event.values[0] - (float) 48.298;
        Y = (float) 0.1432 * event.values[1] - (float) 47.784;
        Z = (float) 0.1521 * event.values[2] - (float) 52.767;
        Measurement();

    }
    void writeToFile(String data)
    {

        try
        {
             if (!RMSFile.exists())
                RMSFile.createNewFile();

            BufferedWriter writer = new BufferedWriter(new FileWriter(RMSFile, true));
            writer.write(data);
            writer.close();

            MediaScannerConnection.scanFile((Context) (this),
                    new String[]{RMSFile.toString()},
                    null,
                    null);
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }
   public void Measurement() {
        average_new_x = average_new_x + X;
        average_new_y = average_new_y + Y;
        average_new_z = average_new_z + Z;

        X = X - average_old_x;
        Y = Y - average_old_y;
        Z = Z - average_old_z;

        RMS_X = RMS_X + (X*X);
        RMS_Y = RMS_Y + (Y*Y);
        RMS_Z = RMS_Z + (Z*Z);

        if (index > 1000)
        {
            index = 0;
            average_new_x = (float) (average_new_x/1000.0);
            average_new_y = (float) (average_new_y/1000.0);
            average_new_z = (float) (average_new_z/1000.0);

            average_old_x = average_new_x;
            average_old_y = average_new_y;
            average_old_z = average_new_z;

            RMS_X = RMS_X / 1000;
            RMS_Y = RMS_Y / 1000;
            RMS_Z = RMS_Z / 1000;


            RMS_X = (float) Math.sqrt(RMS_X);
            RMS_Y = (float) Math.sqrt(RMS_Y);
            RMS_Z = (float) Math.sqrt(RMS_Z);

            String data = Float.toString(RMS_X) +"\t" +Float.toString(RMS_Y)+"\t" +Float.toString(RMS_Z)+ "\n";

            writeToFile(data);

        }
        index++;
    }

    public class MyLocalBinder extends Binder {
        ReadAndSaveAccelerometerdata getService() {
            return ReadAndSaveAccelerometerdata.this;
        }
    };

    @Override
    public void onDestroy()
    {
        super.onDestroy();

    }
}
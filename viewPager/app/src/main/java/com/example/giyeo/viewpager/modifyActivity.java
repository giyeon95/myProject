package com.example.giyeo.viewpager;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Calendar;

public class modifyActivity extends AppCompatActivity {
    private String DiaryStrDate = "____년 __월 __일";
    Handler handler;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.modifydiary);
        updateresult();


        Intent intent = getIntent();
        MyData data = (MyData)intent.getSerializableExtra("diary");
        //Log.e("indextest",data+"입니다");

        handler= new Handler(Looper.getMainLooper());
        handler.post(new Runnable() {
            @Override
            public void run() {



            }
        });


    }

    public void modify_Click(View v){
        Toast.makeText(this, "수정되었습니다.", Toast.LENGTH_SHORT).show();
    }

    public void cancel_Click(View v){
        finish();
    }

    private void updateresult() {
        TextView dateResult = (TextView) findViewById(R.id.textdate);
        dateResult.setText(DiaryStrDate);
    }

    public void date_Click(View v){
        Calendar c = Calendar.getInstance();
        switch (v.getId()){
            case R.id.selectdate:
                int year = c.get(Calendar.YEAR);
                int month = c.get(Calendar.MONTH);
                int day = c.get(Calendar.DATE);
                new DatePickerDialog(this, mDateSetListener, year, month, day).show();

        }
    }

    private DatePickerDialog.OnDateSetListener mDateSetListener
            = new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
            DiaryStrDate = String.format("%d년 %d월 %d일", year, month+1, dayOfMonth);
            updateresult();
        }
    };
}

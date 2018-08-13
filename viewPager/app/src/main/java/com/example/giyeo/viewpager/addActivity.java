package com.example.giyeo.viewpager;

import android.app.DatePickerDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.support.constraint.ConstraintLayout;
import android.support.v4.app.ActivityCompat;
import android.support.v7.app.AppCompatActivity;
import android.util.Base64;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.ByteArrayOutputStream;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class addActivity extends AppCompatActivity {
    private String DiaryStrDate = "____-__- __";
    private String userNickname;
    private String userId;
    private String userUrl;

    private EditText t_title;
    private EditText t_text;
    private EditText t_city;
    private TextView t_date;
    private Bitmap intent_photo;
    private CheckBox checkBox;
    private String d_title;
    private String d_text;
    private String d_city;
    private String travel_date;
    private boolean photoshare = false;
    private String photoshareing;

    private Handler handler;
    ImageView image;
    String temp="";
    MyData modifyData;
    private final long FINISH_INTERVAL_TIME = 2000;
    private long backPressedTime = 0;

    static final int getimagesetting=1001;//for request intent
    private static final int REQUEST_CAMERA = 1;

    String newstring;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.add_diary);

        userId = getIntent().getStringExtra("ID");
        userNickname = getIntent().getStringExtra("nickname");
        userUrl = getIntent().getStringExtra("url");
        ////Log.e("modify",modifyData+"입니다.");


        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );


        handler = new Handler();


        t_title = (EditText) findViewById(R.id.addtitle);
        t_text = (EditText) findViewById(R.id.addText);
        t_city = (EditText) findViewById(R.id.addCity);
        t_date = (TextView) findViewById(R.id.adddate);
        image=(ImageView)findViewById(R.id.image);
        checkBox=(CheckBox)findViewById(R.id.photoCheckbox);

        permission_init();

        updateresult();
    }



    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    void permission_init(){
        if(ActivityCompat.checkSelfPermission(this, android.Manifest.permission.CAMERA)
                != PackageManager.PERMISSION_GRANTED) {	//권한 거절
            // Request missing location permission.
            // Check Permissions Now

            if (ActivityCompat.shouldShowRequestPermissionRationale(this,
                    android.Manifest.permission.CAMERA)) {
                // 이전에 권한거절
                // Toast.makeText(this,getString(R.string.limit),Toast.LENGTH_SHORT).show();

            } else {
                ActivityCompat.requestPermissions(
                        this, new String[]{android.Manifest.permission.CAMERA},
                        REQUEST_CAMERA);
            }

        } else {	//권한승인
            ////Log.e("onConnected","else");
            // mLastLocation = LocationServices.FusedLocationApi.getLastLocation(mGoogleApiClient);
        }

    }

    public void setOnClick(View view) {
        switch(view.getId()){
            case R.id.get:
                addImage();
                break;

        }
    }




    void addImage(){
        Intent intent=new Intent(getApplicationContext(),SetImageActivity.class);

        startActivityForResult(intent, getimagesetting);
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode==getimagesetting){	//if image change

            if(resultCode==RESULT_OK){
                Bitmap selPhoto = null;
                selPhoto=(Bitmap) data.getParcelableExtra("bitmap");
                image.setImageBitmap(selPhoto);//썸네일
                intent_photo = selPhoto;
                BitMapToString(selPhoto);
            }
        }
    }
    public void BitMapToString(Bitmap bitmap){

        ByteArrayOutputStream baos=new  ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.PNG,100, baos);	//bitmap compress
        byte [] arr=baos.toByteArray();
        String image= Base64.encodeToString(arr, Base64.DEFAULT);
        Log.e("diaryInsert","\nBase64 Encoder : ----"+image);


        try{
            temp= URLEncoder.encode(image,"utf-8");
            //Log.e("diaryInsert","\nurl Encoder : ----"+temp);

        }catch (Exception e){
           //Log.e("exception",e.toString());
        }

    }


    public void save_Click(View v){

        photoshare = checkBox.isChecked();
        photoshareing = photoshare ? "1": "0";



        d_title = t_title.getText().toString();
        d_text = t_text.getText().toString();
        d_city = t_city.getText().toString();
        travel_date = t_date.getText().toString();


       if(d_title=="" || d_text =="" || d_city=="" || travel_date == "____-__- __") {

           Toast.makeText(this, "빈칸을 확인하고 다시 입력해주세요", Toast.LENGTH_SHORT).show();
        }
        else {
            //Log.e("addDiary","saveClick 으로 전송");
            addActivity.InsertData task = new addActivity.InsertData(this);
            task.execute(userId,userNickname,d_title,d_text,d_city,travel_date,temp,photoshareing);

            String[] addDiary = new String[4];
            addDiary[0] = d_title;
            addDiary[1] = travel_date;
            addDiary[2] = d_city;
            addDiary[3] = d_text;


            Intent intent = new Intent(this,MainActivity.class);
            intent.putExtra("nickname",userNickname);
            intent.putExtra("ID",userId);
            intent.putExtra("url",userUrl);
            intent.putExtra("addImage",intent_photo);
            intent.putExtra("addDiary",addDiary);
            startActivityForResult(intent,0);

            finish();
        }

    }

    public void cancel_Click(View v){
        finish();
    }

    private void updateresult() {
        TextView dateResult = (TextView) findViewById(R.id.adddate);
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

    private final DatePickerDialog.OnDateSetListener mDateSetListener
            = new DatePickerDialog.OnDateSetListener() {
        @Override
        public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {

            if ((month + 1) < 10 && dayOfMonth >= 10) {
                DiaryStrDate = String.format(year + "-" + 0 + (month + 1) + "-" + dayOfMonth);
            } else if ((month + 1) < 10 && dayOfMonth < 10) {
                DiaryStrDate = String.format(year + "-" + 0 + (month + 1) + "-" + 0 + dayOfMonth);
            } else if ((month + 1) >= 10 && dayOfMonth < 10) {
                DiaryStrDate = String.format(year + "-" + (month + 1) + "-" + 0 + dayOfMonth);
            } else {
                DiaryStrDate = String.format(year + "-" + (month + 1) + "-" + dayOfMonth);
            }
            updateresult();
        }
    };

    //DB에 값저장
    public class InsertData extends AsyncTask<String, Void, String> {

        private String TAG = "diaryInsert";
        ProgressDialog progressDialog;
        private Context mainContext;


        public InsertData(Context con) {
            this.mainContext = con;

        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            progressDialog = ProgressDialog.show(mainContext,
                    "Please Wait", "DB에 저장 중입니다. 잠시만 기다려주세요.", true, true);

        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);
            progressDialog.dismiss();
            finish();
           //Log.d(TAG, "POST response  - " + result);
        }

        @Override
        protected String doInBackground(String... params) {

            String ID = (String) params[0];
            String NicName = (String) params[1];
            String d_title = (String) params[2];
            String d_text = (String) params[3];
            String d_city = (String) params[4];
            String travel_date = (String) params[5];
            String photo = (String) params[6];
            String photo_share = (String) params[7];

            // String serverURL = "http://192.168.25.49:2133/insertdiary.php?image"+photo; // 내부 ip
            String serverURL = "http://118.217.34.116:2133/insertDiary.php?image"+photo;  // 공인 ip
            String postParameters = "kakaoID=" + ID + "&NickName=" + NicName + "&d_title="
                                    + d_title+ "&d_text=" + d_text+ "&d_city=" + d_city
                                    + "&travel_date=" + travel_date +"&photo=" + photo+ "&photoshare=" + photo_share;
           //Log.d(TAG, "addDiary 정보 - " + postParameters);
            try {

                URL url = new URL(serverURL);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();


                httpURLConnection.setReadTimeout(5000);
                httpURLConnection.setConnectTimeout(5000);
                httpURLConnection.setRequestMethod("POST");
                httpURLConnection.connect();


                OutputStream outputStream = httpURLConnection.getOutputStream();
                outputStream.write(postParameters.getBytes("UTF-8"));
                outputStream.flush();
                outputStream.close();


                int responseStatusCode = httpURLConnection.getResponseCode();


                InputStream inputStream;
                if (responseStatusCode == HttpURLConnection.HTTP_OK) {
                    ////Log.d(TAG,"접속");
                    inputStream = httpURLConnection.getInputStream();
                } else {
                    inputStream = httpURLConnection.getErrorStream();
                }

                InputStreamReader inputStreamReader = new InputStreamReader(inputStream, "UTF-8");
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);

                StringBuilder sb = new StringBuilder();
                String line = null;

                while ((line = bufferedReader.readLine()) != null) {
                    sb.append(line);
                }
                bufferedReader.close();

                return sb.toString();

            } catch (Exception e) {

               //Log.d(TAG, "InsertData: Error ", e);

                return new String("Error: " + e.getMessage());
            }

        }
    }
    @Override
    public void onBackPressed() {
        long tempTime = System.currentTimeMillis();
        long intervalTime = tempTime - backPressedTime;

        if (0 <= intervalTime && FINISH_INTERVAL_TIME >= intervalTime) {
            super.onBackPressed();
        } else {
            backPressedTime = tempTime;
            Toast.makeText(this, "뒤로 가시겠습니까?", Toast.LENGTH_SHORT).show();
        }
    }

}
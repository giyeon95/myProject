package com.example.giyeo.viewpager;

import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Base64;
import android.util.Log;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

public class AlbumActivity extends AppCompatActivity {



    private Context context;
    private String userId;
    private String userNick;
    private String userPhoto;
    private TextView textView;
    private ImageView imageView;

    private static final String TAG = "MakePlan";
    private static final String TAG_CITY ="d_city";
    private static final String TAG_NICKNAME = "User_NickName";
    private static final String TAG_PHOTO ="photo";
    private ArrayList<GridData> myData = new ArrayList<>();
    private GridView mGrid;
    private UserGridAdapter mAdapter;


    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.album);
        context = this;




        textView = (TextView)findViewById(R.id.titleTextView);
        imageView = (ImageView)findViewById(R.id.photoOnner);
         mGrid = (GridView) findViewById(R.id.grid);

         GetData task = new GetData();
        // task.execute("http://192.168.25.49:2133/getDiary.php"); // 내부 ip
        userId = getIntent().getStringExtra("userId");
        userNick = getIntent().getStringExtra("userNick");
        userPhoto = getIntent().getStringExtra("userPhoto");
        Glide.with(context).load(userPhoto).apply(new RequestOptions().circleCrop()).into(imageView);
        textView.setText(userNick+" 님의 사진첩");


        task.execute("http://118.217.34.116:2133/getPhotoUser.php",userId); // 공인 ip


    }


    public void data_load(final String result) {

        String[] city;
        String[] user_NickName;
        Bitmap[] photo;
        GridData[] gridData;
        ////Log.e("jsontest",result+"입니다.");
        int jarrayCount =0;

        try{
            JSONObject jsonObject = new JSONObject(result);

            JSONArray jArray= jsonObject.getJSONArray("webnautes");

            jarrayCount = jArray.length();

            ////Log.e("array_count try",jarrayCount+"");


            city=new String[jarrayCount];
            user_NickName=new String[jarrayCount];
            photo=new Bitmap[jarrayCount];
            gridData=new GridData[jarrayCount];


            for(int i=0;i<jarrayCount;i++){
                JSONObject jsonObject2=jArray.getJSONObject(i);

                city[i]=jsonObject2.getString(TAG_CITY);
                user_NickName[i]=jsonObject2.getString(TAG_NICKNAME);
                photo[i]=StringToBitMap(jsonObject2.getString(TAG_PHOTO));

            }

            for(int i=0 ; i <jarrayCount ; i++ ) {
                gridData[i] = new GridData(city[i],photo[i],user_NickName[i]);
            }
            for(int i=jarrayCount-1 ; i>=0 ; i--) {
                ////Log.e("griddata","넘어옴!");
                myData.add(gridData[i]);
            }
               mAdapter = new UserGridAdapter(context, myData);
                mGrid.setAdapter(mAdapter);
                mAdapter.notifyDataSetChanged();




        }catch (Exception e){
            String temp=e.toString();

            while (temp.length() > 0) {
                if (temp.length() > 4000) {
                    ////Log.e("imageLog", temp.substring(0, 4000));
                    temp = temp.substring(4000);
                } else {
                    ////Log.e("imageLog",  temp);
                    break;
                }
            }
        }
    }


    private static Bitmap StringToBitMap(String image){
        ////Log.e("StringToBitMap","StringToBitMap");
        try{
            byte [] encodeByte= Base64.decode(image,Base64.DEFAULT);
            Bitmap bitmap= BitmapFactory.decodeByteArray(encodeByte, 0, encodeByte.length);
            ////Log.e("StringToBitMap","good");
            return bitmap;
        }catch(Exception e){
            e.getMessage();
            return null;
        }
    }

    private class GetData extends AsyncTask<String, Void, String> {
        ProgressDialog progressDialog;
        String errorString = null;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

            progressDialog = ProgressDialog.show(context,
                    "Please Wait", null, true, true);

        }

        @Override
        protected void onPostExecute(final String result) {
            super.onPostExecute(result);

            progressDialog.dismiss();
            ////Log.d(TAG, "response  - " + result);

            data_load(result);
        }


        @Override
        protected String doInBackground(String... params) {

            String serverURL = params[0];
            String User_kakaoID = params[1];

            String postParameters = "kakaoID=" + User_kakaoID;

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
                ////Log.d(TAG, "response code - " + responseStatusCode);

                InputStream inputStream;

                if(responseStatusCode == HttpURLConnection.HTTP_OK) {
                    inputStream = httpURLConnection.getInputStream();
                    ////Log.e(TAG,"접속");
                }

                else{
                    inputStream = httpURLConnection.getErrorStream();
                }


                InputStreamReader inputStreamReader = new InputStreamReader(inputStream, "UTF-8");
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);

                StringBuilder sb = new StringBuilder();
                String line;

                while((line = bufferedReader.readLine()) != null){
                    sb.append(line);
                }


                bufferedReader.close();

                return sb.toString().trim();

            } catch (Exception e) {

                ////Log.d(TAG, "InsertData: Error ", e);

                return null;
            }

        }
    }



}

package com.example.giyeo.viewpager;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class JoinUserList extends AppCompatActivity {


    private String userId;
    private String userNick;
    private String userUrl;
    private String TAG = "listtest";
    private Context context;
    private UserAdapter userAdapter;
    private ListView listView;
    private static final String TAG_KAKAOID ="kakaoID";
    private static final String TAG_NICKNAME ="NickName";
    private static final String TAG_PROFILE ="profile";

    private ArrayList<userData> userData = new ArrayList<>();


    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.join_userlist);
        this.context = this;

        userId = getIntent().getStringExtra("ID");
        userNick = getIntent().getStringExtra("nickname");
        userUrl = getIntent().getStringExtra("url");

        GetData task = new GetData();
        // task.execute("http://192.168.25.49:2133/getDiary.php"); // 내부 ip
        task.execute("http://118.217.34.116:2133/getUserInfo.php"); // 공인 ip


        listView =(ListView)findViewById(R.id.userListView);
        //Log.e("userTest","넘어옴1!");
        userAdapter = new UserAdapter(context, R.layout.join_userlist, userData);
        listView.setAdapter(userAdapter);
        //listView.deferNotifyDataSetChanged();
        //Log.e("userTest","넘어옴2!");
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                registerForContextMenu(listView);

            }
        });

    }


    public void data_load(final String result) {
        String[] kakaoID;
        String[] NickName;
        String[] profile;
        userData[] user;

        //Log.e("jsontest",result+"입니다.");
        int jarrayCount =0;

        try{
            JSONObject jsonObject = new JSONObject(result);

            JSONArray jArray= jsonObject.getJSONArray("webnautes");

            jarrayCount = jArray.length();

            //Log.e("array_count try",jarrayCount+"");

            kakaoID=new String[jarrayCount];
            NickName=new String[jarrayCount];
            profile=new String[jarrayCount];
            user=new userData[jarrayCount];

            for(int i=0;i<jarrayCount;i++){
                JSONObject jsonObject2=jArray.getJSONObject(i);


                kakaoID[i]=jsonObject2.getString(TAG_KAKAOID);
                NickName[i]=jsonObject2.getString(TAG_NICKNAME);
                profile[i]=jsonObject2.getString(TAG_PROFILE);

                //Log.e("jsontest","접속6");


            }
            //Log.e("jsontest","접속7");
            for(int i=0 ; i <jarrayCount ; i++ ) {
                user[i] = new userData(kakaoID[i],NickName[i],profile[i]);
            }
            for(int i=jarrayCount-1 ; i>=0 ; i--) {
                userData.add(user[i]);
            }
            userAdapter.notifyDataSetChanged();


        }catch (Exception e){
            //Log.e("Exception",e+" = error");
        }
    }


    private class GetData extends AsyncTask<String, Void, String> {
        //ProgressDialog progressDialog;
        String errorString = null;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();

        // progressDialog = ProgressDialog.show(context,
      //            "Please Wait", null, true, true);

        }

        @Override
        protected void onPostExecute(final String result) {
            super.onPostExecute(result);

            //progressDialog.dismiss();
            //Log.d(TAG, "response  - " + result);
            //    mJsonString = result;
            data_load(result);
        }


        @Override
        protected String doInBackground(String... params) {

            String serverURL = params[0];





            try {
                URL url = new URL(serverURL);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();


                httpURLConnection.setReadTimeout(5000);
                httpURLConnection.setConnectTimeout(5000);
                httpURLConnection.setRequestMethod("POST");
                httpURLConnection.connect();

                int responseStatusCode = httpURLConnection.getResponseCode();
                //Log.d(TAG, "response code - " + responseStatusCode);

                InputStream inputStream;

                if(responseStatusCode == HttpURLConnection.HTTP_OK) {
                    inputStream = httpURLConnection.getInputStream();
                    //Log.e(TAG,"접속");
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

                //Log.d(TAG, "InsertData: Error ", e);

                return null;
            }

        }
    }
}

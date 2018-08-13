package com.example.giyeo.viewpager;

import android.annotation.SuppressLint;
import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Base64;
import android.util.Log;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;


@SuppressLint("ValidFragment")
public class Diary extends Fragment {

    private String userId;
    private String userNic;

    private final static String FRAGMENT_TAG = "fragment_Diary";
    private static final String TAG = "Frag_Diary";
    private static final String TAG_JSON="webnautes";
    private static final String TAG_KAKAOID = "User_kakaoID";
    private static final String TAG_TITLE ="d_title";
    private static final String TAG_TEXT ="d_text";
    private static final String TAG_CITY ="d_city";
    private static final String TAG_DATE ="travel_date";
    private static final String TAG_PHOTO ="photo";
    private boolean check= false;



    private ListView mList;
    private ArrayList<MyData> myData = new ArrayList<>();
    private MyAdapter myAdapter;
    private  Context context;
    Handler handler;

    public Diary() {

    }

    public Diary(String ID, String nic) {

        this.userId = ID;
        this.userNic = nic;
    }


    //DB에서 데이터값 전송받음
    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        this.context = context;

        handler= new Handler(Looper.getMainLooper());



        GetData task = new GetData();
        // task.execute("http://192.168.25.49:2133/getDiary.php"); // 내부 ip
        task.execute("http://118.217.34.116:2133/getDiary.php",userId); // 공인 ip

    }

    public void data_load(final String result) {
        String[] title;
        String[] text;
        String[] city;
        String[] travel_date;
        Bitmap[] photo;
        MyData[] diary;
        myData.clear();

        //Log.e("jsontest",result+"입니다.");
        int jarrayCount =0;

        try{
            JSONObject jsonObject = new JSONObject(result);

            JSONArray jArray= jsonObject.getJSONArray("webnautes");

            jarrayCount = jArray.length();

            //Log.e("array_count try",jarrayCount+"");

            title=new String[jarrayCount];
            text=new String[jarrayCount];
            city=new String[jarrayCount];
            travel_date=new String[jarrayCount];
            photo=new Bitmap[jarrayCount];
            diary=new MyData[jarrayCount];


            for(int i=0;i<jarrayCount;i++){
                JSONObject jsonObject2=jArray.getJSONObject(i);


                title[i]=jsonObject2.getString(TAG_TITLE);
                text[i]=jsonObject2.getString(TAG_TEXT);
                city[i]=jsonObject2.getString(TAG_CITY);
                travel_date[i]=jsonObject2.getString(TAG_DATE);
                photo[i]=StringToBitMap(jsonObject2.getString(TAG_PHOTO));
                //Log.e("jsontest","접속6");


            }
            //Log.e("jsontest","접속7");
            for(int i=0 ; i <jarrayCount ; i++ ) {
                diary[i] = new MyData(title[i],travel_date[i],city[i],photo[i],text[i]);
            }
            for(int i=jarrayCount-1 ; i>=0 ; i--) {
                myData.add(diary[i]);
            }

           myAdapter.notifyDataSetChanged();

        }catch (Exception e){
            String temp=e.toString();

            while (temp.length() > 0) {
                if (temp.length() > 4000) {
                    //Log.e("imageLog", temp.substring(0, 4000));
                    temp = temp.substring(4000);
                } else {
                    //Log.e("imageLog",  temp);
                    break;
                }
            }
        }
    }


    public static Bitmap StringToBitMap(String image){
        //Log.e("StringToBitMap","StringToBitMap");
        try{
            byte [] encodeByte= Base64.decode(image,Base64.DEFAULT);
            Bitmap bitmap= BitmapFactory.decodeByteArray(encodeByte, 0, encodeByte.length);
            //Log.e("StringToBitMap","good");
            return bitmap;
        }catch(Exception e){
            e.getMessage();
            return null;
        }
    }



    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.layout_diary, container,false);


        mList = (ListView) view.findViewById(R.id.diarylist);

        myAdapter = new MyAdapter(context, R.layout.sub_diary, myData);
        mList.setAdapter(myAdapter);

        mList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                registerForContextMenu(mList);
                //Log.e("context","Context메뉴클릭!");
            }
        });
        return view;
    }

    @Override
    public void onStart() {
        super.onStart();



    }

    @Override
    public void onResume() {
        super.onResume();
     
    }

    @Override
        public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo){
            //Log.e("context","onCreateContextMenu");
            super.onCreateContextMenu(menu, v, menuInfo);
            menu.add(Menu.NONE, R.id.correct,Menu.NONE,"수정");
            menu.add(Menu.NONE, R.id.del,Menu.NONE,"삭제");
        }


        public boolean onContextItemSelected(MenuItem item) {
            AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo)item.getMenuInfo();
            int index = info.position;
            switch(item.getItemId()){
                case R.id.correct:
                    //Toast.makeText(context, "수정!", Toast.LENGTH_SHORT).show();
                   ((MainActivity)getActivity()).diaryCallback(myData.get(index));
                    break;
                case R.id.del:
                    Diary.DeleteData task = new Diary.DeleteData(context);
                    task.execute(userId,myData.get(index).getMyTitle(),myData.get(index).getMyContext(),myData.get(index).getMyCity(),myData.get(index).getMydate());
                    myData.remove(index);
                    myAdapter.notifyDataSetChanged();

                    break;
            }
            return true;
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
            //Log.d(TAG, "response  - " + result);
            //    mJsonString = result;


                    data_load(result);
        }


        @Override
        protected String doInBackground(String... params) {

            String serverURL = params[0];
            String ID = (String)params[1];

            //Log.e(TAG,"넘어온 params[1] = "+ID);

            String postParameters = "kakaoID=" + ID;
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

                //Log.e(TAG,"보내는 값 : "+postParameters);

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

    //DB에 값삭제
    public class DeleteData extends AsyncTask<String, Void, String> {

        private String TAG = "diaryInsert";
        ProgressDialog progressDialog;
        private Context mainContext;


        public DeleteData(Context con) {
            this.mainContext = con;

        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            progressDialog = ProgressDialog.show(mainContext,
                    "Please Wait", "DB에서 삭제중입니다. 잠시만 기다려주세요.", true, true);

        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);
            progressDialog.dismiss();
            //Log.d(TAG, "POST response  - " + result);
        }

        @Override
        protected String doInBackground(String... params) {

            String ID = (String) params[0];
            String d_title = (String) params[1];
            String d_text = (String) params[2];
            String d_city = (String) params[3];
            String travel_date = (String) params[4];

            // String serverURL = "http://192.168.25.49:2133/insertdiary.php?image"+photo; // 내부 ip
            String serverURL = "http://118.217.34.116:2133/deleteDiary.php"; //공인 ip
            String postParameters = "kakaoID=" + ID + "&d_title="
                    + d_title+ "&d_text=" + d_text+ "&d_city=" + d_city
                    + "&travel_date=" + travel_date;
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
                    //Log.d(TAG,"접속");
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

}

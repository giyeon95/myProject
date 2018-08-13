package com.example.giyeo.viewpager;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.Signature;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;
import android.support.constraint.ConstraintLayout;
import android.support.design.widget.TabLayout;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.view.ViewPager;
import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.util.Base64;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;
import com.kakao.usermgmt.UserManagement;
import com.kakao.usermgmt.callback.LogoutResponseCallback;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;


public class MainActivity extends AppCompatActivity {

    /**
     * The {@link android.support.v4.view.PagerAdapter} that will provide
     * fragments for each of the sections. We use a
     * {@link FragmentPagerAdapter} derivative, which will keep every
     * loaded fragment in memory. If this becomes too memory intensive, it
     * may be best to switch to a
     * {@link android.support.v4.app.FragmentStatePagerAdapter}.
     */
    private SectionsPagerAdapter mSectionsPagerAdapter;
    Communication com;
    /**
     * The {@link ViewPager} that will host the section contents.
     */


    private final long FINISH_INTERVAL_TIME = 2000;
    private long backPressedTime = 0;
    private ViewPager mViewPager;
    private Toolbar toolbar;
    private TabLayout tabLayout;
    private Context context;
    private int[] tabIcons = {
            R.drawable.tapic1,
            R.drawable.tapic2,
            R.drawable.tapic3,
            R.drawable.tapic4
    };

    private String userUrl;
    private String userNickname;
    private String userId;
    private  MyInfoData myInfoData;
    public boolean check;

    ConstraintLayout frag_diary;
    //Communication




    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        toolbar = (Toolbar) findViewById(R.id.toolbar);

        context = this;

        userUrl = getIntent().getStringExtra("url");
        userNickname = getIntent().getStringExtra("nickname");
        userId = getIntent().getStringExtra("ID");
        getHashKey();
        //Log.e("usertest",userId+"입니다.");
        //Log.e("usertest",userNickname+"입니다.");




        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );

        check = false;

        setSupportActionBar(toolbar);
        // Create the adapter that will return a fragment for each of the three // 네가지 조각을 반환하는 어댑테 제작
        // primary sections of the activity. // 활동의 기본 섹션
        mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager(),userId,userNickname,userUrl);
        // Set up the ViewPager with the sections adapter. // sectionadepter로 viewpager설정
        mViewPager = (ViewPager) findViewById(R.id.container);
        mViewPager.setAdapter(mSectionsPagerAdapter);

        tabLayout = (TabLayout) findViewById(R.id.tabs);

        mViewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));
        tabLayout.addOnTabSelectedListener(new TabLayout.ViewPagerOnTabSelectedListener(mViewPager));



        myInfoData = new MyInfoData(userId,userNickname,userUrl);


        frag_diary = (ConstraintLayout)findViewById(R.id.frag_diary);


        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                   Intent join_Intent = new Intent(context,JoinUserList.class);
                    join_Intent.putExtra("url",userUrl);
                    join_Intent.putExtra("ID", userId);
                    join_Intent.putExtra("nickname", userNickname);
                   startActivityForResult(join_Intent,0);

            }
        });
        setupTabIcons();


        InsertData task = new InsertData(this);
        task.execute(userId,userNickname,userUrl);
    }

    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    @Override
    protected void onStart() {
        super.onStart();
        Bitmap bitmap;
        String[] tmpArr = new String[5];
        Intent intent = getIntent();
        bitmap = intent.getParcelableExtra("addImage");
        tmpArr = intent.getStringArrayExtra("addDiary");

        //Log.e("intent",tmpArr + "입니다.!!");
    }

    private void setupTabIcons() {

        View customView = (View)getLayoutInflater().inflate(R.layout.customtab,null,false);
        ImageView imageView = (ImageView)customView.findViewById(R.id.tabIcons);
        Glide.with(customView).load(tabIcons[0]).apply(new RequestOptions()).into(imageView);
        tabLayout.getTabAt(0).setCustomView(customView);


        View customView2 = (View)getLayoutInflater().inflate(R.layout.customtab,null,false);
        ImageView imageView2 = (ImageView)customView2.findViewById(R.id.tabIcons);
        Glide.with(customView2).load(tabIcons[1]).apply(new RequestOptions()).into(imageView2);
        tabLayout.getTabAt(1).setCustomView(customView2);


        View customView3 = (View)getLayoutInflater().inflate(R.layout.customtab,null,false);
        ImageView imageView3 = (ImageView)customView3.findViewById(R.id.tabIcons);
        Glide.with(customView3).load(tabIcons[2]).apply(new RequestOptions()).into(imageView3);
        tabLayout.getTabAt(2).setCustomView(customView3);


        View customView4 = (View)getLayoutInflater().inflate(R.layout.customtab,null,false);
        ImageView imageView4 = (ImageView)customView4.findViewById(R.id.tabIcons);
        Glide.with(customView4).load(tabIcons[3]).apply(new RequestOptions()).into(imageView4);
        tabLayout.getTabAt(3).setCustomView(customView4);





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
        int id = item.getItemId();
        switch(id){
            case R.id.adddiary:
                Intent adddiary_intent = new Intent(this, addActivity.class);
                adddiary_intent.putExtra("url",userUrl);
                adddiary_intent.putExtra("ID", userId);
                adddiary_intent.putExtra("nickname", userNickname);
                startActivityForResult(adddiary_intent, 0);
                break;
            case R.id.loadgoogle:
                Intent googleMap_intent = new Intent(this,subGoogle.class);
                startActivityForResult(googleMap_intent, 0);
                break;
        }
        return super.onOptionsItemSelected(item);
    }

    public void mOnClick(View view) {
      //Log.e("Mainkakao",userId);
      //Log.e("Mainkakao",userNickname);
      //Log.e("Mainkakao",userUrl);


    }

    //kakaoData DB 값에 집어넣기..
    public class InsertData extends AsyncTask<String, Void, String> {

        private String TAG = "phptest_MainActivity";
        ProgressDialog progressDialog;
        private Context mainContext;


        public InsertData(Context con) {
            this.mainContext = con;
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            progressDialog = ProgressDialog.show(mainContext,
                    "Please Wait", null, true, true);
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);

            progressDialog.dismiss();
            ////Log.d(TAG, "POST response  - " + result);
        }

        @Override //Login시 User정보 값넣기
        protected String doInBackground(String... params) {

            String ID = (String) params[0];
            String NicName = (String) params[1];
            String userUrl = (String) params[2];
            // String serverURL = "http://192.168.25.49:2133/insert.php"; //내부 ip
            String serverURL = "http://118.217.34.116:2133/insert.php"; //공인 ip
            String postParameters = "kakaoID=" + ID + "&NickName=" + NicName+ "&profile=" + userUrl;
            ////Log.d(TAG, "POST data정보 - " + postParameters);
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
               // //Log.d(TAG, "POST response code - " + responseStatusCode);

                InputStream inputStream;
                if (responseStatusCode == HttpURLConnection.HTTP_OK) {
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

               // //Log.d(TAG, "InsertData: Error ", e);

                return new String("Error: " + e.getMessage());
            }
        }
    }


    public void fun_Click(View view) {
        Intent intent = new Intent();
        switch (view.getId()) {
            case R.id.airbnb:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://www.airbnb.co.kr"));
                break;
            case R.id.staydo:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("https://www.staydo.it/"));
                break;
            case R.id.korea:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:112"));
                break;
            case R.id.china:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:(86-10) 8531-0700"));
                break;
            case R.id.japan:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+81 3-3452-7611"));
                break;
            case R.id.uk:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+44 (0)78 7650 6895"));
                break;
            case R.id.denmark:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+45 39 46 04 00"));
                break;
            case R.id.norway:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+47-2254-7090"));
                break;
            case R.id.usa:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+1 202-939-5600"));
                break;
            case R.id.canada:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:+1-613-244-5010"));
                break;
            case R.id.maksico:
                intent.setAction(Intent.ACTION_DIAL);
                intent.setData(Uri.parse("tel:52-55-5202-9866"));
        }
        if(intent.resolveActivity(getPackageManager()) != null)
            startActivity(intent);

    }

    public void news_Click(View v){
        Intent intent = new Intent();
        switch (v.getId()){
            case R.id.news1:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://news.naver.com/main/read.nhn?mode=LSD&mid=sec&sid1=001&oid=001&aid=0010113551"));
                break;
            case R.id.news2:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://news.naver.com/main/read.nhn?mode=LSD&mid=sec&sid1=001&oid=016&aid=0001398777"));
                break;
            case R.id.news3:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://news.naver.com/main/read.nhn?mode=LSD&mid=sec&sid1=001&oid=025&aid=0002824455"));
                break;
        }
        startActivity(intent);
    }
    public void trip_Click(View v){
        Intent intent = new Intent();
        switch (v.getId()){
            case R.id.num1:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://naver.me/xOG0DYHP"));
                break;
            case R.id.num2:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://naver.me/xUmj6OZu"));
                break;
            case R.id.num3:
                intent.setAction(Intent.ACTION_VIEW);
                intent.setData(Uri.parse("http://chalettnl.kr/221002708228"));
                break;
        }
        startActivity(intent);
    }

        public void diaryCallback(MyData myData) {
            //Log.e("indextest",myData+"입니다~~");
            Intent modify_intent = new Intent(this, addActivity.class);
            //modify_intent.putExtra("modifyDiary", myData);
            startActivityForResult(modify_intent, 0);

        }

        public void chatmake() {

            Intent intent = new Intent(this,MakeChatRoom.class);
            intent.putExtra("myInfoData",myInfoData);
            intent.putExtra("userId",userId);

            intent.putExtra("userName",userNickname);
            intent.putExtra("userPhoto",userUrl);
            startActivityForResult(intent,0);
        }

        public void chatJoin(String title) {
        //Log.e("chatJoin",title+"입니다");
            Intent intent = new Intent(this, RealChat.class);
            //intent.putExtra("chatName",title);
            intent.putExtra("userId",userId);
            intent.putExtra("myInfoData",myInfoData);

            intent.putExtra("userName",userNickname);
            intent.putExtra("userPhoto",userUrl);
            intent.putExtra("chatName",title);
            startActivityForResult(intent,0);
        }

        public void Logout() {
            UserManagement.requestLogout(new LogoutResponseCallback() {
                @Override
                public void onCompleteLogout() {

                }
            });
            finish();
        }
    @Override
    public void onBackPressed() {
        long tempTime = System.currentTimeMillis();
        long intervalTime = tempTime - backPressedTime;

        if (0 <= intervalTime && FINISH_INTERVAL_TIME >= intervalTime) {
            super.onBackPressed();
        } else {
            backPressedTime = tempTime;
            Toast.makeText(this, "종료를 원할시 한번더 눌러주세요.", Toast.LENGTH_SHORT).show();
        }


    }

        public String getMyId() { return userId; }
        public String getMyNick() { return userNickname; }
        public String getMyPhoto() { return userUrl; }




    //KaKao 연동 HashKey 받아오기
    private void getHashKey(){
         try {
            PackageInfo info = getPackageManager().getPackageInfo("com.example.giyeo.viewpager", PackageManager.GET_SIGNATURES);
            for (Signature signature : info.signatures) {
                MessageDigest md = MessageDigest.getInstance("SHA");
                md.update(signature.toByteArray());
                //Log.d("tag","key_hash="+ Base64.encodeToString(md.digest(), Base64.DEFAULT));
            }
        } catch (PackageManager.NameNotFoundException e) {
             //Log.d("tag","key_hash= 에러!!");
            e.printStackTrace();
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }
}

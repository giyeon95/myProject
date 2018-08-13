package com.example.giyeo.viewpager;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class UserStatus extends Activity {


    private String myId;
    private String myNickName;
    private String myPhoto;
    private String userId;
    private String userNickname;
    private String userPhoto;
    Context context;


    private ImageView profile;
    private TextView userName;



    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.user_status);

        this.context = this;

        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );



        userId = getIntent().getStringExtra("userId");
        userNickname = getIntent().getStringExtra("userNick");
        userPhoto = getIntent().getStringExtra("userPhoto");
        myId= getIntent().getStringExtra("myId");
        myNickName = getIntent().getStringExtra("myName");
        myPhoto = getIntent().getStringExtra("myPhoto");


        profile = (ImageView) findViewById(R.id.userInfoPhoto);
        Glide.with(this).load(userPhoto).apply(new RequestOptions().circleCrop()).into(profile);

        userName = (TextView)findViewById(R.id.userInfoNickName);
        userName.setText("User : "+userNickname);

        Button oneChat = (Button)findViewById(R.id.userInfoChatOpen);
        Button infoOut = (Button)findViewById(R.id.userInfoClose);
        oneChat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

             //Log.e("myChat","접속자 ID : "+myId+" 작성자 ID : "+userId);
             //Log.e("myChat","접속자 이름 : "+myNickName+" 작성자 이름 : "+userNickname);

             Intent intent = new Intent(context, RealChat.class);
             intent.putExtra("myId",myId);
             intent.putExtra("otherId",userId);
             intent.putExtra("myNickName",myNickName);
             intent.putExtra("otherNickName",userNickname);
             intent.putExtra("myPhoto",myPhoto);
             startActivity(intent);
             finish();

            }
        });



        infoOut.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

    }
    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }
}

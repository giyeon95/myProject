package com.example.giyeo.viewpager;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class MakeChatRoom extends Activity {

    private String userId;
    private String userNickname;
    private String userPhoto;
    private EditText editText;
    private MyInfoData myInfoData;
    private Button btnCancal;
    private Button btnOk;
    private String title;


    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.makechatroom);


        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );


        myInfoData = (MyInfoData) getIntent().getSerializableExtra("myInfoData");
        userId = getIntent().getStringExtra("userId");
        userNickname = getIntent().getStringExtra("userName");
        userPhoto = getIntent().getStringExtra("userPhoto");
        editText = (EditText)findViewById(R.id.chatRoomName);
        btnCancal = (Button)findViewById(R.id.chatRoomCancal);
        btnOk = (Button)findViewById(R.id.chatRoomOk);


        btnCancal.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });


    }

    public void roomClick(View view) {

        if(editText.getText().toString() !="") {
            title = editText.getText().toString();
            Intent intent = new Intent(this, RealChat.class);
            intent.putExtra("myInfoData",myInfoData);
            intent.putExtra("userId",userId);
            intent.putExtra("chatName",title);
            intent.putExtra("userName",userNickname);
            intent.putExtra("userPhoto",userPhoto);
            startActivity(intent);
            finish();
        }
    }
}

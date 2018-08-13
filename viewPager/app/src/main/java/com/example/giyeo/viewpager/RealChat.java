package com.example.giyeo.viewpager;

import android.content.Context;
import android.database.DataSetObserver;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;

import com.google.firebase.database.ChildEventListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Locale;

import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class RealChat extends AppCompatActivity {

    private ListView listView;
    private EditText editText;
    private Button sendbutton;
    private String userId;
    private String userNickname;
    private String userPhoto;
    private String title;
    private MyInfoData myInfoData;

    private String otherId;
    private String otherNick;
    private String myPhoto;
    private String myId;
    private String myNick;
    private InputMethodManager inputMethodManager;

    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    private ArrayList<ChatData> chatData = new ArrayList<>();
    ChatAdapter adapter;

    private FirebaseDatabase firebaseDatabase = FirebaseDatabase.getInstance();
    private DatabaseReference databaseReference = firebaseDatabase.getReference();

    String str_date;


    @Override
    protected void onPostResume() {
        super.onPostResume();
        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.KOREA);
        this.str_date = df.format(new Date());
    }

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.chatting);

        inputMethodManager =(InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);

        myInfoData = (MyInfoData) getIntent().getSerializableExtra("myInfoData");
        userId = getIntent().getStringExtra("userId");
        userNickname = getIntent().getStringExtra("userName");
        userPhoto = getIntent().getStringExtra("userPhoto");
        title = getIntent().getStringExtra("chatName");

        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );


        listView = (ListView) findViewById(R.id.chatListView);
        editText = (EditText) findViewById(R.id.chatText);
        sendbutton = (Button) findViewById(R.id.chatButton);



        otherId = getIntent().getStringExtra("otherId");
        otherNick = getIntent().getStringExtra("otherNickName");
        myId = getIntent().getStringExtra("myId");
        myNick = getIntent().getStringExtra("myNickName");
        myPhoto = getIntent().getStringExtra("myPhoto");

        if(otherId !=null && myId !=null) {
            int int_otherId = Integer.parseInt(otherId);
            int int_myId = Integer.parseInt(myId);

            int result = (int_myId > int_otherId) ? ((int_myId-int_otherId)*13) : ((int_otherId-int_myId)*13);
            char word = (int_myId > int_otherId) ? myNick.charAt(0) : otherNick.charAt(0);
            char word2 = (int_myId > int_otherId) ? otherNick.charAt(1) : myNick.charAt(1);

            title = word+"1ByOnE"+result+"S2a9"+word2;
            //Log.e("title",title+" 제목 확인!");
            userId = myId;
            userNickname = myNick;
            userPhoto=myPhoto;
            otherId=null;
            myId=null;
        }

        listView.setAdapter(adapter);

        openChat(title);


        sendbutton.setOnClickListener(new Button.OnClickListener() {

            @Override
            public void onClick(View v) {

                HideKeyBoard();
                ChatData chatData = new ChatData(userId,userNickname, editText.getText().toString(), userPhoto, str_date, "GPS");  // 유저 이름과 메세지로 chatData 만들기
                databaseReference.child("message").child(title).push().setValue(chatData);  // 기본 database 하위 message라는 child에 chatData를 list로 만들기
                //databaseReference.child("test").push().setValue(chatData);  // 기본 database 하위 message라는 child에 chatData를 list로 만들기
                editText.setText("");
            }
        });
    }
    private void openChat(String chatName) {

        adapter = new ChatAdapter(this, R.layout.chat, chatData);
        listView.setAdapter(adapter);

        databaseReference.child("message").child(title).addChildEventListener(new ChildEventListener() {  // message는 child의 이벤트를 수신합니다.
            @Override
            public void onChildAdded(DataSnapshot dataSnapshot, String s) {
                ChatData chatData2 = dataSnapshot.getValue(ChatData.class);  // chatData를 가져오고

                chatData.add(chatData2);
                // adapter에 추가합니다.

                listView.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);

                adapter.registerDataSetObserver(new DataSetObserver() {
                    @Override
                    public void onChanged() {
                        super.onChanged();
                        listView.setSelection(adapter.getCount()-1);
                    }
                });
                listView.setTranscriptMode(ListView.TRANSCRIPT_MODE_ALWAYS_SCROLL);
                adapter.notifyDataSetChanged();




            }

            @Override
            public void onChildChanged(DataSnapshot dataSnapshot, String s) {




            }

            @Override
            public void onChildRemoved(DataSnapshot dataSnapshot) {
            }

            @Override
            public void onChildMoved(DataSnapshot dataSnapshot, String s) {
            }

            @Override
            public void onCancelled(DatabaseError databaseError) {
            }
        });
    }

    private void HideKeyBoard()
    {
        inputMethodManager.hideSoftInputFromWindow(editText.getWindowToken(), 0);
    }



}






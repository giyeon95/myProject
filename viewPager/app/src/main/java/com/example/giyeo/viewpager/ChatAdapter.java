package com.example.giyeo.viewpager;



import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.text.Layout;
import android.text.format.DateFormat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

import java.util.ArrayList;

/**
 * Created by okiju on 2018-05-16.
 */

public class ChatAdapter extends BaseAdapter {
    private LayoutInflater inflater;
    private int chatlayout;
    private ArrayList<ChatData> chatData;
    private String userId;
    private String userNick;
    private String userPhoto;
    Context context;

    public ChatAdapter(Context context, int chatlayout, ArrayList<ChatData> cdata) {
        this.inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.chatData = cdata;
        this.chatlayout = chatlayout;
        this.context = context;
    }

    @Override
    public int getCount() {
        return chatData.size();
    }

    @Override
    public Object getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(final int position, View view, final ViewGroup viewGroup) {
        if(view == null) {
            view = inflater.inflate(R.layout.chat, viewGroup, false);
        }

        ChatData cData = chatData.get(position);
        userId= cData.getUserId();
        userNick=cData.getUserName();
        userPhoto=cData.getUserPhoto();

        ImageView profile = (ImageView) view.findViewById(R.id.chatphoto);
        cData.getUserPhoto();

        if(cData.getUserPhoto() != null)
        Glide.with(view).load(cData.getUserPhoto()).apply(new RequestOptions().circleCrop()).into(profile);
        else {
            profile.setImageResource(R.mipmap.ic_launcher_round);
           // Glide.with(view).load(R.mipmap.ic_launcher_round).apply(new RequestOptions().circleCrop()).into(profile);
        }


        TextView writer = (TextView) view.findViewById(R.id.chatwriter);
        writer.setText(cData.getUserName());

        TextView date = (TextView) view.findViewById(R.id.chatdate);
        date.setText(DateFormat.format("yy-MM-dd (HH:mm:ss)", cData.getMessageTime()));

        TextView content = (TextView) view.findViewById(R.id.chatmessage);
        content.setText(cData.getMessage());
        RelativeLayout layout = (RelativeLayout)view.findViewById(R.id.userInfoLayout);
        layout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                ChatData cData2 = chatData.get(position);
                userId= cData2.getUserId();
                userNick=cData2.getUserName();
                userPhoto=cData2.getUserPhoto();

            Intent intent = new Intent(context,UserStatus.class);
            Intent getId = ((Activity)v.getContext()).getIntent();

            String myid = getId.getStringExtra("userId");
            String mynick = getId.getStringExtra("userName");
            String myphoto = getId.getStringExtra("userPhoto");

            //Log.e("myChat","Intent값 확인!"+myid);

            intent.putExtra("userId",userId);
            intent.putExtra("userNick",userNick);
            intent.putExtra("userPhoto",userPhoto);

                intent.putExtra("myId",myid);
                intent.putExtra("myName",mynick);
                intent.putExtra("myPhoto",myphoto);

                context.startActivity(intent);
            }
        });


        return view;
    }
}
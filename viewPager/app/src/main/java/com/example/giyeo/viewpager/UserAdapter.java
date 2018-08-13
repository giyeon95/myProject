package com.example.giyeo.viewpager;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;
import java.util.ArrayList;



public class UserAdapter extends BaseAdapter {
    private LayoutInflater inflater;
    private int userlayout;
    private ArrayList<userData> userData;
    private String userId;
    private String userNick;
    private String userPhoto;
    private Context context;

    public UserAdapter(Context context, int userlayout, ArrayList<userData> udata) {
        this.inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.userData = udata;
        this.userlayout = userlayout;
        this.context = context;
    }



    @Override
    public int getCount() {
        return userData.size();
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
    public View getView(final int position, View view, ViewGroup viewGroup) {

        if(view == null) {
            view = inflater.inflate(R.layout.join_user, viewGroup, false);
        }


        userData uData = userData.get(position);
        userId= uData.getkakaoId();
        userNick=uData.getkakaoNick();
        userPhoto=uData.getkakaoProfile();

        userData.get(position).getkakaoId();
        ImageView profile = (ImageView) view.findViewById(R.id.userphoto);
        uData.getkakaoProfile();

        if(uData.getkakaoProfile() != null)
            Glide.with(view).load(uData.getkakaoProfile()).apply(new RequestOptions().circleCrop()).into(profile);
        else {
            profile.setImageResource(R.mipmap.ic_launcher_round);
            // Glide.with(view).load(R.mipmap.ic_launcher_round).apply(new RequestOptions().circleCrop()).into(profile);
        }

        TextView writer = (TextView) view.findViewById(R.id.userwriter);
         writer.setText(uData.getkakaoNick());
        RelativeLayout layout = (RelativeLayout)view.findViewById(R.id.joinUserLayout);

        layout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                userData userdata1 = userData.get(position);
                userId= userdata1.getkakaoId();
                userNick=userdata1.getkakaoNick();
                userPhoto=userdata1.getkakaoProfile();

                Intent intent = new Intent(context,UserStatus.class);
                Intent getId = ((Activity)v.getContext()).getIntent();
                String myid = getId.getStringExtra("ID");

                Intent getnick = ((Activity)v.getContext()).getIntent();
                String mynick = getId.getStringExtra("nickname");

                Intent geturl = ((Activity)v.getContext()).getIntent();
                String myphoto = getId.getStringExtra("url");
                //Log.e("myChat","Intent값 확인!"+myid);
                //Log.e("mychat2",userNick+"입니다!!!!");

                intent.putExtra("userId",userId);
                intent.putExtra("userNick",userNick);
                intent.putExtra("userPhoto",userPhoto);


                intent.putExtra("myId",myid);
                intent.putExtra("myName",mynick);
                intent.putExtra("myPhoto",myphoto);

                context.startActivity(intent);
            }
        });
        Button button = (Button)view.findViewById(R.id.addButton);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                userData userdata1 = userData.get(position);
                userId= userdata1.getkakaoId();
                userNick=userdata1.getkakaoNick();
                userPhoto=userdata1.getkakaoProfile();

                Intent intent = new Intent(context,AlbumActivity.class);
                Intent getId = ((Activity)v.getContext()).getIntent();

                String myid = getId.getStringExtra("ID");
                String mynick = getId.getStringExtra("nickname");
                String myphoto = getId.getStringExtra("url");

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

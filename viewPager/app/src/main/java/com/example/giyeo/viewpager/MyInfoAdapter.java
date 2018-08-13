package com.example.giyeo.viewpager;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;


import java.util.ArrayList;

public class MyInfoAdapter extends BaseAdapter {
    private LayoutInflater inflater;
    private int chatlayout;
    private ArrayList<MyInfoData> myInfoData;
    private String userId;
    private String userNick;
    private String userPhoto;
    Context context;

    public MyInfoAdapter(Context context, int chatlayout, ArrayList<MyInfoData> myInfoData) {
        this.inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.myInfoData = myInfoData;
        this.chatlayout = chatlayout;
        this.context = context;
    }


    @Override
    public int getCount() {
        return myInfoData.size();
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
    public View getView(int position, View view, ViewGroup parent) {

        return view;
    }
}

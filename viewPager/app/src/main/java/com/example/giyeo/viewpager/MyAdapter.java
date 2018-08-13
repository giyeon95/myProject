package com.example.giyeo.viewpager;

import android.content.Context;
import android.graphics.Bitmap;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;


import java.util.ArrayList;

/**
 * Created by okiju on 2018-05-07.
 */

public class MyAdapter extends BaseAdapter{

    private LayoutInflater inflater;
    private int diarylayout;
    private Bitmap[] blob;
    private ArrayList<MyData> data;


    public MyAdapter(Context context, int diarylayout, ArrayList<MyData> data) {
        this.inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.data = data;
        this.diarylayout = diarylayout;
    }

    public void setBlob(Bitmap[] data){
        blob=data;
    }

    @Override
    public int getCount() {
        return data.size();
    }

    @Override
    public String getItem(int position) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {

        RecyclerView.ViewHolder viewHolder;
        if (view == null) {
            view = inflater.inflate(R.layout.sub_diary, viewGroup, false);

        }

        MyData myData = data.get(position);

        TextView title = (TextView) view.findViewById(R.id.mtitle);
        title.setText(myData.title);

        TextView date = (TextView) view.findViewById(R.id.mdate);
        date.setText(myData.date);

        TextView city = (TextView) view.findViewById(R.id.mcity);
        city.setText(myData.city);

        ImageView pic = (ImageView)view.findViewById(R.id.pic);

        pic.setImageBitmap(myData.blob);

        TextView text = (TextView) view.findViewById(R.id.mycontent);
        text.setText(myData.content);

        return view;
    }
}

package com.example.giyeo.viewpager;


import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;

public class UserGridAdapter extends BaseAdapter {

    private Context ctx;
    private ArrayList<GridData> data;



    public UserGridAdapter(Context ctx, ArrayList<GridData> data) {
        this.ctx = ctx;
        this.data = data;
    }

    @Override
    public int getCount() {
        return data.size();
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        if (view == null){
            LayoutInflater inflater = LayoutInflater.from(ctx);
            view = inflater.inflate(R.layout.user_grid_list, viewGroup, false);
        }
        GridData gridData = data.get(position);


        ImageView image = (ImageView) view.findViewById(R.id.gridimage);
        image.setImageBitmap(gridData.getBlob());
        TextView place = (TextView) view.findViewById(R.id.gridplace);
        place.setText(gridData.getCityname());
        TextView writer = (TextView) view.findViewById(R.id.gridwriter);
        writer.setText(gridData.getWriter());

        return view;
    }
}
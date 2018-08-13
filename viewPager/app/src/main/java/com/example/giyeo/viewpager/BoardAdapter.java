package com.example.giyeo.viewpager;


import android.content.Context;
import android.text.Layout;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.ArrayList;

/**
 * Created by okiju on 2018-05-16.
 */

public class BoardAdapter extends BaseAdapter {
    private LayoutInflater inflater;
    private int boardlayout;
    private ArrayList<BoardData> bdata;
    Context context;

    public BoardAdapter(Context context, int boardlayout, ArrayList<BoardData> bdata) {
        this.context = context;
        this.inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        this.bdata = bdata;
        this.boardlayout = boardlayout;
    }

    @Override
    public int getCount() {
        return bdata.size();
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
            view = inflater.inflate(R.layout.board, viewGroup, false);
        }

        BoardData bData = bdata.get(position);

        ImageView profile = (ImageView) view.findViewById(R.id.profile);
        profile.setImageResource(bData.profile_image);

        TextView writer = (TextView) view.findViewById(R.id.bwriter);
        writer.setText(bData.writer);

        RelativeLayout layout = (RelativeLayout)view.findViewById(R.id.chatInsertLayout);
        layout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if(bdata.get(position).writer=="이탈리아") {
                    //Log.e("clicktest",bdata.get(position).writer+"Click되었습니다");
                    ((MainActivity)context).chatJoin("i2tlnisda3dasrw151");
                }

                else if(bdata.get(position).writer=="영국") {
                    //Log.e("clicktest",bdata.get(position).writer+"Click되었습니다");
                    ((MainActivity)context).chatJoin("u3sk2i7ng52do7m313kxjfzxdsa464efdm421");
                }

                else if (bdata.get(position).writer=="프랑스") {
                    //Log.e("clicktest",bdata.get(position).writer+"Click되었습니다");
                    ((MainActivity)context).chatJoin("f2r6a3nbce23asb1r2w1h34h2d1");

                }
            }
        });




        return view;
    }
}
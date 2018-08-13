package com.example.giyeo.viewpager;


import android.annotation.SuppressLint;
import android.media.Image;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;

@SuppressLint("ValidFragment")
public class Function extends Fragment {

    private final String userId;
    private final String userNic;


    private ImageView airbnb;
    private ImageView staydo;
    private ImageView korea;
    private ImageView china;
    private ImageView japan;
    private ImageView unightkingdom;
    private ImageView denmark;
    private ImageView norway;
    private ImageView usa;
    private ImageView canada;
    private ImageView maksico;


    public Function(String ID, String nic) {

        this.userId = ID;
        this.userNic = nic;
    }


    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.layout_function, container,false);

        airbnb = (ImageView) view.findViewById(R.id.airbnb);
        staydo = (ImageView) view.findViewById(R.id.staydo);
        korea =  (ImageView) view.findViewById(R.id.korea);
        china = (ImageView) view.findViewById(R.id.china);
        japan = (ImageView) view.findViewById(R.id.japan);
        unightkingdom = (ImageView) view.findViewById(R.id.uk);
        denmark = (ImageView) view.findViewById(R.id.denmark);
        norway = (ImageView) view.findViewById(R.id.norway);
        usa = (ImageView)view.findViewById(R.id.usa);
        canada = (ImageView)view.findViewById(R.id.canada);
        maksico = (ImageView)view.findViewById(R.id.maksico);


        Glide.with(view).load(R.drawable.airbnb).apply(new RequestOptions()).into(airbnb);
        Glide.with(view).load(R.drawable.staydo).apply(new RequestOptions()).into(staydo);
        Glide.with(view).load(R.drawable.fun_korea).apply(new RequestOptions()).into(korea);
        Glide.with(view).load(R.drawable.fun_china).apply(new RequestOptions()).into(china);
        Glide.with(view).load(R.drawable.japan).apply(new RequestOptions()).into(japan);
        Glide.with(view).load(R.drawable.fun_england).apply(new RequestOptions()).into(unightkingdom);
        Glide.with(view).load(R.drawable.denmark).apply(new RequestOptions()).into(denmark);
        Glide.with(view).load(R.drawable.fun_aus).apply(new RequestOptions()).into(norway);
        Glide.with(view).load(R.drawable.us).apply(new RequestOptions()).into(usa);
        Glide.with(view).load(R.drawable.fun_canada).apply(new RequestOptions()).into(canada);
        Glide.with(view).load(R.drawable.mak).apply(new RequestOptions()).into(maksico);

        return view;
    }
}

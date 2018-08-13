package com.example.giyeo.viewpager;

import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import com.bumptech.glide.Glide;
import com.bumptech.glide.load.resource.gif.GifDrawable;
import com.bumptech.glide.request.target.DrawableImageViewTarget;
import com.bumptech.glide.request.transition.Transition;


public class LoadingActivity extends AppCompatActivity {

    Context context;

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.loading);
        context = this;


        ImageView imageView = (ImageView)findViewById(R.id.logologo);
        Glide.with(imageView).load(R.drawable.logologo).into(new DrawableImageViewTarget(imageView) {
            @Override
            public void onResourceReady(@NonNull Drawable resource, @Nullable Transition<? super Drawable> transition) {
                super.onResourceReady(resource, transition);
                if(resource instanceof GifDrawable) {
                    GifDrawable gifDrawable = (GifDrawable) resource;

                }
            }
        });

       Handler hd = new Handler();
       hd.postDelayed(new Runnable() {
           @Override
           public void run() {
               Intent intent = new Intent(context,Login.class);
               startActivity(intent);
               finish();
           }
       },3000);



    }



}

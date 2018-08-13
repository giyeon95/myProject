package com.example.giyeo.viewpager;

import android.util.Log;

import java.io.Serializable;

public class MyInfoData implements Serializable {

    private String Id;
    private String Nick;
    private String Photo;
    public MyInfoData() {

    }

    public MyInfoData(String Id, String Nick, String Photo) {
        this.Id = Id;
        this.Nick = Nick;
        this.Photo = Photo;
    }
    public String getMyId() {
        //Log.e("myChat","넘어오는 ID"+Id);
        return Id;
    }
    public String getMyNick() { return Nick; }
    public String getMyPhoto() { return Photo; }
}

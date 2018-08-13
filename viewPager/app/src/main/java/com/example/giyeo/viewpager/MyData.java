package com.example.giyeo.viewpager;

import android.graphics.Bitmap;

import java.io.Serializable;

public class MyData implements Serializable {
    public String title;
    public String date;
    public String city;
    public Bitmap blob;
    public String Check="";
    public String content;

    public MyData() {}

    public MyData(String title, String date, String city,Bitmap blob, String content) {
        this.title = title;
        this.date = date;
        this.city = city;
        this.blob = blob;
        this.content = content;
    }

    public MyData(String check,String title, String date, String city,Bitmap blob, String content) {
        this.Check = check;
        this.title = title;
        this.date = date;
        this.city = city;
        this.blob = blob;
        this.content = content;
    }
    public String getStatus() {
        return Check;
    }

    public String getMyTitle() {
        return title;
    }
    public String getMydate() {
        return date;
    }
    public String getMyCity() {
        return city;
    }
    public String getMyContext () {
        return content;
    }
    public Bitmap getMyImage() {
        return blob;
    }

}

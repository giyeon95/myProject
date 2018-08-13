package com.example.giyeo.viewpager;


import android.graphics.Bitmap;

public class GridData {

    private String cityname;
    private Bitmap blob;
    private String writer;

    public GridData(String cityname, Bitmap blob, String writer) {
        this.cityname = cityname;
        this. blob = blob;
        this.writer = writer;
    }

    public Bitmap getBlob() {
        return blob;
    }
    public String getCityname() { return cityname; }
    public String getWriter() { return writer; }
}

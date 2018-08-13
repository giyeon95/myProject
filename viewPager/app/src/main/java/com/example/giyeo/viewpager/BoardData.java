package com.example.giyeo.viewpager;


import android.view.View;

import java.util.Date;

/**
 * Created by okiju on 2018-05-16.
 */

public class BoardData {
    public int profile_image;
    public String writer;
    public Date writedate;



    public BoardData(int profile_image, String writer, Date writedate) {
        this.profile_image = profile_image;
        this.writer = writer;
        this.writedate = writedate;
    }
}
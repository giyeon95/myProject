package com.example.giyeo.viewpager;

import android.util.Log;

import java.util.Date;

public class ChatData {
    private String userId;
    private String userName;
    private String userPhoto;
    private String message;
    private String writedate;
    private long messageTime;
    private String gps;

    public ChatData() { }

    public ChatData(String userId,String userName, String message, String photo, String writedate, String gps) {
        this.userId = userId;
        this.userName = userName;
        this.message = message;
        this.userPhoto = photo;
        this.writedate = writedate;
        messageTime = new Date().getTime();
        this.gps = gps;
    }

    public String getUserName() {
        return userName;
    }

    public String getUserPhoto() {return userPhoto;}

    public String getUserId() { return userId; }

    public String getWriteDate() {
        //Log.e("getWriteDate","넘어가는값 : "+writedate);
        return writedate;}

    public String getGps() {return gps;}

    public String getMessage() {
        return message;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public long getMessageTime() {
        return messageTime;
    }

    public void setMessageTime(long messageTime) {
        this.messageTime = messageTime;
    }
}
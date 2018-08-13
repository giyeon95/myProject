package com.example.giyeo.viewpager;



import java.io.Serializable;

public class userData implements Serializable {

    private String kakaoId;
    private String kakaoNick;
    private String kakaoProfile;

    public userData() {}

    public userData(String kakaoId, String kakaoNick, String kakaoProfile) {
        this.kakaoId = kakaoId;
        this.kakaoNick = kakaoNick;
        this.kakaoProfile = kakaoProfile;
    }




    public String getkakaoId() {
        return kakaoId;
    }
    public String getkakaoNick() {
        return kakaoNick;
    }
    public String getkakaoProfile() {
        return kakaoProfile;
    }
}
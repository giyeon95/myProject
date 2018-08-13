package com.example.giyeo.viewpager;


import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.widget.Toast;

import com.kakao.auth.ISessionCallback;
import com.kakao.auth.Session;
import com.kakao.network.ErrorResult;
import com.kakao.usermgmt.UserManagement;
import com.kakao.usermgmt.callback.MeResponseCallback;
import com.kakao.usermgmt.response.model.UserProfile;
import com.kakao.util.exception.KakaoException;
import com.kakao.util.helper.log.Logger;


import uk.co.chrisjenx.calligraphy.CalligraphyConfig;
import uk.co.chrisjenx.calligraphy.CalligraphyContextWrapper;

public class Login extends AppCompatActivity {

    SessionCallback callback;
    private String kakaoID;
    private String kakaoNickname;
    private String url;



    @Override
    protected void attachBaseContext(Context newBase) {
        super.attachBaseContext(CalligraphyContextWrapper.wrap(newBase));
    }

    @SuppressLint("MissingPermission")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.layout_login);


        CalligraphyConfig.initDefault(new CalligraphyConfig.Builder()
                .setDefaultFontPath("HoonPinkpungchaR.otf")
                .setFontAttrId(R.attr.fontPath)
                .build()
        );


        callback = new SessionCallback();
        Session.getCurrentSession().addCallback(callback);


    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (Session.getCurrentSession().handleActivityResult(requestCode, resultCode, data)) {
            return;
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Session.getCurrentSession().removeCallback(callback);
    }

    private class SessionCallback implements ISessionCallback {

        @Override
        public void onSessionOpened() {
            requestMe();
            if(kakaoID == null)
            Toast.makeText(Login.this, "KaKaoTalk Login Sussess!", Toast.LENGTH_SHORT).show();
           // if(kakaoID !=null)

        }
        @Override
        public void onSessionOpenFailed(KakaoException exception) {
            if(exception != null) {
                Logger.e(exception);
            }
            setContentView(R.layout.layout_login); // 세션 연결이 실패했을때
        }                                            // 로그인화면을 다시 불러옴
    }

    private void redirectSignupActivity() {       //세션 연결 성공 시 SignupActivity로 넘김
        Toast.makeText(Login.this, kakaoNickname+"님 환영합니다!", Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(this, MainActivity.class);
            intent.putExtra("url", url);
            intent.putExtra("ID", kakaoID);
            intent.putExtra("nickname", kakaoNickname);
            startActivity(intent);
            finish();
    }


    public void requestMe() {
        //유저의 정보를 받아오는 함수

        UserManagement.requestMe(new MeResponseCallback() {
            @Override
            public void onFailure(ErrorResult errorResult) {
                //Log.e("TAG", "error message=" + errorResult);
//                super.onFailure(errorResult);
            }

            @Override
            public void onSessionClosed(ErrorResult errorResult) {

                //Log.d("TAG", "onSessionClosed1 =" + errorResult);
            }

            @Override
            public void onNotSignedUp() {
                //카카오톡 회원이 아닐시
                //Log.d("TAG", "onNotSignedUp ");

            }

            @Override
            public void onSuccess(UserProfile result) {
                 kakaoID = String.valueOf(result.getId()); // userProfile에서 ID값을 가져옴
                 kakaoNickname = result.getNickname();     // Nickname 값을 가져옴
                 url = String.valueOf(result.getProfileImagePath());

                Logger.d("UserProfile : " + result);
                //Log.d("kakao", "==========================");
                //Log.d("kakao", ""+result);
                //Log.d("kakao", kakaoID);
                //Log.d("kakao", kakaoNickname);
                //Log.d("kakao", url);
                //Log.d("kakao", "==========================");
                redirectSignupActivity();  // 세션 연결성공 시 redirectSignupActivity() 호출
            }

        });

    }

}

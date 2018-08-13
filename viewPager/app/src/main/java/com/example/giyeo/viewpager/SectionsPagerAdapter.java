package com.example.giyeo.viewpager;


import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;

//Section 분할 및 * one of the sections/tabs/pages  OK
public class SectionsPagerAdapter extends FragmentPagerAdapter {

    String userId;
    String userNic;
    String userUrl;


    public SectionsPagerAdapter(FragmentManager fm,String  Id,String Nic,String url) {
        super(fm);

        this.userId = Id;
        this.userNic = Nic;
        this.userUrl = url;
    }


    @Override
    public int getItemPosition(@NonNull Object object) {


        return super.getItemPosition(object);
    }

    @Override // Fragment 분할 및 실행 OK
    public Fragment getItem(int position) {

        switch (position) {
            case 0:
                MakePlan makePlan = new MakePlan(userId,userNic);
                return makePlan;
            case 1:
                Diary diary = new Diary(userId,userNic);

                return diary;
            case 2:
                Communication communication = new Communication(userId,userNic,userUrl);
                return communication;
            case 3:
                Function function = new Function(userId,userNic);
                return function;
            default:
                return null;
        }
    }

    @Nullable
    @Override
    public CharSequence getPageTitle(int position) {
        return super.getPageTitle(position);
    }

    @Override // 위에 숫자 생성 OK
    public int getCount() {
        // Show 4 total pages.
        return 4;
    }
}


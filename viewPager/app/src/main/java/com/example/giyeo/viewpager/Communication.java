package com.example.giyeo.viewpager;

import android.annotation.SuppressLint;
import android.content.Context;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.request.RequestOptions;
import com.kakao.usermgmt.UserManagement;
import com.kakao.usermgmt.callback.LogoutResponseCallback;

import java.util.ArrayList;
import java.util.Date;

@SuppressLint("ValidFragment")
public class Communication extends Fragment {

    private String userId;
    private String userNic;
    private String userUrl;

    private ImageView userImage;
    private TextView userCode;
    private TextView userNicName;


    private Context context;

    private ListView bList;
    private ArrayList<BoardData> boardData = new ArrayList<>();
    private BoardAdapter boardAdapter;

    public Communication() {

    }

    public Communication(String ID, String nic,String url) {

        this.userId = ID;
        this.userNic = nic;
        this.userUrl=url;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        this.context = context;


        BoardData board1 = new BoardData(R.drawable.italy, "이탈리아", new Date(System.currentTimeMillis()));
        BoardData board2 = new BoardData(R.drawable.uk, "영국", new Date(System.currentTimeMillis()));
        BoardData board3 = new BoardData(R.drawable.france2, "프랑스", new Date(System.currentTimeMillis()));

        boardData.add(board1);
        boardData.add(board2);
        boardData.add(board3);

    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.layout_communication, container,false);

        userImage = (ImageView) view.findViewById(R.id.com_propile);
        userCode = (TextView) view.findViewById(R.id.com_code);
        userNicName = (TextView) view.findViewById(R.id.com_nickname);
        bList = (ListView) view.findViewById(R.id.boardlist);



        userCode.setText("Code : "+userId);
        userNicName.setText("닉네임 : "+userNic);
        Glide.with(view).load(userUrl).apply(new RequestOptions().circleCrop()).into(userImage);
        final Button button = (Button)view.findViewById(R.id.logoutbtn);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                ((MainActivity)getActivity()).Logout();
            }
        });

        final Button makechat = (Button)view.findViewById(R.id.makechat);
        makechat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ((MainActivity)getActivity()).chatmake();
            }
        });


        boardAdapter = new BoardAdapter(context, R.layout.board, boardData);
        bList.setAdapter(boardAdapter);

        bList.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);

        return view;
    }

}

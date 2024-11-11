using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Real_Time_P : MonoBehaviour
{
    public GameObject[] Aine;

    void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f); // 매 초마다 UpdateTime 함수를 호출하여 시간 업데이트

        //InvokeRepeating()함수를 이용하여 UpdateTime()함수를 1초마다 호출
        //이 함수는 시간을 업데이트 하기 위해 사용됨
    }

    void UpdateTime()
        //DateTimeOffeset.Now을 사용해 현재 시간을 가져온다

    {
        DateTimeOffset currentTime = DateTimeOffset.Now;
        string formattedTime = currentTime.ToString("HH:mm"); // 시간 형식 지정-> 시간:분
        //HHmm는 고정이라 이 문자들을 다르게 바꾸면 안됨(초를 원한다면 :ss추가하기)
        
        if (formattedTime.CompareTo("18:30") >= 0 || formattedTime.CompareTo("08:00") < 0)
        {
            //Debug.Log("밤은 오후 6시 30분부터 오전 8시까지입니다!");
            Aine[0].SetActive(false);
            Aine[1].SetActive(true);

            //CompareTo()는 문자열간의 사전 순서를 비교하는 메서드
            //비교대상 문자열보다 크거나 같으면 0 이상의 값을 반환
        }

        else if (formattedTime.CompareTo("08:00") >= 0 || formattedTime.CompareTo("18:30") < 0)
        {
            //Debug.Log("아침은 오전 8시부터 오후 6시 30분까지입니다!");
            Aine[0].SetActive(true);
            Aine[1].SetActive(false);
        }
        //timeText.text = "현재 시간: " + formattedTime;
    }

    private void Update()
    {
        //Debug.Log("현재 시간: " + DateTimeOffset.Now.ToString());
    }


}
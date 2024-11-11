using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour
{
    public string m_Timer = @"00:00:00"; //시간을 나타내는 문자열 변수 //초기값은 00:00:00


    public KeyCode m_KcdPlay = KeyCode.Space; //카운트 다운을 시작 혹은 일시정지하기 위한 키를 나타내는 키코드 변수
    //private Vector2 initialPosition;//새로 추가한 코드. 현재 위치

    private bool m_IsPlaying; // 카운트 다운이 현재 실행 중인지를 나타내는 변수

    public float m_TotalSeconds = 7; // 카운트 다운 전체 초(5분 X 60초). 
    public Text m_Text; //UI에 표시할 텍스트(Text 컴포넌트)를 참조하는 변수

    private void Start()
    {



        m_Timer = CountdownTimer(false); // Text에 초기값을 넣어 주기 위해
                                         //UI에 표시할 텍스트

        // 오브젝트의 초기 위치를 저장
        //initialPosition = transform.position;//원래 없었음
    }

    private void Update()
    {
        //Vector2 currentPosition = transform.position;//원래 없었음

        //if (currentPosition != initialPosition)//원래 없었음
          //  m_IsPlaying = !m_IsPlaying;

        if (Input.GetKeyDown(m_KcdPlay))
          m_IsPlaying = !m_IsPlaying;
        //매 프레임 실행되며, 사용자의 입력을 감지하고 카운트 다운을 업데이트
        //카운트다운이 완료되면 특정 이벤트를 수행합니다.

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
            //실제 카운트 다운 로직이 구현된 메서드
        }

        // m_TotalSeconds이 줄어들때, 완전히 0에 맞출수 없기 때문에  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //카운트 다운이 종료 될때 [이벤트]를 넣으면 됩니다. 
            Debug.Log("0임");
        }

        if (m_Text)
            m_Text.text = m_Timer;
        //m_Text 변수가 할당되어 있다면(UI 텍스트가 있는 경우)
        //m_Timer값을 해당 텍스트에 표시합니다.
    }

    public void Go_Point2()
    {
        m_IsPlaying = !m_IsPlaying;
    }


    private string CountdownTimer(bool IsUpdate = true)
        //매 프레임마다 시간을 업데이트, 그에 따른 문자열 반환
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;
        //IsUpdate 매개변수에 따라 m_TotalSeconds 를 업데이트할 지 여부를 결정

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}:{2:00}",
            timespan.Hours, timespan.Minutes, timespan.Seconds);
        //m_TotalSeconds를 Time.deltaTime만큼 감소시킨다.
        //실제로 카운트다운을 진행시키기 위함

        //TimeSpan 클래스를 사용하여 남은 시간을 시간, 분, 초 밀리초로 분리
        //string.Format를 사용하여 00:00:00 형식의 문자열로 변환

        return timer;
        //변환된 문자열을 반환
    }

    private void SetZero()
    {
        m_Timer = @"00:00:00";
        //m_Timer 를 00:00:00로 초기화

        m_TotalSeconds = 0;
        // m_TotalSeconds = 0으로 설정하여 카운트 다운이 멈추도록

        m_IsPlaying = false;
        //m_IsPlaying = false로 설정하여 카운트 다운이 일시정지 상태로 전환
    }
}

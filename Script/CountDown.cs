using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountDown : MonoBehaviour
{
    public string m_Timer = @"00:00:00"; //�ð��� ��Ÿ���� ���ڿ� ���� //�ʱⰪ�� 00:00:00


    public KeyCode m_KcdPlay = KeyCode.Space; //ī��Ʈ �ٿ��� ���� Ȥ�� �Ͻ������ϱ� ���� Ű�� ��Ÿ���� Ű�ڵ� ����
    //private Vector2 initialPosition;//���� �߰��� �ڵ�. ���� ��ġ

    private bool m_IsPlaying; // ī��Ʈ �ٿ��� ���� ���� �������� ��Ÿ���� ����

    public float m_TotalSeconds = 7; // ī��Ʈ �ٿ� ��ü ��(5�� X 60��). 
    public Text m_Text; //UI�� ǥ���� �ؽ�Ʈ(Text ������Ʈ)�� �����ϴ� ����

    private void Start()
    {



        m_Timer = CountdownTimer(false); // Text�� �ʱⰪ�� �־� �ֱ� ����
                                         //UI�� ǥ���� �ؽ�Ʈ

        // ������Ʈ�� �ʱ� ��ġ�� ����
        //initialPosition = transform.position;//���� ������
    }

    private void Update()
    {
        //Vector2 currentPosition = transform.position;//���� ������

        //if (currentPosition != initialPosition)//���� ������
          //  m_IsPlaying = !m_IsPlaying;

        if (Input.GetKeyDown(m_KcdPlay))
          m_IsPlaying = !m_IsPlaying;
        //�� ������ ����Ǹ�, ������� �Է��� �����ϰ� ī��Ʈ �ٿ��� ������Ʈ
        //ī��Ʈ�ٿ��� �Ϸ�Ǹ� Ư�� �̺�Ʈ�� �����մϴ�.

        if (m_IsPlaying)
        {
            m_Timer = CountdownTimer();
            //���� ī��Ʈ �ٿ� ������ ������ �޼���
        }

        // m_TotalSeconds�� �پ�鶧, ������ 0�� ����� ���� ������  
        if (m_TotalSeconds <= 0)
        {
            SetZero();
            //ī��Ʈ �ٿ��� ���� �ɶ� [�̺�Ʈ]�� ������ �˴ϴ�. 
            Debug.Log("0��");
        }

        if (m_Text)
            m_Text.text = m_Timer;
        //m_Text ������ �Ҵ�Ǿ� �ִٸ�(UI �ؽ�Ʈ�� �ִ� ���)
        //m_Timer���� �ش� �ؽ�Ʈ�� ǥ���մϴ�.
    }

    public void Go_Point2()
    {
        m_IsPlaying = !m_IsPlaying;
    }


    private string CountdownTimer(bool IsUpdate = true)
        //�� �����Ӹ��� �ð��� ������Ʈ, �׿� ���� ���ڿ� ��ȯ
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;
        //IsUpdate �Ű������� ���� m_TotalSeconds �� ������Ʈ�� �� ���θ� ����

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}:{2:00}",
            timespan.Hours, timespan.Minutes, timespan.Seconds);
        //m_TotalSeconds�� Time.deltaTime��ŭ ���ҽ�Ų��.
        //������ ī��Ʈ�ٿ��� �����Ű�� ����

        //TimeSpan Ŭ������ ����Ͽ� ���� �ð��� �ð�, ��, �� �и��ʷ� �и�
        //string.Format�� ����Ͽ� 00:00:00 ������ ���ڿ��� ��ȯ

        return timer;
        //��ȯ�� ���ڿ��� ��ȯ
    }

    private void SetZero()
    {
        m_Timer = @"00:00:00";
        //m_Timer �� 00:00:00�� �ʱ�ȭ

        m_TotalSeconds = 0;
        // m_TotalSeconds = 0���� �����Ͽ� ī��Ʈ �ٿ��� ���ߵ���

        m_IsPlaying = false;
        //m_IsPlaying = false�� �����Ͽ� ī��Ʈ �ٿ��� �Ͻ����� ���·� ��ȯ
    }
}

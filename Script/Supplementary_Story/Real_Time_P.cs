using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Real_Time_P : MonoBehaviour
{
    public GameObject[] Aine;

    void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f); // �� �ʸ��� UpdateTime �Լ��� ȣ���Ͽ� �ð� ������Ʈ

        //InvokeRepeating()�Լ��� �̿��Ͽ� UpdateTime()�Լ��� 1�ʸ��� ȣ��
        //�� �Լ��� �ð��� ������Ʈ �ϱ� ���� ����
    }

    void UpdateTime()
        //DateTimeOffeset.Now�� ����� ���� �ð��� �����´�

    {
        DateTimeOffset currentTime = DateTimeOffset.Now;
        string formattedTime = currentTime.ToString("HH:mm"); // �ð� ���� ����-> �ð�:��
        //HHmm�� �����̶� �� ���ڵ��� �ٸ��� �ٲٸ� �ȵ�(�ʸ� ���Ѵٸ� :ss�߰��ϱ�)
        
        if (formattedTime.CompareTo("18:30") >= 0 || formattedTime.CompareTo("08:00") < 0)
        {
            //Debug.Log("���� ���� 6�� 30�к��� ���� 8�ñ����Դϴ�!");
            Aine[0].SetActive(false);
            Aine[1].SetActive(true);

            //CompareTo()�� ���ڿ����� ���� ������ ���ϴ� �޼���
            //�񱳴�� ���ڿ����� ũ�ų� ������ 0 �̻��� ���� ��ȯ
        }

        else if (formattedTime.CompareTo("08:00") >= 0 || formattedTime.CompareTo("18:30") < 0)
        {
            //Debug.Log("��ħ�� ���� 8�ú��� ���� 6�� 30�б����Դϴ�!");
            Aine[0].SetActive(true);
            Aine[1].SetActive(false);
        }
        //timeText.text = "���� �ð�: " + formattedTime;
    }

    private void Update()
    {
        //Debug.Log("���� �ð�: " + DateTimeOffset.Now.ToString());
    }


}
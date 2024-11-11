using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Mark : MonoBehaviour
{
    public B_Button b_btn;

    public Side_Story side_story;
    public Main_Stroy_1 Main_story_1;
    public Main_Stroy_2 Main_story_2;
    public GameObject[] Story;//�ϸ�ũ �� ���丮��

    public Animator Book_Mark_Anim;
    public GameObject mark;
    public void Go_Side_Story2()
    {
        side_story.Go_Side_Story();//�޿��� ���̵� ���丮 �ҷ����� ��

        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
            //Go_Back_Main();
        }

        
    }

    public void Go_Main_Story1()
    {
        Main_story_1.Go_Main_Story_1();//���ν��丮 1ȭ �ҷ����� ��
        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
            //Go_Back_Main();
        }
    }

    public void Go_Main_Story2()
    {
        Main_story_2.Go_Main_Story_2();//���ν��丮 2ȭ �ҷ����� ��
        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void FixedUpdate()
    {
        //���� �޿����� ���� ������̶��
        //
        if(side_story.Stars[1].activeSelf==true)
        {
            //0��°�� �޿��� ���̵� ���丮
            Story[2].SetActive(true);
        }

        if (side_story.Stars[0].activeSelf == true)
        {
            //�Ͼ���̶��
            Story[2].SetActive(false);
        }


        //���� ���丮1ȭ ��
        if (Main_story_1.Main_Story_1_Stars[1].activeSelf == true)
        {
            //1��°�� 1ȭ
            Story[0].SetActive(true);
        }

        if (Main_story_1.Main_Story_1_Stars[0].activeSelf == true)
        {
            //�Ͼ���̶��
            Story[0].SetActive(false);
        }

        //���� ���丮2ȭ ��
        if (Main_story_2.Main_Story_2_Stars[1].activeSelf == true)
        {
            //2��°�� 2ȭ
            Story[1].SetActive(true);
        }

        if (Main_story_2.Main_Story_2_Stars[0].activeSelf == true)
        {
            //�Ͼ���̶��
            Story[1].SetActive(false);
        }

    }

    public void Show_Book_Mark()
    {
        //�ϸ�ũ�� ���� ��
        Book_Mark_Anim.SetTrigger("Go_Left");
        mark.SetActive(true);

        b_btn.Hide_Bty();//0723�߰�
    }

    public void Go_Back_Main()
    {
        //�ϸ�ũ���� �������� ���� ��
        Book_Mark_Anim.SetTrigger("Go_Right");
        //mark.SetActive(false);
    }
}

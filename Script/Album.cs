using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Album : MonoBehaviour
{
    public B_Button b_btn;

    public Animator Album_R_L;
    public Animator[] Album_R_L_Inside;//캐릭터 눌렀을 때, 캐릭터 설명을 볼 수 있게 하는 거

    public GameObject[] Hyuohjan_Surprised;//휴오쟌 사이드 스토리 - 놀란 거

    public Side_Story_1_1 side_S_1_1;
    public Side_Story_1_2 side_S_1_2;
    public Side_Story side;

    public RectTransform album;//컨테이너

    public GameObject[] Album_1;
    public GameObject[] Album_2;
    public GameObject[] Album_3;
    public GameObject[] Album_4;
    public GameObject[] Album_5;

    public void Start()
    {

    }

    public void FixedUpdate()
    {
        /*if(side_S.Page_2[2].activeSelf==true || side_S.Side_story[3].activeSelf == true
            || side_S.Side_story[4].activeSelf == true || side_S.Side_story[5].activeSelf == true
            || side_S.Side_story[6].activeSelf == true || side_S.Side_story[7].activeSelf == true
            || side_S.Side_story[8].activeSelf == true || side_S.Side_story[9].activeSelf == true
            || side_S.Side_story[10].activeSelf == true || side_S.Side_story[11].activeSelf == true
            || side_S.Side_story[12].activeSelf == true || side_S.Side_story[13].activeSelf == true
            || side_S.Side_story[14].activeSelf == true || side_S.Side_story[15].activeSelf == true
            || side_S.Side_story[16].activeSelf == true)
        {
            Hyuohjan_Surprised[0].SetActive(false);
            Hyuohjan_Surprised[1].SetActive(true);
        }*/

        if (side_S_1_1.Page_12[1].activeSelf == true || side_S_1_2.Page_12[1].activeSelf == true)
        {
            Hyuohjan_Surprised[0].SetActive(false);
            Hyuohjan_Surprised[1].SetActive(true);
            //Debug.Log("나와라?");
        }

        if ((side_S_1_1.Page_12[1].activeSelf == true || side_S_1_2.Page_12[1].activeSelf == true)
            && (side.First_Side_Story_Object[1].activeSelf == true || side.First_Side_Story_Object[2].activeSelf == true))
        {
            Hyuohjan_Surprised[0].SetActive(false);
            Hyuohjan_Surprised[1].SetActive(true);
            //Debug.Log("나와라?2");
        }

        /*if (side_S.Page_2[1].activeSelf == true)
        {
            Debug.Log("나와라?");
            Hyuohjan_Surprised[0].SetActive(false);
            Hyuohjan_Surprised[1].SetActive(true);
        }*/

        else
        {
            Hyuohjan_Surprised[0].SetActive(true);
            Hyuohjan_Surprised[1].SetActive(false);


            //Debug.Log("니가 실행되는 거니?");
        }
    }

    public void Go_Album()
    {
        b_btn.Hide_Bty();//0723추가

        Album_R_L.SetTrigger("Go_Left");
        album.offsetMin = new Vector2(0, -503.755f);//left, bottom
        album.offsetMax = new Vector2(0, 0.002990723f);//-right, -top
    }

    public void Go_Main()
    {
        Album_R_L.SetTrigger("Go_Right");
    }


    public void Go_Album_Select_1()
    {
        Album_R_L_Inside[0].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_2()
    {
        Album_R_L_Inside[1].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_3()
    {
        Album_R_L_Inside[2].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_4()
    {
        Album_R_L_Inside[3].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_5()
    {
        Album_R_L_Inside[4].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_6()
    {
        Album_R_L_Inside[5].SetTrigger("Go_Right");

    }

    public void Go_Album_Select_7()//휴오쟌 사이드 스토리 - 놀란 거
    {
        Album_R_L_Inside[6].SetTrigger("Go_Right");

    }

    public void Go_One_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[0].SetTrigger("Go_Left");
    }

    public void Go_Two_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[1].SetTrigger("Go_Left");
    }

    public void Go_Three_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[2].SetTrigger("Go_Left");
    }

    public void Go_Four_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[3].SetTrigger("Go_Left");
    }

    public void Go_Five_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[4].SetTrigger("Go_Left");
    }

    public void Go_Six_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[5].SetTrigger("Go_Left");
    }

    public void Go_Seven_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Album_R_L_Inside[6].SetTrigger("Go_Left");
    }
}

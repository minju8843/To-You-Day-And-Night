using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Side_Story_1_2
{//사용자 설정 데이터를 저장하는 클래스
    public int First_Side_Story;//현재 몇 번째 스토리가 활성화되어 있는지 1, 1-1, 1-2
    public int First_Page_What_Page;//첫 번째 이야기의 몇 번째 페이지에서 저장했는지

    public int Page_5_Index;
    public int Page_6_Index;
    public int Page_7_Index;
    public int Page_8_Index;
    public int Page_9_Index;
    public int Page_10_Index;
    public int Page_11_Index;
    public int Page_12_Index;
    public int Page_13_Index;
    public int Page_14_Index;
    public int Page_15_Index;
    public int Page_16_Index;
    public int Page_17_Index;

}

public class Side_Story_1_2 : MonoBehaviour
{
    public int First_Side_Story_Object_Index;
    public int Default_First_Side_Story_Object_Index;


    public GameObject[] Ten_Page_Background;
    public GameObject[] Twelve_Page_Background;


    public Player_Name player_name;

    //5번째 페이지의 2번째부터 나타나는 걸로

    public GameObject First_1_1_Story_Object;

    public Side_Story side_story;
    //public GameObject[] Stars;


    public Slider Side_Story_Slider;
    public int Default_Story_Page = 5;//기본 볼륨 값
    public int Reset_Story_Page = 5;
    public int Current_Story_Page = 5;//현재 볼륨이 얼마인지 알려주기 위함

    public Text Left_Page;


    public GameObject[] Side_story;//페이지별로 넣어둘 거

    public GameObject[] Page_5;//첫 번째 페이지에 나타날 Ui들 넣을 곳
    public GameObject[] Page_6;
    public GameObject[] Page_7;
    public GameObject[] Page_8;
    public GameObject[] Page_9;
    public GameObject[] Page_10;
    public GameObject[] Page_11;
    public GameObject[] Page_12;
    public GameObject[] Page_13;
    public GameObject[] Page_14;
    public GameObject[] Page_15;
    public GameObject[] Page_16;
    public GameObject[] Page_17;

    public GameObject[] Page_Button;

    //public int Default_Page_Count_1 = 0;//현재 몇 페이지인지    
    // -> 디폴트 볼륨과 같은 거라고 생각하기
    //public int Page_Count_1;//리셋되어 디폴트 될 때
    // -> 슬라이더와 같은 거라고 생각하기
    //public int Currnet_Page_Count_1;//현재 페이지가 뭔지  
    // -> 현재 볼륨이라고 생각하기

    public SFX_Manager sfx;

    public int Default_Page_Count_5 = 0;
    public int Page_Count_5;
    public int Currnet_Page_Count_5;

    public int Default_Page_Count_6 = 0;
    public int Page_Count_6;
    public int Currnet_Page_Count_6;

    public int Default_Page_Count_7 = 0;
    public int Page_Count_7;
    public int Currnet_Page_Count_7;

    public int Default_Page_Count_8 = 0;
    public int Page_Count_8;
    public int Currnet_Page_Count_8;

    public int Default_Page_Count_9 = 0;
    public int Page_Count_9;
    public int Currnet_Page_Count_9;

    public int Default_Page_Count_10 = 0;
    public int Page_Count_10;
    public int Currnet_Page_Count_10;

    public int Default_Page_Count_11 = 0;
    public int Page_Count_11;
    public int Currnet_Page_Count_11;

    public int Default_Page_Count_12 = 0;
    public int Page_Count_12;
    public int Currnet_Page_Count_12;

    public int Default_Page_Count_13 = 0;
    public int Page_Count_13;
    public int Currnet_Page_Count_13;

    public int Default_Page_Count_14 = 0;
    public int Page_Count_14;
    public int Currnet_Page_Count_14;

    public int Default_Page_Count_15 = 0;
    public int Page_Count_15;
    public int Currnet_Page_Count_15;

    public int Default_Page_Count_16 = 0;
    public int Page_Count_16;
    public int Currnet_Page_Count_16;

    public int Default_Page_Count_17 = 0;
    public int Page_Count_17;
    public int Currnet_Page_Count_17;


    public int Star_B_Count = 0;

    public Animator Side_Story_R_L;

    public void Go_Side_Story()
    {
        if (side_story.First_Side_Story_Object[0].activeSelf == true)
        {
            Side_Story_R_L.SetTrigger("Go_Left");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Left");
        }

        else if (side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            side_story.side_1_1.Side_Story_R_L.SetTrigger("Go_Left");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Left");
        }

        else if (side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            side_story.side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Left");
        }


    }

    public void Go_Main()
    {
        if (side_story.First_Side_Story_Object[0].activeSelf == true)
        {
            Side_Story_R_L.SetTrigger("Go_Right");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Right");
        }

        else if (side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            side_story.side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Right");
        }

        else if (side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            side_story.side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
            side_story.Button_Side_Story_R_L.SetTrigger("Go_Right");
        }

    }

    public void OnEnable()
    {
        Page_5_Text_LoadSettings();
        Side_Story_What_Page_LoadSettings();

        Page_6_Text_LoadSettings();
        Page_7_Text_LoadSettings();
        Page_8_Text_LoadSettings();
        Page_9_Text_LoadSettings();
        Page_10_Text_LoadSettings();
        Page_11_Text_LoadSettings();
        Page_12_Text_LoadSettings();
        Page_13_Text_LoadSettings();
        Page_14_Text_LoadSettings();
        Page_15_Text_LoadSettings();
        Page_16_Text_LoadSettings();
        Page_17_Text_LoadSettings();

    }

    private void Start()
    {

    }

    public void Update()
    {
        //만약
        if (Page_Count_5 >= Page_5.Length && Page_6[0].activeSelf == false &&

            (Side_story[4].activeSelf == true || Side_story[5].activeSelf == true)// [4]  [5]

            //[4]
            && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
             && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
             && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
             && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
             && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
             && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[1].SetActive(true);
        }

        //6
        if (Page_Count_6 >= Page_6.Length && Page_7[0].activeSelf == false &&

            (Side_story[5].activeSelf == true || Side_story[6].activeSelf == true)// [5]  [6]

            //[5]
            && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
             && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
             && Side_story[5].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
             && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
             && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
             && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[2].SetActive(true);//2
        }

        //7
        if (Page_Count_7 >= Page_7.Length && Page_8[0].activeSelf == false &&

           (Side_story[6].activeSelf == true || Side_story[7].activeSelf == true)// [6]  [7]

           //[6]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[5].activeSelf == false && Side_story[6].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[3].SetActive(true);//3
        }

        //8
        if (Page_Count_8 >= Page_8.Length && Page_9[0].activeSelf == false &&

           (Side_story[7].activeSelf == true || Side_story[8].activeSelf == true)// [7]  [8]

           //[7]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[5].activeSelf == false && Side_story[7].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[4].SetActive(true);//4
        }

        //9
        if (Page_Count_9 >= Page_9.Length && Page_10[0].activeSelf == false &&

           (Side_story[8].activeSelf == true || Side_story[9].activeSelf == true)// [8]  [9]

           //[8]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[5].activeSelf == false
            && Side_story[8].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[5].SetActive(true);//5
        }

        //10
        if (Page_Count_10 >= Page_10.Length && Page_11[0].activeSelf == false &&

           (Side_story[9].activeSelf == true || Side_story[10].activeSelf == true)// [9]  [10]

           //[9]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[5].activeSelf == false && Side_story[9].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[6].SetActive(true);//6
        }

        //11
        if (Page_Count_11 >= Page_11.Length && Page_12[0].activeSelf == false &&

           (Side_story[10].activeSelf == true || Side_story[11].activeSelf == true)// [10]  [11]

           //[10]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[5].activeSelf == false && Side_story[10].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[7].SetActive(true);//7
        }

        //12
        if (Page_Count_12 >= Page_12.Length && Page_13[0].activeSelf == false &&

           (Side_story[11].activeSelf == true || Side_story[12].activeSelf == true)// [11]  [12]

           //[11]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[5].activeSelf == false
            && Side_story[11].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[8].SetActive(true);//8
        }

        //13
        if (Page_Count_13 >= Page_13.Length && Page_14[0].activeSelf == false &&

           (Side_story[12].activeSelf == true || Side_story[13].activeSelf == true)// [12]  [13]

           //[12]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[5].activeSelf == false && Side_story[12].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[9].SetActive(true);//9
        }

        //14
        if (Page_Count_14 >= Page_14.Length && Page_15[0].activeSelf == false &&

           (Side_story[13].activeSelf == true || Side_story[14].activeSelf == true)// [13]  [14]

           //[13]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[5].activeSelf == false && Side_story[13].activeSelf == false
            && Side_story[15].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[10].SetActive(true);//10
        }

        //15
        if (Page_Count_15 >= Page_15.Length && Page_16[0].activeSelf == false &&

           (Side_story[14].activeSelf == true || Side_story[15].activeSelf == true)// [14]  [15]

           //[14]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[5].activeSelf == false
            && Side_story[14].activeSelf == false && Side_story[16].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[11].SetActive(true);//11
        }

        //16
        if (Page_Count_16 >= Page_16.Length && Page_17[0].activeSelf == false &&

           (Side_story[15].activeSelf == true || Side_story[16].activeSelf == true)// [15]  [16]

           //[15]
           && Side_story[0].activeSelf == false && Side_story[1].activeSelf == false && Side_story[2].activeSelf == false
            && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
            && Side_story[6].activeSelf == false && Side_story[7].activeSelf == false && Side_story[8].activeSelf == false
            && Side_story[9].activeSelf == false && Side_story[10].activeSelf == false && Side_story[11].activeSelf == false
            && Side_story[12].activeSelf == false && Side_story[13].activeSelf == false && Side_story[14].activeSelf == false
            && Side_story[5].activeSelf == false && Side_story[15].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[12].SetActive(true);//12
        }
        //여기까지 0724 추가

        //버튼 오류로 일단 만들어봄
        if (Page_Count_5 < Page_5.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 1; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_6 < Page_6.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 2; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_7 < Page_7.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 3; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_8 < Page_8.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 4; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_9 < Page_9.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 5; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_10 < Page_10.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 6; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_11 < Page_11.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 7; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_12 < Page_12.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 8; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_13 < Page_13.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 9; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_14 < Page_14.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 10; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_15 < Page_15.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 11; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_16 < Page_16.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 12; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }


        /*if (Page_Count_10 == 3)
        {
            Ten_Page_Background[0].SetActive(false);
            Ten_Page_Background[1].SetActive(true);
        }*/

        if (Page_Count_10 <= 3)
        {
            Ten_Page_Background[0].SetActive(true);
            Ten_Page_Background[1].SetActive(false);
        }

        if (Page_Count_10 > 3)
        {
            Ten_Page_Background[0].SetActive(false);
            Ten_Page_Background[1].SetActive(true);
        }

        /*if (Page_Count_12 == 3)
        {
            Twelve_Page_Background[0].SetActive(false);
            Twelve_Page_Background[1].SetActive(true);
        }*/

        if (Page_Count_12 > 3)
        {
            Twelve_Page_Background[0].SetActive(false);
            Twelve_Page_Background[1].SetActive(true);
        }

        if (Page_Count_12 <= 3)
        {
            Twelve_Page_Background[0].SetActive(true);
            Twelve_Page_Background[1].SetActive(false);
        }


        /*if (side_story.Stars[0].activeSelf == true)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(false);

            Star_B_Count = 0;
        }

        else if (side_story.Stars[1].activeSelf == true)
        {
            Stars[0].SetActive(false);
            Stars[1].SetActive(true);

            Star_B_Count = 1;
        }*/


        Current_Story_Page = (int)Side_Story_Slider.value;
        Left_Page.text = Current_Story_Page.ToString();



        foreach (GameObject Story_Page in Side_story)
        {
            Story_Page.SetActive(false);
        }

        Side_story[Current_Story_Page - 1].SetActive(true);

        Side_Story_1_SaveSettings();

        Currnet_Page_Count_5 = Page_Count_5;
        Currnet_Page_Count_6 = Page_Count_6;
        Currnet_Page_Count_7 = Page_Count_7;
        Currnet_Page_Count_8 = Page_Count_8;
        Currnet_Page_Count_9 = Page_Count_9;
        Currnet_Page_Count_10 = Page_Count_10;
        Currnet_Page_Count_11 = Page_Count_11;
        Currnet_Page_Count_12 = Page_Count_12;
        Currnet_Page_Count_13 = Page_Count_13;
        Currnet_Page_Count_14 = Page_Count_14;
        Currnet_Page_Count_15 = Page_Count_15;
        Currnet_Page_Count_16 = Page_Count_16;
        Currnet_Page_Count_17 = Page_Count_17;

        /* if (Star_B_Count % 2 == 0)
         {
             Stars[0].SetActive(true);
             Stars[1].SetActive(false);
         }*/


        //아래엔 1/14에 추가
        /*foreach (GameObject First_Side_Story_Object_1 in side_story.First_Side_Story_Object)
        {
            First_Side_Story_Object_1.SetActive(false);
        }

        side_story.First_Side_Story_Object[First_Side_Story_Object_Index].SetActive(true);
        */
        //바로 위에거는 필요하다 싶으면 주석 지우기


        //첫 번째 선택지 다음 1-1에대한 거
        /*if((Current_Story_Page < 15 || Current_Story_Page > 16)&& side_story.First_Side_Story_Object[1].activeSelf==true && Page_Count_16==3)
        {
            Page_16[3].SetActive(false);
        }

        else if (Current_Story_Page == 16 && side_story.First_Side_Story_Object[1].activeSelf == true && Page_Count_16 == 3)
        {
            Page_16[3].SetActive(true);
        }*/

        //첫 번째 선택지 다음 1-2에 대한 거
        /*if ((Current_Story_Page < 15 || Current_Story_Page > 16) && side_story.First_Side_Story_Object[2].activeSelf == true && Page_Count_16 == 3)
        {
            Page_16[3].SetActive(false);
        }

        else if (Current_Story_Page == 16 && side_story.First_Side_Story_Object[2].activeSelf == true && Page_Count_16 == 3)
        {
            Page_16[3].SetActive(true);
        }*/


        //1-1에 대한 거 //여기 아래부터는 1/14에 수정
        /*if ((Current_Story_Page < 16 || Current_Story_Page > 16) && Page_Button[11].activeSelf == false && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            Page_Button[11].SetActive(false);
        }

        else if ((Page_Button[0].activeSelf == true || Page_Button[2].activeSelf == true || Page_Button[2].activeSelf == true
            || Page_Button[3].activeSelf == true || Page_Button[4].activeSelf == true || Page_Button[5].activeSelf == true
            || Page_Button[6].activeSelf == true || Page_Button[7].activeSelf == true || Page_Button[8].activeSelf == true
            || Page_Button[9].activeSelf == true || Page_Button[10].activeSelf == true) && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            Page_Button[11].SetActive(false);
        }

        else if (Current_Story_Page == 16 && Page_16[2].activeSelf == true && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            //Page_5[1].SetActive(true);
            Page_Button[11].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            Page_16[3].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && Currnet_Page_Count_16 == 4 && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            Page_16[3].SetActive(true);
        }

        //1-2
        if ((Current_Story_Page < 16 || Current_Story_Page > 16) && Page_Button[11].activeSelf == false && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            Page_Button[11].SetActive(false);
        }

        else if ((Page_Button[0].activeSelf == true || Page_Button[2].activeSelf == true || Page_Button[2].activeSelf == true
            || Page_Button[3].activeSelf == true || Page_Button[4].activeSelf == true || Page_Button[5].activeSelf == true
            || Page_Button[6].activeSelf == true || Page_Button[7].activeSelf == true || Page_Button[8].activeSelf == true
            || Page_Button[9].activeSelf == true || Page_Button[10].activeSelf == true) && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            Page_Button[11].SetActive(false);
        }

        else if (Current_Story_Page == 16 && Page_16[2].activeSelf == true && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            //Page_5[1].SetActive(true);
            Page_Button[11].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && Currnet_Page_Count_16 == 4 && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(true);
        }*/
    }

    private void FixedUpdate()
    {
        //13개

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17번 다 봤으면
       /* if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
            && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
            && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length)
            && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length) && (Page_Count_15 > Page_15.Length)
            && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length))
        {//5페이지 이후
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
            && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
            && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length)
            && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length) && (Page_Count_15 > Page_15.Length)
            && (Page_Count_16 > Page_16.Length))
        {//5페이지 이후
            for (int i = 0; i < 12; i++)
            {
                Page_Button[i].SetActive(false);
            }


        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
            && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
            && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length)
            && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length) && (Page_Count_15 > Page_15.Length))
        {//5페이지 이후
            for (int i = 0; i < 11; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 12; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }



        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
        && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length)
        && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length))
        {//5페이지 이후
            for (int i = 0; i < 10; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 11; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
        && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length)
        && (Page_Count_13 > Page_13.Length))
        {//5페이지 이후
            for (int i = 0; i < 9; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 10; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10, 11, 12번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
        && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length) && (Page_Count_12 > Page_12.Length))
        {//5페이지 이후
            for (int i = 0; i < 8; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 9; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10, 11번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
        && (Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length))
        {//5페이지 이후
            for (int i = 0; i < 7; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 8; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length)
        && (Page_Count_10 > Page_10.Length))
        {//5페이지 이후
            for (int i = 0; i < 6; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 7; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length) && (Page_Count_9 > Page_9.Length))
        {//5페이지 이후
            for (int i = 0; i < 5; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 6; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length))
        {//5페이지 이후
            for (int i = 0; i < 4; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 5; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length)
        && (Page_Count_7 > Page_7.Length))
        {//5페이지 이후

            //0, 1, 2다 봄
            //3활성
            //4비활성

            // 12 - 10

            for (int i = 0; i < 3; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 4; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length) && (Page_Count_6 > Page_6.Length))
        {//5페이지 이후

            //0, 1다 봄
            //2 활성화
            //3부터 비활성

            for (int i = 0; i < 2; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 3; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        //5번 다 봤으면
        else if ((Page_Count_5 > Page_5.Length))
        {//5페이지 이후 
         //1페이지 다 봤으면(0끝)
         //1 활성화

            for (int i = 0; i < 1; i++)
            {//0(1페이지)
                Page_Button[i].SetActive(false); //0
            }

            //5, 6, 7 // 0, 1, 2
            for (int i = 2; i < Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }
        }

        else
        {
            for (int i = 1; i < Page_Button.Length; i++)
            {//0(1페이지)
                Page_Button[i].SetActive(false); //0
            }

            Page_Button[0].SetActive(true);
        }


        //1, 2, 3, 4, 5번 다 봤으면
        /*if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
            && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length))
        {//5페이지 이후
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        //1, 2, 3, 4봤으면
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
            && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length))
        {
            //5페이지
            for (int i = 0; i < Page_Button.Length - 1; i++)
            {
                Page_Button[i].SetActive(false);
            }


        }

        //1, 2, 3봤으면
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
            && (Page_Count_3 > Page_3.Length))
        {
            //4페이지
            for (int i = 0; i < Page_Button.Length - 2; i++)//3
            {//0, 1, 2
                Page_Button[i].SetActive(false);
            }

            for (int i = 4; i < Page_Button.Length; i++)
            {
                //4
                Page_Button[i].SetActive(false);
            }

        }

        //1, 2
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length))
        {
            //3페이지 일 경우
            for (int i = 0; i < Page_Button.Length - 3; i++)//2
            {//0(1페이지)
                Page_Button[i].SetActive(false);
            }

            for (int i = 3; i < Page_Button.Length; i++)
            {
                //
                Page_Button[i].SetActive(false);
            }

        }

        //1
        else if (Page_Count_1 > Page_1.Length)
        {//2페이지일 경우
            for (int i = 0; i < 1; i++)
            {//0(1페이지)
                Page_Button[i].SetActive(false); //0
            }

            for (int i = 2; i > Page_Button.Length; i++)
            {
                //2(3페이지)
                Page_Button[i].SetActive(false);
            }

        }*/



    }

    private void Side_Story_What_Page_LoadSettings()
    {
        //여기부터는 첫 번째 이야기의 몇 번째 페이지에서 저장했는지
        if (PlayerPrefs.HasKey("SideStory_1_2_What_Page"))
        {
            string What_Page_First_Page_jsonData_1 = PlayerPrefs.GetString("SideStory_1_2_What_Page");
            GameData_Side_Story_1_2 What_Page_First_Page_data_1 = JsonUtility.FromJson<GameData_Side_Story_1_2>(What_Page_First_Page_jsonData_1);


            Side_Story_Slider.value = What_Page_First_Page_data_1.First_Page_What_Page;
            Current_Story_Page = (int)Side_Story_Slider.value;


           // Debug.Log("현재 불러온 스토리 페이지는? :" + Current_Story_Page);
            
        }

        else
        {
            Side_Story_Slider.value = Reset_Story_Page;

            Current_Story_Page = (int)Side_Story_Slider.value;

            Side_story[4].SetActive(true);

            for (int i = 5; i < Side_story.Length; i++)
            {
                Side_story[i].SetActive(false);
            }

            for (int i = 0; i < 4; i++)
            {
                Side_story[i].SetActive(false);
            }
        }
    }

    private void Side_Story_1_SaveSettings()//일단 첫 번째 사이드 스토리의 몇 번째인지(1, 1-1, 1-2중)
    {
        //여기부터는 지금 1, 1-1, 1-2 중에서 뭐인지 저장한 코드
        GameData_Side_Story_1_2 data = new GameData_Side_Story_1_2();
        data.First_Side_Story = First_Side_Story_Object_Index;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SideStory_1_2", jsonData);
        PlayerPrefs.Save();


        //여기부터는 첫 번째 이야기의 몇 번째 페이지에서 저장했는지
        GameData_Side_Story_1_2 What_Page_First_Page_data_1 = new GameData_Side_Story_1_2();
        What_Page_First_Page_data_1.First_Page_What_Page = (int)Side_Story_Slider.value;

        string What_Page_First_Page_jsonData_1 = JsonUtility.ToJson(What_Page_First_Page_data_1);
        PlayerPrefs.SetString("SideStory_1_2_What_Page", What_Page_First_Page_jsonData_1);
        PlayerPrefs.Save();

        //Debug.Log("현재 저장한 스토리 페이지는? :" + What_Page_First_Page_jsonData_1);

        //여기부터는 첫 번째 이야기의 몇 번째 텍스트가 나왔는지

        //5번 페이지
        GameData_Side_Story_1_2 Page_5_Text_data = new GameData_Side_Story_1_2();
        Page_5_Text_data.Page_5_Index = Page_Count_5;

        string Page_5_Text_jsonData = JsonUtility.ToJson(Page_5_Text_data);
        PlayerPrefs.SetString("Page_5_2_Text", Page_5_Text_jsonData);
        PlayerPrefs.Save();

        //6번
        GameData_Side_Story_1_2 Page_6_Text_data = new GameData_Side_Story_1_2();
        Page_6_Text_data.Page_6_Index = Page_Count_6;

        string Page_6_Text_jsonData = JsonUtility.ToJson(Page_6_Text_data);
        PlayerPrefs.SetString("Page_6_2_Text", Page_6_Text_jsonData);
        PlayerPrefs.Save();

        //7번
        GameData_Side_Story_1_2 Page_7_Text_data = new GameData_Side_Story_1_2();
        Page_7_Text_data.Page_7_Index = Page_Count_7;

        string Page_7_Text_jsonData = JsonUtility.ToJson(Page_7_Text_data);
        PlayerPrefs.SetString("Page_7_2_Text", Page_7_Text_jsonData);
        PlayerPrefs.Save();

        //8번
        GameData_Side_Story_1_2 Page_8_Text_data = new GameData_Side_Story_1_2();
        Page_8_Text_data.Page_8_Index = Page_Count_8;

        string Page_8_Text_jsonData = JsonUtility.ToJson(Page_8_Text_data);
        PlayerPrefs.SetString("Page_8_2_Text", Page_8_Text_jsonData);
        PlayerPrefs.Save();

        //9번
        GameData_Side_Story_1_2 Page_9_Text_data = new GameData_Side_Story_1_2();
        Page_9_Text_data.Page_9_Index = Page_Count_9;

        string Page_9_Text_jsonData = JsonUtility.ToJson(Page_9_Text_data);
        PlayerPrefs.SetString("Page_9_2_Text", Page_9_Text_jsonData);
        PlayerPrefs.Save();

        //10번 페이지
        GameData_Side_Story_1_2 Page_10_Text_data = new GameData_Side_Story_1_2();
        Page_10_Text_data.Page_10_Index = Page_Count_10;

        string Page_10_Text_jsonData = JsonUtility.ToJson(Page_10_Text_data);
        PlayerPrefs.SetString("Page_10_2_Text", Page_10_Text_jsonData);
        PlayerPrefs.Save();

        //11번
        GameData_Side_Story_1_2 Page_11_Text_data = new GameData_Side_Story_1_2();
        Page_11_Text_data.Page_11_Index = Page_Count_11;

        string Page_11_Text_jsonData = JsonUtility.ToJson(Page_11_Text_data);
        PlayerPrefs.SetString("Page_11_2_Text", Page_11_Text_jsonData);
        PlayerPrefs.Save();

        //12번
        GameData_Side_Story_1_2 Page_12_Text_data = new GameData_Side_Story_1_2();
        Page_12_Text_data.Page_12_Index = Page_Count_12;

        string Page_12_Text_jsonData = JsonUtility.ToJson(Page_12_Text_data);
        PlayerPrefs.SetString("Page_12_2_Text", Page_12_Text_jsonData);
        PlayerPrefs.Save();

        //13번
        GameData_Side_Story_1_2 Page_13_Text_data = new GameData_Side_Story_1_2();
        Page_13_Text_data.Page_13_Index = Page_Count_13;

        string Page_13_Text_jsonData = JsonUtility.ToJson(Page_13_Text_data);
        PlayerPrefs.SetString("Page_13_2_Text", Page_13_Text_jsonData);
        PlayerPrefs.Save();

        //14번
        GameData_Side_Story_1_2 Page_14_Text_data = new GameData_Side_Story_1_2();
        Page_14_Text_data.Page_14_Index = Page_Count_14;

        string Page_14_Text_jsonData = JsonUtility.ToJson(Page_14_Text_data);
        PlayerPrefs.SetString("Page_14_2_Text", Page_14_Text_jsonData);
        PlayerPrefs.Save();

        //15번 페이지
        GameData_Side_Story_1_2 Page_15_Text_data = new GameData_Side_Story_1_2();
        Page_15_Text_data.Page_15_Index = Page_Count_15;

        string Page_15_Text_jsonData = JsonUtility.ToJson(Page_15_Text_data);
        PlayerPrefs.SetString("Page_15_2_Text", Page_15_Text_jsonData);
        PlayerPrefs.Save();

        //16번
        GameData_Side_Story_1_2 Page_16_Text_data = new GameData_Side_Story_1_2();
        Page_16_Text_data.Page_16_Index = Page_Count_16;

        string Page_16_Text_jsonData = JsonUtility.ToJson(Page_16_Text_data);
        PlayerPrefs.SetString("Page_16_2_Text", Page_16_Text_jsonData);
        PlayerPrefs.Save();

        //17번
        GameData_Side_Story_1_2 Page_17_Text_data = new GameData_Side_Story_1_2();
        Page_17_Text_data.Page_17_Index = Page_Count_17;

        string Page_17_Text_jsonData = JsonUtility.ToJson(Page_17_Text_data);
        PlayerPrefs.SetString("Page_17_2_Text", Page_17_Text_jsonData);
        PlayerPrefs.Save();



    }

    public void Side_Story_1_1_ResetSettings()
    {
        /*PlayerPrefs.DeleteKey("SideStory_1");
        PlayerPrefs.Save();

        First_Side_Story_Object_Index = Default_First_Side_Story_Object_Index;
        foreach (GameObject first_side_story in side_story.First_Side_Story_Object)
        {
            first_side_story.SetActive(false);
        }

        Side_Story_R_L.SetTrigger("Go_Right");
        side_story.side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
        side_story.side_1_2.Side_Story_R_L.SetTrigger("Go_Right");

        side_story.First_Side_Story_Object[First_Side_Story_Object_Index].SetActive(true);
        */

        //여기부터는 첫 번째 이야기의 몇 번째 페이지에서 저장했는지
        PlayerPrefs.DeleteKey("SideStory_1_2_What_Page");
        PlayerPrefs.Save();

        Side_Story_Slider.value = Reset_Story_Page;
        Current_Story_Page = (int)Side_Story_Slider.value;
        foreach (GameObject first_side_story_Page in Side_story)
        {
            first_side_story_Page.SetActive(false);
        }

        Side_story[Current_Story_Page].SetActive(true);



        //5번 페이지 몇 번째 텍스트까지 나왔는지
        PlayerPrefs.DeleteKey("Page_5_2_Text");
        PlayerPrefs.Save();
        Page_Count_5 = Default_Page_Count_5;
        foreach (GameObject Page_5_Text in Page_5)
        {
            Page_5_Text.SetActive(false);
        }


        //6
        PlayerPrefs.DeleteKey("Page_6_2_Text");
        PlayerPrefs.Save();
        Page_Count_6 = Default_Page_Count_6;
        foreach (GameObject Page_6_Text in Page_6)
        {
            Page_6_Text.SetActive(false);
        }

        //7
        PlayerPrefs.DeleteKey("Page_7_2_Text");
        PlayerPrefs.Save();
        Page_Count_7 = Default_Page_Count_7;
        foreach (GameObject Page_7_Text in Page_7)
        {
            Page_7_Text.SetActive(false);
        }

        //8
        PlayerPrefs.DeleteKey("Page_8_2_Text");
        PlayerPrefs.Save();
        Page_Count_8 = Default_Page_Count_8;
        foreach (GameObject Page_8_Text in Page_8)
        {
            Page_8_Text.SetActive(false);
        }

        //9
        PlayerPrefs.DeleteKey("Page_9_2_Text");
        PlayerPrefs.Save();
        Page_Count_9 = Default_Page_Count_9;
        foreach (GameObject Page_9_Text in Page_9)
        {
            Page_9_Text.SetActive(false);
        }

        //10
        PlayerPrefs.DeleteKey("Page_10_2_Text");
        PlayerPrefs.Save();
        Page_Count_10 = Default_Page_Count_10;
        foreach (GameObject Page_10_Text in Page_10)
        {
            Page_10_Text.SetActive(false);
        }

        //11
        PlayerPrefs.DeleteKey("Page_11_2_Text");
        PlayerPrefs.Save();
        Page_Count_11 = Default_Page_Count_11;
        foreach (GameObject Page_11_Text in Page_11)
        {
            Page_11_Text.SetActive(false);
        }

        //12
        PlayerPrefs.DeleteKey("Page_12_2_Text");
        PlayerPrefs.Save();
        Page_Count_12 = Default_Page_Count_12;
        foreach (GameObject Page_12_Text in Page_12)
        {
            Page_12_Text.SetActive(false);
        }

        //13
        PlayerPrefs.DeleteKey("Page_13_2_Text");
        PlayerPrefs.Save();
        Page_Count_13 = Default_Page_Count_13;
        foreach (GameObject Page_13_Text in Page_13)
        {
            Page_13_Text.SetActive(false);
        }

        //14
        PlayerPrefs.DeleteKey("Page_14_2_Text");
        PlayerPrefs.Save();
        Page_Count_14 = Default_Page_Count_14;
        foreach (GameObject Page_14_Text in Page_14)
        {
            Page_14_Text.SetActive(false);
        }

        //15
        PlayerPrefs.DeleteKey("Page_15_2_Text");
        PlayerPrefs.Save();
        Page_Count_15 = Default_Page_Count_15;
        foreach (GameObject Page_15_Text in Page_15)
        {
            Page_15_Text.SetActive(false);
        }

        //16
        PlayerPrefs.DeleteKey("Page_16_2_Text");
        PlayerPrefs.Save();
        Page_Count_16 = Default_Page_Count_16;
        foreach (GameObject Page_16_Text in Page_16)
        {
            Page_16_Text.SetActive(false);
        }

        //17
        PlayerPrefs.DeleteKey("Page_17_2_Text");
        PlayerPrefs.Save();
        Page_Count_17 = Default_Page_Count_17;
        foreach (GameObject Page_17_Text in Page_17)
        {
            Page_17_Text.SetActive(false);
        }
    }

    //5번 텍스트
    private void Page_5_Text_LoadSettings()
    {

        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_5_2_Text"))
        {
            string Page_5_Text_jsonData = PlayerPrefs.GetString("Page_5_2_Text");
            GameData_Side_Story_1_2 Page_5_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_5_Text_jsonData);

            Page_Count_5 = Page_5_Text_data.Page_5_Index;

            if (Page_Count_5 > 0)
            {
                foreach (GameObject Page_5_Text in Page_5)
                {
                    Page_5_Text.SetActive(true);
                }

                for (int i = Page_Count_5; i < Page_5.Length; i++)
                {
                    Page_5[i].SetActive(false);//여기도 문제

                    if (Page_Count_5 > Page_5.Length)
                    {
                        Page_Button[0].SetActive(false);
                    }

                    else
                    {
                        Page_Button[0].SetActive(true);
                    }
                }
                if (Page_Count_5 > Page_5.Length)
                {
                    Page_Button[0].SetActive(false);
                }

                else
                {
                    Page_Button[0].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_5_Text in Page_5)
                {
                    Page_5_Text.SetActive(false);
                }

                for (int i = 0; i < Page_5.Length; i++)
                {
                    Page_5[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_5 = Default_Page_Count_5;
        }

    }

    //6
    private void Page_6_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_6_2_Text"))
        {
            string Page_6_Text_jsonData = PlayerPrefs.GetString("Page_6_2_Text");
            GameData_Side_Story_1_2 Page_6_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_6_Text_jsonData);

            Page_Count_6 = Page_6_Text_data.Page_6_Index;

            if (Page_Count_6 > 0)
            {
                foreach (GameObject Page_6_Text in Page_6)
                {
                    Page_6_Text.SetActive(true);
                }

                for (int i = Page_Count_6; i < Page_6.Length; i++)
                {
                    Page_6[i].SetActive(false);//여기도 문제

                    if (Page_Count_6 > Page_6.Length)
                    {
                        Page_Button[1].SetActive(false);
                    }

                    else
                    {
                        Page_Button[1].SetActive(true);
                    }

                   // Debug.Log("불러온 텍스트 숫자는?" + Page_Count_6);
                }
                if (Page_Count_6 > Page_6.Length)
                {
                    Page_Button[1].SetActive(false);
                }

                else
                {
                    Page_Button[1].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_6_Text in Page_6)
                {
                    Page_6_Text.SetActive(false);
                }

                for (int i = 0; i < Page_6.Length; i++)
                {
                    Page_6[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_6 = Default_Page_Count_6;
        }

    }

    //7
    private void Page_7_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_7_2_Text"))
        {
            string Page_7_Text_jsonData = PlayerPrefs.GetString("Page_7_2_Text");
            GameData_Side_Story_1_2 Page_7_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_7_Text_jsonData);

            Page_Count_7 = Page_7_Text_data.Page_7_Index;

            if (Page_Count_7 > 0)
            {
                foreach (GameObject Page_7_Text in Page_7)
                {
                    Page_7_Text.SetActive(true);
                }

                for (int i = Page_Count_7; i < Page_7.Length; i++)
                {
                    Page_7[i].SetActive(false);//여기도 문제

                    if (Page_Count_7 > Page_7.Length)
                    {
                        Page_Button[2].SetActive(false);
                    }

                    else
                    {
                        Page_Button[2].SetActive(true);
                    }
                }
                if (Page_Count_7 > Page_7.Length)
                {
                    Page_Button[2].SetActive(false);
                }

                else
                {
                    Page_Button[2].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_7_Text in Page_7)
                {
                    Page_7_Text.SetActive(false);
                }

                for (int i = 0; i < Page_7.Length; i++)
                {
                    Page_7[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_7 = Default_Page_Count_7;
        }

    }

    //8
    private void Page_8_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_8_2_Text"))
        {
            string Page_8_Text_jsonData = PlayerPrefs.GetString("Page_8_2_Text");
            GameData_Side_Story_1_2 Page_8_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_8_Text_jsonData);

            Page_Count_8 = Page_8_Text_data.Page_8_Index;

            if (Page_Count_8 > 0)
            {
                foreach (GameObject Page_8_Text in Page_8)
                {
                    Page_8_Text.SetActive(true);
                }

                for (int i = Page_Count_8; i < Page_8.Length; i++)
                {
                    Page_8[i].SetActive(false);//여기도 문제

                    if (Page_Count_8 > Page_8.Length)
                    {
                        Page_Button[3].SetActive(false);
                    }

                    else
                    {
                        Page_Button[3].SetActive(true);
                    }
                }
                if (Page_Count_8 > Page_8.Length)
                {
                    Page_Button[3].SetActive(false);
                }

                else
                {
                    Page_Button[3].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_8_Text in Page_8)
                {
                    Page_8_Text.SetActive(false);
                }

                for (int i = 0; i < Page_8.Length; i++)
                {
                    Page_8[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_8 = Default_Page_Count_8;
        }

    }

    //9
    private void Page_9_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_9_2_Text"))
        {
            string Page_9_Text_jsonData = PlayerPrefs.GetString("Page_9_2_Text");
            GameData_Side_Story_1_2 Page_9_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_9_Text_jsonData);

            Page_Count_9 = Page_9_Text_data.Page_9_Index;

            if (Page_Count_9 > 0)
            {
                foreach (GameObject Page_9_Text in Page_9)
                {
                    Page_9_Text.SetActive(true);
                }

                for (int i = Page_Count_9; i < Page_9.Length; i++)
                {
                    Page_9[i].SetActive(false);//여기도 문제

                    if (Page_Count_9 > Page_9.Length)
                    {
                        Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[4].SetActive(true);
                    }
                }
                if (Page_Count_9 > Page_9.Length)
                {
                    Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[4].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_9_Text in Page_9)
                {
                    Page_9_Text.SetActive(false);
                }

                for (int i = 0; i < Page_9.Length; i++)
                {
                    Page_9[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_9 = Default_Page_Count_9;
        }

    }

    //10
    private void Page_10_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_10_2_Text"))
        {
            string Page_10_Text_jsonData = PlayerPrefs.GetString("Page_10_2_Text");
            GameData_Side_Story_1_2 Page_10_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_10_Text_jsonData);

            Page_Count_10 = Page_10_Text_data.Page_10_Index;

            if (Page_Count_10 > 0)
            {
                foreach (GameObject Page_10_Text in Page_10)
                {
                    Page_10_Text.SetActive(true);
                }

                for (int i = Page_Count_10; i < Page_10.Length; i++)
                {
                    Page_10[i].SetActive(false);//여기도 문제

                    if (Page_Count_10 > Page_10.Length)
                    {
                        Page_Button[5].SetActive(false);
                    }

                    else
                    {
                        Page_Button[5].SetActive(true);
                    }
                }
                if (Page_Count_10 > Page_10.Length)
                {
                    Page_Button[5].SetActive(false);
                }

                else
                {
                    Page_Button[5].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_10_Text in Page_10)
                {
                    Page_10_Text.SetActive(false);
                }

                for (int i = 0; i < Page_10.Length; i++)
                {
                    Page_10[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_10 = Default_Page_Count_10;
        }

    }

    //11
    private void Page_11_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_11_2_Text"))
        {
            string Page_11_Text_jsonData = PlayerPrefs.GetString("Page_11_2_Text");
            GameData_Side_Story_1_2 Page_11_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_11_Text_jsonData);

            Page_Count_11 = Page_11_Text_data.Page_11_Index;

            if (Page_Count_11 > 0)
            {
                foreach (GameObject Page_11_Text in Page_11)
                {
                    Page_11_Text.SetActive(true);
                }

                for (int i = Page_Count_11; i < Page_11.Length; i++)
                {
                    Page_11[i].SetActive(false);//여기도 문제

                    if (Page_Count_11 > Page_11.Length)
                    {
                        Page_Button[6].SetActive(false);
                    }

                    else
                    {
                        Page_Button[6].SetActive(true);
                    }
                }
                if (Page_Count_11 > Page_11.Length)
                {
                    Page_Button[6].SetActive(false);
                }

                else
                {
                    Page_Button[6].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_11_Text in Page_11)
                {
                    Page_11_Text.SetActive(false);
                }

                for (int i = 0; i < Page_11.Length; i++)
                {
                    Page_11[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_11 = Default_Page_Count_11;
        }

    }

    //12
    private void Page_12_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_12_2_Text"))
        {
            string Page_12_Text_jsonData = PlayerPrefs.GetString("Page_12_2_Text");
            GameData_Side_Story_1_2 Page_12_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_12_Text_jsonData);

            Page_Count_12 = Page_12_Text_data.Page_12_Index;

            if (Page_Count_12 > 0)
            {
                foreach (GameObject Page_12_Text in Page_12)
                {
                    Page_12_Text.SetActive(true);
                }

                for (int i = Page_Count_12; i < Page_12.Length; i++)
                {
                    Page_12[i].SetActive(false);//여기도 문제

                    if (Page_Count_12 > Page_12.Length)
                    {
                        Page_Button[7].SetActive(false);
                    }

                    else
                    {
                        Page_Button[7].SetActive(true);
                    }
                }
                if (Page_Count_12 > Page_12.Length)
                {
                    Page_Button[7].SetActive(false);
                }

                else
                {
                    Page_Button[7].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_12_Text in Page_12)
                {
                    Page_12_Text.SetActive(false);
                }

                for (int i = 0; i < Page_12.Length; i++)
                {
                    Page_12[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_12 = Default_Page_Count_12;
        }

    }

    //13
    private void Page_13_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_13_2_Text"))
        {
            string Page_13_Text_jsonData = PlayerPrefs.GetString("Page_13_2_Text");
            GameData_Side_Story_1_2 Page_13_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_13_Text_jsonData);

            Page_Count_13 = Page_13_Text_data.Page_13_Index;

            if (Page_Count_13 > 0)
            {
                foreach (GameObject Page_13_Text in Page_13)
                {
                    Page_13_Text.SetActive(true);
                }

                for (int i = Page_Count_13; i < Page_13.Length; i++)
                {
                    Page_13[i].SetActive(false);//여기도 문제

                    if (Page_Count_13 > Page_13.Length)
                    {
                        Page_Button[8].SetActive(false);
                    }

                    else
                    {
                        Page_Button[8].SetActive(true);
                    }
                }
                if (Page_Count_13 > Page_13.Length)
                {
                    Page_Button[8].SetActive(false);
                }

                else
                {
                    Page_Button[8].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_13_Text in Page_13)
                {
                    Page_13_Text.SetActive(false);
                }

                for (int i = 0; i < Page_13.Length; i++)
                {
                    Page_13[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_13 = Default_Page_Count_13;
        }

    }

    //14
    private void Page_14_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_14_2_Text"))
        {
            string Page_14_Text_jsonData = PlayerPrefs.GetString("Page_14_2_Text");
            GameData_Side_Story_1_2 Page_14_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_14_Text_jsonData);

            Page_Count_14 = Page_14_Text_data.Page_14_Index;

            if (Page_Count_14 > 0)
            {
                foreach (GameObject Page_14_Text in Page_14)
                {
                    Page_14_Text.SetActive(true);
                }

                for (int i = Page_Count_14; i < Page_14.Length; i++)
                {
                    Page_14[i].SetActive(false);//여기도 문제

                    if (Page_Count_14 > Page_14.Length)
                    {
                        Page_Button[9].SetActive(false);
                    }

                    else
                    {
                        Page_Button[9].SetActive(true);
                    }
                }
                if (Page_Count_14 > Page_14.Length)
                {
                    Page_Button[9].SetActive(false);
                }

                else
                {
                    Page_Button[9].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_14_Text in Page_14)
                {
                    Page_14_Text.SetActive(false);
                }

                for (int i = 0; i < Page_14.Length; i++)
                {
                    Page_14[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_14 = Default_Page_Count_14;
        }

    }

    //15
    private void Page_15_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_15_2_Text"))
        {
            string Page_15_Text_jsonData = PlayerPrefs.GetString("Page_15_2_Text");
            GameData_Side_Story_1_2 Page_15_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_15_Text_jsonData);

            Page_Count_15 = Page_15_Text_data.Page_15_Index;

            if (Page_Count_15 > 0)
            {
                foreach (GameObject Page_15_Text in Page_15)
                {
                    Page_15_Text.SetActive(true);
                }

                for (int i = Page_Count_15; i < Page_15.Length; i++)
                {
                    Page_15[i].SetActive(false);//여기도 문제

                    if (Page_Count_15 > Page_15.Length)
                    {
                        Page_Button[10].SetActive(false);
                    }

                    else
                    {
                        Page_Button[10].SetActive(true);
                    }
                }
                if (Page_Count_15 > Page_15.Length)
                {
                    Page_Button[10].SetActive(false);
                }

                else
                {
                    Page_Button[10].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_15_Text in Page_15)
                {
                    Page_15_Text.SetActive(false);
                }

                for (int i = 0; i < Page_15.Length; i++)
                {
                    Page_15[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_15 = Default_Page_Count_15;
        }

    }

    //16
    private void Page_16_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_16_2_Text"))
        {
            string Page_16_Text_jsonData = PlayerPrefs.GetString("Page_16_2_Text");
            GameData_Side_Story_1_2 Page_16_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_16_Text_jsonData);

            Page_Count_16 = Page_16_Text_data.Page_16_Index;

            if (Page_Count_16 > 0)
            {
                foreach (GameObject Page_16_Text in Page_16)
                {
                    Page_16_Text.SetActive(true);
                }

                for (int i = Page_Count_16; i < Page_16.Length; i++)
                {
                    Page_16[i].SetActive(false);//여기도 문제

                    if (Page_Count_16 > Page_16.Length)
                    {
                        Page_Button[11].SetActive(false);
                    }

                    else
                    {
                        Page_Button[11].SetActive(true);
                    }
                }
                if (Page_Count_16 > Page_16.Length)
                {
                    Page_Button[11].SetActive(false);
                }

                else
                {
                    Page_Button[11].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_16_Text in Page_16)
                {
                    Page_16_Text.SetActive(false);
                }

                for (int i = 0; i < Page_16.Length; i++)
                {
                    Page_16[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_16 = Default_Page_Count_16;
        }

    }

    //17
    private void Page_17_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Page_17_2_Text"))
        {
            string Page_17_Text_jsonData = PlayerPrefs.GetString("Page_17_2_Text");
            GameData_Side_Story_1_2 Page_17_Text_data = JsonUtility.FromJson<GameData_Side_Story_1_2>(Page_17_Text_jsonData);

            Page_Count_17 = Page_17_Text_data.Page_17_Index;

            if (Page_Count_17 > 0)
            {
                foreach (GameObject Page_17_Text in Page_17)
                {
                    Page_17_Text.SetActive(true);
                }

                for (int i = Page_Count_17; i < Page_17.Length; i++)
                {
                    Page_17[i].SetActive(false);//여기도 문제

                    if (Page_Count_17 > Page_17.Length)
                    {
                        Page_Button[12].SetActive(false);
                    }

                    else
                    {
                        Page_Button[12].SetActive(true);
                    }
                }
                if (Page_Count_17 > Page_17.Length)
                {
                    Page_Button[12].SetActive(false);
                }

                else
                {
                    Page_Button[12].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_17_Text in Page_17)
                {
                    Page_17_Text.SetActive(false);
                }

                for (int i = 0; i < Page_17.Length; i++)
                {
                    Page_17[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_17 = Default_Page_Count_17;
        }

    }

    /*public void Star()
    {
        Star_B_Count++;

        if (Star_B_Count % 2 == 0)
        {
            Stars[0].SetActive(true);
            Stars[1].SetActive(false);
        }

        else if (Star_B_Count % 2 == 1)
        {
            Stars[0].SetActive(false);
            Stars[1].SetActive(true);
        }
    }*/

    public void Five_Page()
    {
        //길이는 11
        if (Page_Count_5 <= Page_5.Length)
        {

            if (Page_Count_5 == Page_5.Length)
            {
                Page_Count_5 = Page_5.Length + 1;
            }

            else if (Page_Count_5 == 1)
            {
                Page_5[1].SetActive(true);
            }


            else
            {
                Page_5[Page_Count_5].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_5++;
            Debug.Log(Page_Count_5);
            if (Page_Count_5 > Page_5.Length)
            {//11보다 커지면?

                Side_story[4].SetActive(false);
                Page_Button[0].SetActive(false);

                Side_story[5].SetActive(true);
                Page_Button[1].SetActive(true);
               // Debug.Log("아앙Page_Count_5 > Page_5.Length");

                Side_Story_Slider.value = 6;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_6 = 1;
                Page_6[0].SetActive(true);

            }


        }


    }

    public void Six_Page()
    {
        if (Page_Count_6 <= Page_6.Length)
        {

            if (Page_Count_6 == Page_6.Length)
            {
                Page_Count_6 = Page_6.Length + 1;
            }

            else if (Page_Count_6 == 1)
            {
                Page_6[1].SetActive(true);
            }

            else if (Page_Count_6 == 4)
            {
                Page_Button[1].SetActive(false);
                Page_6[4].SetActive(true);
            }


            else
            {
                Page_6[Page_Count_6].SetActive(true);
                Page_Button[1].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_6++;

      
            Debug.Log(Page_Count_6);
            if (Page_Count_6 > Page_6.Length)
            {//11보다 커지면?

                Side_story[5].SetActive(false);
                Page_Button[1].SetActive(false);

                Side_story[6].SetActive(true);
                Page_Button[2].SetActive(true);
               // Debug.Log("아앙Page_Count_6 > Page_6.Length");

                Side_Story_Slider.value = 7;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_7 = 1;
                Page_7[0].SetActive(true);

            }


        }
    }

    //1-2
    public void Six_Page_1_2()
    {
        if (Page_Count_6 <= Page_6.Length)
        {

            if (Page_Count_6 == Page_6.Length)
            {
                Page_Count_6 = Page_6.Length + 1;
            }

            else if (Page_Count_6 == 1)
            {
                Page_6[1].SetActive(true);
            }

            else if (Page_Count_6 == 5)
            {
                Page_Button[1].SetActive(false);
                Page_6[5].SetActive(true);
            }


            else if (Page_Count_6 == 6)
            {
                Page_6[6].SetActive(true);
                Debug.Log(Page_Count_6);
               // Debug.Log("6번째 ");
                Currnet_Page_Count_6 = Page_Count_6;

            }

            else if (Page_Count_6 == 7)
            {
                Page_6[7].SetActive(true);
                Debug.Log(Page_Count_6);
               // Debug.Log("7번째 (이름)휴오쟌 나와야 함");
                Currnet_Page_Count_6 = Page_Count_6;

            }

            else if (Page_Count_6 == 8)
            {
                Page_6[8].SetActive(true);
                Debug.Log(Page_Count_6);
               // Debug.Log("7번째 (이름)휴오쟌 나와야 함");
                Currnet_Page_Count_6 = Page_Count_6;

            }

            else
            {
                Page_6[Page_Count_6].SetActive(true);
                Page_Button[1].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_6++;
            /*else if (Page_Count_6 == 6)
            {
                Page_6[6].SetActive(true);
                Debug.Log(Page_Count_6);
                Debug.Log("6번째 ");
                Currnet_Page_Count_6 = Page_Count_6;

            }

            else if (Page_Count_6 == 7)
            {
                Page_6[7].SetActive(true);
                Debug.Log(Page_Count_6);
                Debug.Log("7번째 (이름)휴오쟌 나와야 함");
                Currnet_Page_Count_6 = Page_Count_6;

            }

            else if (Page_Count_6 == 8)
            {
                Page_6[8].SetActive(true);
                Debug.Log(Page_Count_6);
                Debug.Log("7번째 (이름)휴오쟌 나와야 함");
                Currnet_Page_Count_6 = Page_Count_6;

            }*/

            Debug.Log(Page_Count_6);
            if (Page_Count_6 > Page_6.Length)
            {//11보다 커지면?

                Side_story[5].SetActive(false);
                Page_Button[1].SetActive(false);

                Side_story[6].SetActive(true);
                Page_Button[2].SetActive(true);
               // Debug.Log("Page_Count_6 > Page_6.Length");

                Side_Story_Slider.value = 7;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_7 = 1;
                Page_7[0].SetActive(true);

            }


        }
    }

    public void Seven_Page()
    {
        if (Page_Count_7 <= Page_7.Length)
        {

            if (Page_Count_7 == Page_7.Length)
            {
                Page_Count_7 = Page_7.Length + 1;
            }

            else if (Page_Count_7 == 1)
            {
                Page_7[1].SetActive(true);
            }


            else
            {
                Page_7[Page_Count_7].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_7++;
            Debug.Log(Page_Count_7);
            if (Page_Count_7 > Page_7.Length)
            {//11보다 커지면?

                Side_story[6].SetActive(false);
                Page_Button[2].SetActive(false);

                Side_story[7].SetActive(true);
                Page_Button[3].SetActive(true);
               // Debug.Log("아앙Page_Count_7 > Page_7.Length");

                Side_Story_Slider.value = 8;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_8 = 1;
                Page_8[0].SetActive(true);
                //return;

            }


        }
    }

    //4
    public void Eight_Page()
    {
        if (Page_Count_8 <= Page_8.Length)
        {

            if (Page_Count_8 == Page_8.Length)
            {
                Page_Count_8 = Page_8.Length + 1;
            }

            else if (Page_Count_8 == 1)
            {
                Page_8[1].SetActive(true);
            }


            else
            {
                Page_8[Page_Count_8].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_8++;
            Debug.Log(Page_Count_8);
            if (Page_Count_8 > Page_8.Length)
            {//11보다 커지면?

                Side_story[7].SetActive(false);
                Page_Button[3].SetActive(false);

                Side_story[8].SetActive(true);
                Page_Button[4].SetActive(true);
              //  Debug.Log("아앙Page_Count_8 > Page_8.Length");

                Side_Story_Slider.value = 9;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_9 = 1;
                Page_9[0].SetActive(true);

            }


        }
    }

    //5
    public void Nine_Page()
    {


        if (Page_Count_9 <= Page_9.Length)
        {

            if (Page_Count_9 == Page_9.Length)
            {
                Page_Count_9 = Page_9.Length + 1;
            }

            else if (Page_Count_9 == 1)
            {
                Page_9[1].SetActive(true);
            }


            else
            {
                Page_9[Page_Count_9].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_9++;
            Debug.Log(Page_Count_9);
            if (Page_Count_9 > Page_9.Length)
            {//11보다 커지면?

                Side_story[8].SetActive(false);
                Page_Button[4].SetActive(false);

                Side_story[9].SetActive(true);
                Page_Button[5].SetActive(true);

                //Debug.Log("아앙Page_Count_9 > Page_9.Length");



                Side_Story_Slider.value = 10;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_10 = 1;
                Page_10[0].SetActive(true);

            }


        }
    }

    //6
    public void Ten_Page()
    {
        if (Page_Count_10 <= Page_10.Length)
        {

            if (Page_Count_10 == Page_10.Length)
            {
                Page_Count_10 = Page_10.Length + 1;
            }

            else if (Page_Count_10 == 1)
            {
                Page_10[1].SetActive(true);
            }

            else if (Page_Count_10 == 3)
            {
                Page_10[3].SetActive(true);
                Ten_Page_Background[0].SetActive(false);
                Ten_Page_Background[1].SetActive(true);
            }

            else
            {
                Page_10[Page_Count_10].SetActive(true);
                //Debug.Log("되나?");


            }

            Page_Count_10++;
            Debug.Log(Page_Count_10);
            if (Page_Count_10 > Page_10.Length)
            {//11보다 커지면?

                Side_story[9].SetActive(false);
                Page_Button[5].SetActive(false);

                Side_story[10].SetActive(true);
                Page_Button[6].SetActive(true);
                //Debug.Log("아앙Page_Count_10 > Page_10.Length");

                Side_Story_Slider.value = 11;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_11 = 1;
                Page_11[0].SetActive(true);

            }


        }
    }

    //11
    public void Eleven_Page()
    {
        if (Page_Count_11 <= Page_11.Length)
        {

            if (Page_Count_11 == Page_11.Length)
            {
                Page_Count_11 = Page_11.Length + 1;
            }

            else if (Page_Count_11 == 1)
            {
                Page_11[1].SetActive(true);
            }


            else
            {
                Page_11[Page_Count_11].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_11++;
            Debug.Log(Page_Count_11);
            if (Page_Count_11 > Page_11.Length)
            {//11보다 커지면?

                Side_story[10].SetActive(false);
                Page_Button[6].SetActive(false);

                Side_story[11].SetActive(true);
                Page_Button[7].SetActive(true);
                //Debug.Log("아앙Page_Count_11 > Page_11.Length");



                Side_Story_Slider.value = 12;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_12 = 1;
                Page_12[0].SetActive(true);

            }


        }
    }

    //12
    public void Twelve_Page()
    {
        if (Page_Count_12 <= Page_12.Length)
        {

            if (Page_Count_12 == Page_12.Length)
            {
                Page_Count_12 = Page_12.Length + 1;
            }

            else if (Page_Count_12 == 1)
            {
                Page_12[1].SetActive(true);
            }

            else if (Page_Count_12 == 3)
            {
                Page_12[3].SetActive(true);
                Twelve_Page_Background[0].SetActive(false);
                Twelve_Page_Background[1].SetActive(true);
            }

            else
            {
                Page_12[Page_Count_12].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_12++;
            Debug.Log(Page_Count_12);
            if (Page_Count_12 > Page_12.Length)
            {//11보다 커지면?

                Side_story[11].SetActive(false);
                Page_Button[7].SetActive(false);

                Side_story[12].SetActive(true);
                Page_Button[8].SetActive(true);
               // Debug.Log("아앙Page_Count_11 > Page_11.Length");


                Side_Story_Slider.value = 13;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_13 = 1;
                Page_13[0].SetActive(true);

            }


        }
    }

    //13
    public void Thirteen_Page()
    {
        if (Page_Count_13 <= Page_13.Length)
        {

            if (Page_Count_13 == Page_13.Length)
            {
                Page_Count_13 = Page_13.Length + 1;
            }

            else if (Page_Count_13 == 1)
            {
                Page_13[1].SetActive(true);
            }


            else
            {
                Page_13[Page_Count_13].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_13++;
            Debug.Log(Page_Count_13);
            if (Page_Count_13 > Page_13.Length)
            {//11보다 커지면?

                Side_story[12].SetActive(false);
                Page_Button[8].SetActive(false);

                Side_story[13].SetActive(true);
                Page_Button[9].SetActive(true);
               // Debug.Log("아앙Page_Count_13 > Page_13.Length");



                Side_Story_Slider.value = 14;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_14 = 1;
                Page_14[0].SetActive(true);

            }


        }
    }

    //14
    public void Fourteen_Page()
    {
        if (Page_Count_14 <= Page_14.Length)
        {

            if (Page_Count_14 == Page_14.Length)
            {
                Page_Count_14 = Page_14.Length + 1;
            }

            else if (Page_Count_14 == 1)
            {
                Page_14[1].SetActive(true);
            }


            else
            {
                Page_14[Page_Count_14].SetActive(true);
               // Debug.Log("되나?");
            }

            Page_Count_14++;
            Debug.Log(Page_Count_14);
            if (Page_Count_14 > Page_14.Length)
            {//11보다 커지면?

                Side_story[13].SetActive(false);
                Page_Button[9].SetActive(false);

                Side_story[14].SetActive(true);
                Page_Button[10].SetActive(true);
                //Debug.Log("아앙Page_Count_14 > Page_14.Length");



                Side_Story_Slider.value = 15;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_15 = 1;
                Page_15[0].SetActive(true);

            }


        }
    }

    //15
    public void Fifteen_Page()
    {
        if (Page_Count_15 <= Page_15.Length)
        {

            if (Page_Count_15 == Page_15.Length)
            {
                Page_Count_15 = Page_15.Length + 1;
            }

            else if (Page_Count_15 == 1)
            {
                Page_15[1].SetActive(true);
            }


            else
            {
                Page_15[Page_Count_15].SetActive(true);
              //  Debug.Log("되나?");
            }

            Page_Count_15++;
            Debug.Log(Page_Count_15);
            if (Page_Count_15 > Page_15.Length)
            {//11보다 커지면?

                Side_story[14].SetActive(false);
                Page_Button[10].SetActive(false);

                Side_story[15].SetActive(true);
                Page_Button[11].SetActive(true);
               // Debug.Log("아앙Page_Count_15 > Page_15.Length");



                Side_Story_Slider.value = 16;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_16 = 1;
                Page_16[0].SetActive(true);

            }


        }
    }

    //16
    public void Run()
    {
        Page_16[3].SetActive(false);
        

        Sixteen_Page();
        Page_Button[11].SetActive(true);
    }


    public void Sixteen_Page()
    {
        if (Page_Count_16 <= Page_16.Length)
        {

            if (Page_Count_16 == Page_16.Length)
            {
                Page_Count_16 = Page_16.Length + 1;
            }

            else if (Page_Count_16 == 1)
            {
                Page_16[1].SetActive(true);
            }

            /*else if (Page_Count_16 == 3)
            {
                Page_16[3].SetActive(true);
                Page_Button[11].SetActive(false);
            }*/


            else
            {
                Page_16[Page_Count_16].SetActive(true);
              //  Debug.Log("되나?");
            }

            Page_Count_16++;
            Debug.Log(Page_Count_16);
            if (Page_Count_16 > Page_16.Length)
            {//11보다 커지면?

                Side_story[15].SetActive(false);
                Page_Button[11].SetActive(false);

                Side_story[16].SetActive(true);
                Page_Button[12].SetActive(true);
              //  Debug.Log("Page_Count_16-1 > Page_16-1.Length");

                //return;

                Side_Story_Slider.value = 17;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_17 = 1;
                Page_17[0].SetActive(true);

            }


        }
    }

    //17
    public void Seventeen_Page()
    {
        if (Page_Count_17 <= Page_17.Length)
        {

            if (Page_Count_17 == Page_17.Length)
            {
                Page_Count_17 = Page_17.Length + 1;
            }

            else if (Page_Count_17 == 1)
            {
                Page_17[1].SetActive(true);
            }

            else if (Page_Count_17 == 3)
            {
                Page_17[3].SetActive(true);
                //벨 소리
                sfx.Bell_Sound();
            }

            else
            {
                Page_17[Page_Count_17].SetActive(true);
             //   Debug.Log("되나?");
            }

            Page_Count_17++;
            Debug.Log(Page_Count_17);
            if (Page_Count_17 > Page_17.Length)
            {//11보다 커지면?

                //Side_story[16].SetActive(false);
                Page_Button[12].SetActive(false);

                //Side_story[15].SetActive(true);
                //Page_Button[11].SetActive(true);
              //  Debug.Log("아앙Page_Count_17 > Page_17.Length");



                //Side_Story_Slider.value = 16;

                // Current_Story_Page = (int)Side_Story_Slider.value;
                //Left_Page.text = Current_Story_Page.ToString();

                // Page_Count_16 = 1;
                //Page_16[0].SetActive(true);

            }


        }
    }



}

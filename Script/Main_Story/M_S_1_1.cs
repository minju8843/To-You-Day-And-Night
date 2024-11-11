using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Main_Story_1_1_R
{//사용자 설정 데이터를 저장하는 클래스
    public int First_Main_Story;//현재 몇 번째 스토리가 활성화되어 있는지 1, 1-1, 1-2
    public int First_Page_1_1_What_Page;//첫 번째 이야기의 몇 번째 페이지에서 저장했는지

    public int Page_10_Index;
    public int Page_11_Index;
    public int Page_12_Index;
    public int Page_13_Index;
    public int Page_14_Index;
    public int Page_15_Index;
    public int Page_16_Index;
    public int Page_17_Index;
    public int Page_18_Index;
    public int Page_19_Index;
    public int Page_20_Index;
    public int Page_21_Index;
    public int Page_22_Index;
    public int Page_23_Index;
    public int Page_24_Index;
    public int Page_25_Index;
    public int Page_26_Index;
    public int Page_27_Index;
    public int Page_28_Index;
    public int Page_29_Index;

}

public class M_S_1_1 : MonoBehaviour
{
    public SFX_Manager sfx;
    public BGM_Manager bgm;

    //배경
    public GameObject[] Page19_BG;
    public GameObject[] Page21_BG;
    public GameObject[] Page24_BG;
    public GameObject[] Page25_BG;

    //편지함
    public Letter letter;

    public Main_Stroy_1 mainstory;
    //앨볌 해금
    public Album album;
    public M_S_1_2 m_s_1_2;

    public int First_Main_Story_Object_Index;
    public int Default_First_Side_Story_Object_Index;


    //public GameObject[] Ten_Page_Background;
    //public GameObject[] Twelve_Page_Background;


    //5번째 페이지의 2번째부터 나타나는 걸로

    //public GameObject First_1_1_Story_Object;// 쓸거임

    //public Side_Story side_story;


    public Slider Main_Story_Slider;
    public int Default_Story_Page = 10;//기본 볼륨 값
    public int Reset_Story_Page = 10;
    public int Current_Story_Page = 10;//현재 볼륨이 얼마인지 알려주기 위함

    public Text Left_Page;


    public GameObject[] Main_story;//페이지별로 넣어둘 거

    public GameObject[] Page_10;//첫 번째 페이지에 나타날 Ui들 넣을 곳
    public GameObject[] Page_11;
    public GameObject[] Page_12;
    public GameObject[] Page_13;
    public GameObject[] Page_14;
    public GameObject[] Page_15;
    public GameObject[] Page_16;
    public GameObject[] Page_17;
    public GameObject[] Page_18;
    public GameObject[] Page_19;
    public GameObject[] Page_20;
    public GameObject[] Page_21;
    public GameObject[] Page_22;
    public GameObject[] Page_23;
    public GameObject[] Page_24;
    public GameObject[] Page_25;
    public GameObject[] Page_26;
    public GameObject[] Page_27;
    public GameObject[] Page_28;
    public GameObject[] Page_29;

    public GameObject[] Page_Button;

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

    public int Default_Page_Count_18 = 0;
    public int Page_Count_18;
    public int Currnet_Page_Count_18;

    public int Default_Page_Count_19 = 0;
    public int Page_Count_19;
    public int Currnet_Page_Count_19;

    public int Default_Page_Count_20 = 0;
    public int Page_Count_20;
    public int Currnet_Page_Count_20;

    public int Default_Page_Count_21 = 0;
    public int Page_Count_21;
    public int Currnet_Page_Count_21;

    public int Default_Page_Count_22 = 0;
    public int Page_Count_22;
    public int Currnet_Page_Count_22;

    public int Default_Page_Count_23 = 0;
    public int Page_Count_23;
    public int Currnet_Page_Count_23;

    public int Default_Page_Count_24 = 0;
    public int Page_Count_24;
    public int Currnet_Page_Count_24;

    public int Default_Page_Count_25 = 0;
    public int Page_Count_25;
    public int Currnet_Page_Count_25;

    public int Default_Page_Count_26 = 0;
    public int Page_Count_26;
    public int Currnet_Page_Count_26;

    public int Default_Page_Count_27 = 0;
    public int Page_Count_27;
    public int Currnet_Page_Count_27;

    public int Default_Page_Count_28 = 0;
    public int Page_Count_28;
    public int Currnet_Page_Count_28;

    public int Default_Page_Count_29 = 0;
    public int Page_Count_29;
    public int Currnet_Page_Count_29;


    //public int Star_B_Count = 0;

    public Animator Main_Story_1_R_L;


    public void OnEnable()
    {
        Page_10_Text_LoadSettings();
        Main_Story_1_1What_Page_LoadSettings();

        Page_11_Text_LoadSettings();
        Page_12_Text_LoadSettings();
        Page_13_Text_LoadSettings();
        Page_14_Text_LoadSettings();
        Page_15_Text_LoadSettings();
        Page_16_Text_LoadSettings();
        Page_17_Text_LoadSettings();
        Page_18_Text_LoadSettings();
        Page_19_Text_LoadSettings();
        Page_20_Text_LoadSettings();
        Page_21_Text_LoadSettings();
        Page_22_Text_LoadSettings();
        Page_23_Text_LoadSettings();
        Page_24_Text_LoadSettings();
        Page_25_Text_LoadSettings();
        Page_26_Text_LoadSettings();
        Page_27_Text_LoadSettings();
        Page_28_Text_LoadSettings();
        Page_29_Text_LoadSettings();

    }

    private void Start()
    {

      
    }

    public void Update()
    {
        //배경
        if (Page_19[3].activeSelf == true)
        {
            Page19_BG[0].SetActive(false);
            Page19_BG[1].SetActive(true);
        }

        if (Page_19[3].activeSelf == false)
        {
            Page19_BG[0].SetActive(true);
            Page19_BG[1].SetActive(false);
        }

        //21페이지 배경
        if (Page_21[2].activeSelf == false)
        {
            Page21_BG[0].SetActive(true);
            Page21_BG[1].SetActive(false);
            Page21_BG[2].SetActive(false);
        }

        if (Page_21[2].activeSelf == true)
        {
            Page21_BG[0].SetActive(false);
            Page21_BG[1].SetActive(true);
            Page21_BG[2].SetActive(false);
        }

        if (Page_21[7].activeSelf == true)
        {
            Page21_BG[0].SetActive(false);
            Page21_BG[1].SetActive(false);
            Page21_BG[2].SetActive(true);
        }

        //24페이지 배경
        if (Page_24[2].activeSelf == false)
        {
            Page24_BG[0].SetActive(false);
            Page24_BG[1].SetActive(true);
        }

        if (Page_24[2].activeSelf == true)
        {
            Page24_BG[0].SetActive(true);
            Page24_BG[1].SetActive(false);
        }

        //25페이지 배경
        if (Page_25[6].activeSelf == false)
        {
            Page25_BG[0].SetActive(true);
            Page25_BG[1].SetActive(false);
        }

        if (Page_25[6].activeSelf == true)
        {
            Page25_BG[0].SetActive(false);
            Page25_BG[1].SetActive(true);
        }


        if (Page_13[5].activeSelf == true || m_s_1_2.Page_13[5].activeSelf == true)
        {
            album.Album_2[0].SetActive(false);
            album.Album_2[1].SetActive(true);
        }

        if (Page_13[5].activeSelf == false && m_s_1_2.Page_13[5].activeSelf == false)
        {
            album.Album_2[0].SetActive(true);
            album.Album_2[1].SetActive(false);
        }

        //3번 앨범
        if (Page_20[0].activeSelf == true || m_s_1_2.Page_20[0].activeSelf == true)
        {
            album.Album_3[0].SetActive(false);
            album.Album_3[1].SetActive(true);
        }

        if (Page_20[0].activeSelf == false && m_s_1_2.Page_20[0].activeSelf == false)
        {
            //19페이지까지 다 보지 못했을 때
            album.Album_3[0].SetActive(true);
            album.Album_3[1].SetActive(false);
        }

        //편지2번째
        if (Page_22[4].activeSelf == true || m_s_1_2.Page_22[4].activeSelf == true)
        {
            letter.Two_Letter.SetActive(true);
        }

        if (Page_22[4].activeSelf == false && m_s_1_2.Page_22[4].activeSelf == false)
        {
            letter.Two_Letter.SetActive(false);
        }


        //9, 10

        if (Page_Count_10 >= Page_10.Length && Page_11[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[9].activeSelf == true || Main_story[10].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false )
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[1].SetActive(true);

            Debug.Log("나와라라라");

        }

        //10, 11
        if (Page_Count_11 >= Page_11.Length && Page_12[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[10].activeSelf == true || Main_story[11].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[2].SetActive(true);

        }

        //11, 12
        if (Page_Count_12 >= Page_12.Length && Page_13[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[11].activeSelf == true || Main_story[12].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[3].SetActive(true);

        }

        //12, 13
        if (Page_Count_13 >= Page_13.Length && Page_14[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[12].activeSelf == true || Main_story[13].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[10].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[4].SetActive(true);

        }

        //13, 14
        if (Page_Count_14 >= Page_14.Length && Page_15[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[13].activeSelf == true || Main_story[14].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[5].SetActive(true);

        }

        //14, 15
        if (Page_Count_15 >= Page_15.Length && Page_16[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[14].activeSelf == true || Main_story[15].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[6].SetActive(true);

        }

        //15, 16
        if (Page_Count_16 >= Page_16.Length && Page_17[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[15].activeSelf == true || Main_story[16].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[10].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[7].SetActive(true);

        }

        //16, 17
        if (Page_Count_17 >= Page_17.Length && Page_18[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[16].activeSelf == true || Main_story[17].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[8].SetActive(true);

        }

        //17, 18
        if (Page_Count_18 >= Page_18.Length && Page_19[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[17].activeSelf == true || Main_story[18].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[9].SetActive(true);

        }

        //18, 19
        if (Page_Count_19 >= Page_19.Length && Page_20[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[18].activeSelf == true || Main_story[19].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[10].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[10].SetActive(true);

        }

        //19, 20
        if (Page_Count_20 >= Page_20.Length && Page_21[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[19].activeSelf == true || Main_story[20].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[11].SetActive(true);

        }

        //20, 21
        if (Page_Count_21 >= Page_21.Length && Page_22[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[20].activeSelf == true || Main_story[21].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[12].SetActive(true);

        }

        //21, 22
        if (Page_Count_22 >= Page_22.Length && Page_23[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[21].activeSelf == true || Main_story[22].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[10].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[13].SetActive(true);

        }

        //22, 23
        if (Page_Count_23 >= Page_23.Length && Page_24[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[22].activeSelf == true || Main_story[23].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[14].SetActive(true);

        }

        //23, 24
        if (Page_Count_24 >= Page_24.Length && Page_25[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[23].activeSelf == true || Main_story[24].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[15].SetActive(true);

        }

        //24, 25
        if (Page_Count_25 >= Page_25.Length && Page_26[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[24].activeSelf == true || Main_story[25].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[10].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[16].SetActive(true);

        }

        //25, 26
        if (Page_Count_26 >= Page_26.Length && Page_27[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[25].activeSelf == true || Main_story[26].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[10].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[17].SetActive(true);

        }

        //26, 27
        if (Page_Count_27 >= Page_27.Length && Page_28[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[26].activeSelf == true || Main_story[27].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[10].activeSelf == false && Main_story[28].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[18].SetActive(true);

        }

        //27, 28
        if (Page_Count_28 >= Page_28.Length && Page_29[0].activeSelf == false &&//뒤에 있는 숫자가 앞에, 그 다음은 그 뒤에 있는 숫자 +1
            (Main_story[27].activeSelf == true || Main_story[28].activeSelf == true)

            //뒤에 있는 숫자 삭제
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
            && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
            && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false
            && Main_story[9].activeSelf == false && Main_story[11].activeSelf == false
            && Main_story[12].activeSelf == false && Main_story[13].activeSelf == false && Main_story[14].activeSelf == false
            && Main_story[15].activeSelf == false && Main_story[16].activeSelf == false && Main_story[17].activeSelf == false
            && Main_story[18].activeSelf == false && Main_story[19].activeSelf == false && Main_story[20].activeSelf == false
            && Main_story[21].activeSelf == false && Main_story[22].activeSelf == false && Main_story[23].activeSelf == false
            && Main_story[24].activeSelf == false && Main_story[25].activeSelf == false && Main_story[26].activeSelf == false
            && Main_story[27].activeSelf == false && Main_story[10].activeSelf == false)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[19].SetActive(true);

        }

        //새로 추가0716
        /*if (Page_Count_10 < Page_10.Length && Page_11[0].activeSelf == false && Main_story[9].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[0].SetActive(true);
        }*/

        //새로 추가0716
        /*if (Page_Count_10 >= Page_10.Length && Page_11[0].activeSelf == false && Main_story[10].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_11 >= Page_11.Length && Page_12[0].activeSelf == false && Main_story[11].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[1].SetActive(false);
            Page_Button[2].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_12 >= Page_12.Length && Page_13[0].activeSelf == false && Main_story[12].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[2].SetActive(false);
            Page_Button[3].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_13 >= Page_13.Length && Page_14[0].activeSelf == false && Main_story[13].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[11].SetActive(false);
            Page_Button[12].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_14 >= Page_14.Length && Page_15[0].activeSelf == false && Main_story[14].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[12].SetActive(false);
            Page_Button[13].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_15 >= Page_15.Length && Page_16[0].activeSelf == false && Main_story[15].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[13].SetActive(false);
            Page_Button[14].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_16 >= Page_16.Length && Page_17[0].activeSelf == false && Main_story[16].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[14].SetActive(false);
            Page_Button[15].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_17 >= Page_17.Length && Page_18[0].activeSelf == false && Main_story[17].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[15].SetActive(false);
            Page_Button[16].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_18 >= Page_18.Length && Page_19[0].activeSelf == false && Main_story[18].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_19 >= Page_19.Length && Page_20[0].activeSelf == false && Main_story[19].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_20 >= Page_20.Length && Page_21[0].activeSelf == false && Main_story[20].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_21 >= Page_21.Length && Page_22[0].activeSelf == false && Main_story[21].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_22 >= Page_22.Length && Page_23[0].activeSelf == false && Main_story[22].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_23 >= Page_23.Length && Page_24[0].activeSelf == false && Main_story[23].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_24 >= Page_24.Length && Page_25[0].activeSelf == false && Main_story[24].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_25 >= Page_25.Length && Page_26[0].activeSelf == false && Main_story[25].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_26 >= Page_26.Length && Page_27[0].activeSelf == false && Main_story[26].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_27 >= Page_27.Length && Page_28[0].activeSelf == false && Main_story[27].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[16].SetActive(false);
            Page_Button[17].SetActive(true);
        }

        //새로 추가0716
        if (Page_Count_28 >= Page_28.Length && Page_29[0].activeSelf == false && Main_story[28].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[18].SetActive(false);
            Page_Button[19].SetActive(true);
        }


        //새로 추가0716
        if (Page_Count_29 >= Page_29.Length && Main_story[28].activeSelf == true)
        {
            //두 번째 페이지에서 모든 글씨가 다 나왔다면
            //세 번째 버튼 활성화 (세 번째 페이지의 글씨가 하나도 나오지 않았다면)
            //두 번째 페이지 버튼 비활성화
            Page_Button[19].SetActive(false);

        }*/

        //버튼 오류로 일단 만들어봄
        if (Page_Count_10 < Page_10.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 1; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_11 < Page_11.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 2; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_12 < Page_12.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 3; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_13 < Page_13.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 4; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_14 < Page_14.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 5; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_15 < Page_15.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 6; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_16 < Page_16.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 7; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_17 < Page_17.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 8; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_18 < Page_18.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 9; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_19 < Page_19.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 10; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_20 < Page_20.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 11; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_21 < Page_21.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 12; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_22 < Page_22.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 13; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_23 < Page_23.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 14; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_24 < Page_24.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 15; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_25 < Page_25.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 16; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_26 < Page_26.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 17; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_27 < Page_27.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 18; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_28 < Page_28.Length)// <=
        {
            //나머지 버튼 다 비활성
            for (int i = 19; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

     

        //여기까지 버튼 오류로 인해 만든 코드



        /*if (Page_Count_10 == 3)
        {
            Ten_Page_Background[0].SetActive(false);
            Ten_Page_Background[1].SetActive(true);
        }*/

        /*if (Page_Count_10 <= 3)
        {
            Ten_Page_Background[0].SetActive(true);
            Ten_Page_Background[1].SetActive(false);
        }

        if (Page_Count_10 > 3)
        {
            Ten_Page_Background[0].SetActive(false);
            Ten_Page_Background[1].SetActive(true);
        }*/

        /*if (Page_Count_12 == 3)
        {
            Twelve_Page_Background[0].SetActive(false);
            Twelve_Page_Background[1].SetActive(true);
        }*/

        /*if (Page_Count_12 > 3)
        {
            Twelve_Page_Background[0].SetActive(false);
            Twelve_Page_Background[1].SetActive(true);
        }

        if (Page_Count_12 <= 3)
        {
            Twelve_Page_Background[0].SetActive(true);
            Twelve_Page_Background[1].SetActive(false);
        }*/




        Current_Story_Page = (int)Main_Story_Slider.value;
        Left_Page.text = Current_Story_Page.ToString();



        foreach (GameObject Story_Page in Main_story)
        {
            Story_Page.SetActive(false);
        }

        Main_story[Current_Story_Page - 1].SetActive(true);

        Main_Story_1_1_SaveSettings();

        Currnet_Page_Count_10 = Page_Count_10;
        Currnet_Page_Count_11 = Page_Count_11;
        Currnet_Page_Count_12 = Page_Count_12;
        Currnet_Page_Count_13 = Page_Count_13;
        Currnet_Page_Count_14 = Page_Count_14;
        Currnet_Page_Count_15 = Page_Count_15;
        Currnet_Page_Count_16 = Page_Count_16;
        Currnet_Page_Count_17 = Page_Count_17;
        Currnet_Page_Count_18 = Page_Count_18;
        Currnet_Page_Count_19 = Page_Count_19;
        Currnet_Page_Count_20 = Page_Count_20;
        Currnet_Page_Count_21 = Page_Count_21;
        Currnet_Page_Count_22 = Page_Count_22;
        Currnet_Page_Count_23 = Page_Count_23;
        Currnet_Page_Count_24 = Page_Count_24;
        Currnet_Page_Count_25 = Page_Count_25;
        Currnet_Page_Count_26 = Page_Count_26;
        Currnet_Page_Count_27 = Page_Count_27;
        Currnet_Page_Count_28 = Page_Count_28;
        Currnet_Page_Count_29 = Page_Count_29;

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

        else if ((Page_Button[0].activeSelf == true || Page_Button[1].activeSelf == true || Page_Button[2].activeSelf == true
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

            //12
            for (int i = 0; i < Page_Button.Length-2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);


            Page_Button[11].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            for (int i = 0; i < Page_Button.Length - 2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);


            Page_16[3].SetActive(true);


        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && Currnet_Page_Count_16 == 4 && side_story.First_Side_Story_Object[1].activeSelf == true)
        {
            for (int i = 0; i < Page_Button.Length - 2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);


            Page_16[3].SetActive(true);
        }

        //1-2
        if ((Current_Story_Page < 16 || Current_Story_Page > 16) && Page_Button[11].activeSelf == false && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            //Page_Button[11].SetActive(false);
            
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Button[0].activeSelf == true || Page_Button[2].activeSelf == true || Page_Button[2].activeSelf == true
            || Page_Button[3].activeSelf == true || Page_Button[4].activeSelf == true || Page_Button[5].activeSelf == true
            || Page_Button[6].activeSelf == true || Page_Button[7].activeSelf == true || Page_Button[8].activeSelf == true
            || Page_Button[9].activeSelf == true || Page_Button[10].activeSelf == true) && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            Page_16[3].SetActive(false);
            //Page_Button[11].SetActive(false);
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        else if (Current_Story_Page == 16 && Page_16[2].activeSelf == true && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            //Page_5[1].SetActive(true);

            //12 
            for (int i = 0; i < Page_Button.Length - 2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);

            Page_Button[11].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            for (int i = 0; i < Page_Button.Length - 2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);

            //기존
            Page_16[3].SetActive(true);
        }

        else if (Current_Story_Page == 16 && Page_Button[11].activeSelf == true && Currnet_Page_Count_16 == 4 && side_story.First_Side_Story_Object[2].activeSelf == true)
        {
            for (int i = 0; i < Page_Button.Length - 2; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[12].SetActive(false);

            //기존
            Page_16[3].SetActive(true);
        }*/
    }

    private void FixedUpdate()
    {
        //13개

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17번 다 봤으면
        /*if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length)
            && (Page_Count_25 > Page_25.Length) && (Page_Count_26 > Page_26.Length)
            && (Page_Count_27 > Page_27.Length) && (Page_Count_28 > Page_28.Length)
            && (Page_Count_29 > Page_29.Length))
        {//5페이지 이후
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length)
            && (Page_Count_25 > Page_25.Length) && (Page_Count_26 > Page_26.Length)
            && (Page_Count_27 > Page_27.Length) && (Page_Count_28 > Page_28.Length))
        {//5페이지 이후
            for (int i = 0; i < Page_Button.Length-1; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length)
            && (Page_Count_25 > Page_25.Length) && (Page_Count_26 > Page_26.Length)
            && (Page_Count_27 > Page_27.Length))
        {//5페이지 이후
            for (int i = 0; i < 18; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 19; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length)
            && (Page_Count_25 > Page_25.Length) && (Page_Count_26 > Page_26.Length))
        {//5페이지 이후
            for (int i = 0; i < 17; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 18; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length)
            && (Page_Count_25 > Page_25.Length))
        {//5페이지 이후
            for (int i = 0; i < 16; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 17; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length) && (Page_Count_24 > Page_24.Length))
        {//5페이지 이후
            for (int i = 0; i < 15; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 16; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length)
            && (Page_Count_23 > Page_23.Length))
        {//5페이지 이후
            for (int i = 0; i < 14; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 15; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length) && (Page_Count_22 > Page_22.Length))
        {//5페이지 이후
            for (int i = 0; i < 13; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 14; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16번 다 봤으면
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length)
            && (Page_Count_21 > Page_21.Length))
        {//5페이지 이후
            for (int i = 0; i < 12; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 13; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }


        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15번 다 봤으면
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length) && (Page_Count_20 > Page_20.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length) && (Page_Count_19 > Page_19.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length)
            && (Page_Count_18 > Page_18.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length) && (Page_Count_17 > Page_17.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length) && (Page_Count_16 > Page_16.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length)
            && (Page_Count_15 > Page_15.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length) && (Page_Count_14 > Page_14.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length) && (Page_Count_13 > Page_13.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length)
            && (Page_Count_12 > Page_12.Length))
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
        else if ((Page_Count_10 > Page_10.Length) && (Page_Count_11 > Page_11.Length))
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
        else if ((Page_Count_10 > Page_10.Length))
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

    private void Main_Story_1_1What_Page_LoadSettings()
    {
        //여기부터는 첫 번째 이야기의 몇 번째 페이지에서 저장했는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_What_Page"))
        {
            string What_Page_First_Page_jsonData_1 = PlayerPrefs.GetString("Main_Story_1_1_What_Page");
            GameData_Main_Story_1_1_R What_Page_First_Page_data_1 = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(What_Page_First_Page_jsonData_1);


            Main_Story_Slider.value = What_Page_First_Page_data_1.First_Page_1_1_What_Page;
            Current_Story_Page = (int)Main_Story_Slider.value;


            Debug.Log("현재 불러온 스토리 페이지는? :" + Current_Story_Page);

        }

        else
        {
            Main_Story_Slider.value = Reset_Story_Page;

            Current_Story_Page = (int)Main_Story_Slider.value;

            Main_story[4].SetActive(true);

            for (int i = 5; i < Main_story.Length; i++)
            {
                Main_story[i].SetActive(false);
            }

            for (int i = 0; i < 4; i++)
            {
                Main_story[i].SetActive(false);
            }
        }
    }

    private void Main_Story_1_1_SaveSettings()//일단 첫 번째 사이드 스토리의 몇 번째인지(1, 1-1, 1-2중)
    {
        //여기부터는 지금 1, 1-1, 1-2 중에서 뭐인지 저장한 코드
        GameData_Main_Story_1_1_R data = new GameData_Main_Story_1_1_R();
        data.First_Main_Story = First_Main_Story_Object_Index;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Main_Story_1_1", jsonData);
        PlayerPrefs.Save();


        //여기부터는 첫 번째 이야기의 몇 번째 페이지에서 저장했는지
        GameData_Main_Story_1_1_R What_Page_First_Page_data_1 = new GameData_Main_Story_1_1_R();
        What_Page_First_Page_data_1.First_Page_1_1_What_Page = (int)Main_Story_Slider.value;

        string What_Page_First_Page_jsonData_1 = JsonUtility.ToJson(What_Page_First_Page_data_1);
        PlayerPrefs.SetString("Main_Story_1_1_What_Page", What_Page_First_Page_jsonData_1);
        PlayerPrefs.Save();

        //Debug.Log("현재 저장한 스토리 페이지는? :" + What_Page_First_Page_jsonData_1);

        //여기부터는 첫 번째 이야기의 몇 번째 텍스트가 나왔는지

        //10번 페이지
        GameData_Main_Story_1_1_R Page_10_Text_data = new GameData_Main_Story_1_1_R();
        Page_10_Text_data.Page_10_Index = Page_Count_10;

        string Page_10_Text_jsonData = JsonUtility.ToJson(Page_10_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_10_Text", Page_10_Text_jsonData);
        PlayerPrefs.Save();

        //11번
        GameData_Main_Story_1_1_R Page_11_Text_data = new GameData_Main_Story_1_1_R();
        Page_11_Text_data.Page_11_Index = Page_Count_11;

        string Page_11_Text_jsonData = JsonUtility.ToJson(Page_11_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_11_Text", Page_11_Text_jsonData);
        PlayerPrefs.Save();

        //12번
        GameData_Main_Story_1_1_R Page_12_Text_data = new GameData_Main_Story_1_1_R();
        Page_12_Text_data.Page_12_Index = Page_Count_12;

        string Page_12_Text_jsonData = JsonUtility.ToJson(Page_12_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_12_Text", Page_12_Text_jsonData);
        PlayerPrefs.Save();

        //13번
        GameData_Main_Story_1_1_R Page_13_Text_data = new GameData_Main_Story_1_1_R();
        Page_13_Text_data.Page_13_Index = Page_Count_13;

        string Page_13_Text_jsonData = JsonUtility.ToJson(Page_13_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_13_Text", Page_13_Text_jsonData);
        PlayerPrefs.Save();

        //14번
        GameData_Main_Story_1_1_R Page_14_Text_data = new GameData_Main_Story_1_1_R();
        Page_14_Text_data.Page_14_Index = Page_Count_14;

        string Page_14_Text_jsonData = JsonUtility.ToJson(Page_14_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_14_Text", Page_14_Text_jsonData);
        PlayerPrefs.Save();

        //15번 페이지
        GameData_Main_Story_1_1_R Page_15_Text_data = new GameData_Main_Story_1_1_R();
        Page_15_Text_data.Page_15_Index = Page_Count_15;

        string Page_15_Text_jsonData = JsonUtility.ToJson(Page_15_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_15_Text", Page_15_Text_jsonData);
        PlayerPrefs.Save();

        //16번
        GameData_Main_Story_1_1_R Page_16_Text_data = new GameData_Main_Story_1_1_R();
        Page_16_Text_data.Page_16_Index = Page_Count_16;

        string Page_16_Text_jsonData = JsonUtility.ToJson(Page_16_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_16_Text", Page_16_Text_jsonData);
        PlayerPrefs.Save();

        //17번
        GameData_Main_Story_1_1_R Page_17_Text_data = new GameData_Main_Story_1_1_R();
        Page_17_Text_data.Page_17_Index = Page_Count_17;

        string Page_17_Text_jsonData = JsonUtility.ToJson(Page_17_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_17_Text", Page_17_Text_jsonData);
        PlayerPrefs.Save();

        //18번
        GameData_Main_Story_1_1_R Page_18_Text_data = new GameData_Main_Story_1_1_R();
        Page_18_Text_data.Page_18_Index = Page_Count_18;

        string Page_18_Text_jsonData = JsonUtility.ToJson(Page_18_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_18_Text", Page_18_Text_jsonData);
        PlayerPrefs.Save();

        //19번
        GameData_Main_Story_1_1_R Page_19_Text_data = new GameData_Main_Story_1_1_R();
        Page_19_Text_data.Page_19_Index = Page_Count_19;

        string Page_19_Text_jsonData = JsonUtility.ToJson(Page_19_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_19_Text", Page_19_Text_jsonData);
        PlayerPrefs.Save();

        //20번 페이지
        GameData_Main_Story_1_1_R Page_20_Text_data = new GameData_Main_Story_1_1_R();
        Page_20_Text_data.Page_20_Index = Page_Count_20;

        string Page_20_Text_jsonData = JsonUtility.ToJson(Page_20_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_20_Text", Page_20_Text_jsonData);
        PlayerPrefs.Save();

        //21번
        GameData_Main_Story_1_1_R Page_21_Text_data = new GameData_Main_Story_1_1_R();
        Page_21_Text_data.Page_21_Index = Page_Count_21;

        string Page_21_Text_jsonData = JsonUtility.ToJson(Page_21_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_21_Text", Page_21_Text_jsonData);
        PlayerPrefs.Save();

        //22번
        GameData_Main_Story_1_1_R Page_22_Text_data = new GameData_Main_Story_1_1_R();
        Page_22_Text_data.Page_22_Index = Page_Count_22;

        string Page_22_Text_jsonData = JsonUtility.ToJson(Page_22_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_22_Text", Page_22_Text_jsonData);
        PlayerPrefs.Save();

        //23
        GameData_Main_Story_1_1_R Page_23_Text_data = new GameData_Main_Story_1_1_R();
        Page_23_Text_data.Page_23_Index = Page_Count_23;

        string Page_23_Text_jsonData = JsonUtility.ToJson(Page_23_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_23_Text", Page_23_Text_jsonData);
        PlayerPrefs.Save();

        //14번
        GameData_Main_Story_1_1_R Page_24_Text_data = new GameData_Main_Story_1_1_R();
        Page_24_Text_data.Page_24_Index = Page_Count_24;

        string Page_24_Text_jsonData = JsonUtility.ToJson(Page_24_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_24_Text", Page_24_Text_jsonData);
        PlayerPrefs.Save();

        //15번 페이지
        GameData_Main_Story_1_1_R Page_25_Text_data = new GameData_Main_Story_1_1_R();
        Page_25_Text_data.Page_25_Index = Page_Count_25;

        string Page_25_Text_jsonData = JsonUtility.ToJson(Page_25_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_25_Text", Page_25_Text_jsonData);
        PlayerPrefs.Save();

        //16번
        GameData_Main_Story_1_1_R Page_26_Text_data = new GameData_Main_Story_1_1_R();
        Page_26_Text_data.Page_26_Index = Page_Count_26;

        string Page_26_Text_jsonData = JsonUtility.ToJson(Page_26_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_26_Text", Page_26_Text_jsonData);
        PlayerPrefs.Save();

        //17번
        GameData_Main_Story_1_1_R Page_27_Text_data = new GameData_Main_Story_1_1_R();
        Page_27_Text_data.Page_27_Index = Page_Count_27;

        string Page_27_Text_jsonData = JsonUtility.ToJson(Page_27_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_27_Text", Page_27_Text_jsonData);
        PlayerPrefs.Save();

        //18번
        GameData_Main_Story_1_1_R Page_28_Text_data = new GameData_Main_Story_1_1_R();
        Page_28_Text_data.Page_28_Index = Page_Count_28;

        string Page_28_Text_jsonData = JsonUtility.ToJson(Page_28_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_28_Text", Page_28_Text_jsonData);
        PlayerPrefs.Save();

        //19번
        GameData_Main_Story_1_1_R Page_29_Text_data = new GameData_Main_Story_1_1_R();
        Page_29_Text_data.Page_29_Index = Page_Count_29;

        string Page_29_Text_jsonData = JsonUtility.ToJson(Page_29_Text_data);
        PlayerPrefs.SetString("Main_Story_1_1_Page_29_Text", Page_29_Text_jsonData);
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
        PlayerPrefs.DeleteKey("Main_Story_1_1_What_Page");
        PlayerPrefs.Save();

        Main_Story_Slider.value = Reset_Story_Page;
        Current_Story_Page = (int)Main_Story_Slider.value;
        foreach (GameObject first_side_story_Page in Main_story)
        {
            first_side_story_Page.SetActive(false);
        }

        Main_story[Current_Story_Page].SetActive(true);



        //5번 페이지 몇 번째 텍스트까지 나왔는지
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_10_Text");
        PlayerPrefs.Save();
        Page_Count_10 = Default_Page_Count_10;
        foreach (GameObject Page_10_Text in Page_10)
        {
            Page_10_Text.SetActive(false);
        }


        //6
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_11_Text");
        PlayerPrefs.Save();
        Page_Count_11 = Default_Page_Count_11;
        foreach (GameObject Page_11_Text in Page_11)
        {
            Page_11_Text.SetActive(false);
        }

        //12
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_12_Text");
        PlayerPrefs.Save();
        Page_Count_12 = Default_Page_Count_12;
        foreach (GameObject Page_12_Text in Page_12)
        {
            Page_12_Text.SetActive(false);
        }

        //13
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_13_Text");
        PlayerPrefs.Save();
        Page_Count_13 = Default_Page_Count_13;
        foreach (GameObject Page_13_Text in Page_13)
        {
            Page_13_Text.SetActive(false);
        }

        //9
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_14_Text");
        PlayerPrefs.Save();
        Page_Count_14= Default_Page_Count_14;
        foreach (GameObject Page_14_Text in Page_14)
        {
            Page_14_Text.SetActive(false);
        }

        //10
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_15_Text");
        PlayerPrefs.Save();
        Page_Count_15 = Default_Page_Count_15;
        foreach (GameObject Page_15_Text in Page_15)
        {
            Page_15_Text.SetActive(false);
        }

        //11
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_16_Text");
        PlayerPrefs.Save();
        Page_Count_16 = Default_Page_Count_16;
        foreach (GameObject Page_16_Text in Page_16)
        {
            Page_16_Text.SetActive(false);
        }

        //17
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_17_Text");
        PlayerPrefs.Save();
        Page_Count_17 = Default_Page_Count_17;
        foreach (GameObject Page_17_Text in Page_17)
        {
            Page_17_Text.SetActive(false);
        }

        //18
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_18_Text");
        PlayerPrefs.Save();
        Page_Count_18 = Default_Page_Count_18;
        foreach (GameObject Page_18_Text in Page_18)
        {
            Page_18_Text.SetActive(false);
        }

        //14
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_19_Text");
        PlayerPrefs.Save();
        Page_Count_19 = Default_Page_Count_19;
        foreach (GameObject Page_19_Text in Page_19)
        {
            Page_19_Text.SetActive(false);
        }

        //15
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_20_Text");
        PlayerPrefs.Save();
        Page_Count_20 = Default_Page_Count_20;
        foreach (GameObject Page_20_Text in Page_20)
        {
            Page_20_Text.SetActive(false);
        }

        //21
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_21_Text");
        PlayerPrefs.Save();
        Page_Count_21 = Default_Page_Count_21;
        foreach (GameObject Page_21_Text in Page_21)
        {
            Page_21_Text.SetActive(false);
        }

        //22
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_22_Text");
        PlayerPrefs.Save();
        Page_Count_22 = Default_Page_Count_22;
        foreach (GameObject Page_22_Text in Page_22)
        {
            Page_22_Text.SetActive(false);
        }

        //23
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_23_Text");
        PlayerPrefs.Save();
        Page_Count_23 = Default_Page_Count_23;
        foreach (GameObject Page_23_Text in Page_23)
        {
            Page_23_Text.SetActive(false);
        }

        //9
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_24_Text");
        PlayerPrefs.Save();
        Page_Count_24 = Default_Page_Count_24;
        foreach (GameObject Page_24_Text in Page_24)
        {
            Page_24_Text.SetActive(false);
        }

        //10
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_25_Text");
        PlayerPrefs.Save();
        Page_Count_25 = Default_Page_Count_25;
        foreach (GameObject Page_25_Text in Page_25)
        {
            Page_25_Text.SetActive(false);
        }

        //11
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_26_Text");
        PlayerPrefs.Save();
        Page_Count_26 = Default_Page_Count_26;
        foreach (GameObject Page_26_Text in Page_26)
        {
            Page_26_Text.SetActive(false);
        }

        //17
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_27_Text");
        PlayerPrefs.Save();
        Page_Count_27 = Default_Page_Count_27;
        foreach (GameObject Page_27_Text in Page_27)
        {
            Page_27_Text.SetActive(false);
        }

        //18
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_28_Text");
        PlayerPrefs.Save();
        Page_Count_28 = Default_Page_Count_28;
        foreach (GameObject Page_28_Text in Page_28)
        {
            Page_28_Text.SetActive(false);
        }

        //14
        PlayerPrefs.DeleteKey("Main_Story_1_1_Page_29_Text");
        PlayerPrefs.Save();
        Page_Count_29 = Default_Page_Count_29;
        foreach (GameObject Page_29_Text in Page_29)
        {
            Page_29_Text.SetActive(false);
        }
    }

    //5번 텍스트
    private void Page_10_Text_LoadSettings()
    {

        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_10_Text"))
        {
            string Page_10_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_10_Text");
            GameData_Main_Story_1_1_R Page_10_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_10_Text_jsonData);

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
                        Page_Button[0].SetActive(false);
                    }

                    else
                    {
                        Page_Button[0].SetActive(true);
                    }
                }
                if (Page_Count_10 > Page_10.Length)
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
                foreach (GameObject Page_5_Text in Page_10)
                {
                    Page_5_Text.SetActive(false);
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

    //6
    private void Page_11_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_11_Text"))
        {
            string Page_11_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_11_Text");
            GameData_Main_Story_1_1_R Page_11_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_11_Text_jsonData);

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
                        Page_Button[1].SetActive(false);
                    }

                    else
                    {
                        Page_Button[1].SetActive(true);
                    }
                }
                if (Page_Count_11 > Page_11.Length)
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
                foreach (GameObject Page_6_Text in Page_11)
                {
                    Page_6_Text.SetActive(false);
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

    //7
    private void Page_12_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_12_Text"))
        {
            string Page_12_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_12_Text");
            GameData_Main_Story_1_1_R Page_12_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_12_Text_jsonData);

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
                        Page_Button[2].SetActive(false);
                    }

                    else
                    {
                        Page_Button[2].SetActive(true);
                    }
                }
                if (Page_Count_12 > Page_12.Length)
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

    //8
    private void Page_13_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_13_Text"))
        {
            string Page_13_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_13_Text");
            GameData_Main_Story_1_1_R Page_13_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_13_Text_jsonData);

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
                        Page_Button[3].SetActive(false);
                    }

                    else
                    {
                        Page_Button[3].SetActive(true);
                    }
                }
                if (Page_Count_13 > Page_13.Length)
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

    //9
    private void Page_14_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_14_Text"))
        {
            string Page_14_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_14_Text");
            GameData_Main_Story_1_1_R Page_14_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_14_Text_jsonData);

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
                        Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[4].SetActive(true);
                    }
                }
                if (Page_Count_14 > Page_14.Length)
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
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_15_Text"))
        {
            string Page_15_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_15_Text");
            GameData_Main_Story_1_1_R Page_15_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_15_Text_jsonData);

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
                        Page_Button[5].SetActive(false);
                    }

                    else
                    {
                        Page_Button[5].SetActive(true);
                    }
                }
                if (Page_Count_15 > Page_15.Length)
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

    //11
    private void Page_16_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_16_Text"))
        {
            string Page_16_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_16_Text");
            GameData_Main_Story_1_1_R Page_16_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_16_Text_jsonData);

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
                        Page_Button[6].SetActive(false);
                    }

                    else
                    {
                        Page_Button[6].SetActive(true);
                    }
                }
                if (Page_Count_16 > Page_16.Length)
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

    //12
    private void Page_17_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_17_Text"))
        {
            string Page_17_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_17_Text");
            GameData_Main_Story_1_1_R Page_17_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_17_Text_jsonData);

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
                        Page_Button[7].SetActive(false);
                    }

                    else
                    {
                        Page_Button[7].SetActive(true);
                    }
                }
                if (Page_Count_17 > Page_17.Length)
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

    //13
    private void Page_18_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_18_Text"))
        {
            string Page_18_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_18_Text");
            GameData_Main_Story_1_1_R Page_18_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_18_Text_jsonData);

            Page_Count_18 = Page_18_Text_data.Page_18_Index;

            if (Page_Count_18 > 0)
            {
                foreach (GameObject Page_18_Text in Page_18)
                {
                    Page_18_Text.SetActive(true);
                }

                for (int i = Page_Count_18; i < Page_18.Length; i++)
                {
                    Page_18[i].SetActive(false);//여기도 문제

                    if (Page_Count_18 > Page_18.Length)
                    {
                        Page_Button[8].SetActive(false);
                    }

                    else
                    {
                        Page_Button[8].SetActive(true);
                    }
                }
                if (Page_Count_18 > Page_18.Length)
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
                foreach (GameObject Page_18_Text in Page_18)
                {
                    Page_18_Text.SetActive(false);
                }

                for (int i = 0; i < Page_18.Length; i++)
                {
                    Page_18[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_18 = Default_Page_Count_18;
        }

    }

    //14
    private void Page_19_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_19_Text"))
        {
            string Page_19_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_19_Text");
            GameData_Main_Story_1_1_R Page_19_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_19_Text_jsonData);

            Page_Count_19 = Page_19_Text_data.Page_19_Index;

            if (Page_Count_19 > 0)
            {
                foreach (GameObject Page_19_Text in Page_19)
                {
                    Page_19_Text.SetActive(true);
                }

                for (int i = Page_Count_19; i < Page_19.Length; i++)
                {
                    Page_19[i].SetActive(false);//여기도 문제

                    if (Page_Count_19 > Page_19.Length)
                    {
                        Page_Button[9].SetActive(false);
                    }

                    else
                    {
                        Page_Button[9].SetActive(true);
                    }
                }
                if (Page_Count_19 > Page_19.Length)
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
                foreach (GameObject Page_19_Text in Page_19)
                {
                    Page_19_Text.SetActive(false);
                }

                for (int i = 0; i < Page_19.Length; i++)
                {
                    Page_19[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_19 = Default_Page_Count_19;
        }

    }

    //15
    private void Page_20_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_20_Text"))
        {
            string Page_20_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_20_Text");
            GameData_Main_Story_1_1_R Page_20_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_20_Text_jsonData);

            Page_Count_20 = Page_20_Text_data.Page_20_Index;

            if (Page_Count_20 > 0)
            {
                foreach (GameObject Page_20_Text in Page_20)
                {
                    Page_20_Text.SetActive(true);
                }

                for (int i = Page_Count_20; i < Page_20.Length; i++)
                {
                    Page_20[i].SetActive(false);//여기도 문제

                    if (Page_Count_20 > Page_20.Length)
                    {
                        Page_Button[10].SetActive(false);
                    }

                    else
                    {
                        Page_Button[10].SetActive(true);
                    }
                }
                if (Page_Count_20 > Page_20.Length)
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
                foreach (GameObject Page_20_Text in Page_20)
                {
                    Page_20_Text.SetActive(false);
                }

                for (int i = 0; i < Page_20.Length; i++)
                {
                    Page_20[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_20 = Default_Page_Count_20;
        }

    }

    //16
    private void Page_21_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_21_Text"))
        {
            string Page_21_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_21_Text");
            GameData_Main_Story_1_1_R Page_21_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_21_Text_jsonData);

            Page_Count_21 = Page_21_Text_data.Page_21_Index;

            if (Page_Count_21 > 0)
            {
                foreach (GameObject Page_21_Text in Page_21)
                {
                    Page_21_Text.SetActive(true);
                }

                for (int i = Page_Count_21; i < Page_21.Length; i++)
                {
                    Page_21[i].SetActive(false);//여기도 문제

                    if (Page_Count_21 > Page_16.Length)
                    {
                        Page_Button[11].SetActive(false);
                    }

                    else
                    {
                        Page_Button[11].SetActive(true);
                    }
                }
                if (Page_Count_21 > Page_21.Length)
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
                foreach (GameObject Page_21_Text in Page_21)
                {
                    Page_21_Text.SetActive(false);
                }

                for (int i = 0; i < Page_21.Length; i++)
                {
                    Page_21[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_21 = Default_Page_Count_21;
        }

    }

    //17
    private void Page_22_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_22_Text"))
        {
            string Page_22_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_22_Text");
            GameData_Main_Story_1_1_R Page_22_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_22_Text_jsonData);

            Page_Count_22 = Page_22_Text_data.Page_22_Index;

            if (Page_Count_22 > 0)
            {
                foreach (GameObject Page_22_Text in Page_22)
                {
                    Page_22_Text.SetActive(true);
                }

                for (int i = Page_Count_22; i < Page_22.Length; i++)
                {
                    Page_22[i].SetActive(false);//여기도 문제

                    if (Page_Count_22 > Page_22.Length)
                    {
                        Page_Button[12].SetActive(false);
                    }

                    else
                    {
                        Page_Button[12].SetActive(true);
                    }
                }
                if (Page_Count_22 > Page_22.Length)
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
                foreach (GameObject Page_22_Text in Page_22)
                {
                    Page_22_Text.SetActive(false);
                }

                for (int i = 0; i < Page_22.Length; i++)
                {
                    Page_22[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_22 = Default_Page_Count_22;
        }

    }

    //23
    private void Page_23_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_23_Text"))
        {
            string Page_23_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_23_Text");
            GameData_Main_Story_1_1_R Page_23_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_23_Text_jsonData);

            Page_Count_23 = Page_23_Text_data.Page_23_Index;

            if (Page_Count_23 > 0)
            {
                foreach (GameObject Page_23_Text in Page_23)
                {
                    Page_23_Text.SetActive(true);
                }

                for (int i = Page_Count_23; i < Page_23.Length; i++)
                {
                    Page_23[i].SetActive(false);//여기도 문제

                    if (Page_Count_23 > Page_23.Length)
                    {
                        Page_Button[13].SetActive(false);
                    }

                    else
                    {
                        Page_Button[13].SetActive(true);
                    }
                }
                if (Page_Count_23 > Page_22.Length)
                {
                    Page_Button[13].SetActive(false);
                }

                else
                {
                    Page_Button[13].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_23_Text in Page_23)
                {
                    Page_23_Text.SetActive(false);
                }

                for (int i = 0; i < Page_23.Length; i++)
                {
                    Page_23[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_23 = Default_Page_Count_23;
        }

    }

    //24
    private void Page_24_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_24_Text"))
        {
            string Page_24_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_24_Text");
            GameData_Main_Story_1_1_R Page_24_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_24_Text_jsonData);

            Page_Count_24 = Page_24_Text_data.Page_24_Index;

            if (Page_Count_24 > 0)
            {
                foreach (GameObject Page_24_Text in Page_24)
                {
                    Page_24_Text.SetActive(true);
                }

                for (int i = Page_Count_24; i < Page_24.Length; i++)
                {
                    Page_24[i].SetActive(false);//여기도 문제

                    if (Page_Count_24 > Page_24.Length)
                    {
                        Page_Button[14].SetActive(false);
                    }

                    else
                    {
                        Page_Button[14].SetActive(true);
                    }
                }
                if (Page_Count_24 > Page_24.Length)
                {
                    Page_Button[14].SetActive(false);
                }

                else
                {
                    Page_Button[14].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_24_Text in Page_24)
                {
                    Page_24_Text.SetActive(false);
                }

                for (int i = 0; i < Page_24.Length; i++)
                {
                    Page_24[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_24 = Default_Page_Count_24;
        }

    }

    //25
    private void Page_25_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_25_Text"))
        {
            string Page_25_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_25_Text");
            GameData_Main_Story_1_1_R Page_25_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_25_Text_jsonData);

            Page_Count_25 = Page_25_Text_data.Page_25_Index;

            if (Page_Count_25 > 0)
            {
                foreach (GameObject Page_25_Text in Page_25)
                {
                    Page_25_Text.SetActive(true);
                }

                for (int i = Page_Count_25; i < Page_25.Length; i++)
                {
                    Page_25[i].SetActive(false);//여기도 문제

                    if (Page_Count_25 > Page_25.Length)
                    {
                        Page_Button[15].SetActive(false);
                    }

                    else
                    {
                        Page_Button[15].SetActive(true);
                    }
                }
                if (Page_Count_25 > Page_25.Length)
                {
                    Page_Button[15].SetActive(false);
                }

                else
                {
                    Page_Button[15].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_25_Text in Page_25)
                {
                    Page_25_Text.SetActive(false);
                }

                for (int i = 0; i < Page_25.Length; i++)
                {
                    Page_25[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_25 = Default_Page_Count_25;
        }

    }

    //26
    private void Page_26_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_26_Text"))
        {
            string Page_26_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_26_Text");
            GameData_Main_Story_1_1_R Page_26_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_26_Text_jsonData);

            Page_Count_26 = Page_26_Text_data.Page_26_Index;

            if (Page_Count_26 > 0)
            {
                foreach (GameObject Page_26_Text in Page_26)
                {
                    Page_26_Text.SetActive(true);
                }

                for (int i = Page_Count_26; i < Page_26.Length; i++)
                {
                    Page_26[i].SetActive(false);//여기도 문제

                    if (Page_Count_26 > Page_26.Length)
                    {
                        Page_Button[16].SetActive(false);
                    }

                    else
                    {
                        Page_Button[16].SetActive(true);
                    }
                }
                if (Page_Count_26 > Page_26.Length)
                {
                    Page_Button[16].SetActive(false);
                }

                else
                {
                    Page_Button[16].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_26_Text in Page_26)
                {
                    Page_26_Text.SetActive(false);
                }

                for (int i = 0; i < Page_26.Length; i++)
                {
                    Page_26[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_26 = Default_Page_Count_26;
        }

    }

    //27
    private void Page_27_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_27_Text"))
        {
            string Page_27_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_27_Text");
            GameData_Main_Story_1_1_R Page_27_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_27_Text_jsonData);

            Page_Count_27 = Page_27_Text_data.Page_27_Index;

            if (Page_Count_27 > 0)
            {
                foreach (GameObject Page_27_Text in Page_27)
                {
                    Page_27_Text.SetActive(true);
                }

                for (int i = Page_Count_27; i < Page_27.Length; i++)
                {
                    Page_27[i].SetActive(false);//여기도 문제

                    if (Page_Count_27 > Page_27.Length)
                    {
                        Page_Button[17].SetActive(false);
                    }

                    else
                    {
                        Page_Button[17].SetActive(true);
                    }
                }
                if (Page_Count_27 > Page_27.Length)
                {
                    Page_Button[17].SetActive(false);
                }

                else
                {
                    Page_Button[17].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_27_Text in Page_27)
                {
                    Page_27_Text.SetActive(false);
                }

                for (int i = 0; i < Page_27.Length; i++)
                {
                    Page_27[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_27 = Default_Page_Count_27;
        }

    }

    //28
    private void Page_28_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_28_Text"))
        {
            string Page_28_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_28_Text");
            GameData_Main_Story_1_1_R Page_28_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_28_Text_jsonData);

            Page_Count_28 = Page_28_Text_data.Page_28_Index;

            if (Page_Count_28 > 0)
            {
                foreach (GameObject Page_28_Text in Page_28)
                {
                    Page_28_Text.SetActive(true);
                }

                for (int i = Page_Count_28; i < Page_28.Length; i++)
                {
                    Page_28[i].SetActive(false);//여기도 문제

                    if (Page_Count_28 > Page_28.Length)
                    {
                        Page_Button[18].SetActive(false);
                    }

                    else
                    {
                        Page_Button[18].SetActive(true);
                    }
                }
                if (Page_Count_28 > Page_28.Length)
                {
                    Page_Button[18].SetActive(false);
                }

                else
                {
                    Page_Button[18].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_28_Text in Page_28)
                {
                    Page_28_Text.SetActive(false);
                }

                for (int i = 0; i < Page_28.Length; i++)
                {
                    Page_28[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_28 = Default_Page_Count_28;
        }

    }

    //29
    private void Page_29_Text_LoadSettings()
    {
        //5페이지 몇 번째 텍스트 나왔는지
        if (PlayerPrefs.HasKey("Main_Story_1_1_Page_29_Text"))
        {
            string Page_29_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_1_Page_29_Text");
            GameData_Main_Story_1_1_R Page_29_Text_data = JsonUtility.FromJson<GameData_Main_Story_1_1_R>(Page_29_Text_jsonData);

            Page_Count_29 = Page_29_Text_data.Page_29_Index;

            if (Page_Count_29 > 0)
            {
                foreach (GameObject Page_29_Text in Page_29)
                {
                    Page_29_Text.SetActive(true);
                }

                for (int i = Page_Count_29; i < Page_29.Length; i++)
                {
                    Page_29[i].SetActive(false);//여기도 문제

                    if (Page_Count_29 > Page_29.Length)
                    {
                        Page_Button[19].SetActive(false);
                    }

                    else
                    {
                        Page_Button[19].SetActive(true);
                    }
                }
                if (Page_Count_29 > Page_29.Length)
                {
                    Page_Button[19].SetActive(false);
                }

                else
                {
                    Page_Button[19].SetActive(true);
                }

            }

            else
            {
                foreach (GameObject Page_29_Text in Page_29)
                {
                    Page_29_Text.SetActive(false);
                }

                for (int i = 0; i < Page_29.Length; i++)
                {
                    Page_29[i].SetActive(false);
                }
            }
        }
        else
        {
            Page_Count_29 = Default_Page_Count_29;
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

    public void Ten_Page()
    {
        //길이는 11
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


            else
            {
                Page_10[Page_Count_10].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_10++;
            Debug.Log(Page_Count_10);
            if (Page_Count_10 > Page_10.Length)
            {//11보다 커지면?

                Main_story[9].SetActive(false);
                Page_Button[0].SetActive(false);

                Main_story[10].SetActive(true);
                Page_Button[1].SetActive(true);
                //Debug.Log("아앙Page_Count_5 > Page_5.Length");

                Main_Story_Slider.value = 11;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_11 = 1;
                Page_11[0].SetActive(true);

            }


        }


    }

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
    
            }

            Page_Count_11++;
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

            Debug.Log(Page_Count_11);
            if (Page_Count_11 > Page_11.Length)
            {//11보다 커지면?

                Main_story[10].SetActive(false);
                Page_Button[1].SetActive(false);

                Main_story[11].SetActive(true);
                Page_Button[2].SetActive(true);
                //Debug.Log("Page_Count_6 > Page_6.Length");

                Main_Story_Slider.value = 12;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_12 = 1;
                Page_12[0].SetActive(true);

            }


        }

        /*if (Page_Count_6 <= Page_6.Length)
        {

            if (Page_Count_6 == Page_6.Length)
            {
                Page_Count_6 = Page_6.Length + 1;
            }

            else if (Page_Count_6 == 1)
            {
                Page_6[1].SetActive(true);
            }

            else if(Page_Count_6 == 4)
            {
                Page_Button[1].SetActive(false);
                Page_6[4].SetActive(true);
            }


            else
            {
                Page_6[Page_Count_6].SetActive(true);
                Page_Button[1].SetActive(true);
                Debug.Log("되나?");
            }

            Page_Count_6++;
            Debug.Log(Page_Count_6);
            if (Page_Count_6 > Page_6.Length)
            {//11보다 커지면?

                Side_story[5].SetActive(false);
                Page_Button[1].SetActive(false);

                Side_story[6].SetActive(true);
                Page_Button[2].SetActive(true);
                Debug.Log("아앙Page_Count_6 > Page_6.Length");

                Side_Story_Slider.value = 7;

                Current_Story_Page = (int)Side_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_7 = 1;
                Page_7[0].SetActive(true);

            }


        }*/
    }

    public void Tweleve_Page()
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


            else
            {
                Page_12[Page_Count_12].SetActive(true);
                // Debug.Log("되나?");
            }

            Page_Count_12++;
            Debug.Log(Page_Count_12);
            if (Page_Count_12 > Page_12.Length)
            {//11보다 커지면?

                Main_story[11].SetActive(false);
                Page_Button[2].SetActive(false);

                Main_story[12].SetActive(true);
                Page_Button[3].SetActive(true);
                //Debug.Log("아앙Page_Count_7 > Page_7.Length");

                Main_Story_Slider.value = 13;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_13 = 1;
                Page_13[0].SetActive(true);
                //return;

            }


        }
    }

    //4
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

            else if (Page_Count_13 == 3)
            {
                Page_13[3].SetActive(true);
                sfx.Door_Open_Sound();
            }


            else
            {
                Page_13[Page_Count_13].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_13++;
            Debug.Log(Page_Count_13);
            if (Page_Count_13 > Page_13.Length)
            {//11보다 커지면?

                Main_story[12].SetActive(false);
                Page_Button[3].SetActive(false);

                Main_story[13].SetActive(true);
                Page_Button[4].SetActive(true);
                //Debug.Log("아앙Page_Count_8 > Page_8.Length");

                Main_Story_Slider.value = 14;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_14 = 1;
                Page_14[0].SetActive(true);

            }


        }
    }

    //5
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
                //Debug.Log("되나?");
            }

            Page_Count_14++;
            Debug.Log(Page_Count_14);
            if (Page_Count_14 > Page_14.Length)
            {//11보다 커지면?

                Main_story[13].SetActive(false);
                Page_Button[4].SetActive(false);

                Main_story[14].SetActive(true);
                Page_Button[5].SetActive(true);

                //Debug.Log("아앙Page_Count_9 > Page_9.Length");



                Main_Story_Slider.value = 15;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_15 = 1;
                Page_15[0].SetActive(true);

            }


        }
    }

    //6
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

            else if (Page_Count_15 == 3)
            {
                Page_15[3].SetActive(true);
                //Ten_Page_Background[0].SetActive(false);
                //Ten_Page_Background[1].SetActive(true);
            }

            else
            {
                Page_15[Page_Count_15].SetActive(true);
                // Debug.Log("되나?");


            }

            Page_Count_15++;
            Debug.Log(Page_Count_15);
            if (Page_Count_15 > Page_15.Length)
            {//11보다 커지면?

                Main_story[14].SetActive(false);
                Page_Button[5].SetActive(false);

                Main_story[15].SetActive(true);
                Page_Button[6].SetActive(true);
                // Debug.Log("아앙Page_Count_10 > Page_10.Length");

                Main_Story_Slider.value = 16;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_16 = 1;
                Page_16[0].SetActive(true);

            }


        }
    }

    //11
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

            else if (Page_Count_16 == 6)
            {
                Page_16[6].SetActive(true);
                sfx.Door_Open_Sound();
            }


            else
            {
                Page_16[Page_Count_16].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_16++;
            Debug.Log(Page_Count_16);
            if (Page_Count_16 > Page_16.Length)
            {//11보다 커지면?

                Main_story[15].SetActive(false);
                Page_Button[6].SetActive(false);

                Main_story[16].SetActive(true);
                Page_Button[7].SetActive(true);
                //  Debug.Log("아앙Page_Count_11 > Page_11.Length");



                Main_Story_Slider.value = 17;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_17 = 1;
                Page_17[0].SetActive(true);

            }


        }
    }

    //12
    public void Sevneteen_Page()
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
                //Twelve_Page_Background[0].SetActive(false);
                //Twelve_Page_Background[1].SetActive(true);
            }

            

            else
            {
                Page_17[Page_Count_17].SetActive(true);
                //  Debug.Log("되나?");
            }

            Page_Count_17++;
            Debug.Log(Page_Count_17);
            if (Page_Count_17 > Page_17.Length)
            {//11보다 커지면?

                Main_story[16].SetActive(false);
                Page_Button[7].SetActive(false);

                Main_story[17].SetActive(true);
                Page_Button[8].SetActive(true);
                // Debug.Log("아앙Page_Count_11 > Page_11.Length");


                Main_Story_Slider.value = 18;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_18 = 1;
                Page_18[0].SetActive(true);

            }


        }
    }

    //13
    public void Eightteen_Page()
    {
        if (Page_Count_18 <= Page_18.Length)
        {

            if (Page_Count_18 == Page_18.Length)
            {
                Page_Count_18 = Page_18.Length + 1;
            }

            else if (Page_Count_18 == 1)
            {
                Page_18[1].SetActive(true);
            }


            else
            {
                Page_18[Page_Count_18].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_18++;
            Debug.Log(Page_Count_18);
            if (Page_Count_18 > Page_18.Length)
            {//11보다 커지면?

                Main_story[17].SetActive(false);
                Page_Button[8].SetActive(false);

                Main_story[18].SetActive(true);
                Page_Button[9].SetActive(true);
                // Debug.Log("아앙Page_Count_13 > Page_13.Length");



                Main_Story_Slider.value = 19;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_19 = 1;
                Page_19[0].SetActive(true);

            }


        }
    }

    //14
    public void Nineteen_Page()
    {
        if (Page_Count_19 <= Page_19.Length)
        {

            if (Page_Count_19 == Page_19.Length)
            {
                Page_Count_19 = Page_19.Length + 1;
            }

            else if (Page_Count_19 == 1)
            {
                Page_19[1].SetActive(true);
            }

            else if (Page_Count_19 == 6)
            {
                Page_19[6].SetActive(true);
                sfx.Runnng_Sound();
            }

            else
            {
                Page_19[Page_Count_19].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_19++;
            Debug.Log(Page_Count_19);
            if (Page_Count_19 > Page_19.Length)
            {//11보다 커지면?

                Main_story[18].SetActive(false);
                Page_Button[9].SetActive(false);

                Main_story[19].SetActive(true);
                Page_Button[10].SetActive(true);
                // Debug.Log("아앙Page_Count_14 > Page_14.Length");



                Main_Story_Slider.value = 20;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_20 = 1;
                Page_20[0].SetActive(true);

            }


        }
    }

    //20
    public void Twenty_Page()
    {
        if (Page_Count_20 <= Page_20.Length)
        {

            if (Page_Count_20 == Page_20.Length)
            {
                Page_Count_20 = Page_20.Length + 1;
            }

            else if (Page_Count_20 == 1)
            {
                Page_20[1].SetActive(true);
            }


            else
            {
                Page_20[Page_Count_20].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_20++;
            Debug.Log(Page_Count_20);
            if (Page_Count_20 > Page_20.Length)
            {//11보다 커지면?

                Main_story[19].SetActive(false);
                Page_Button[10].SetActive(false);

                Main_story[20].SetActive(true);
                Page_Button[11].SetActive(true);
                //Debug.Log("아앙Page_Count_15 > Page_15.Length");



                Main_Story_Slider.value = 21;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_21 = 1;
                Page_21[0].SetActive(true);

            }


        }
    }



    public void Twenty_One_Page()
    {
        if (Page_Count_21 <= Page_21.Length)
        {

            if (Page_Count_21 == Page_21.Length)
            {
                Page_Count_21 = Page_21.Length + 1;
            }

            else if (Page_Count_21 == 1)
            {
                Page_21[1].SetActive(true);
            }

            else if (Page_Count_21 == 6)
            {
                Page_21[6].SetActive(true);
                sfx.Knock_Sound();
            }

            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_21[Page_Count_21].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_21++;
            Debug.Log(Page_Count_21);
            if (Page_Count_21 > Page_21.Length)
            {//11보다 커지면?

                Main_story[20].SetActive(false);
                Page_Button[11].SetActive(false);

                Main_story[21].SetActive(true);
                Page_Button[12].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 22;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_22 = 1;
                Page_22[0].SetActive(true);

            }


        }
    }

    //22
    public void Twenty_Two_Page()
    {
        if (Page_Count_22 <= Page_22.Length)
        {

            if (Page_Count_22 == Page_22.Length)
            {
                Page_Count_22 = Page_22.Length + 1;
            }

            else if (Page_Count_22 == 1)
            {
                Page_22[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_22[Page_Count_22].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_22++;
            Debug.Log(Page_Count_22);
            if (Page_Count_22 > Page_22.Length)
            {//11보다 커지면?

                Main_story[21].SetActive(false);
                Page_Button[12].SetActive(false);

                Main_story[22].SetActive(true);
                Page_Button[13].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 23;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_23 = 1;
                Page_23[0].SetActive(true);

            }


        }
    }

    //23
    public void Twenty_Three_Page()
    {
        if (Page_Count_23 <= Page_23.Length)
        {

            if (Page_Count_23 == Page_23.Length)
            {
                Page_Count_23 = Page_23.Length + 1;
            }

            else if (Page_Count_23 == 1)
            {
                Page_23[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_23[Page_Count_23].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_23++;
            Debug.Log(Page_Count_23);
            if (Page_Count_23 > Page_23.Length)
            {//11보다 커지면?

                Main_story[22].SetActive(false);
                Page_Button[13].SetActive(false);

                Main_story[23].SetActive(true);
                Page_Button[14].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 24;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_24 = 1;
                Page_24[0].SetActive(true);

            }


        }
    }

    //24
    public void Twenty_Four_Page()
    {
        if (Page_Count_24 <= Page_24.Length)
        {

            if (Page_Count_24 == Page_24.Length)
            {
                Page_Count_24 = Page_24.Length + 1;
            }

            else if (Page_Count_24 == 1)
            {
                Page_24[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_24[Page_Count_24].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_24++;
            Debug.Log(Page_Count_24);
            if (Page_Count_24 > Page_24.Length)
            {//11보다 커지면?

                Main_story[23].SetActive(false);
                Page_Button[14].SetActive(false);

                Main_story[24].SetActive(true);
                Page_Button[15].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 25;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_25 = 1;
                Page_25[0].SetActive(true);

            }


        }
    }

    //25
    public void Twenty_Five_Page()
    {
        if (Page_Count_25 <= Page_25.Length)
        {

            if (Page_Count_25 == Page_25.Length)
            {
                Page_Count_25 = Page_25.Length + 1;
            }

            else if (Page_Count_25 == 1)
            {
                Page_25[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_25[Page_Count_25].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_25++;
            Debug.Log(Page_Count_25);
            if (Page_Count_25 > Page_25.Length)
            {//11보다 커지면?

                Main_story[24].SetActive(false);
                Page_Button[15].SetActive(false);

                Main_story[25].SetActive(true);
                Page_Button[16].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 26;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_26 = 1;
                Page_26[0].SetActive(true);

            }


        }
    }

    //26
    public void Twenty_Six_Page()
    {
        if (Page_Count_26 <= Page_26.Length)
        {

            if (Page_Count_26 == Page_26.Length)
            {
                Page_Count_26 = Page_26.Length + 1;
            }

            else if (Page_Count_26 == 1)
            {
                Page_26[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_26[Page_Count_26].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_26++;
            Debug.Log(Page_Count_26);
            if (Page_Count_26 > Page_26.Length)
            {//11보다 커지면?

                Main_story[25].SetActive(false);
                Page_Button[16].SetActive(false);

                Main_story[26].SetActive(true);
                Page_Button[17].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 27;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_27 = 1;
                Page_27[0].SetActive(true);

            }


        }
    }

    //27
    public void Twenty_Seven_Page()
    {
        if (Page_Count_27 <= Page_27.Length)
        {

            if (Page_Count_27 == Page_27.Length)
            {
                Page_Count_27 = Page_27.Length + 1;
            }

            else if (Page_Count_27 == 1)
            {
                Page_27[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_27[Page_Count_27].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_27++;
            Debug.Log(Page_Count_27);
            if (Page_Count_27 > Page_27.Length)
            {//11보다 커지면?

                Main_story[26].SetActive(false);
                Page_Button[17].SetActive(false);

                Main_story[27].SetActive(true);
                Page_Button[18].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 28;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_28 = 1;
                Page_28[0].SetActive(true);

            }


        }
    }

    //28
    public void Twenty_Eight_Page()
    {
        if (Page_Count_28 <= Page_28.Length)
        {

            if (Page_Count_28 == Page_28.Length)
            {
                Page_Count_28 = Page_28.Length + 1;
            }

            else if (Page_Count_28 == 1)
            {
                Page_28[1].SetActive(true);
            }



            /*else if (Page_Count_16 == 4)
            {
                Page_16[3].SetActive(false);
                Page_16[4].SetActive(true);
                Debug.Log("선택지 없어져라?");
                //Page_Button[11].SetActive(false);
            }*/

            else
            {
                Page_28[Page_Count_28].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_28++;
            Debug.Log(Page_Count_28);
            if (Page_Count_28 > Page_28.Length)
            {//11보다 커지면?

                Main_story[27].SetActive(false);
                Page_Button[18].SetActive(false);

                Main_story[28].SetActive(true);
                Page_Button[19].SetActive(true);
                //Debug.Log("아앙Page_Count_16 > Page_16.Length");

                //return;

                Main_Story_Slider.value = 29;

                Current_Story_Page = (int)Main_Story_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_29 = 1;
                Page_29[0].SetActive(true);

            }


        }
    }

    //29
    public void Twenty_Nine_Page()
    {
        if (Page_Count_29 <= Page_29.Length)
        {

            if (Page_Count_29 == Page_29.Length)
            {
                Page_Count_29 = Page_29.Length + 1;
            }

            else if (Page_Count_29 == 1)
            {
                Page_29[1].SetActive(true);
                sfx.Falling_Sound();
            }



            else
            {
                Page_29[Page_Count_29].SetActive(true);
                //Debug.Log("되나?");
            }

            Page_Count_29++;
            Debug.Log(Page_Count_29);
            if (Page_Count_29 > Page_29.Length)
            {//11보다 커지면?

                //Side_story[16].SetActive(false);
                Page_Button[19].SetActive(false);

                //Side_story[15].SetActive(true);
                //Page_Button[11].SetActive(true);
                //Debug.Log("아앙Page_Count_17 > Page_17.Length");



                //Side_Story_Slider.value = 16;

                // Current_Story_Page = (int)Side_Story_Slider.value;
                //Left_Page.text = Current_Story_Page.ToString();

                // Page_Count_16 = 1;
                //Page_16[0].SetActive(true);

            }


        }
    }



}

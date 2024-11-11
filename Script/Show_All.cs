using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_All : MonoBehaviour
{
    //현재 진행된 거에서는 볼 수는 없지만
    //만든 게 아까워서 내가 만들었던 거 잠시나마 볼 수 있게 해주는 스크립트

    //가방(물건, 인물)
    public Bag bag;

    //편지
    public Letter letter;
    
    //등장인물
    public Ch ch;

    public GameObject[] Will_Show;//안 보이던거 보이게 할 건지, 말건지 문구
    public GameObject[] Show_Text;

    //내가 해야 할 거
    //1화를 다 봐야지 2화를 볼 수 있게 하기
    //슬라이더? 바 좌우에 있는 화살표는 이전 화, 다음 화로 갈 수 있는 걸로 하자
    //내가 어느 화 까지 봤는지 메인 화면에서 볼 수 있고, 바로 그 화수로 갈 수 있게 하기
    //메인 스토리, 외전에 효과음 넣기

    public void FixedUpdate()
    {
        if (letter.Four_Letter.activeSelf == false)
        {
            //만약 보여지지 않아야 할 게 하나라도 보여지고 있으면
            Show_Text[0].SetActive(true);//보여주기
            Show_Text[1].SetActive(false);//감추기
        }

        else if (letter.Four_Letter.activeSelf == true)
        {
            //만약 하나라도 보이지 않아야 할 게 보이지 않는다면
            Show_Text[0].SetActive(false);
            Show_Text[1].SetActive(true);
        }
    }

    public void Show_Or_Not()
    {
        if(letter.Four_Letter.activeSelf==false)
        {
            //만약 보여지지 않아야 할 게 하나라도 보여지고 있으면
            Will_Show[0].SetActive(true);//보여주기
            Will_Show[1].SetActive(false);//감추기
        }

        else if (letter.Four_Letter.activeSelf == true)
        {
            //만약 하나라도 보이지 않아야 할 게 보이지 않는다면
            Will_Show[0].SetActive(false);
            Will_Show[1].SetActive(true);
        }
    }

    public void Show_all_Yes()
    {
        //내가 만든 거 다 보여주자
        //스토리 진행하면 해금될 수 있는 것 제외

        //편지
        letter.Three_Letter.SetActive(true);
        letter.Four_Letter.SetActive(true);
        letter.Five_Letter.SetActive(true);
        letter.Six_Letter.SetActive(true);
        letter.Seven_Letter.SetActive(true);

        //가방 - 장갑
        bag.Obj_Inform_Select_2[0].SetActive(true);
        bag.Obj_Inform_Select_2[1].SetActive(false);

        //가방 - 아이네 정보
        bag.Ch_1_Text[6].SetActive(false);//4
        bag.Ch_1_Text[7].SetActive(true);
        bag.Ch_1_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_1_Text[8].SetActive(false);//5
        bag.Ch_1_Text[9].SetActive(true);
        bag.Ch_1_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_1_Text[10].SetActive(false);//6
        bag.Ch_1_Text[11].SetActive(true);
        bag.Ch_1_Image[5].color = new Color(255, 255, 255 / 255);

        //가방 - 진 정보
        bag.Ch_2_Text[2].SetActive(false);//2
        bag.Ch_2_Text[3].SetActive(true);
        bag.Ch_2_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[4].SetActive(false);//3
        bag.Ch_2_Text[5].SetActive(true);
        bag.Ch_2_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[6].SetActive(false);//4
        bag.Ch_2_Text[7].SetActive(true);
        bag.Ch_2_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[8].SetActive(false);//5
        bag.Ch_2_Text[9].SetActive(true);
        bag.Ch_2_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[10].SetActive(false);//6
        bag.Ch_2_Text[11].SetActive(true);
        bag.Ch_2_Image[5].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[12].SetActive(false);//7
        bag.Ch_2_Text[13].SetActive(true);
        bag.Ch_2_Image[6].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[14].SetActive(false);//8
        bag.Ch_2_Text[15].SetActive(true);
        bag.Ch_2_Image[7].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[16].SetActive(false);//9
        bag.Ch_2_Text[17].SetActive(true);
        bag.Ch_2_Image[8].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[18].SetActive(false);//10
        bag.Ch_2_Text[19].SetActive(true);
        bag.Ch_2_Image[9].color = new Color(255, 255, 255 / 255);

        //가방 - 하레이스 정보
        bag.Ch_Inform_Select_3[0].SetActive(true);//열림
        bag.Ch_Inform_Select_3[1].SetActive(false);//닫힘

        bag.Ch_3_Text[0].SetActive(false);//1
        bag.Ch_3_Text[1].SetActive(true);
        bag.Ch_3_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[2].SetActive(false);//2
        bag.Ch_3_Text[3].SetActive(true);
        bag.Ch_3_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[4].SetActive(false);//3
        bag.Ch_3_Text[5].SetActive(true);
        bag.Ch_3_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[6].SetActive(false);//4
        bag.Ch_3_Text[7].SetActive(true);
        bag.Ch_3_Image[3].color = new Color(255, 255, 255 / 255);

        //가방 - 루시세리나 정보
        bag.Ch_Inform_Select_4[0].SetActive(true);//열림
        bag.Ch_Inform_Select_4[1].SetActive(false);//닫힘

        bag.Ch_4_Text[0].SetActive(false);//1
        bag.Ch_4_Text[1].SetActive(true);
        bag.Ch_4_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[2].SetActive(false);//2
        bag.Ch_4_Text[3].SetActive(true);
        bag.Ch_4_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[4].SetActive(false);//3
        bag.Ch_4_Text[5].SetActive(true);
        bag.Ch_4_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[6].SetActive(false);//4
        bag.Ch_4_Text[7].SetActive(true);
        bag.Ch_4_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[8].SetActive(false);//4
        bag.Ch_4_Text[9].SetActive(true);
        bag.Ch_4_Image[4].color = new Color(255, 255, 255 / 255);

        //가방 - 마탑주 정보
        bag.Ch_Inform_Select_5[0].SetActive(true);//열림
        bag.Ch_Inform_Select_5[1].SetActive(false);//닫힘

        bag.Ch_5_Text[0].SetActive(false);//1
        bag.Ch_5_Text[1].SetActive(true);
        bag.Ch_5_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[2].SetActive(false);//2
        bag.Ch_5_Text[3].SetActive(true);
        bag.Ch_5_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[4].SetActive(false);//3
        bag.Ch_5_Text[5].SetActive(true);
        bag.Ch_5_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[6].SetActive(false);//4
        bag.Ch_5_Text[7].SetActive(true);
        bag.Ch_5_Image[3].color = new Color(255, 255, 255 / 255);

        //가방 - 아이젤 정보
        bag.Ch_Inform_Select_6[0].SetActive(true);//열림
        bag.Ch_Inform_Select_6[1].SetActive(false);//닫힘

        bag.Ch_6_Text[0].SetActive(false);//1
        bag.Ch_6_Text[1].SetActive(true);
        bag.Ch_6_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[2].SetActive(false);//2
        bag.Ch_6_Text[3].SetActive(true);
        bag.Ch_6_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[4].SetActive(false);//3
        bag.Ch_6_Text[5].SetActive(true);
        bag.Ch_6_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[6].SetActive(false);//4
        bag.Ch_6_Text[7].SetActive(true);
        bag.Ch_6_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[8].SetActive(false);//3
        bag.Ch_6_Text[9].SetActive(true);
        bag.Ch_6_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[10].SetActive(false);//4
        bag.Ch_6_Text[11].SetActive(true);
        bag.Ch_6_Image[5].color = new Color(255, 255, 255 / 255);

        //등장인물
        ch.Ch_Hide[0].SetActive(false);//렌
        ch.Ch_Hide[2].SetActive(false);//아이젤
        ch.Ch_Hide[3].SetActive(false);//하레이스
        ch.Ch_Hide[4].SetActive(false);//루시세리나
        ch.Ch_Hide[5].SetActive(false);//아자르
        ch.Ch_Hide[6].SetActive(false);//리베나

        ch.Two.SetActive(true);//렌
        ch.Four.SetActive(true);//아이젤
        ch.Five.SetActive(true);//하레이스
        ch.Six.SetActive(true);//루시세리나
        ch.Seven.SetActive(true);//아자르
        ch.Eight.SetActive(true);//리베나

        //아이네 - 성인일 때와,악마 버전
        ch.One_Ch_Inside_1[2].SetActive(false);//컸을 때 못보는거
        ch.One_Ch_Inside_1[3].SetActive(true);//컸을 때 보는거
        ch.One_Ch_Inside_1[4].SetActive(false);//전생 못보는거
        ch.One_Ch_Inside_1[5].SetActive(true);//전생 보는거
       

        //렌 - 정체 밝혀질 때
        ch.One_Ch_Inside_2[0].SetActive(false);//못보는거
        ch.One_Ch_Inside_2[1].SetActive(true);//보는거

        //진 - 성인일 때와, 정체 밝혀질 때
        ch.One_Ch_Inside_3[0].SetActive(false);//못보는거
        ch.One_Ch_Inside_3[1].SetActive(true);//보는거
        ch.One_Ch_Inside_3[2].SetActive(false);// 못보는거
        ch.One_Ch_Inside_3[3].SetActive(true);// 보는거

        //아이젤 - 성인 때
        ch.One_Ch_Inside_4[0].SetActive(false);//못보는거
        ch.One_Ch_Inside_4[1].SetActive(true);//보는거

        //루시세리나 - 눈떴다
        ch.One_Ch_Inside_6[0].SetActive(false);//못보는거
        ch.One_Ch_Inside_6[1].SetActive(true);//보는거

        Will_Show[0].SetActive(false);
    }

    public void Return_all_Yes()
    {

        //다시 안 보이던 거 안보이게 만들기

        //편지
        letter.Three_Letter.SetActive(false);
        letter.Four_Letter.SetActive(false);
        letter.Five_Letter.SetActive(false);
        letter.Six_Letter.SetActive(false);
        letter.Seven_Letter.SetActive(false);

        //가방 - 장갑
        bag.Obj_Inform_Select_2[0].SetActive(false);
        bag.Obj_Inform_Select_2[1].SetActive(true);

        //가방 - 아이네 정보
        bag.Ch_1_Text[6].SetActive(true);//4
        bag.Ch_1_Text[7].SetActive(false);
        bag.Ch_1_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_1_Text[8].SetActive(true);//5
        bag.Ch_1_Text[9].SetActive(false);
        bag.Ch_1_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_1_Text[10].SetActive(true);//6
        bag.Ch_1_Text[11].SetActive(false);
        bag.Ch_1_Image[5].color = new Color(0, 0, 0 / 255);

        //가방 - 진 정보
        bag.Ch_2_Text[2].SetActive(true);//2
        bag.Ch_2_Text[3].SetActive(false);
        bag.Ch_2_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[4].SetActive(true);//3
        bag.Ch_2_Text[5].SetActive(false);
        bag.Ch_2_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[6].SetActive(true);//4
        bag.Ch_2_Text[7].SetActive(false);
        bag.Ch_2_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[8].SetActive(true);//5
        bag.Ch_2_Text[9].SetActive(false);
        bag.Ch_2_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[10].SetActive(true);//6
        bag.Ch_2_Text[11].SetActive(false);
        bag.Ch_2_Image[5].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[12].SetActive(true);//7
        bag.Ch_2_Text[13].SetActive(false);
        bag.Ch_2_Image[6].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[14].SetActive(true);//8
        bag.Ch_2_Text[15].SetActive(false);
        bag.Ch_2_Image[7].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[16].SetActive(true);//9
        bag.Ch_2_Text[17].SetActive(false);
        bag.Ch_2_Image[8].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[18].SetActive(true);//10
        bag.Ch_2_Text[19].SetActive(false);
        bag.Ch_2_Image[9].color = new Color(0, 0, 0 / 255);

        //가방 - 하레이스 정보
        bag.Ch_Inform_Select_3[0].SetActive(false);//열림
        bag.Ch_Inform_Select_3[1].SetActive(true);//닫힘

        bag.Ch_3_Text[0].SetActive(true);//1
        bag.Ch_3_Text[1].SetActive(false);
        bag.Ch_3_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[2].SetActive(true);//2
        bag.Ch_3_Text[3].SetActive(false);
        bag.Ch_3_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[4].SetActive(true);//3
        bag.Ch_3_Text[5].SetActive(false);
        bag.Ch_3_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[6].SetActive(true);//4
        bag.Ch_3_Text[7].SetActive(false);
        bag.Ch_3_Image[3].color = new Color(0, 0, 0 / 255);

        //가방 - 루시세리나 정보
        bag.Ch_Inform_Select_4[0].SetActive(false);//열림
        bag.Ch_Inform_Select_4[1].SetActive(true);//닫힘

        bag.Ch_4_Text[0].SetActive(true);//1
        bag.Ch_4_Text[1].SetActive(false);
        bag.Ch_4_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[2].SetActive(true);//2
        bag.Ch_4_Text[3].SetActive(false);
        bag.Ch_4_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[4].SetActive(true);//3
        bag.Ch_4_Text[5].SetActive(false);
        bag.Ch_4_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[6].SetActive(true);//4
        bag.Ch_4_Text[7].SetActive(false);
        bag.Ch_4_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[8].SetActive(true);//4
        bag.Ch_4_Text[9].SetActive(false);
        bag.Ch_4_Image[4].color = new Color(0, 0, 0 / 255);

        //가방 - 마탑주 정보
        bag.Ch_Inform_Select_5[0].SetActive(false);//열림
        bag.Ch_Inform_Select_5[1].SetActive(true);//닫힘

        bag.Ch_5_Text[0].SetActive(true);//1
        bag.Ch_5_Text[1].SetActive(false);
        bag.Ch_5_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[2].SetActive(true);//2
        bag.Ch_5_Text[3].SetActive(false);
        bag.Ch_5_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[4].SetActive(true);//3
        bag.Ch_5_Text[5].SetActive(false);
        bag.Ch_5_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[6].SetActive(true);//4
        bag.Ch_5_Text[7].SetActive(false);
        bag.Ch_5_Image[3].color = new Color(0, 0, 0 / 255);

        //가방 - 아이젤 정보
        bag.Ch_Inform_Select_6[0].SetActive(false);//열림
        bag.Ch_Inform_Select_6[1].SetActive(true);//닫힘

        bag.Ch_6_Text[0].SetActive(true);//1
        bag.Ch_6_Text[1].SetActive(false);
        bag.Ch_6_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[2].SetActive(true);//2
        bag.Ch_6_Text[3].SetActive(false);
        bag.Ch_6_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[4].SetActive(true);//3
        bag.Ch_6_Text[5].SetActive(false);
        bag.Ch_6_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[6].SetActive(true);//4
        bag.Ch_6_Text[7].SetActive(false);
        bag.Ch_6_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[8].SetActive(true);//3
        bag.Ch_6_Text[9].SetActive(false);
        bag.Ch_6_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[10].SetActive(true);//4
        bag.Ch_6_Text[11].SetActive(false);
        bag.Ch_6_Image[5].color = new Color(0, 0, 0 / 255);

        //등장인물
        ch.Ch_Hide[0].SetActive(true);//렌
        ch.Ch_Hide[2].SetActive(true);//아이젤
        ch.Ch_Hide[3].SetActive(true);//하레이스
        ch.Ch_Hide[4].SetActive(true);//루시세리나
        ch.Ch_Hide[5].SetActive(true);//아자르
        ch.Ch_Hide[6].SetActive(true);//리베나

        ch.Two.SetActive(false);//렌
        ch.Four.SetActive(false);//아이젤
        ch.Five.SetActive(false);//하레이스
        ch.Six.SetActive(false);//루시세리나
        ch.Seven.SetActive(false);//아자르
        ch.Eight.SetActive(false);//리베나

        //아이네 - 성인일 때와,악마 버전
        ch.One_Ch_Inside_1[2].SetActive(true);//컸을 때 못보는거
        ch.One_Ch_Inside_1[3].SetActive(false);//컸을 때 보는거
        ch.One_Ch_Inside_1[4].SetActive(true);//전생 못보는거
        ch.One_Ch_Inside_1[5].SetActive(false);//전생 보는거
        ch.One_Ch_Inside_1[6].SetActive(false);//전생 보는거

        //렌 - 정체 밝혀질 때
        ch.One_Ch_Inside_2[0].SetActive(true);//못보는거
        ch.One_Ch_Inside_2[1].SetActive(false);//보는거

        //진 - 성인일 때와, 정체 밝혀질 때
        ch.One_Ch_Inside_3[0].SetActive(true);//못보는거
        ch.One_Ch_Inside_3[1].SetActive(false);//보는거
        ch.One_Ch_Inside_3[2].SetActive(true);// 못보는거
        ch.One_Ch_Inside_3[3].SetActive(false);// 보는거

        //아이젤 - 성인 때
        ch.One_Ch_Inside_4[0].SetActive(true);//못보는거
        ch.One_Ch_Inside_4[1].SetActive(false);//보는거

        //루시세리나 - 눈떴다
        ch.One_Ch_Inside_6[0].SetActive(true);//못보는거
        ch.One_Ch_Inside_6[1].SetActive(false);//보는거

        Will_Show[1].SetActive(false);
    }
}

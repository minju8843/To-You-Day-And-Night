using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bag : MonoBehaviour
{
    public B_Button b_btn;

    //캐릭터 정보 모음
    public GameObject[] Ch_Inform_Select_1;//아이네
    public GameObject[] Ch_Inform_Select_2;//진
    public GameObject[] Ch_Inform_Select_3;//하레이스
    public GameObject[] Ch_Inform_Select_4;//루시세리나
    public GameObject[] Ch_Inform_Select_5;//마탑주
    public GameObject[] Ch_Inform_Select_6;//아이젤


    public GameObject[] Collection;
    public GameObject bag;

    public Animator bag_anim;
    
    public Animator[] Inside_anim;
    public GameObject[] Collection_Inside;

    public RectTransform[] bag_slider;
    public RectTransform[] inside_Slider;//컨테이너

    public Image[] Ch_1_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    //Ch_1는 0 ~ 5까지 있음
    public GameObject[] Ch_1_Text;//인물 정보 안의 글씨 등장하게 할 것인지
    //Ch_1는 0 ~ 11까지 있음

    public Image[] Ch_2_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    public GameObject[] Ch_2_Text;//인물 정보 안의 글씨 등장하게 할 것인지

    public Image[] Ch_3_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    public GameObject[] Ch_3_Text;//인물 정보 안의 글씨 등장하게 할 것인지

    public Image[] Ch_4_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    public GameObject[] Ch_4_Text;//인물 정보 안의 글씨 등장하게 할 것인지

    public Image[] Ch_5_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    public GameObject[] Ch_5_Text;//인물 정보 안의 글씨 등장하게 할 것인지

    public Image[] Ch_6_Image;//인물 정보 안의 회색 이미지 색깔 바꿀 거
    public GameObject[] Ch_6_Text;//인물 정보 안의 글씨 등장하게 할 것인지

    //여기부터는 물건 정보에 대한 이야기
    //public RectTransform bag_Obj_slider;

    public GameObject[] Obj_Inform_Select_1;//구슬 //열림, 닫힘
    public GameObject[] Obj_Inform_Select_2;//장갑 //열림, 닫힘

    public GameObject[] Show_Inside_Object;//안의 내용물()

    public Animator[] Obj_Inside_Black_anim;//안에 검은 거
    public Animator[] Obj_Inform_Text_anim;//안에 텍스트


    public void Start()
    {
        //검은 장갑 닫기
        Obj_Inform_Select_2[0].SetActive(false);//열림
        Obj_Inform_Select_2[1].SetActive(true);//닫힘


        // <열리고 닫히는거 - 이거는 이후 저장하는 거 하면 위치 변경될 예정>

        //진
        Ch_Inform_Select_2[0].SetActive(false);//열림
        Ch_Inform_Select_2[1].SetActive(true);//닫힘
        //하레이스
        Ch_Inform_Select_3[0].SetActive(false);//열림
        Ch_Inform_Select_3[1].SetActive(true);//닫힘
        //루시세리나
        Ch_Inform_Select_4[0].SetActive(false);//열림
        Ch_Inform_Select_4[1].SetActive(true);//닫힘
        //마탑주
        Ch_Inform_Select_5[0].SetActive(false);//열림
        Ch_Inform_Select_5[1].SetActive(true);//닫힘
        //아이젤
        Ch_Inform_Select_6[0].SetActive(false);//열림
        Ch_Inform_Select_6[1].SetActive(true);//닫힘



        //bag.SetActive(false);
        Collection[1].SetActive(false);//인물이 1
        Collection[0].SetActive(true);   //물건이0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);

        //아이네
        for(int i=0; i< Ch_1_Image.Length; i++)
        {
            Ch_1_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for(int i=0; i< Ch_1_Text.Length/2; i++)
        {
            Ch_1_Text[i*2].SetActive(true);
        }

        for (int i = 0; i < Ch_1_Text.Length/2; i++)
        {
            Ch_1_Text[i * 2 + 1].SetActive(false);
        }

        //진
        for (int i = 0; i < Ch_2_Image.Length; i++)
        {
            Ch_2_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_2_Text.Length / 2; i++)
        {
            Ch_2_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_2_Text.Length / 2; i++)
        {
            Ch_2_Text[i * 2 + 1].SetActive(false);
        }

        //하레이스
        for (int i = 0; i < Ch_3_Image.Length; i++)
        {
            Ch_3_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_3_Text.Length / 2; i++)
        {
            Ch_3_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_3_Text.Length / 2; i++)
        {
            Ch_3_Text[i * 2 + 1].SetActive(false);
        }

        //루시세리나
        for (int i = 0; i < Ch_4_Image.Length; i++)
        {
            Ch_4_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_4_Text.Length / 2; i++)
        {
            Ch_4_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_4_Text.Length / 2; i++)
        {
            Ch_4_Text[i * 2 + 1].SetActive(false);
        }

        //렌
        for (int i = 0; i < Ch_5_Image.Length; i++)
        {
            Ch_5_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_5_Text.Length / 2; i++)
        {
            Ch_5_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_5_Text.Length / 2; i++)
        {
            Ch_5_Text[i * 2 + 1].SetActive(false);
        }

        //아이젤
        for (int i = 0; i < Ch_6_Image.Length; i++)
        {
            Ch_6_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_6_Text.Length / 2; i++)
        {
            Ch_6_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_6_Text.Length / 2; i++)
        {
            Ch_6_Text[i * 2 + 1].SetActive(false);
        }

        //물건 내용 클릭했을 때, 나올 검은 창과 글씨 들어있는거 비활성
        Show_Inside_Object[0].SetActive(false);
        Show_Inside_Object[1].SetActive(false);

    }


    public void Go_Glass_Bead()
    {
        //유리구슬
        StartCoroutine(Glass_Bead());
        IEnumerator Glass_Bead()
        {
            Show_Inside_Object[0].SetActive(true);
            Obj_Inside_Black_anim[0].SetTrigger("On");
            Obj_Inform_Text_anim[0].SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);

            Debug.Log("이거 되는지 확인2");
        }

    }

    public void Go_Back_Glass_Bead()
    {
        //유리구슬에서 다시 선택으로
        StartCoroutine(Back_Glass_Bead());
        IEnumerator Back_Glass_Bead()
        {
            Obj_Inside_Black_anim[0].SetTrigger("Off");
            Obj_Inform_Text_anim[0].SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Show_Inside_Object[0].SetActive(false);
            Debug.Log("이거 되는지 확인");
        }
    }

    public void Go_Black_Gloves()
    {
        //장갑
        StartCoroutine(Black_Gloves());
        IEnumerator Black_Gloves()
        {
            Show_Inside_Object[1].SetActive(true);
            Obj_Inside_Black_anim[1].SetTrigger("On");
            Obj_Inform_Text_anim[1].SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);

            Debug.Log("이거 되는지 확인2");
        }
    }

    public void Go_Back_Black_Gloves()
    {
        //장갑에서 다시 선택으로
        StartCoroutine(Back_Black_Gloves());
        IEnumerator Back_Black_Gloves()
        {
            Obj_Inside_Black_anim[1].SetTrigger("Off");
            Obj_Inform_Text_anim[1].SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Show_Inside_Object[1].SetActive(false);
            Debug.Log("이거 되는지 확인");
        }
    }



    public void Go_Bag()
    {
        b_btn.Hide_Bty();//0723추가

        bag.SetActive(true);
        bag_anim.SetTrigger("Go_Left");

        bag_slider[0].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

        bag_slider[1].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[1].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

        Collection[1].SetActive(false);//인물이 1
        Collection[0].SetActive(true);   //물건이0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);
    }

        //아이네
        public void Go_1_Inside()
    {
        Inside_anim[0].SetTrigger("Go_Left");

        inside_Slider[0].offsetMin = new Vector2(0, -767.9815f);//left, bottom
        inside_Slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

    }

    public void Go_Back_1()
    {
        Inside_anim[0].SetTrigger("Go_Right");
    }

    //진
    public void Go_2_Inside()
    {
        Inside_anim[1].SetTrigger("Go_Left");

        inside_Slider[1].offsetMin = new Vector2(0, -1799.048f);//left, bottom
        inside_Slider[1].offsetMax = new Vector2(0, -6.103516e-05f);//-right, -top

    }

    public void Go_Back_2()
    {
        Inside_anim[1].SetTrigger("Go_Right");
    }

    //하레이스
    public void Go_3_Inside()
    {
        Inside_anim[2].SetTrigger("Go_Left");

        inside_Slider[2].offsetMin = new Vector2(0, -245.0295f);//left, bottom
        inside_Slider[2].offsetMax = new Vector2(0, -0.0004959106f);//-right, -top

    }

    public void Go_Back_3()
    {
        Inside_anim[2].SetTrigger("Go_Right");
    }

    //루시세리나
    public void Go_4_Inside()
    {
        Inside_anim[3].SetTrigger("Go_Left");

        inside_Slider[3].offsetMin = new Vector2(0, -514.2539f);//left, bottom
        inside_Slider[3].offsetMax = new Vector2(0, -0.0001525879f);//-right, -top

    }

    public void Go_Back_4()
    {
        Inside_anim[3].SetTrigger("Go_Right");
    }

    //렌
    public void Go_5_Inside()
    {
        Inside_anim[4].SetTrigger("Go_Left");

        inside_Slider[4].offsetMin = new Vector2(0, -261.906f);//left, bottom
        inside_Slider[4].offsetMax = new Vector2(0, 0f);//-right, -top

    }

    public void Go_Back_5()
    {
        Inside_anim[4].SetTrigger("Go_Right");
    }

    //아이젤
    public void Go_6_Inside()
    {
        Inside_anim[5].SetTrigger("Go_Left");

        inside_Slider[5].offsetMin = new Vector2(0, -767.9815f);//left, bottom
        inside_Slider[5].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

    }

    public void Go_Back_6()
    {
        Inside_anim[5].SetTrigger("Go_Right");
    }

    public void Go_Back_Main()
    {
        //bag.SetActive(false);
        bag_anim.SetTrigger("Go_Right");
    }

    public void Go_Ch_Information()
    {
        Collection[1].SetActive(true);//인물이 1
        Collection[0].SetActive(false);   //물건이0

        Collection_Inside[1].SetActive(true);
        Collection_Inside[0].SetActive(false);

        bag_slider[0].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top
    }

    public void Go_Obj_Information()
    {
        Collection[1].SetActive(false);//인물이 1
        Collection[0].SetActive(true);   //물건이0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);

        bag_slider[1].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[1].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top
    }
}

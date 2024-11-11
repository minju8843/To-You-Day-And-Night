using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//저장을 위해 새로 추가함
public class Text_Data
{
    public int Text_Index;
}

public class Main_Story_S : MonoBehaviour
{
    public B_Button b_btn;

    public GameObject[] text;
    public int Default_Text_Count = 0;
    public int Text_Count;
    public int Current_Text_Count;


    public GameObject Aine_X_Button;//챕터 1한정
    public GameObject Aine_Touch_Start;
    public Animator Aine_Size_Up_Down;
    public Animator Main_Story_Go;

    public GameObject Aine_Fade_Obj;
    public Fade fade;

    public Main_Stroy_1 main_story1;
    public M_S_1_1 m_s_1_1;
    public M_S_1_2 m_s_1_2;

    public Main_Stroy_2 main_story2;
    public Side_Story side_story2;

    //public Recent_Key save_key;


    //아이네 있는 책 버튼 누르면 오브젝트 활성화하고 점점 커지는 애니메이션 실행

    //애니메이션 실행 후, X하고 시작 버튼 누르는 거 활성화하기

    //아이네 누르면 챕터 1의 20화까지 쭉 나열된 거 보이고
    //챕터의 화수 누르면 해당 화수로 바로 들어가도록(페이드 없음)
    //해당 화수의 뒤로가기 누르면 챕터 1 화수 선택지로 돌아가도록

    //챕터1 화수 선택시, 컨테이너 위치는 초기화
    //왼: -6.103516e-05  위: 0.0002441406
    //오른쪽: 6.103516e-05 아래: -2671.605

    //챕터 1 화수 적힌 것 보여주기
    //public GameObject Ch_1;
    public RectTransform Container;

    //아직 개발중입니당 화면
    public GameObject[] Not_Open;

    //챕터 선택하는 것으로 돌아감
    public Animator Select_Main_Story_Ch;

    private void Start()
    {
        //Ch_1.SetActive(false);
        Not_Open[0].SetActive(false);
        Not_Open[1].SetActive(false);
    }


    public void OnEnable()
    {
        Load_Text();
    }

    public void Update()
    {
        Save_Text();
    }

    public void Save_Text()
    {
        Text_Data text_data = new Text_Data();
        text_data.Text_Index = Text_Count;

        string text_jsonData = JsonUtility.ToJson(text_data);
        PlayerPrefs.SetString("Text_Data", text_jsonData);
        PlayerPrefs.Save();
    }

    public void Load_Text()
    {
        if (PlayerPrefs.HasKey("Text_Data"))
        {
            string Text_Index_jsonData = PlayerPrefs.GetString("Text_Data");
            Text_Data Text_Index_data = JsonUtility.FromJson<Text_Data>(Text_Index_jsonData);

            Text_Count = Text_Index_data.Text_Index;

            if(Text_Count==0)
            {
                text[0].SetActive(true);
                text[1].SetActive(false);
                text[2].SetActive(false);
            }

            else if(Text_Count == 1)
            {
                text[0].SetActive(false);
                text[1].SetActive(true);
                text[2].SetActive(false);
            }

            else
            {
                text[0].SetActive(false);
                text[1].SetActive(false);
                text[2].SetActive(true);
            }

        }

        else
        {
            Text_Count = Default_Text_Count;
            text[0].SetActive(true);
            text[1].SetActive(false);
            text[2].SetActive(false);
            Debug.Log("메인1");
        }
    }

    public void Reset_Text()
    {
        PlayerPrefs.DeleteKey("Text_Data");
        PlayerPrefs.Save();
        Text_Count = Default_Text_Count;

        text[0].SetActive(true);
        text[1].SetActive(false);
        text[2].SetActive(false);
    }

        public void Select_Ch()
    {
        //챕터 선택하는 곳으로 돌아감
        Select_Main_Story_Ch.SetTrigger("Go_Right");//
    }

    public void Go_Main_Story_1()
    {
        Main_Story_Go.SetTrigger("Go_Left");

        b_btn.Hide_Bty();//0723추가
    }

    public void Go_Main()
    {
        Main_Story_Go.SetTrigger("Go_Right");
    }

    public void Main_Aine_Story_X()
    {//X누르면 휴오쟌 책 있는 그림 다시 줄어들게 하기
        Aine_Size_Up_Down.SetTrigger("Size_Down");
    }

    public void Aine_Go_Size_Up()
    {
        Aine_Size_Up_Down.SetTrigger("Size_Up");
    }

    public void Aine_Go_Back_Select_Side_Story()
    {
        main_story1.Go_Main();
    }

    public void Main_Story_1_Fade_In()
    {
        fade.Fade_BE.SetActive(true);
        fade.Fade_In_Out.SetTrigger("Go_Black");

        StartCoroutine(Show_Main());
        IEnumerator Show_Main()
        {
            yield return new WaitForSeconds(1.0f);
            Aine_Size_Up_Down.SetTrigger("Size_Down");

            //Ch_1.SetActive(true);//메인스토리 화수 나타남
            Select_Main_Story_Ch.SetTrigger("Go_Left");

            //왼: -6.103516e-05  위: 0.0002441406
            //오른쪽: 6.103516e-05 아래: -2671.605
            Container.offsetMin = new Vector2(-6.103516e-05f, -2671.605f);//left, bottom
            Container.offsetMax = new Vector2(-6.103516e-05f, -0.0002441406f);//-right, -top
        }

        StartCoroutine(Go_Main_Black_Empty());

        IEnumerator Go_Main_Black_Empty()
        {
            yield return new WaitForSeconds(1.5f);
            fade.Fade_In_Out.SetTrigger("Go_Empty");
        }

        StartCoroutine(Bye_Fade());
        IEnumerator Bye_Fade()
        {
            yield return new WaitForSeconds(3.5f);
            fade.Fade_BE.SetActive(false);

        }
    }

    //메인 스토리 1화
    public void Go_Ch_1_1_Story()
    {
        b_btn.Hide_Bty();//0723추가;

        if (text[0].activeSelf==true)
        {
            main_story1.Go_Main_Story_1();//메인스토리 나타나는 것
            Debug.Log("1화 나와라");
        }
        

        else if (text[1].activeSelf == true)
        {
            main_story2.Go_Main_Story_2();//메인스토리 나타나는 것
            Debug.Log("2화 나와라");
        }

        else if (text[2].activeSelf == true)
        {
            side_story2.Go_Side_Story();//사이드 스토리 나타나는 것
        }
        Debug.Log("하소연 나와라");
    }

    //메인스토리 2화
    /*public void Go_Ch_2_1_Story()
    {
        if (save_key.Save_Story[1].activeSelf == true)
        {
            main_story2.Go_Main_Story_2();//메인스토리 나타나는 것
        }
        Debug.Log("2화 나와라");
    }

    //사이드 스토리  - 하소연
    public void Go_Side_Story()
    {
        if (save_key.Save_Story[2].activeSelf == true)
        {
            side_story2.Go_Side_Story();//사이드 스토리 나타나는 것
        }
        Debug.Log("하소연 나와라");
    }*/

    public void Go_Ch_1_2()//2화로 가는 버튼 눌렀을 때
    {
        if(m_s_1_1.Page_Count_29 >= m_s_1_1.Page_29.Length || m_s_1_2.Page_Count_29 >= m_s_1_1.Page_29.Length)
        {
            //만약 현재 1화를 다 본 상태라면
            //이전화를 감상해주세요 보이지 않도록
            Not_Open[1].SetActive(false);
            main_story2.Go_Main_Story_2();
        }

        else
        {
            //만약 현재 1화를 다 보지 않은 상태라면
            //이전화를 감상해주세요 보이도록
            Not_Open[1].SetActive(true);
        }
    }

    public void Closed_Ch_1_2()//이전화를 감상해주세요 감추기
    {
        Not_Open[1].SetActive(false);
    }


    public void Go_Ch_Else_Story()
    {
        //아직 개발중입니다! 적힌 오브젝트 나오기
        Not_Open[0].SetActive(true);
    }

    public void Go_Ch_Else_Story_Ok()
    {
        //아직 개발중입니다! 적힌 오브젝트 확인 버튼 나왔을 때 없애기
        Not_Open[0].SetActive(false);
    }
}

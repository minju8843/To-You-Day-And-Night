using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Select_Ch
{//사용자 설정 데이터를 저장하는 클래스
    public int Aine_Index;
    public int Ren_Index;
    public int Jin_Index;
    public int Aiselle_Index;

}


public class Select_Ch : MonoBehaviour
{
    public B_Button b_btn;//0723 추가

    public Animator Black;
    public Animator Size;


    public GameObject Ch_Select;


    public RectTransform Jin_T;
    public RectTransform Aine_T;
    public RectTransform Ren_T;
    public RectTransform Aiselle_T;//아이젤

    public Button Jin;
    public Button Aine;
    public Button Ren;
    public Button Aiselle;//아이젤

    public Image Jin_Img;
    public Image Aine_Img;
    public Image Ren_Img;
    public Image Aiselle_Img;

    public GameObject Jin_Main;
    public GameObject Aine_Main;
    public GameObject Ren_Main;
    public GameObject Aiselle_Main;//아이젤


    public Animator Aine_Anim;//모바일에서는 호버에 문제가 생겨서 이걸로 다시
    public Animator Jin_Anim;
    public Animator Ren_Anim;
    public Animator Aiselle_Anim;

    //저장 기능을 위해...
    public int Aine_Default_Count = 0;
    public int Aine_Count;
    public int Current_Aine_Count;

    public int Jin_Default_Count = 0;
    public int Jin_Count;
    public int Current_Jin_Count;

    public int Ren_Default_Count = 0;
    public int Ren_Count;
    public int Current_Ren_Count;

    public int Aiselle_Default_Count = 0;
    public int Aiselle_Count;
    public int Current_Aiselle_Count;

    public void Select_Ch_ResetSettings()
    {
        PlayerPrefs.DeleteKey("Jin_Picture");
        PlayerPrefs.Save();
        Jin_Count = Jin_Default_Count;

        PlayerPrefs.DeleteKey("Ren_Picture");
        PlayerPrefs.Save();
        Ren_Count = Ren_Default_Count;

        PlayerPrefs.DeleteKey("Aine_Picture");
        PlayerPrefs.Save();
        Aine_Count = Aine_Default_Count;

        PlayerPrefs.DeleteKey("Aiselle_Picture");
        PlayerPrefs.Save();
        Aiselle_Count = Aiselle_Default_Count;

        if (Aiselle_Count == 0 && Jin_Count == 0 && Ren_Count == 0 && Aine_Count == 0)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

    }

    private void Start()
    {
        Ch_Select.SetActive(false);
        //일단 캐릭터들의 현재 스케일이 원래대로여야 함.
        /*Aine_Anim.SetTrigger("Stay");
        Jin_Anim.SetTrigger("Stay");
        Ren_Anim.SetTrigger("Stay");
        Aiselle_Anim.SetTrigger("Stay");
        */
        //1일때는 선택만 되었을 때
        //2일 때는 선택하고 버튼 눌렀을 때

    }

    public void OnEnable()
    {
        Aine_LoadSettings();
        Jin_LoadSettings();
        Ren_LoadSettings();
        Aiselle_LoadSettings();

        if (Aine_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            //나머지가 0이나 1일 경우

            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if (Ren_Count == 2 && (Aine_Count == 0 || Aine_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Jin_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Aine_Count == 0 || Aine_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Aiselle_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aine_Count == 0 || Aine_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }

        if(Aiselle_Count == 0 && Jin_Count == 0 && Ren_Count == 0 && Aine_Count == 0)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if ((Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aine_Count == 0 || Aine_Count == 1)&& (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }
    }

    public void Update()
    {
        Ch_Select_SaveSettings();

        Current_Aiselle_Count = Aiselle_Count;
        Current_Aine_Count = Aine_Count;
        Current_Ren_Count = Ren_Count;
        Current_Jin_Count = Jin_Count;
    }

    private void FixedUpdate()
    {
        /*if (Aine_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if (Ren_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Jin_Count == 1)
        {
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Aiselle_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }*/
    }


    public void Ch_Select_SaveSettings()
    {
        //아이네
        GameData_Select_Ch Aine_data = new GameData_Select_Ch();
        Aine_data.Aine_Index = Aine_Count;

        string Aine_jsonData = JsonUtility.ToJson(Aine_data);
        PlayerPrefs.SetString("Aine_Picture", Aine_jsonData);
        PlayerPrefs.Save();

        //진
        GameData_Select_Ch Jin_data = new GameData_Select_Ch();
        Jin_data.Jin_Index = Jin_Count;

        string Jin_jsonData = JsonUtility.ToJson(Jin_data);
        PlayerPrefs.SetString("Jin_Picture", Jin_jsonData);
        PlayerPrefs.Save();

        //렌
        GameData_Select_Ch Ren_data = new GameData_Select_Ch();
        Ren_data.Ren_Index = Ren_Count;

        string Ren_jsonData = JsonUtility.ToJson(Ren_data);
        PlayerPrefs.SetString("Ren_Picture", Ren_jsonData);
        PlayerPrefs.Save();

        //아이젤
        GameData_Select_Ch Aiselle_data = new GameData_Select_Ch();
        Aiselle_data.Aiselle_Index = Aiselle_Count;

        string Aiselle_jsonData = JsonUtility.ToJson(Aiselle_data);
        PlayerPrefs.SetString("Aiselle_Picture", Aiselle_jsonData);
        PlayerPrefs.Save();
    }

    public void Aine_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Aine_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Aine_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Aine_Count = data.Aine_Index;
            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Aine_Count = Aine_Default_Count;
            //Aine_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Ren_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Ren_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Ren_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Ren_Count = data.Ren_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Ren_Count = Ren_Default_Count;
            //Ren_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Aiselle_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Aiselle_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Aiselle_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Aiselle_Count = data.Aiselle_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Aiselle_Count = Aiselle_Default_Count;
            //Aiselle_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Jin_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Jin_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Jin_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Jin_Count = data.Jin_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Jin_Count = Jin_Default_Count;
            //Jin_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }


    public void Select_Character()//캐릭터 선택하면 그 캐릭터 메뉴에 들어옴
    {

        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Black.SetTrigger("Off");
            Size.SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Ch_Select.SetActive(false);
            Debug.Log("이거 되는지 확인");
        }
        //Ch_Select.SetActive(false);



        if (Mathf.Approximately(Aine_Img.color.r, 128 / 225f) && Mathf.Approximately(Aine_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Aine_Img.color.b, 96 / 225f))
        {
            //아이네가 선택되었다면
            Aine_Count =2;

            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Ren_Img.color.r, 128 / 225f) && Mathf.Approximately(Ren_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Ren_Img.color.b, 96 / 225f))
        {
            Ren_Count = 2;

            //렌이 선택되었다면
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Jin_Img.color.r, 128 / 225f) && Mathf.Approximately(Jin_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Jin_Img.color.b, 96 / 225f))
        {
            Jin_Count = 2;

            //진이 선택되었다면
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Aiselle_Img.color.r, 128 / 225f) && Mathf.Approximately(Aiselle_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Aiselle_Img.color.b, 96 / 225f))
        {
            Aiselle_Count = 2;

            //아이젤이 선택되었다면
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }
    }

    public void Go_Select_Color()//버튼 아무것도 누르지 않았을 때, 원래 색으로 유지
    {
        b_btn.Hide_Bty();//0723추가


        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Ch_Select.SetActive(true);
            Black.SetTrigger("On");
            Size.SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);
            
            
            Debug.Log("이거 되는지 확인2");
        }

        //캐릭터 선택 창으로 들어가는 거
        //Black.SetTrigger("On");
        //Size.SetTrigger("Up");


        Aine_Count = 0;
        Jin_Count = 0;
        Ren_Count = 0;
        Aiselle_Count = 0;

        //Ch_Select.SetActive(true);

        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;
    }

    public void Go_Back()
    {

        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Black.SetTrigger("Off");
            Size.SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);
            
            Ch_Select.SetActive(false);
            Debug.Log("이거 되는지 확인");
        }

        

        
        //메인 화면에 현재 들어와 있는 거를 그래도 적용하면서
        //해당 캐릭터의 인덱스를 2로 설정
        //그리고 애니메이션 다 스테이로 설정

        if(Aine_Main.activeSelf==true)
        {
            Aine_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
           // Aine_Anim.SetTrigger("Stay");
           // Jin_Anim.SetTrigger("Stay");
           // Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Jin_Main.activeSelf == true)
        {
            Jin_Count = 2;
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Ren_Main.activeSelf == true)
        {
            Ren_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Aiselle_Main.activeSelf == true)
        {
            Aiselle_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }


        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;
    }

    public void Coose_Jin()
    {

        //진을 눌렀을 때
        //카운트 1로 만들고
        //나머지 얘들 카운트 0으로 만들기

        //만약 이전에 하나 카운트가 1이었으면, 그걸 0으로 만들면서
        //크기 줄어드는 애니메이션 재생
        Jin_Count = 1;

        if(Ren_Count==1)
        {
            Jin_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Ren_Count = 0;
        }

        if (Aine_Count == 1)
        {
            Jin_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Jin_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 1)
        {
            Jin_Count = 1;
            Jin_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Jin_Count = 1;
            Jin_Anim.SetTrigger("Up");
        }


        //여기는 이전에 썼던 코드
        /*if(Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Ren_Anim.SetTrigger("Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)&&
            Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Jin_Anim.SetTrigger("Up");
        }*/


        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Jin_Img.color;

        Jin_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Jin = Aine_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //선택 시 버튼 색 바뀜

        //다른 건 원래 색으로 돌아옴
        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
        Jin.colors = color_Jin;


        //
        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;


        if (Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Jin1 = Jin.colors;
            color_Jin1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
            Jin.colors = color_Jin1;

            //


           /* Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);

            */
            

            //

            /*ColorBlock color_Ren = Ren.colors;
            color_Ren.highlightedColor = new Color(192, 176, 157, 225);
            Ren.colors = color_Ren;

            ColorBlock color_Aiselle = Aiselle.colors;
            color_Aiselle.highlightedColor = new Color(192, 176, 157, 225);
            Aiselle.colors = color_Aiselle;

            ColorBlock color_Aine = Aine.colors;
            color_Aine.highlightedColor = new Color(192, 176, 157, 225);
            Aine.colors = color_Aine;*/
        }


    }


    public void Coose_Aine()
    {
        Aine_Count = 1;

        if (Ren_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Debug.Log("렌이었다가 아이네 실행되냐?");
            Ren_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Debug.Log("진이었다가 아이네 실행되냐?");
            Jin_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Debug.Log("아이젤이었다가 아이네 실행되냐?");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 1
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aine_Count = 1;
            Aine_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aine_Count = 1;
            Aine_Anim.SetTrigger("Up");
        }

        /* if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Jin_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Ren_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Aiselle_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
             && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
             && Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
         {
             Aine_Anim.SetTrigger("Size_Up");
         }*/

        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Aine_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //선택 시 버튼 색 바뀜

        //다른 건 원래 색으로 돌아옴
        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
        Aine.colors = color_Aine;


        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;


        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;



        if (Mathf.Approximately(ImageColor_Jin.r, 255/225f)&& Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) && 
            Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Aine1 = Aine.colors;
            color_Aine1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
            Aine.colors = color_Aine1;

            /*ColorBlock color_Jin = Jin.colors;
            color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);//이게 하이라이트 색
            Jin.colors = color_Jin;

            ColorBlock color_Ren = Ren.colors;
            color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
            Ren.colors = color_Ren;

            ColorBlock color_Aiselle = Aiselle.colors;
            color_Aiselle.highlightedColor = new Color(192/ 225f, 176 / 225f, 157 / 225f, 225 / 225f);
            Aiselle.colors = color_Aiselle;*/
        }

        
    }

    

        public void Coose_Ren()
    {
        Ren_Count = 1;

        if (Aine_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Jin_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 1 && Jin_Count == 0)
        {
            Ren_Count = 1;
            Ren_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Ren_Count = 1;
            Ren_Anim.SetTrigger("Up");
        }

        /*if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Jin_Anim.SetTrigger("Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Ren_Anim.SetTrigger("Up");
        }*/



        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Ren_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //선택 시 버튼 색 바뀜

        //다른 건 원래 색으로 돌아옴
        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
        Ren.colors = color_Ren;

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;

        if (Mathf.Approximately(ImageColor_Jin.r, 255 / 225f) && Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aine.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Ren1 = Ren.colors;
            color_Ren1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
            Ren.colors = color_Ren1;

        }


    }

    public void Coose_Aiselle()
    {
        Aiselle_Count = 1;

        if (Aine_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Jin_Count = 0;
        }

        if (Ren_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Ren_Count = 0;
        }

        if (Aiselle_Count == 1 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aiselle_Count = 1;
            Aiselle_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aiselle_Count = 1;
            Aiselle_Anim.SetTrigger("Up");
        }

        /*if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Jin_Anim.SetTrigger("Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if (Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Ren_Anim.SetTrigger("Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if(Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f) && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Up");
        }*/



        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Aiselle_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //선택 시 버튼 색 바뀜

        //다른 건 원래 색으로 돌아옴
        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
        Aiselle.colors = color_Aiselle;

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;


        if (Mathf.Approximately(ImageColor_Jin.r, 255 / 225f) && Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aine.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f))
        {
            ColorBlock color_Aiselle1 = Aiselle.colors;
            color_Aiselle1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//이건 눌렸을 때 색임
            Aiselle.colors = color_Aiselle1;

   
        }


    }


}

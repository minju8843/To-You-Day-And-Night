using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//저장을 위해 새로 추가함

public class GameData_Finding0
{
    //현재 몇 번째 탐색중인지 - 아이네 방인지, 마탑 밖인지, 마탑 안인지
    //public int TouchAble_Index;
    public int Sentences_0_Index;//새로 추가 0720


}

public class Find_Something : MonoBehaviour
{
    public GameObject Typ_Dia_Total;

    public GameObject Name;//이름

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find_s;
    public Find_Something1 find_s1;

    public Butt_Ch sug;//제시하기 버튼 비활성화 시키기 위해 작성
    public Item item;

    //탐색 시작 후 보일 버튼
    public GameObject btn_Collection;//버튼 다 모여있는 부모 오브젝트
    public GameObject[] touch_able_b;

    //탐색 시작 후 보일 버튼 저장하려고 만든 거 
    //현재 몇 번째 탐색중인지 - 아이네 방인지, 마탑 밖인지, 마탑 안인지
    //public int Default_TouchAble = 0; // 현재 어디까지 진행되었는지
    //public int TouchAble;//리셋되어 디폴트 될 때
    //public int Current_TouchAble; // 현재 

    public GameObject[] Dia;//터치한 오브젝트에 대한 말풍선들
    public Text[] text;//터치한 오브젝트에 대한 말풍선 내부 텍스트들

    //금색 패에 대한 정보 타이핑 관련
   // public string[] sentences_0; // 표시될 대화 문장들
    //public int Sentences_0;//리셋되어 디폴트 될 때
    //private bool isTyping_0 = false; // 타이핑 중인지 여부

    //금색 패에 대한 정보 타이핑 관련
    public string[] sentences_0; // 표시될 대화 문장들
    public int Sentences_0 = 0;//리셋되어 디폴트 될 때
    private bool isTyping_0 = false; // 타이핑 중인지 여부

    //문장 저장
    public int Default_Sentences_0 = 0; // 현재 어디까지 진행되었는지
    public int Current_Sentences_0 = 0; // 현재 문장의 인덱스

    //거울에 대한 정보 타이핑 관련
    public string[] sentences_1; // 표시될 대화 문장들
    public int Sentences_1;//리셋되어 디폴트 될 때
    private bool isTyping_1 = false; // 타이핑 중인지 여부

    //컵 있는 책상에 대한 정보 타이핑 관련
    public string[] sentences_2; // 표시될 대화 문장들
    public int Sentences_2;//리셋되어 디폴트 될 때
    private bool isTyping_2 = false; // 타이핑 중인지 여부

    //서랍에 대한 정보 타이핑 관련
    public string[] sentences_3; // 표시될 대화 문장들
    public int Sentences_3;//리셋되어 디폴트 될 때
    private bool isTyping_3 = false; // 타이핑 중인지 여부

    //의자에 대한 정보 타이핑 관련
    public string[] sentences_4; // 표시될 대화 문장들
    public int Sentences_4;//리셋되어 디폴트 될 때
    private bool isTyping_4 = false; // 타이핑 중인지 여부

    //침대에 대한 정보 타이핑 관련
    public string[] sentences_5; // 표시될 대화 문장들
    public int Sentences_5;//리셋되어 디폴트 될 때
    private bool isTyping_5 = false; // 타이핑 중인지 여부

    //창문에 대한 정보 타이핑 관련
    public string[] sentences_6; // 표시될 대화 문장들
    public int Sentences_6;//리셋되어 디폴트 될 때
    private bool isTyping_6 = false; // 타이핑 중인지 여부


    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조

    void Start()
    {
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//일단 말풍선 다 비활성
            //터치하면 나오게 할 거니까
        }

        Name.SetActive(false);


        //새로 추가 0720
        if (Sentences_0 > 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }

            Name.SetActive(false);

            //sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 5;

            Sectences_Save_Settings();

             Debug.Log("몇 번째야" + Sentences_0);
        }

        //새로 추가
        else if (Sentences_0 == 0)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }

            Name.SetActive(false);




        }
    }

    public void Update()
    {


        //Debug.Log("몇 번째야" + Sentences_0);
        //새로 추가 

        if (Sentences_0 == 0 && typ.Sentences_1 > typ.sentences_1.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(true);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
       

            //Sectences_Save_Settings();

            Sentences_0 = 0;
            Sectences_Save_Settings();

            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
        }

        if (typ.Sentences_1 == 0)
        {
            Dia[0].SetActive(false);
            typ1.Dia.SetActive(false);
        }

        Current_Sentences_0 = Sentences_0;

        if (Sentences_0 == 0 && (typ.Bg[0].activeSelf == true || typ.Bg[2].activeSelf == true)
             && typ.Sentences_1 >= typ.sentences_1.Length
             && typ1.Sentences_1 < 1 && typ.Ch[3].activeSelf == false)
        {
            Dia[0].SetActive(false);
            typ1.Dia.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
            Debug.Log("너0720");
        }

        if (Sentences_0 == 0 && item.Item_Count == 4
            && typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true
             && Name.activeSelf == false && typ.Bg[2].activeSelf == false)
        {
            Dia[0].SetActive(false);
            typ1.Dia.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
            Debug.Log("너너0720");


            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

        if (Sentences_0 == 0 && typ.Bg[1].activeSelf == true && item.Item_Count == 4
            && typ.Sentences_1 >= typ.sentences_1.Length
            && Name.activeSelf == true && typ.Bg[2].activeSelf == false
            && (Dia[1].activeSelf == false && Dia[2].activeSelf == false&&
            Dia[6].activeSelf == false && Dia[4].activeSelf == false
            && Dia[5].activeSelf == false && Dia[6].activeSelf == false))
        {

            
            Dia[0].SetActive(true);
            Debug.Log("너너너0720");
            typ.Ch[3].SetActive(true);

            typ1.Dia.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0720 추가

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }


        if (Sentences_0 == 0 && item.Item_Count == 1)
        {
            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Name.SetActive(false);
            typ1.Dia.SetActive(false);

        }

        //체그
        //침대에서 탐색중인 말풍선이 등장하지 않을 때
        if (typ1.Sentences_1 >= typ1.sentences_1.Length && item.Item_Count == 1 && sug.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false &&
            Dia[5].activeSelf == false && Dia[6].activeSelf == false) && typ1.Sentences_1 < 1)/*&&
           (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
            && typ1.Sentences_1<1)*/
        {
            find_s.touch_able_b[0].SetActive(true);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);
            find_s.btn_Collection.SetActive(true);

            typ1.Dia.SetActive(false);
            //Debug.Log("이거냐? 0714");

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

        //침대에서 현재 탐색중인 말풍선이 나올 때
        if (typ1.Sentences_1 >= typ1.sentences_1.Length && item.Item_Count == 1 && sug.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            | Dia[4].activeSelf == true ||
            Dia[5].activeSelf == true || Dia[6].activeSelf == true) && typ1.Sentences_1 < 1)/*||
            (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true)
            && typ1.Sentences_1 < 1)*/
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);
            find_s.btn_Collection.SetActive(false);

            typ1.Dia.SetActive(false);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
            //Debug.Log("이거? 0714");
        }


        //예전거
        if (Sentences_1==1 || Sentences_1 == 2)
        {
            typ.Ch[2].SetActive(true);
            typ1.Dia.SetActive(false);
        }

        if (Sentences_1 == 3)
        {
            typ.Ch[2].SetActive(false);
            typ1.Dia.SetActive(false);
        }

        if (Sentences_0 == 1)
        {
            typ.Ch[3].SetActive(true);
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
            Dia[0].SetActive(true);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Sentences_0 = 1;
            Sectences_Save_Settings();

            typ1.Dia.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
        }

        if (Sentences_0 == 2)
        {
            typ.Ch[3].SetActive(true);
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
            Dia[0].SetActive(true);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Sentences_0 = 2;
            Sectences_Save_Settings();

            typ1.Dia.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
        }

        if (Sentences_0 ==3)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
            Dia[0].SetActive(true);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Sentences_0 = 3;
            Sectences_Save_Settings();

            typ1.Dia.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
        }

        if (Sentences_0 == 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Dia[0].SetActive(true);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Sentences_0 = 4;
            Sectences_Save_Settings();//새로 추가720

            typ1.Dia.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0720 추가
        }

        if (Sentences_0 > 4)
        {
          
            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);

            Sentences_0 = 5;

            Sectences_Save_Settings();//새로 추가720
        }


    }

    public void OnEnable()
    {
        Load_Sentences_0();//새로 추가0720

        //새로추가 0720
        if (Sentences_0 == 0 && (find_s1.Current_Sentences_0 < 0
           || typ.Current_Sentences_1 < typ.sentences_1.Length
           || typ1.Current_Sentences_1 < 0
           || Sentences_0 >= sentences_0.Length))
        {
            Name.SetActive(false);


            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }

        }

    }

    //새로 추가0720
    public void Reset_Settings()
    {
        find_s.touch_able_b[0].SetActive(false);
        find_s.touch_able_b[1].SetActive(false);
        find_s.touch_able_b[2].SetActive(false);
        find_s.touch_able_b[3].SetActive(false);

        PlayerPrefs.DeleteKey("find_Text_Data0");
        PlayerPrefs.Save();

        Sentences_0 = 0;

        Dia[0].SetActive(false);
        Dia[1].SetActive(false);
        Dia[2].SetActive(false);
        Dia[3].SetActive(false);
        Dia[4].SetActive(false);
        Dia[5].SetActive(false);
        Dia[6].SetActive(false);

        Name.SetActive(false);


        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }


    }

    //새로 추가 0720
    public void Load_Sentences_0()
    {
        if (PlayerPrefs.HasKey("find_Text_Data0"))
        {
            string jsonData = PlayerPrefs.GetString("find_Text_Data0");
            GameData_Finding0 data = JsonUtility.FromJson<GameData_Finding0>(jsonData);

            Sentences_0 = data.Sentences_0_Index;


            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);


            Name.SetActive(false);

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                if (Sentences_0 > 4)
                {
                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    Dia[0].SetActive(false);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);
                    Dia[4].SetActive(false);
                    Dia[5].SetActive(false);
                    Dia[6].SetActive(false);

                    Name.SetActive(false);

                    find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼

                    Sentences_0 = 5;//새로 추가720
                    Sectences_Save_Settings();//새로 추가720
                    //Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    find_s.Typ_Dia_Total.SetActive(true);//0720 추가

                }


                if (Sentences_0 <= 4)
                {

                    Dia[0].SetActive(true);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);
                    Dia[4].SetActive(false);
                    Dia[5].SetActive(false);
                    Dia[6].SetActive(false);

                    sug.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);

                    //Name.SetActive(true);


                    Sentences_0--;
                    Next_Text_0();
                    Sectences_Save_Settings();

                    Debug.Log("몇 번째야" + Sentences_0);
                }

            }

        }
        else
        {
            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);
            Dia[6].SetActive(false);


            Name.SetActive(false);

            Sentences_0 = 0;
            StartCoroutine(Show_B_Story());

            IEnumerator Show_B_Story()
            {

                yield return new WaitForSeconds(2.0f);
                Dia[0].SetActive(true);
                Dia[1].SetActive(false);
                Dia[2].SetActive(false);
                Dia[3].SetActive(false);
                Dia[4].SetActive(false);
                Dia[5].SetActive(false);
                Dia[6].SetActive(false);

                //StartTyping(); // 대화 시작
            }

            /*typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
            typ.Bg[6].SetActive(false);*/
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //문장들 저장
        GameData_Finding0 data = new GameData_Finding0();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data0", jsonData);
        PlayerPrefs.Save();


    }

    public void Choose_Obj_0()
    {
        typ.Ch[3].SetActive(true);

        Sentences_0 = 0;
        StartTyping_0();

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }
        
        Dia[0].SetActive(true);//0번째 말풍선만 활성화

        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
       

    }

    public void Choose_Obj_1()
    {
        Sentences_1 = 0;
        StartTyping_1();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[1].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
       
    }

    public void Choose_Obj_2()
    {
        Sentences_2 = 0;
        StartTyping_2();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
        
    }

    public void Choose_Obj_3()
    {
        Sentences_3 = 0;
        StartTyping_3();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
       
    }

    public void Choose_Obj_4()
    {
        Sentences_4 = 0;
        StartTyping_4();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[4].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
        
    }

    public void Choose_Obj_5()
    {
        Sentences_5= 0;
        StartTyping_5();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[5].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
    }

    public void Choose_Obj_6()
    {
        Sentences_6 = 0;
        StartTyping_6();

        // typ.Names.SetActive(true);//이름 쓰는 곳
        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[6].SetActive(true);//0번째 말풍선만 활성화
        touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
    }


    //만약 금색 패를 터치했을 때 0
    public void Next_Text_0()
    {
        typ.Ch[3].SetActive(true);

        Sectences_Save_Settings();

        if (isTyping_0)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_0();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_0();
        }
    }

    public void StartTyping_0()
    {
        typingCoroutine = StartCoroutine(TypeSentence_0(sentences_0[Sentences_0]));
    }

    public void NextSentence_0()
    {
        Sentences_0++;

        if (Sentences_0 < sentences_0.Length)
        {
            StartTyping_0();
            
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[0].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);


            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(true);//아이네 방 비활성
            typ.Bg[2].SetActive(false);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
           

            typ.Bg_0 = 1;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(false);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
            item.Item_Count = 4;
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            typ.Ch[3].SetActive(false);
            Name.SetActive(false);

            //touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            //아이템에 금색 패 추가
            //item.small_square[1].SetActive(true);
            //item.Item_Count = 1;

            //배경 바뀜에 따라 버튼 누를 수 있는 것도 달라짐
            touch_able_b[0].SetActive(false);
            touch_able_b[1].SetActive(false);
            touch_able_b[2].SetActive(false);
            touch_able_b[3].SetActive(false);



            typ1.Go_1_Typing();
            


            typ.Bg_0 =2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(true);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
         
            Debug.Log("배경 바뀌어라");


            item.Item_Count =1 ;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
          


            find_s.Typ_Dia_Total.SetActive(true);//0720 추가

        }

    }

    public void CompleteTyping_0()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[0].text = sentences_0[Sentences_0];
        isTyping_0 = false;
    }

    IEnumerator TypeSentence_0(string sentence)
    {
        isTyping_0 = true;
        text[0].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[0].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[0].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[0].text += ' ';
            }
        }

        isTyping_0 = false;
    }

    //만약 거울을 터치했을 때 1
    public void Next_Text_1()
    {
        if (isTyping_1)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_1();

        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_1();
        }
    }

    void StartTyping_1()
    {
        typingCoroutine = StartCoroutine(TypeSentence_1(sentences_1[Sentences_1]));
    }

    void NextSentence_1()
    {
        Sentences_1++;
        if (Sentences_1 < sentences_1.Length)
        {
            StartTyping_1();
        
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[1].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_1()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[1].text = sentences_1[Sentences_1];
        isTyping_1 = false;
    }

    IEnumerator TypeSentence_1(string sentence)
    {
        isTyping_1 = true;
        text[1].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[1].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[1].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[1].text += ' ';
            }
        }

        isTyping_1 = false;
    }

    //만약 컵 있는 책상을 터치했을 때 2
    public void Next_Text_2()
    {
        if (isTyping_2)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_2();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_2();
        }
    }

    void StartTyping_2()
    {
        typingCoroutine = StartCoroutine(TypeSentence_2(sentences_2[Sentences_2]));
    }

    void NextSentence_2()
    {
        Sentences_2++;
        if (Sentences_2 < sentences_2.Length)
        {
            StartTyping_2();
            
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[2].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

       
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_2()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[2].text = sentences_2[Sentences_2];
        isTyping_2 = false;
    }

    IEnumerator TypeSentence_2(string sentence)
    {
        isTyping_2 = true;
        text[2].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[2].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[2].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[2].text += ' ';
            }
        }

        isTyping_2 = false;
    }

    //만약 서랍을 터치했을 때 3
    public void Next_Text_3()
    {
        if (isTyping_3)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_3();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_3();
        }
    }

    void StartTyping_3()
    {
        typingCoroutine = StartCoroutine(TypeSentence_3(sentences_3[Sentences_3]));
    }

    void NextSentence_3()
    {
        Sentences_3++;
        if (Sentences_3 < sentences_3.Length)
        {
            StartTyping_3();
       
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[3].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

          
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_3()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[3].text = sentences_3[Sentences_3];
        isTyping_3 = false;
    }

    IEnumerator TypeSentence_3(string sentence)
    {
        isTyping_3 = true;
        text[3].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[3].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[3].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[3].text += ' ';
            }
        }

        isTyping_3 = false;
    }

    //만약 의자를 터치했을 때 4
    public void Next_Text_4()
    {
        if (isTyping_4)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_4();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_4();
        }
    }

    void StartTyping_4()
    {
        typingCoroutine = StartCoroutine(TypeSentence_4(sentences_4[Sentences_4]));
    }

    void NextSentence_4()
    {
        Sentences_4++;
        if (Sentences_4 < sentences_4.Length)
        {
            StartTyping_4();
         
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[4].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

           
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_4()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[4].text = sentences_4[Sentences_4];
        isTyping_4 = false;
    }

    IEnumerator TypeSentence_4(string sentence)
    {
        isTyping_4 = true;
        text[4].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[4].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[4].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[4].text += ' ';
            }
        }

        isTyping_4 = false;
    }

    //만약 침대를 터치했을 때 5
    public void Next_Text_5()
    {
        if (isTyping_5)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_5();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_5();
        }
    }

    void StartTyping_5()
    {
        typingCoroutine = StartCoroutine(TypeSentence_5(sentences_5[Sentences_5]));
    }

    void NextSentence_5()
    {
        Sentences_5++;
        if (Sentences_5 < sentences_5.Length)
        {
            StartTyping_5();
            
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[5].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_5()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[5].text = sentences_5[Sentences_5];
        isTyping_5 = false;
    }

    IEnumerator TypeSentence_5(string sentence)
    {
        isTyping_5 = true;
        text[5].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[5].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[5].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[5].text += ' ';
            }
        }

        isTyping_5 = false;
    }

    //만약 창문을 터치했을 때 6
    public void Next_Text_6()
    {
        if (isTyping_6)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping_6();
        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence_6();
        }
    }

    void StartTyping_6()
    {
        typingCoroutine = StartCoroutine(TypeSentence_6(sentences_6[Sentences_6]));
    }

    void NextSentence_6()
    {
        Sentences_6++;
        if (Sentences_6 < sentences_6.Length)
        {
            StartTyping_6();
            
            Name.SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[6].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

    }

    void CompleteTyping_6()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        text[6].text = sentences_6[Sentences_6];
        isTyping_6 = false;
    }

    IEnumerator TypeSentence_6(string sentence)
    {
        isTyping_6 = true;
        text[6].text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[6].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[6].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                text[6].text += ' ';
            }
        }

        isTyping_6 = false;
    }
}
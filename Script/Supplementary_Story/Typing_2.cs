using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//타이핑 관련된 것 있음(메모, 돋보기에 대한 건 다른 곳에 있음)


[System.Serializable]//저장을 위해 새로 추가함

public class GameData_Typing2
{//사용자 설정 데이터를 저장하는 클래스
    //현재 몇 번째 문장 인덱스까지 진행되었는지 저장하는 클래스

    public int Sentences_1_Index;//맨 처음 시작 부분 인덱스
}

public class Typing_2 : MonoBehaviour
{
    public SFX_Manager sfx;

    //public GameObject[] Talk;//스토리 말풍선 전체 포함

    public Typing typ;
    public Typing_1 typ1;
    public Hint hint;

    public Butt_Ch butt_ch;
    public Item item;

    public GameObject Dia;
    public GameObject Inside_Dia;

    //public GameObject Names;

    public Text dialogueText; // 대화창에 표시될 텍스트 UI
    public string[] sentences_1; // 표시될 대화 문장들

    public bool isTyping = false; // 타이핑 중인지 여부

    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조

    public GameObject[] Name;//캐릭터 이름



    //문장 어디까지 진행되었는지
    public int Default_Sentences_1 = 0; // 현재 어디까지 진행되었는지
    public int Sentences_1 = 0;//리셋되어 디폴트 될 때
    public int Current_Sentences_1 = 0; // 현재 문장의 인덱스

    //탐색 시작
    public GameObject start;
    public Animator Start_Ainm;


    //탐색 시작 후 보일 버튼 저장하려고 만든 거 
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;
    public Find_Something3 find_s3;

    public int Start_Count = 0;

    public void OnEnable()
    {
        start.SetActive(false);//탐색 시작 이미지 비활성

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //아래 새로 추가
        //Load_Sentences1();//아이네 방에서 나온 문장들 불러오는 거
        Debug.Log("불러와 진 거니?");

    }

    void Start()
    {
        start.SetActive(false);//탐색 시작 이미지 비활성

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        Load_Sentences1();//수정 0724

        Start_Count = 1;
    }


    public void Load_Sentences1()
    {
        //아이네 방에서 나온 문장들 불러오기
        if (PlayerPrefs.HasKey("Typing_GameData2"))
        {
            string jsonData = PlayerPrefs.GetString("Typing_GameData2");
            GameData_Typing2 data = JsonUtility.FromJson<GameData_Typing2>(jsonData);

            Sentences_1 = data.Sentences_1_Index;

            Dia.SetActive(false);
            //Talk.SetActive(false);

            Inside_Dia.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(false);

            //Names.SetActive(false);

            //sentences_1[Sentences_1]

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                if (Sentences_1 > 45)
                {
                    butt_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                    Dia.SetActive(false);


                    Name[1].SetActive(false);
                    Name[0].SetActive(false);



                    Dia.SetActive(false);
                    Inside_Dia.SetActive(false);
                    Sentences_1 = 46;
                    //Sectences_Save_Settings();//새로 추가720

                }

                if (Sentences_1 <= 45)
                {
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);


                    //StartTyping(); // 대화 시작
                    //뉴
                    Sentences_1--;
                    Next_Text();
                    //Sectences_Save_Settings();

                    Debug.Log("몇 번째야" + Sentences_1);
                }

            }

        }

        else
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);


            Name[1].SetActive(false);
            Name[0].SetActive(false);


            Sentences_1 = Default_Sentences_1;
            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                Dia.SetActive(true);

                Inside_Dia.SetActive(true);

                StartTyping(); // 대화 시작

            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //아이네방에서 나올 문장들 저장
        GameData_Typing2 data = new GameData_Typing2();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData2", jsonData);
        PlayerPrefs.Save();

    }

    public void Sectences_Reset_Settings()
    {
        //아이네 방에서 나올 문장들 리셋
        PlayerPrefs.DeleteKey("Typing_GameData2");
        PlayerPrefs.Save();
        Load_Sentences1();
        hint.Touch_Index = 0;
        hint.Anim.SetTrigger("Up");



        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);

        Start_Count = 0;

    }

    public void Update()
    {
        if(Sentences_1 >= sentences_1.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);
        }

        if (Sentences_1 < sentences_1.Length && find_s2.Sentences_0 >= find_s2.sentences_0.Length)//나머지는 아이네
        {

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

        }



        if (typ.Sentences_1 < typ.sentences_1.Length || find_s.Sentences_0 < find_s.sentences_0.Length
            || find_s1.Sentences_0 < find_s1.sentences_0.Length || find_s2.Sentences_0 < find_s2.sentences_0.Length)
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);
        }

        Sectences_Save_Settings();

        Current_Sentences_1 = Sentences_1;


        if (Sentences_1 <= 45 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //0
        if (Sentences_1 == 0 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            /*item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
            */
            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);

           // Sentences_1 = 0;
           // Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //1
        if (Sentences_1 == 1 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            // Sentences_1 = 1;
            // Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            Dia.SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Debug.Log("이거? 0714");

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }
       

        //2
        if (Sentences_1 == 2 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Dia.SetActive(true);

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            //Sentences_1 = 2;
            //Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }


        //3
        if (Sentences_1 == 3 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            //Sentences_1 = 3;
            //Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //4
        if (Sentences_1 == 4 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

           // Sentences_1 = 4;
            //Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //5
        if (Sentences_1 == 5 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[10].SetActive(true);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            //Sentences_1 = 5;
            //Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //6
        if (Sentences_1 == 6 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

           // Sentences_1 = 6;
           // Sectences_Save_Settings();

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //7
        if ((Sentences_1 ==7 ||Sentences_1 == 9) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        if ((Sentences_1 == 8 || Sentences_1 == 10) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            //리베나
            typ.Ch[6].SetActive(true);

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(true);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //11
        if ((Sentences_1 >= 11 && Sentences_1 <= 14) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //15
        if ((Sentences_1 ==15 || Sentences_1 == 16) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[6].SetActive(true);//리베나

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(true);//리베나
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //17
        if ((Sentences_1 == 17 || Sentences_1 == 18) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //8
        if ((Sentences_1 >= 19 && Sentences_1 <= 20) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[11].SetActive(true);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //9
        if ((Sentences_1 >= 21 && Sentences_1 <= 24) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[12].SetActive(true);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //10
        if ((Sentences_1 >= 25 && Sentences_1 <= 27) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[13].SetActive(true);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        //11
        if ((Sentences_1 == 28) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            // Sentences_1 = 28;
            // Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //12
        if ((Sentences_1 == 29 || Sentences_1 == 30) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[14].SetActive(true);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //13
        if ((Sentences_1 == 31 || Sentences_1 == 32 || Sentences_1 == 33) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[6].SetActive(true);//리베나

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(true);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //14
        if (Sentences_1 == 34 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            // Sentences_1 = 34;
            // Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //15
        if (Sentences_1 == 35 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[6].SetActive(true);//리베나

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(true);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            //-417
            find_s2.lab[0].anchoredPosition = new Vector2(-417, 0);
            find_s2.lab[1].anchoredPosition = new Vector2(-417, 0);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sentences_1 = 35;
            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(true);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //16
        if (Sentences_1 == 36 && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Ch[14].SetActive(true);//검은 마도구

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);//방문 앞
            typ.Bg[5].SetActive(false);



            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sentences_1 = 36;
            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //17
        if ((Sentences_1 == 37 || Sentences_1 == 38 || Sentences_1 == 39 || Sentences_1 == 40) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);//방문 앞
            typ.Bg[5].SetActive(false);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //18 -> 39(열렸다! 다음부터)
        if ((Sentences_1 >= 41 && Sentences_1 <= 45) && find_s2.Sentences_0 >= find_s2.sentences_0.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
            item.small_square[4].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s2.Arrow[0].SetActive(false);
            find_s2.Arrow[1].SetActive(false);
            find_s2.Arrow[2].SetActive(false);
            find_s2.Arrow[3].SetActive(false);
            find_s2.Arrow[4].SetActive(false);
            find_s2.Arrow[5].SetActive(false);

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);//방문 앞
            typ.Bg[5].SetActive(true);


            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            // Sectences_Save_Settings();

            Dia.SetActive(true);
            Inside_Dia.SetActive(true);
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }



    }

    public void Go_2_Typing()
    {
        //find_something에서 사용할 거
        //PlayerPrefs.DeleteKey("Typing_GameData2");
        //PlayerPrefs.Save();

        //Sentences_1 = 0;
        StartTyping();

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);
        //Load_Sentences1();

        find_s2.Arrow[0].SetActive(false);
        find_s2.Arrow[1].SetActive(false);
        find_s2.Arrow[2].SetActive(false);
        find_s2.Arrow[3].SetActive(false);
        find_s2.Arrow[4].SetActive(false);
        find_s2.Arrow[5].SetActive(false);

        item.Item_Count = 2;

        item.small_square[0].SetActive(true);
        item.small_square[1].SetActive(true);
        item.small_square[2].SetActive(true);
        item.small_square[3].SetActive(false);
        item.small_square[4].SetActive(true);
    }

    private void FixedUpdate()
    {

        if (typ.Bg_0 == 5)//마탑 배경일 때, 아이네 방 탐사는 이제 못하도록
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

        }


    }

    public void Next_Text()
    {
        Sectences_Save_Settings();

        if (isTyping)
        {
            // 타이핑 중일 때는 현재 타이핑을 완료하고 다음 문장으로 이동
            CompleteTyping();

        }
        else
        {
            // 타이핑 중이 아닐 때는 다음 문장을 타이핑 시작
            NextSentence();
        }

        find_s.btn_Collection.SetActive(false);
    }

    public void StartTyping()
    {
        typingCoroutine = StartCoroutine(TypeSentence(sentences_1[Sentences_1]));


    }

    public void NextSentence()
    {
        Sentences_1++;

        if (Sentences_1 < sentences_1.Length)
        {
            StartTyping();
            find_s.btn_Collection.SetActive(false);

            Debug.Log("이거");
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            if(Sentences_1 == 37)
            {
                sfx.Book_UnLock();//문 장금 해제
            }

            if (Sentences_1 == 40)
            {
                sfx.Door_Open();//문 열리는 소리
            }
        }

        else if (Sentences_1 > 45)
        {
            Debug.Log("대화 종료");
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);

            // Names.SetActive(false);
            Name[1].SetActive(false);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
            //public GameObject start;
            //public Animator Start_Ainm;

            start.SetActive(true);
            Start_Ainm.SetTrigger("Up");//

            StartCoroutine(Next_Anim());

            IEnumerator Next_Anim()
            {
                //yield return new WaitForSeconds(1.5f);
                yield return new WaitForSeconds(2.0f);
                Start_Ainm.SetTrigger("Down");
                //start.SetActive(false);
            }

            StartCoroutine(Next_Anim_1());
            IEnumerator Next_Anim_1()
            {
                yield return new WaitForSeconds(2.5f);
                //애니메이션이 실행되고 난 뒤 0.5초 후에 없어지도록 하자
                start.SetActive(false);

                //탐색할 수 있도록 배경 선택할 수 있는 버튼을 보여주도록
                find_s.touch_able_b[4].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }
        }


        else
        {
            Debug.Log("대화 종료");
            Dia.SetActive(false);
            //Talk.SetActive(false);
            Inside_Dia.SetActive(false);

            //Names.SetActive(false);
            Name[1].SetActive(false);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
            //public GameObject start;
            //public Animator Start_Ainm;

            start.SetActive(true);
            Start_Ainm.SetTrigger("Up");//

            StartCoroutine(Next_Anim());

            IEnumerator Next_Anim()
            {
                //yield return new WaitForSeconds(1.5f);
                yield return new WaitForSeconds(2.0f);
                Start_Ainm.SetTrigger("Down");
                //start.SetActive(false);
            }

            StartCoroutine(Next_Anim_1());
            IEnumerator Next_Anim_1()
            {
                yield return new WaitForSeconds(2.5f);
                //애니메이션이 실행되고 난 뒤 0.5초 후에 없어지도록 하자
                start.SetActive(false);

                //탐색할 수 있도록 배경 선택할 수 있는 버튼을 보여주도록
                find_s.touch_able_b[4].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }

        }
        Sectences_Save_Settings();

    }

    public void CompleteTyping()
    {
        // 타이핑 중이던 것을 완료하고 다음 문장으로 이동
        StopCoroutine(typingCoroutine);
        dialogueText.text = sentences_1[Sentences_1];
        isTyping = false;


    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

        // 문장을 공백을 기준으로 나누어 처리
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "렌..." 부분을 처리
            if (word.StartsWith("ㄱ"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            // "살고..." 부분을 처리
            else if (word.StartsWith("ㄴ"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // "살아서..." 부분을 처리
            else if (word.StartsWith("ㄷ"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // 그 외의 부분은 기본 속도로 타이핑
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }


            // 단어 사이에 공백 추가
            if (i < words.Length - 1)
            {
                dialogueText.text += ' ';
            }
        }

        isTyping = false;
    }
}
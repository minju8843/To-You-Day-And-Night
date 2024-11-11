using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Item//아이템 어디까지 활성화되어 있는지 저장하는 거
{
    public int Item_Index;
}

public class Item : MonoBehaviour
{
   


    public GameObject[] Sugg_Names;

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find;
    public Find_Something1 find1;
    public Find_Something2 find2;
    public Find_Something3 find3;
    public Find_Something4 find4;


    //아이템 선택했을 때, 금색 프레임의 색이 변하고
    //위의 큰 금색 프레임 안에 아이템의 선택한 아이템의 그림이 나타난다
    // + 아이템의 이름이 나타난다(오브젝트로 해서 활성화 시키는 걸로)

    //제시하기 버튼을 누르면 일단은 플레이어(아이네)가 그 아이템에 대한 생각을 말함
    //타이핑 스크립트 참고하기


    public GameObject Suggest;//제안하기 버튼 활성/비활성

    public Image[] Item_Button; //작은 이미지가 들어있는 금색 프레임 색 바꿀 거임

    public GameObject[] item;//큰 금색 프레임 안에 들어갈 그림
    public GameObject[] Item_Name;//아이템 이름이 적힌 오브젝트

    public GameObject Up_Button;
    public GameObject Meno;

    public RectTransform Container;//컨테이너

    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조

    public GameObject[] Dia;
    //public GameObject[] Text;
    public Text[] text;

    public Butt_Ch ch;

    //악마의 힘에 대한 정보
    public string[] sentences_0; // 표시될 대화 문장들
    public int Sentences_0;//리셋되어 디폴트 될 때
    private bool isTyping_0 = false; // 타이핑 중인지 여부

    //마탑 패
    public string[] sentences_1; // 표시될 대화 문장들
    public int Sentences_1;//리셋되어 디폴트 될 때
    private bool isTyping_1 = false; // 타이핑 중인지 여부

    //마도구
    public string[] sentences_2; // 표시될 대화 문장들
    public int Sentences_2;//리셋되어 디폴트 될 때
    private bool isTyping_2 = false; // 타이핑 중인지 여부

    //검은 마도구
    public string[] sentences_3; // 표시될 대화 문장들
    public int Sentences_3;//리셋되어 디폴트 될 때
    private bool isTyping_3 = false; // 타이핑 중인지 여부

    //반지
    public string[] sentences_4; // 표시될 대화 문장들
    public int Sentences_4;//리셋되어 디폴트 될 때
    private bool isTyping_4 = false; // 타이핑 중인지 여부



    public GameObject[] Buttons;


    //몇 번째 아이템까지 있는지 활성화하는 거 (저장하는 거)
    public GameObject[] small_square;//아이템 네모 작은 거

    public int Default_Item_Count = 0;
    public int Item_Count;
    public int Currnet_Item_Count;

    //아이템 카운트
    public int Item_0 = 0;
    public int Item_1 = 0;
    public int Item_2 = 0;
    public int Item_3 = 0;
    public int Item_4 = 0;

    public void Start()
    {
        for (int i = 0; i < Sugg_Names.Length; i++)
        {
            Sugg_Names[i].SetActive(false);
        }

    }

    public void OnEnable()
    {
        //아이템 작은 거 어디까지 저장되었는지
        Item_LoadSettings();
    }

    public void Update()
    {
        Item_SaveSettings();

        Currnet_Item_Count = Item_Count;

        if (Item_Count == 0)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(false);
        }

        if (Item_Count == 1)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 2)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(true);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 3)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(false);
            small_square[3].SetActive(true);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 4)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }
    }

    public void Item_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Item_Count"))
        {
            string jsonData = PlayerPrefs.GetString("Item_Count");
            GameData_Item data = JsonUtility.FromJson<GameData_Item>(jsonData);

            Item_Count = data.Item_Index;

            if (Item_Count == 0)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(false);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(false);
            }

            if (Item_Count == 1)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 2)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(true);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 3)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(false);
                small_square[3].SetActive(true);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 4)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(false);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }
        }

        else
        {
            Item_Count = Default_Item_Count;
            Item_Count = 0;

            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(false);
        }
    }

    public void Item_SaveSettings()
    {
        GameData_Item Item_data = new GameData_Item();
        Item_data.Item_Index = Item_Count;

        string Item_jsonData = JsonUtility.ToJson(Item_data);
        PlayerPrefs.SetString("Item_Count", Item_jsonData);
        PlayerPrefs.Save();
    }

    public void Item_ResetSettings()
    {
        PlayerPrefs.DeleteKey("Item_Count");
        PlayerPrefs.Save();

        Item_Count = 0;

        small_square[0].SetActive(true);
        small_square[1].SetActive(false);
        small_square[2].SetActive(false);
        small_square[3].SetActive(false);
        small_square[4].SetActive(false);

        // small_square[Item_Count].SetActive(true);
    }

    public void Select_People()
    {
        Buttons[0].SetActive(true);
        Buttons[1].SetActive(false);

        for (int i = 0; i < ch.Character.Length; i++)
        {
            ch.Character[i].SetActive(false);
        }

        for (int i = 0; i < ch.Character_Name.Length; i++)
        {
            ch.Character_Name[i].SetActive(false);
        }

        //붉은색이었던 거 전부 원래대로 돌려놓기
        for (int i = 0; i < ch.Ch_Button.Length; i++)
        {
            ch.Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        ch.Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        ch.Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        
    }

    public void Select_Item()
    {
        

        Buttons[0].SetActive(false);
        Buttons[1].SetActive(true);

        for (int i = 0; i < item.Length; i++)
        {
            item[i].SetActive(false);
        }

        for (int i = 0; i < Item_Name.Length; i++)
        {
            Item_Name[i].SetActive(false);
        }

        //붉은색이었던 거 전부 원래대로 돌려놓기
        for (int i = 0; i < ch.Ch_Button.Length; i++)
        {
            ch.Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        ch.Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        ch.Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }
    }

    public void Think()
    {
        find2.Arrow[0].SetActive(false);
        find2.Arrow[1].SetActive(false);
        find2.Arrow[2].SetActive(false);
        find2.Arrow[3].SetActive(false);
        find2.Arrow[4].SetActive(false);
        find2.Arrow[5].SetActive(false);

        if (item[0].activeSelf == false && item[1].activeSelf == false &&
            item[2].activeSelf == false && item[3].activeSelf == false && item[4].activeSelf == false)
        {
            return;
        }

        else
        {
            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);

            for(int i=0; i<find.touch_able_b.Length; i++)
            {
                find.touch_able_b[i].SetActive(false);//버튼이 들어있는 거 비활성화
            }

            /*find.touch_able_b[0].SetActive(false);//버튼이 들어있는 거 비활성화
            find.touch_able_b[1].SetActive(false);//버튼이 들어있는 거 비활성화
            find.touch_able_b[2].SetActive(false);//버튼이 들어있는 거 비활성화
            find.touch_able_b[3].SetActive(false);//버튼이 들어있는 거 비활성화
            find.touch_able_b[4].SetActive(false);//버튼이 들어있는 거 비활성화
            find.touch_able_b[5].SetActive(false);//버튼이 들어있는 거 비활성화
            */

            for (int i = 0; i < find.Dia.Length; i++)
            {
                find.Dia[i].SetActive(false);//오브젝트 설명창 비활성화
            }


            //0
            if (item[0].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//아이네 이름

                Sentences_0 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                StartTyping_0();
            }

            //1
            if (item[1].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//아이네 이름

                Sentences_1 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
               // typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[1].SetActive(true);

                StartTyping_1();
            }

            //2
            if (item[2].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//아이네 이름

                Sentences_2 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
               // typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[2].SetActive(true);

                StartTyping_2();
            }

            //3
            if (item[3].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//아이네 이름

                Sentences_3 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[3].SetActive(true);

                StartTyping_3();
            }

            //4
            if (item[4].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//아이네 이름

                Sentences_4 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[4].SetActive(true);

                StartTyping_4();
            }
        }

        

        
    }

    //0 악마의 힘
    public void Next_Text_0()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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

    void StartTyping_0()
    {
        typingCoroutine = StartCoroutine(TypeSentence_0(sentences_0[Sentences_0]));
    }

    void NextSentence_0()
    {
        Sentences_0++;
        if (Sentences_0 < sentences_0.Length)
        {
            StartTyping_0();
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[0].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            Suggest.SetActive(true);
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//아이네 이름

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //휴오쟌과 대화하는 문구
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성화

            }

            //구슬 보세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                
                
                if(find2.Arrow[0].activeSelf==true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//버튼이 들어있는 거 활성화
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//버튼이 들어있는 거 활성화
                }
            }

            //책 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //벽에 붙어있는 그림 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//버튼이 들어있는 거 활성화
            }
        }

    }

    void CompleteTyping_0()
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

    //
    public void Next_Text_1()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
           // typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[1].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            Suggest.SetActive(true);
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//아이네 이름

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //휴오쟌과 대화하는 문구
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성화

            }

            //구슬 보세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//버튼이 들어있는 거 활성화
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//버튼이 들어있는 거 활성화
                }
            }

            //책 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //벽에 붙어있는 그림 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//버튼이 들어있는 거 활성화
            }
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

    //2
    public void Next_Text_2()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[2].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            Suggest.SetActive(true);
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//아이네 이름

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //휴오쟌과 대화하는 문구
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성화

            }

            //구슬 보세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//버튼이 들어있는 거 활성화
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//버튼이 들어있는 거 활성화
                }
            }

            //책 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //벽에 붙어있는 그림 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//버튼이 들어있는 거 활성화
            }
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

    //3
    public void Next_Text_3()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[3].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            Suggest.SetActive(true);
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//아이네 이름

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //휴오쟌과 대화하는 문구
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성화

            }

            //구슬 보세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//버튼이 들어있는 거 활성화
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//버튼이 들어있는 거 활성화
                }
            }

            //책 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //벽에 붙어있는 그림 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//버튼이 들어있는 거 활성화
            }
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

    //4
    public void Next_Text_4()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[4].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            Suggest.SetActive(true);
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//아이네 이름

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //휴오쟌과 대화하는 문구
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성화

            }

            //구슬 보세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//버튼이 들어있는 거 활성화
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//버튼이 들어있는 거 활성화
                }
            }

            //책 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성화
            }

            //벽에 붙어있는 그림 확인하세요
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//버튼이 들어있는 거 활성화
            }
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

    //버튼1
    //만약 메모 버튼을 눌렀을 때
    //위에 있던 버튼은 없어지고 메모 창이 나타난다(애니메이션 없음)

    public void Go_Meno()
    {
        Meno.SetActive(true);
        Up_Button.SetActive(false);

        //큰 이미지에 있던 그림 다 비활성
        for (int i = 0; i < item.Length; i++)
        {
            item[i].SetActive(false);
        }

        //이름도 비활성
        for (int i = 0; i < Item_Name.Length; i++)
        {
            Item_Name[i].SetActive(false);
        }

        //작은 그림 선택되었음 표시하는 색도 원래대로
        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        //컨테이너 위치 조절
        //-0.0002441406 ->위
        //-681.8718 ->아래
        Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

    }

    //버튼2
    //메모에서 엑스 버튼을 누르면 메모창이 없어지고 위에 있던 버튼이 나타난다
    public void X_Button()
    {
        Meno.SetActive(false);
        Up_Button.SetActive(true);
    }

    //버튼3
    //인물을 선택했을 때
    //0번 인물 선택
    public void Choose_Item_0()
    {

        Item_0 ++;

        if(Item_0 == 1)
        {
            //아이네
            //이미지 색 바뀌기 && 나머지 이미지 색 원래대로 되돌리기
            Item_Button[0].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 1; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            item[0].SetActive(true);

            for (int i = 1; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            Item_Name[0].SetActive(true);
            for (int i = 1; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_0 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

    

    }

    public void Choose_Item_1()
    {
        //진
        Item_1++;

        if(Item_1 == 1)
        {
            //이미지 색 바뀌기 && 나머지 이미지 색 원래대로 되돌리기
            Item_Button[1].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 1; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 2; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            item[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 2; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            Item_Name[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 2; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_1 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Item_2()
    {
        //렌
        Item_2++;

        if(Item_2 == 1)
        {
            //이미지 색 바뀌기 && 나머지 이미지 색 원래대로 되돌리기
            Item_Button[2].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 2; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 3; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            item[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 3; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            Item_Name[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 3; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_2 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }
        
    }

    public void Choose_Item_3()
    {
        //아이젤
        Item_3++;

        if (Item_3 == 1)
        {
            //이미지 색 바뀌기 && 나머지 이미지 색 원래대로 되돌리기
            Item_Button[3].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 3; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 4; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            item[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 4; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            Item_Name[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 4; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_3 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }
            
    }

    //반지
    public void Choose_Item_4()
    {
        //아이젤
        Item_4++;

        if (Item_4 == 1)
        {
            //이미지 색 바뀌기 && 나머지 이미지 색 원래대로 되돌리기
            Item_Button[4].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 4; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 5; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            item[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 5; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            Item_Name[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 5; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_4 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //큰 이미지에 나타나기, 나머지 그림은 비활성
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //이름도 나타내기. 나머지는 비활성
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//타이핑 관련된 것 있음(메모, 돋보기에 대한 건 다른 곳에 있음)


[System.Serializable]//저장을 위해 새로 추가함

public class GameData_Typing1
{//사용자 설정 데이터를 저장하는 클래스
    //현재 몇 번째 문장 인덱스까지 진행되었는지 저장하는 클래스

    public int Sentences_1_Index;//맨 처음 시작 부분 인덱스
}

public class Typing_1 : MonoBehaviour
{
    //public GameObject[] Talk;//스토리 말풍선 전체 포함

    public Typing typ;
    public Typing_2 typ2;
    public Hint hint;

    public Butt_Ch butt_ch;
    public Item item;

    public GameObject Dia;
    public GameObject Inside_Dia;

    //public GameObject Names;

    public Text dialogueText; // 대화창에 표시될 텍스트 UI
    public string[] sentences_1; // 표시될 대화 문장들

    public bool isTyping = false; // 타이핑 중인지 여부

    public Coroutine typingCoroutine; // 타이핑 Coroutine 참조

    public GameObject[] Name;//캐릭터 이름



    //문장 어디까지 진행되었는지
    public int Default_Sentences_1 = 0; // 현재 어디까지 진행되었는지
    public int Sentences_1;//리셋되어 디폴트 될 때
    public int Current_Sentences_1; // 현재 문장의 인덱스

    //탐색 시작
    public GameObject start;
    public Animator Start_Ainm;


    //탐색 시작 후 보일 버튼 저장하려고 만든 거 
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;

    public int Start_Count = 0;

    public void OnEnable()
    {
        start.SetActive(false);//탐색 시작 이미지 비활성

        Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //아래 새로 추가
        //Load_Sentences1();//아이네 방에서 나온 문장들 불러오는 거

    }

    void Start()
    {
        Load_Sentences1();//0724 수정

        Start_Count = 1;
    }

    
    public void Load_Sentences1()
    {
        //아이네 방에서 나온 문장들 불러오기
        if (PlayerPrefs.HasKey("Typing_GameData1"))
        {
            string jsonData = PlayerPrefs.GetString("Typing_GameData1");
            GameData_Typing1 data = JsonUtility.FromJson<GameData_Typing1>(jsonData);

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

                if (Sentences_1 > 5 )
                {
                    //butt_ch.Suggest.SetActive(true);
                    //item.Suggest.SetActive(true);
                    Dia.SetActive(false);
                    //Names.SetActive(false);

                    Name[1].SetActive(false);
                    Name[0].SetActive(false);

                    if(find_s1.Dia[0].activeSelf==false)
                    {
                        find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼
                        find_s.touch_able_b[0].SetActive(false);
                        find_s.touch_able_b[1].SetActive(true);
                        find_s.touch_able_b[3].SetActive(false);//리베나 있는 마탑 연구실
                        find_s.touch_able_b[2].SetActive(false);//리베나 있는 마탑 연구실
                    }
                    
                    if(find_s1.Dia[0].activeSelf == true)
                    {
                        find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼
                        for (int i = 0; i < find_s.touch_able_b.Length; i++)
                        {
                            find_s.touch_able_b[i].SetActive(false);
                        }
                    }


                    //Next_Text();
                    Dia.SetActive(false);
                    Sentences_1 = 6;
                    Sectences_Save_Settings();//새로 추가720

                }

                if (Sentences_1 <= 5)
                {
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    //butt_ch.Suggest.SetActive(false);
                    //item.Suggest.SetActive(false);
                   

                    //뉴
                    Sentences_1--;
                    Next_Text();
                    Sectences_Save_Settings();

                    Debug.Log("몇 번째야" + Sentences_1);

                    find_s1.Dia[0].SetActive(false);
                }

            }

        }

        else
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);


            Name[1].SetActive(false);
            Name[0].SetActive(false);

            //Names.SetActive(false);

            Sentences_1 = Default_Sentences_1;
            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                Dia.SetActive(true);
                //Talk.SetActive(true);

                Inside_Dia.SetActive(true);

                // Names.SetActive(true);
                StartTyping(); // 대화 시작

            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //아이네방에서 나올 문장들 저장
        GameData_Typing1 data = new GameData_Typing1();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData1", jsonData);
        PlayerPrefs.Save();

    }

    public void Sectences_Reset_Settings()
    {
        //아이네 방에서 나올 문장들 리셋
        PlayerPrefs.DeleteKey("Typing_GameData1");
        PlayerPrefs.Save();
        Load_Sentences1();
        hint.Touch_Index = 0;
        hint.Anim.SetTrigger("Up");

        //터치 가능한 버튼 보여주기 비활성화
        find_s.touch_able_b[0].SetActive(false);

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);

        Start_Count = 0;

    }

    private void Update()
    {
        if(Dia.activeSelf==true)
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
        }

        if (Dia.activeSelf == true && Sentences_1 ==5)
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
        }

        if (typ.Sentences_1<typ.sentences_1.Length || find_s.Sentences_0 < find_s.sentences_0.Length)
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);
        
        }

        Sectences_Save_Settings();

        Current_Sentences_1 = Sentences_1;


        if (Sentences_1 <= 5 && find_s.Sentences_0>find_s.sentences_0.Length)
        {
            find_s.btn_Collection.SetActive(false);
             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }
        }

        //0
        if (Sentences_1 ==0 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
      

            //Sectences_Save_Settings();

            Sentences_1 = 0;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);


        }

        //1
        if (Sentences_1 ==1 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 1;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //2
        if (Sentences_1 ==2 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 2;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //3
        if (Sentences_1 ==3 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 3;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //4
        if (Sentences_1 ==4  && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Sentences_1 = 4;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //5
        if (Sentences_1 ==5  && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 5;
            Sectences_Save_Settings();

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

    }

    public void Go_1_Typing()
    {
        //find_something에서 사용할 거
        //PlayerPrefs.DeleteKey("Typing_GameData1");
        //PlayerPrefs.Save();

        StartTyping();

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);
        Load_Sentences1();
    }

    private void FixedUpdate()
    {
        
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

            //0721추가
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);
        }

        else if (Sentences_1 > 5)
        {
            Debug.Log("대화 종료");
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


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
                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
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
                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(true);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);

                find_s.btn_Collection.SetActive(true);

            }

        }

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
            if (word.StartsWith("렌..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            // "살고..." 부분을 처리
            else if (word.StartsWith("살고..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // "살아서..." 부분을 처리
            else if (word.StartsWith("살아서..."))
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
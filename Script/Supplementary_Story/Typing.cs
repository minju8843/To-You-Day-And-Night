using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//타이핑 관련된 것 있음(메모, 돋보기에 대한 건 다른 곳에 있음)


[System.Serializable]//저장을 위해 새로 추가함

public class GameData_Typing
{//사용자 설정 데이터를 저장하는 클래스
    //현재 몇 번째 문장 인덱스까지 진행되었는지 저장하는 클래스

    public int Sentences_1_Index;//맨 처음 시작 부분 인덱스



    public int Bg_Index;//몇 번째 배경인지
}

public class Typing : MonoBehaviour
{
    //public GameObject[] Talk;//스토리 말풍선 전체 포함

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
    public GameObject[] Ch;//캐릭터 전신 및 이미지
    public GameObject[] Bg;//배경

    //배경 몇 번째 인지
    public int Default_Bg_0 = 0; // 현재 어디까지 진행되었는지
    public int Bg_0;//리셋되어 디폴트 될 때
    public int Current_Bg_0; // 현재 문장의 인덱스


    //문장 어디까지 진행되었는지
    public int Default_Sentences_1 = 0; // 현재 어디까지 진행되었는지
    public int Sentences_1;//리셋되어 디폴트 될 때
    public int Current_Sentences_1; // 현재 문장의 인덱스

    //탐색 시작
    public GameObject start;
    public Animator Start_Ainm;


    //탐색 시작 후 보일 버튼 저장하려고 만든 거 
    public Find_Something find_s;
    public Find_Something find_s1;


    public int Start_Count = 1;




    public void OnEnable()
    {
        start.SetActive(false);//탐색 시작 이미지 비활성

        //Names.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //아래 새로 추가
        //Load_Sentences1();//아이네 방에서 나온 문장들 불러오는 거
        //Load_Bg_0();

        /*if (Bg[0].activeSelf == true && Sentences_1 == 0)
        {
            Load_Sentences1();//0724 수정
            Load_Bg_0();//0724 수정

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                Dia.SetActive(true);
                //Talk.SetActive(true);

                Inside_Dia.SetActive(true);

                // Names.SetActive(true);
                //StartTyping(); // 대화 시작
                find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
            }
        }*/
    }

    public void Start()
    {
        Load_Sentences1();//0724 수정
        Load_Bg_0();//0724 수정

        Start_Count = 1;

    }

    public void Load_Bg_0()
    {
        if (PlayerPrefs.HasKey("Bg_GameData"))
        {
            string jsonData = PlayerPrefs.GetString("Bg_GameData");
            GameData_Typing data = JsonUtility.FromJson<GameData_Typing>(jsonData);

            Bg_0 = data.Bg_Index;

            foreach (GameObject Back_ground in Bg)
            {
                Back_ground.SetActive(false);
            }

            Bg[Bg_0].SetActive(true);

            if(Sentences_1 >= 17 && typ1.Sentences_1 < 1 && find_s.Sentences_0 < 1 && find_s1.Sentences_0 < 1 )//새로 추가
            {
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);

                find_s.btn_Collection.SetActive(true);
            }

        }

        else
        {
            find_s.touch_able_b[0].SetActive(false);
            Bg_0 = Default_Bg_0;

        }
    }
    
    public void Load_Sentences1()
    {
        //아이네 방에서 나온 문장들 불러오기
        if (PlayerPrefs.HasKey("Typing_GameData"))
        {
            string jsonData = PlayerPrefs.GetString("Typing_GameData");
            GameData_Typing data = JsonUtility.FromJson<GameData_Typing>(jsonData);

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

                if(Sentences_1 > 17)
                {
                    butt_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                    Dia.SetActive(false);
                    //Names.SetActive(false);

                    Name[1].SetActive(false);
                    Name[0].SetActive(false);

                    find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼

        
                }

                if (Sentences_1 <= 17)
                {
                    find_s.Typ_Dia_Total.SetActive(true);//0721추가추가

                    Dia.SetActive(true);
                    //Talk.SetActive(true);

                    Inside_Dia.SetActive(true);
                   // Names.SetActive(true);
                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);
                    StartTyping(); // 대화 시작

                   /* if(Sentences_1==11)
                    {

                    }*/
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
                find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //아이네방에서 나올 문장들 저장
        GameData_Typing data = new GameData_Typing();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData", jsonData);
        PlayerPrefs.Save();

        //배경
       GameData_Typing bg_data = new GameData_Typing();
        bg_data.Bg_Index = Bg_0;
        string bg_jsonData = JsonUtility.ToJson(bg_data);
        PlayerPrefs.SetString("Bg_GameData", bg_jsonData);
        PlayerPrefs.Save();
       

    }

    public void Sectences_Reset_Settings()
    {
        //아이네 방에서 나올 문장들 리셋
        PlayerPrefs.DeleteKey("Typing_GameData");
        PlayerPrefs.Save();
        Load_Sentences1();
        hint.Touch_Index = 0;
        hint.Anim.SetTrigger("Up");

        //터치 가능한 버튼 보여주기 비활성화
        find_s.touch_able_b[0].SetActive(false);

        //아이네 방에서 나올 문장들 리셋
        PlayerPrefs.DeleteKey("Bg_GameData");
        PlayerPrefs.Save();
        Bg_0 = 0;
        for(int i=0; i<Bg.Length; i++)
        {
            Bg[i].SetActive(false);
        }
        Bg[0].SetActive(true);
       
        Load_Bg_0();

        
        Name[1].SetActive(false);
        Name[0].SetActive(true);

        //Names.SetActive(true);
        find_s.Typ_Dia_Total.SetActive(true);//0720 추가

        Start_Count = 0;
    }

    public void Update()
    {

       

        if (Sentences_1 == 5)//진 얼굴
        {
            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[0].SetActive(true);
        }

        if (Sentences_1 == 7)
        {
            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(false);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
            item.Item_Count = 4;

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[27].SetActive(true);
        }

        if (Sentences_1 == 11)//진 자고 있는 거 나오게
        {

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[1].SetActive(true);
        }

        //예전거
        if (Sentences_1 == 5)//진 이름 나오도록
        {
            Name[1].SetActive(true);
            Name[0].SetActive(false);
        }




        if (Sentences_1 != 5 && Sentences_1 < sentences_1.Length)//나머지는 아이네
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);
        }

        Sectences_Save_Settings();

        Current_Sentences_1 = Sentences_1;

        Current_Bg_0 = Bg_0;

        if(Sentences_1 < sentences_1.Length)
        {
            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
        }


        if (Sentences_1 < sentences_1.Length && (Sentences_1 != 11 && Sentences_1 != 5 && Sentences_1 != 7))
        {
            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
        }


        //배경 변경
        if (Sentences_1 >= 0 && Sentences_1 <= 15)//아이네 이름, [16]에서 배경 변경
        {
            Bg_0 = 0;

            Bg[0].SetActive(true);
            Bg[1].SetActive(false);
            Bg[2].SetActive(false);
            Bg[3].SetActive(false);
            Bg[4].SetActive(false);
            Bg[5].SetActive(false);

        }

        if (Sentences_1 > 15 && item.Item_Count == 4)//아이네 이름, [16]에서 배경 변경
        {
            Bg_0 = 1;

            Bg[0].SetActive(false);
            Bg[1].SetActive(true);
            Bg[2].SetActive(false);
            Bg[3].SetActive(false);
            Bg[4].SetActive(false);
            Bg[5].SetActive(false);

        }

        //아이네 침대에서 탐색중인 말풍선이 등장하지 않을 때
        if (Sentences_1 >= 17 && item.Item_Count == 0 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (find_s.Dia[0].activeSelf == false && find_s.Dia[1].activeSelf == false &&
            find_s.Dia[2].activeSelf == false && find_s.Dia[3].activeSelf == false &&
            find_s.Dia[4].activeSelf == false && find_s.Dia[5].activeSelf == false &&
            find_s.Dia[6].activeSelf == false) &&
            (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false || item.Dia[4].activeSelf == false))
        {
            find_s.touch_able_b[0].SetActive(true);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);
            find_s.touch_able_b[4].SetActive(false);

            //Debug.Log("이거냐? 0714");
        }

        //아이네 침대에서 현재 탐색중인 말풍선이 나올 때
        if (Sentences_1 >= 17 && item.Item_Count == 0 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (find_s.Dia[0].activeSelf == true || find_s.Dia[1].activeSelf == true ||
            find_s.Dia[2].activeSelf == true || find_s.Dia[3].activeSelf == true ||
            find_s.Dia[4].activeSelf == true || find_s.Dia[5].activeSelf == true ||
            find_s.Dia[6].activeSelf == true) ||
            (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true || item.Dia[4].activeSelf == true))
        {
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
            //Debug.Log("이거? 0714");
        }


        if (Sentences_1 > 17 && Bg[1].activeSelf == true)
        {
            Dia.SetActive(false);


        }

        if (Bg_0 == 2)//마탑 배경일 때, 아이네 방 탐사는 이제 못하도록
        {
            find_s.touch_able_b[0].SetActive(false);

        }



    }

    private void FixedUpdate()
    {
        
        

    }

    public void Next_Text()
    {
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

            

        }

        else if(Sentences_1 > 17)
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
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
                find_s.btn_Collection.SetActive(true);

            }

            find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
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
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
                find_s.btn_Collection.SetActive(true);

                find_s.Typ_Dia_Total.SetActive(false);//0720 추가
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Find_s3
{
    public int Sentences_0_Index;//맨 처음 시작 부분 인덱스
}
public class Find_Something3 : MonoBehaviour
{
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;

    public Butt_Ch butt_ch;

    public GameObject[] Name;//이름

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//제시하기 버튼 비활성화 시키기 위해 작성
    public Item item;


    public GameObject[] Dia;//터치한 오브젝트에 대한 말풍선들
    public Text[] text;//터치한 오브젝트에 대한 말풍선 내부 텍스트들


    //탐색 시작
    public GameObject start;
    public Animator Start_Ainm;

    //휴오쟌에 대한 정보 타이핑 관련
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

 


    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조


    public void Start()
    {
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//일단 말풍선 다 비활성
            //터치하면 나오게 할 거니까
        }

        start.SetActive(false);//탐색 시작 이미지 비활성

        Name[0].SetActive(false);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나


        if (Sentences_0 > 29)
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

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            //sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 30;

            Sectences_Save_Settings();


        }

    }

    public void OnEnable()
    {
        Load_Sentences_0();
       


        if (Sentences_0 == 0 && (find_s1.Current_Sentences_0 < find_s1.sentences_0.Length
            || typ.Current_Sentences_1 < typ.sentences_1.Length
            || typ1.Current_Sentences_1 < typ1.sentences_1.Length || typ2.Current_Sentences_1 < typ2.sentences_1.Length
            || find_s.Sentences_0 < find_s.sentences_0.Length || find_s1.Sentences_0 < find_s1.sentences_0.Length 
            || find_s2.Sentences_0 < find_s2.sentences_0.Length
            || Sentences_0 >= sentences_0.Length))
        {
            Name[0].SetActive(false);
            Name[1].SetActive(false);
            Name[2].SetActive(false);//리베나

           

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }

            Debug.Log("화살표 체크1");

            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        if (Sentences_0 == 0 && typ2.Current_Sentences_1 > typ2.sentences_1.Length)
        {
            find_s.btn_Collection.SetActive(true);

            Debug.Log("이거 안 나오니0?");

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


        }

    }

    

    public void Reset_Settings()
    {
 
        find_s.touch_able_b[4].SetActive(false);

        PlayerPrefs.DeleteKey("find_Text_Data3");
        PlayerPrefs.Save();

        Sentences_0 = 0;

        Dia[0].SetActive(false);
        Dia[1].SetActive(false);
        Dia[2].SetActive(false);
        Dia[3].SetActive(false);
        Dia[4].SetActive(false);
        Dia[5].SetActive(false);


        Name[0].SetActive(false);
        Name[1].SetActive(false);
        Name[2].SetActive(false);

        typ.Bg_0 = 0;
        typ.Bg[0].SetActive(true);
        typ.Bg[1].SetActive(false);
        typ.Bg[2].SetActive(false);
        typ.Bg[3].SetActive(false);
        typ.Bg[4].SetActive(false);
        typ.Bg[5].SetActive(false);

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        find_s.Typ_Dia_Total.SetActive(true);//0721추가추가

    }


    public void Load_Sentences_0()
    {
        if (PlayerPrefs.HasKey("find_Text_Data3"))
        {
            string jsonData = PlayerPrefs.GetString("find_Text_Data3");
            GameData_Find_s3 data = JsonUtility.FromJson<GameData_Find_s3>(jsonData);

            Sentences_0 = data.Sentences_0_Index;


            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);



            Name[0].SetActive(false);
            Name[1].SetActive(false);
            Name[2].SetActive(false);

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                if (Sentences_0 > 29)
                {
                    butt_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    Dia[0].SetActive(false);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);
                    Dia[4].SetActive(false);
                    Dia[5].SetActive(false);


                    Name[0].SetActive(false);
                    Name[1].SetActive(false);
                    Name[2].SetActive(false);

                    find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    //find_s.Typ_Dia_Total.SetActive(true);//0721추가추가

                }




                else if (Sentences_0 <= 29)
                {

                    Dia[0].SetActive(false);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);
                    Dia[4].SetActive(false);
                    Dia[5].SetActive(false);


                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);

                    Sentences_0--;
                    Next_Text_0();

                    Sectences_Save_Settings();

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



            Name[0].SetActive(true);
            Name[1].SetActive(false);
            Name[2].SetActive(false);

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


                //StartTyping(); // 대화 시작
            }

           
        }

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //문장들 저장
        GameData_Find_s3 data = new GameData_Find_s3();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data3", jsonData);
        PlayerPrefs.Save();


    }





    public void Update()
    {
        Current_Sentences_0 = Sentences_0;
     

        if(typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
        }

        //금색 테 나오는 경우
        if (Sentences_0 == 0 && typ.Ch[9].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Debug.Log("확인1");
        }

        //금색 테 나오는 경우
        if (Sentences_0 == 0 && typ.Ch[9].activeSelf == false && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            Debug.Log("확인4");
        }

        /*if (typ.Ch[6].activeSelf == true && Name[2].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            Debug.Log("확인2");
        }

        if (typ.Ch[20].activeSelf == true && Name[1].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            Debug.Log("확인3");
        }*/

        if (typ.Sentences_1 == 0 || typ1.Sentences_1 == 0 || typ2.Sentences_1 == 0)
        {
            Dia[0].SetActive(false);
        }

        if (Sentences_0 == 0 && typ2.Sentences_1 >= typ2.sentences_1.Length &&
            (item.Suggest.activeSelf == true || butt_ch.Suggest.activeSelf == true))
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        if (Sentences_0 == 0 && typ.Bg[5].activeSelf == true && typ.Ch[9].activeSelf == true
            && typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            Debug.Log("확인4");

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if (Sentences_0 == 0 && typ.Bg[5].activeSelf == true && typ.Ch[9].activeSelf == false
            && typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            Debug.Log("확인4");
        }

        //문장과 이름 나오는 경우
        if ((Sentences_0 == 29) && Name[1].activeSelf == true)//휴오쟌
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            typ.Ch[20].SetActive(true);
        }

        if ((Sentences_0 ==19 || Sentences_0 == 20
            || Sentences_0 == 23 || Sentences_0 == 24 || Sentences_0 == 25 || Sentences_0 == 28) && Name[2].activeSelf == true)//리베나
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            typ.Ch[6].SetActive(true);
        }

        if ((Sentences_0 >=1 || Sentences_0 <= 18) && Name[0].activeSelf == true)//아이네
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        if ((Sentences_0 == 21 || Sentences_0 == 22 || Sentences_0 == 26 || Sentences_0 == 27) && Name[0].activeSelf == true)//아이네
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }
       
        


        /*if (Sentences_0 > 0 && Sentences_0 < 30)//수정0718
        {
            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }*/

        //예전거
       

        if (typ2.Sentences_1 <= 45)
        {
           
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }
        }


       


        //탐색중인 말풍선이 등장하지 않을 때
        if (typ2.Sentences_1 > 45 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false) && typ.Bg[5].activeSelf == true)
           /* (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
            &&typ.Bg[5].activeSelf == true)*/
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);//리베나 있는 마탑 연구실
            find_s.touch_able_b[3].SetActive(false);//리베나 있는 마탑 연구실
            find_s.touch_able_b[4].SetActive(true);//리베나 있는 마탑 연구실


            find_s.btn_Collection.SetActive(true);
            //Debug.Log("이거냐? 0714");

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

        

        // 현재 탐색중인 말풍선이 나올 때
        if (typ2.Sentences_1 > 45 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true) && typ.Bg[5].activeSelf == true)
        /*(item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true)
        && typ.Bg[5].activeSelf == true)*/
        {
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }


            find_s.btn_Collection.SetActive(false);
        }


        //0번째 문장
        if ((Sentences_0 == 29))//휴오쟌
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            typ.Ch[20].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(true);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if ((Sentences_0 == 19 || Sentences_0 == 20
            || Sentences_0 == 23 || Sentences_0 == 24 || Sentences_0 == 25 || Sentences_0 == 28))//리베나
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

           Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(true);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if ((Sentences_0 >= 1 && Sentences_0 <= 18))//아이네
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if ((Sentences_0 == 21 || Sentences_0 == 22 || Sentences_0 == 26 || Sentences_0 == 27))//아이네
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
        

        //1번째 문장 + 리베나
        if ( Sentences_1 == 4 || Sentences_1 == 6
            || Sentences_1 == 7 || Sentences_1 == 8 || Sentences_1 == 9)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(true);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //1번째 문장 + 아이네 + 사진
        if (Sentences_1 == 1 || Sentences_1 == 2
            || Sentences_1 == 3)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[15].SetActive(true);

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방


        }

        //1번째 문장 + 아이네 + 없음
        if (Sentences_1 == 10 || Sentences_1 == 11 || Sentences_1 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //2번 문장 + 아이네 없음
        if (Sentences_2 == 1)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //3번 문장 아이네
        if (Sentences_3 >= 1 && Sentences_3 <= 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //4번 문장 아이네
        if (Sentences_4 == 1)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //5번 문장 아이네 //수정해야 함
        if (Sentences_5 == 1 || Sentences_5 == 2 || Sentences_5 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

        //5번 문장 리베나
        if (Sentences_5 == 3 || Sentences_5 == 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(true);//리베나

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(true);// 진의 방

        }

    }

    public void Choose_Obj_0()
    {
        Sentences_0 = 0;
        StartTyping_0();

        typ.Ch[9].SetActive(true);//책


        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[0].SetActive(true);//0번째 말풍선만 활성화

        for(int i=0; i<find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

       

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }

    public void Choose_Obj_1()
    {

        Sentences_1 = 0;
        StartTyping_1();

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[1].SetActive(true);//0번째 말풍선만 활성화
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }

    public void Choose_Obj_2()
    {
        Sentences_2 = 0;
        StartTyping_2();

        //typ1.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0번째 말풍선만 활성화
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }

    public void Choose_Obj_3()
    {
        Sentences_3 = 0;
        StartTyping_3();

        // typ1.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0번째 말풍선만 활성화
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }

    //4
    public void Choose_Obj_4()
    {
        Sentences_4 = 0;
        StartTyping_4();

        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[4].SetActive(true);//0번째 말풍선만 활성화
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }

    public void Choose_Obj_5()
    {

        Sentences_5 = 0;
        StartTyping_5();

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[5].SetActive(true);//0번째 말풍선만 활성화


        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


    }




    //0
    public void Next_Text_0()
    {
        Sectences_Save_Settings();

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


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
            Sectences_Save_Settings();

            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            StartTyping_0();

            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌
            //Name[2].SetActive(false);//리베나


            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[0].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);


            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(false);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);//리베나 없는 마탑
            typ.Bg[4].SetActive(false);//문 앞
            typ.Bg[5].SetActive(true);//진 방


            typ.Bg_0 = 5;

        }

        else if (Sentences_1 > 29)
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

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
                find_s.touch_able_b[5].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }
        }


        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나


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
                find_s.touch_able_b[5].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }

        }
        Sectences_Save_Settings();

        /*else
        {
            Sectences_Save_Settings();

            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나


            //touch_able_b[0].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


            //배경 바뀜에 따라 버튼 누를 수 있는 것도 달라짐
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //typ2.Go_2_Typing();


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s.Typ_Dia_Total.SetActive(true);//0721추가추가


        }*/

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
            if (word.StartsWith("ㅅ"))
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

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

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
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌

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


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//

            find_s.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
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
            if (word.StartsWith("ㅅ"))
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
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

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
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            StartTyping_2();

            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌

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


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
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
            if (word.StartsWith("ㅅ"))
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
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

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

            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌
            //Name[2].SetActive(false);//리베나

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


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
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
            if (word.StartsWith("ㅅ"))
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
        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(true);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(false);// 진의 방


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

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
            find_s.touch_able_b[2].SetActive(false);//리베나 있는 마탑 연구실
            find_s.touch_able_b[3].SetActive(false);//리베나 있는 마탑 연구실
            find_s.touch_able_b[4].SetActive(false);//리베나 있는 마탑 연구실
            find_s.touch_able_b[5].SetActive(false);//리베나 있는 마탑 연구실

            StartTyping_4();


            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌
            //Name[2].SetActive(false);//리베나

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


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
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
            if (word.StartsWith("ㅅ"))
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

    //5
    public void Next_Text_5()
    {
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// 진 쓰러진 방
        typ.Bg[1].SetActive(false);// 아이네 방
        typ.Bg[2].SetActive(false);// 마탑 앞
        typ.Bg[3].SetActive(false);// 마탑 안
        typ.Bg[4].SetActive(false);// 마탑 문 앞
        typ.Bg[5].SetActive(true);// 진의 방


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

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

            //Name[0].SetActive(true);//아이네
            //Name[1].SetActive(false);//휴오쟌
            //Name[2].SetActive(false);//리베나

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[5].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
        }

        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            find_s.touch_able_b[4].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
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
            if (word.StartsWith("ㅅ"))
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




}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//저장을 위해 새로 추가함
public class GameData_Find_s1
{//사용자 설정 데이터를 저장하는 클래스
    //현재 몇 번째 문장 인덱스까지 진행되었는지 저장하는 클래스

    public int Sentences_0_Index;//맨 처음 시작 부분 인덱스
}

public class Find_Something1 : MonoBehaviour
{
    public GameObject blue;
    public Blue_Fade fade;

    public Find_Something find_s;
    public Find_Something2 find2;
    public Find_Something3 find3;
    public Find_Something4 find4;

    public Butt_Ch butt_ch;

    public GameObject[] Name;//이름

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//제시하기 버튼 비활성화 시키기 위해 작성
    public Item item;

    //탐색 시작 후 보일 버튼 저장하려고 만든 거 
    //현재 몇 번째 탐색중인지 - 아이네 방인지, 마탑 밖인지, 마탑 안인지
    //public int Default_TouchAble = 0; // 현재 어디까지 진행되었는지
    //public int TouchAble;//리셋되어 디폴트 될 때
    //public int Current_TouchAble; // 현재 

    public GameObject[] Dia;//터치한 오브젝트에 대한 말풍선들
    public Text[] text;//터치한 오브젝트에 대한 말풍선 내부 텍스트들

    //휴오쟌에 대한 정보 타이핑 관련
    public string[] sentences_0; // 표시될 대화 문장들
    public int Sentences_0 = 0;//리셋되어 디폴트 될 때
    private bool isTyping_0 = false; // 타이핑 중인지 여부

    //휴오쟌 관련 문장 저장
    public int Default_Sentences_0 = 0; // 현재 어디까지 진행되었는지
    public int Current_Sentences_0 = 0 ; // 현재 문장의 인덱스


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
    /*public string[] sentences_4; // 표시될 대화 문장들
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
    */


    private Coroutine typingCoroutine; // 타이핑 Coroutine 참조


    //탐색 시작
    public GameObject start;
    public Animator Start_Ainm;

    void Start()
    {
        start.SetActive(false);//탐색 시작 이미지 비활성

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//일단 말풍선 다 비활성
            //터치하면 나오게 할 거니까
        }

        Name[0].SetActive(false);
        Name[1].SetActive(false);
        Name[2].SetActive(false);//리베나

        //Load_Sentences_0();


        //새로 추가
        if (Sentences_0 > 42)
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

            for (int i = 0; i < Name.Length; i++)
            {
                Name[i].SetActive(false);//일단 말풍선 다 비활성
                                        //터치하면 나오게 할 거니까
            }
            /*
                        Dia[0].SetActive(false);
                        Dia[1].SetActive(false);
                        Dia[2].SetActive(false);
                        Dia[3].SetActive(false);

                        Name[0].SetActive(false);//아이네
                        Name[1].SetActive(false);//휴오쟌

              */

            //배경
           /* typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(true);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
          **/


           // sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 43;

            Sectences_Save_Settings();

            
        }
        

    }

    public void OnEnable()
    {

        //만약 첫 번째 장소에서 스토리 대사가 다 나오면 탐색이 활성화되도록
        /* if (typ1.Current_Sentences_1 >= typ1.sentences_1.Length)
         {
             find_s.touch_able_b[1].SetActive(true);
             find_s.btn_Collection.SetActive(true);


         }*/

        if (Sentences_0 == 0 && (
           typ.Current_Sentences_1 < typ.sentences_1.Length
           || typ1.Current_Sentences_1 < typ1.sentences_1.Length || typ2.Current_Sentences_1 < typ2.sentences_1.Length
           || find_s.Sentences_0 < find_s.sentences_0.Length || find4.Sentences_0 < find4.sentences_0.Length
           || find2.Sentences_0 < find2.sentences_0.Length || find3.Sentences_0 < find3.sentences_0.Length
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

        if (Sentences_0 == 0 && typ1.Current_Sentences_1 > typ1.sentences_1.Length
            && (start.activeSelf==true || find2.Arrow[0].activeSelf==true))
        {
            find_s.btn_Collection.SetActive(true);

            Debug.Log("이거 안 나오니0?");

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(true);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방


        }

        Load_Sentences_0();


    }

    public void Update()
    {

        if (Sentences_0 >= 42 && start.activeSelf==true && find2.Arrow[0].activeSelf==false && typ.Bg[5].activeSelf == false)
        {
            typ.Bg_0 = 4;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(false);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);
        }


        if (typ.Sentences_1==0)
        {
            Dia[0].SetActive(false);
        }

        if (typ1.Sentences_1 == 6)
        {
            find_s.touch_able_b[0].SetActive(false);
        }

        Current_Sentences_0 = Sentences_0;

        if (Sentences_0 == 0 && (typ.Bg[0].activeSelf == true || typ.Bg[1].activeSelf == true)
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && find2.Sentences_0 < 1 && typ.Ch[4].activeSelf == false)
        {
            Dia[0].SetActive(false);

            Debug.Log("너0720");
        }

        if (Sentences_0 == 0 && item.Item_Count == 1
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Bg[2].activeSelf == true
             && typ.Ch[4].activeSelf == false && Name[0].activeSelf == false)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            Debug.Log("너너0720");
        }

        if (Sentences_0 == 0 && typ.Bg[2].activeSelf == true && item.Item_Count == 1
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Ch[4].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
            Debug.Log("너너너0720");

            typ.Bg_0 = 2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(true);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Dia[0].SetActive(false);
        }

        //
        if (Sentences_0 == 0 && item.Item_Count == 0
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Bg[2].activeSelf == true
             && typ.Ch[4].activeSelf == false && Name[0].activeSelf == false)
        {
            Dia[0].SetActive(false);

            Debug.Log("너너0720");
        }

        if (Sentences_0 == 0 && typ.Bg[2].activeSelf == true && item.Item_Count == 0
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Ch[4].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(false);
            Debug.Log("너너너0720");
        }

  


        //마탑 밖에서 탐색중인 말풍선이 등장하지 않을 때
        if (typ1.Sentences_1 >= typ1.sentences_1.Length && item.Item_Count == 1 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false)) /*&&
            (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false))
        */{
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(true);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);
            find_s.touch_able_b[4].SetActive(false);
            find_s.touch_able_b[5].SetActive(false);
            find_s.btn_Collection.SetActive(true);


            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
            //Debug.Log("이거냐? 0714");
        }

        //마탑 밖에서 현재 탐색중인 말풍선이 나올 때
        if (typ1.Sentences_1 >= typ1.sentences_1.Length && item.Item_Count == 1 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true)) /*||
            (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true))
        */{
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
            find_s.btn_Collection.SetActive(false);
            //Debug.Log("이거? 0714");
        }


        if (Sentences_0 > 0 && Sentences_0 < 43)//수정0718
        {
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            // find_s.touch_able_b[2].SetActive(false);
            // find_s.touch_able_b[3].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
        //이거 이상하면 지우기
        //푸른 구슬
        if (Sentences_0 == 19 || Sentences_0 == 20)
        {
            Dia[0].SetActive(true);
            find_s.Dia[0].SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[7].SetActive(true);

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(true);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
      

            Debug.Log("설마 너니????");
        }

        //휴오쟌 뒷모습
        else if (Sentences_0 < 3 && Sentences_0 > 0)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[4].SetActive(true);

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

            typ.Bg_0 = 2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(true);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
        }


        //휴오쟌 어깨 걸침
        else if (Sentences_0 == 4 || Sentences_0 == 7 || Sentences_0 == 8
            || Sentences_0 == 10 || Sentences_0 == 14 || Sentences_0 == 16
            || Sentences_0 == 17 || Sentences_0 == 21)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[5].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(true);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(true);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
           

            Debug.Log("아님 넌가???");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        //금색 패
        else if (Sentences_0 == 13)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[3].SetActive(true);

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(true);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
      

            Debug.Log("너????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }



        //리베나
        else if (Sentences_0 == 26 || Sentences_0 == 31)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(true);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(true);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
    

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        //리베나
        else if (Sentences_0 == 35 
            || Sentences_0 == 37 || Sentences_0 == 38 || Sentences_0 == 39)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(true);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(true);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
       

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }



        else if (Sentences_0 == 5 || Sentences_0 == 6 || Sentences_0 == 9
           || Sentences_0 == 11 || Sentences_0 == 12 || Sentences_0 == 13
           || Sentences_0 == 15 || Sentences_0 == 18
           || Sentences_0 == 22 || Sentences_0 == 3 || Sentences_0 == 23)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            //배경
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(true);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
            

            Debug.Log("말해랏????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

        }

        else if (Sentences_0 == 36 || Sentences_0 == 40
            || Sentences_0 == 41 || Sentences_0 == 42)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            //배경
            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(true);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
  

            //Debug.Log("이거 안 나오니?");
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가

        }

        else if (Sentences_0 == 27 || Sentences_0 == 32 || Sentences_0 == 28
            || Sentences_0 == 29 || Sentences_0 == 30 || Sentences_0 == 33 || Sentences_0 == 34)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            //배경
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(true);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
           

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        else if (Sentences_0 == 24)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(true);

            //배경
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(true);// 마탑 앞
            typ.Bg[3].SetActive(false);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
     

            Debug.Log("범인은 누구냣????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }

        else if (Sentences_0 == 25)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            blue.SetActive(false);

            //배경
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// 진 쓰러진 방
            typ.Bg[1].SetActive(false);// 아이네 방
            typ.Bg[2].SetActive(false);// 마탑 앞
            typ.Bg[3].SetActive(true);// 마탑 안
            typ.Bg[4].SetActive(false);// 마탑 문 앞
            typ.Bg[5].SetActive(false);// 진의 방
       

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721추가추가
        }


    }

    public void Load_Sentences_0()
    {
        if (PlayerPrefs.HasKey("find_Text_Data1"))
        {
            string jsonData = PlayerPrefs.GetString("find_Text_Data1");
            GameData_Find_s1 data = JsonUtility.FromJson<GameData_Find_s1>(jsonData);

            Sentences_0 = data.Sentences_0_Index;

            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);

            Name[0].SetActive(false);
            Name[1].SetActive(false);
            Name[2].SetActive(false);

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

               

                if (Sentences_0 > 42 && typ1.Sentences_1<1)
                {
                    butt_ch.Suggest.SetActive(true);

                    item.Suggest.SetActive(true);

                    Dia[0].SetActive(false);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);

                    Name[0].SetActive(false);
                    Name[1].SetActive(false);
                    Name[2].SetActive(false);

                    find_s.btn_Collection.SetActive(true);//아이네 방 탐색 버튼

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    
                  

                    if((sug.Suggest.activeSelf==false || item.Suggest.activeSelf==false)
                        &&(find2.Dia[0].activeSelf == true || find2.Dia[1].activeSelf == true ||
            find2.Dia[2].activeSelf == true || find2.Dia[3].activeSelf == true
            || find2.Dia[4].activeSelf == true || find2.Dia[5].activeSelf == true))
                    {//제시하기 비활성화가 되어 있고 대사창이 나와있는 상태라면
                        find2.Arrow[0].SetActive(false);
                        find2.Arrow[1].SetActive(false);
                        find2.Arrow[2].SetActive(false);
                        find2.Arrow[3].SetActive(false);
                        find2.Arrow[4].SetActive(false);
                        find2.Arrow[5].SetActive(false);

                    }

                    if((sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true)
                        && (find2.Dia[0].activeSelf == false && find2.Dia[1].activeSelf == false &&
            find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
            && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
            && find2.R_Normal_Arrow == 2)
                    {
                        //제시하기가 활성화 되어있고
                        //대화창이 비활성화 되어 있다면
                        //화살표를 보여준다.
                        find2.Arrow[0].SetActive(false);
                        find2.Arrow[1].SetActive(false);
                        find2.Arrow[2].SetActive(false);
                        find2.Arrow[3].SetActive(false);
                        find2.Arrow[4].SetActive(true);
                        find2.Arrow[5].SetActive(true);

                        //배경
                        typ.Bg_0 = 3;

                        typ.Bg[0].SetActive(false);// 진 쓰러진 방
                        typ.Bg[1].SetActive(false);// 아이네 방
                        typ.Bg[2].SetActive(false);// 마탑 앞
                        typ.Bg[3].SetActive(true);// 마탑 안
                        typ.Bg[4].SetActive(false);// 마탑 문 앞
                        typ.Bg[5].SetActive(false);// 진의 방
                    }

                    if ((sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true)
                        && (find2.Dia[0].activeSelf == false && find2.Dia[1].activeSelf == false &&
            find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
            && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
            && find2.R_Normal_Arrow == 0)
                    {
                        //제시하기가 활성화 되어있고
                        //대화창이 비활성화 되어 있다면
                        //화살표를 보여준다.
                        find2.Arrow[0].SetActive(true);
                        find2.Arrow[1].SetActive(true);
                        find2.Arrow[2].SetActive(false);
                        find2.Arrow[3].SetActive(false);
                        find2.Arrow[4].SetActive(false);
                        find2.Arrow[5].SetActive(false);

                        //배경
                        typ.Bg_0 = 4;

                        typ.Bg[0].SetActive(false);// 진 쓰러진 방
                        typ.Bg[1].SetActive(false);// 아이네 방
                        typ.Bg[2].SetActive(false);// 마탑 앞
                        typ.Bg[3].SetActive(false);// 마탑 안
                        typ.Bg[4].SetActive(true);// 마탑 문 앞
                        typ.Bg[5].SetActive(false);// 진의 방
                    }

                    if ((sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true)
                        && (find2.Dia[0].activeSelf == false && find2.Dia[1].activeSelf == false &&
            find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
            && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false )
            && find2.R_Normal_Arrow == 1)
                    {
                        //제시하기가 활성화 되어있고
                        //대화창이 비활성화 되어 있다면
                        //화살표를 보여준다.
                        find2.Arrow[0].SetActive(false);
                        find2.Arrow[1].SetActive(false);
                        find2.Arrow[2].SetActive(true);
                        find2.Arrow[3].SetActive(true);
                        find2.Arrow[4].SetActive(false);
                        find2.Arrow[5].SetActive(false);

                        //배경
                        typ.Bg_0 = 3;

                        typ.Bg[0].SetActive(false);// 진 쓰러진 방
                        typ.Bg[1].SetActive(false);// 아이네 방
                        typ.Bg[2].SetActive(false);// 마탑 앞
                        typ.Bg[3].SetActive(true);// 마탑 안
                        typ.Bg[4].SetActive(false);// 마탑 문 앞
                        typ.Bg[5].SetActive(false);// 진의 방
                    }
                }

            

                if (Sentences_0 <= 42)
                {

                    Dia[0].SetActive(true);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);

                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);

                    Sentences_0--;
                    Next_Text_0();

                    Sectences_Save_Settings();


                    typ.Bg_0 = 3;

                    typ.Bg[0].SetActive(false);// 진 쓰러진 방
                    typ.Bg[1].SetActive(false);// 아이네 방
                    typ.Bg[2].SetActive(false);// 마탑 앞
                    typ.Bg[3].SetActive(true);// 마탑 안
                    typ.Bg[4].SetActive(false);// 마탑 문 앞
                    typ.Bg[5].SetActive(false);// 진의 방
                }

            }

        }
        else
        {
            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);

            Name[0].SetActive(false);
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

                //StartTyping(); // 대화 시작
            }

           
     
        }

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //문장들 저장
        GameData_Find_s1 data = new GameData_Find_s1();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data1", jsonData);
        PlayerPrefs.Save();


    }

    public void Sectences_Reset_Settings()
    {
        //아이네 방에서 나올 문장들 리셋
        PlayerPrefs.DeleteKey("find_Text_Data1");
        PlayerPrefs.Save();

        Sentences_0 = 0;

        Dia[0].SetActive(false);
        Dia[1].SetActive(false);
        Dia[2].SetActive(false);
        Dia[3].SetActive(false);

        Name[0].SetActive(false);
        Name[1].SetActive(false);
        Name[2].SetActive(false);

        find_s.Typ_Dia_Total.SetActive(true);//0721추가추가
    }

    public void FixedUpdate()
    {
       
    }


    public void Choose_Obj_0()//휴오쟌 발견
    {
        find_s.Dia[0].SetActive(false);
        typ.Ch[4].SetActive(true);

        Sentences_0 = 0;
        StartTyping_0();

        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        typ.Ch[4].SetActive(true);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나


        //typ.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[0].SetActive(true);//0번째 말풍선만 활성화

        find_s.touch_able_b[1].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나


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
        find_s.touch_able_b[1].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

    }

    public void Choose_Obj_2()
    {
        Sentences_2 = 0;
        StartTyping_2();

       // typ1.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0번째 말풍선만 활성화
        find_s.touch_able_b[1].SetActive(false);//버튼이 들어있는 거 비활성화
        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

    }

    public void Choose_Obj_3()
    {
        Sentences_3 = 0;
        StartTyping_3();

        //typ1.Names.SetActive(true);//이름 쓰는 곳

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0번째 말풍선만 활성화
        find_s.touch_able_b[1].SetActive(false);//버튼이 들어있는 거 비활성화

        //sug.Suggest.SetActive(false);//제시하기 버튼 비활성화

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//아이네
        Name[1].SetActive(false);//휴오쟌
        Name[2].SetActive(false);//리베나

    }

 

    //만약 금색 패를 터치했을 때 0
    public void Next_Text_0()
    {
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

    void NextSentence_0()
    {
        Sentences_0++;


        if (Sentences_0 < sentences_0.Length)
        {
            if(Sentences_0 == 0)
            {
                StartTyping_0();

                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                sug.Suggest.SetActive(false);
                item.Suggest.SetActive(false);

                if (Sentences_0 == 23)//24는 같아서 생략 //24에서 배경 바꾸기
                {
                    fade.Fade_BE.SetActive(true);
                    fade.Fade_In_Out.SetTrigger("Go_Blue");

                   
                }

                if(Sentences_0 == 24)
                {
                    blue.SetActive(true);

                  
                }


                if (Sentences_0 > 24 && Sentences_0 < 35)
                {
                    if (Sentences_0 == 25)
                    {
                        blue.SetActive(false);

                        fade.Fade_In_Out.SetTrigger("Go_Empty");
                        StartCoroutine(Bye_Fade());
                        IEnumerator Bye_Fade()
                        {
                            yield return new WaitForSeconds(1.5f);
                            fade.Fade_BE.SetActive(false);

                        }
                    }

                    if (Sentences_0 == 25)
                    {
                        fade.Fade_BE.SetActive(false);
                    }

                  

                }

            }

            /*if (Sentences_0 == 23)//24는 같아서 생략 //24에서 배경 바꾸기
            {

                StartTyping_0();

                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                sug.Suggest.SetActive(false);
                item.Suggest.SetActive(false);

                fade.Fade_BE.SetActive(true);
                fade.Fade_In_Out.SetTrigger("Go_Blue");


            }

            if (Sentences_0 == 24)
            {
                blue.SetActive(true);
                StartTyping_0();

                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                sug.Suggest.SetActive(false);
                item.Suggest.SetActive(false);

            }


            if (Sentences_0 > 24 && Sentences_0 < 35)
            {
                if (Sentences_0 == 25)
                {
                    StartTyping_0();

                    for (int i = 0; i < Dia.Length; i++)
                    {
                        Dia[i].SetActive(false);
                    }
                    Dia[0].SetActive(true);

                    sug.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);

                    blue.SetActive(false);

                    fade.Fade_BE.SetActive(false);
                    fade.Fade_In_Out.SetTrigger("Go_Empty");
                    StartCoroutine(Bye_Fade());
                    IEnumerator Bye_Fade()
                    {
                        yield return new WaitForSeconds(1.5f);
                        fade.Fade_BE.SetActive(false);

                    }
                }

                if (Sentences_0 == 25)
                {
                    StartTyping_0();

                    for (int i = 0; i < Dia.Length; i++)
                    {
                        Dia[i].SetActive(false);
                    }
                    Dia[0].SetActive(true);

                    sug.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);
                    fade.Fade_BE.SetActive(false);
                }



            }*/

            else
            {
                Sectences_Save_Settings();

                StartTyping_0();

                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                sug.Suggest.SetActive(false);
                item.Suggest.SetActive(false);

                if (Sentences_0 == 23)//24는 같아서 생략 //24에서 배경 바꾸기
                {
                    fade.Fade_BE.SetActive(true);
                    fade.Fade_In_Out.SetTrigger("Go_Blue");

                    
                }


                if (Sentences_0 > 24 && Sentences_0 < 35)
                {
                    if (Sentences_0 == 25)
                    {
                        fade.Fade_In_Out.SetTrigger("Go_Empty");
                        StartCoroutine(Bye_Fade());
                        IEnumerator Bye_Fade()
                        {
                            yield return new WaitForSeconds(1.5f);
                            fade.Fade_BE.SetActive(false);

                        }
                    }

                    if (Sentences_0 == 25)
                    {
                        fade.Fade_BE.SetActive(false);
                    }

                }

                if(Sentences_0 >= 35 && Sentences_0 <= 43)
                {
                    typ.Bg_0 = 4;
                    typ.Bg[0].SetActive(false);
                    typ.Bg[1].SetActive(false);//아이네 방 비활성
                    typ.Bg[2].SetActive(false);//마탑 앞 활성화
                    typ.Bg[3].SetActive(false);
                    typ.Bg[4].SetActive(true);
                    typ.Bg[5].SetActive(false);
                }

            }
            
            
        }

        else if (Sentences_1 >= 42)
        {
            typ.Bg_0 = 4;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(false);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);

            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            for (int i = 0; i < Name.Length; i++)
            {
                Name[i].SetActive(false);
            }


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
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[0].SetActive(false);
                // find_s.touch_able_b[2].SetActive(false);
                // find_s.touch_able_b[3].SetActive(false);
                find_s.btn_Collection.SetActive(true);



                find2.Arrow[0].SetActive(true);
                find2.Arrow[1].SetActive(true);
                find2.Arrow[2].SetActive(false);
                find2.Arrow[3].SetActive(false);
                find2.Arrow[4].SetActive(false);
                find2.Arrow[5].SetActive(false);

                find2.Name[0].SetActive(false);
                find2.Name[1].SetActive(false);
                find2.Name[2].SetActive(false);//리베나

            }
        }


        else
        {
            Debug.Log("대화 종료");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            find_s.Typ_Dia_Total.SetActive(true);//0721추가추가

            typ.Bg_0 = 4;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//아이네 방 비활성
            typ.Bg[2].SetActive(false);//마탑 앞 활성화
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);


            Debug.Log("배경 바뀌어라");

            //find2.Go_Find2();


            Name[0].SetActive(false);//아이네
            Name[1].SetActive(false);//휴오쟌
            Name[2].SetActive(false);//리베나

            //find_s.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            
            //배경 바뀜에 따라 버튼 누를 수 있는 것도 달라짐
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            //find_s.touch_able_b[2].SetActive(false);//진 방문앞 버튼


            //새로 추가
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
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[0].SetActive(false);
               // find_s.touch_able_b[2].SetActive(false);
               // find_s.touch_able_b[3].SetActive(false);
                find_s.btn_Collection.SetActive(true);

          

                /*find2.Arrow[0].SetActive(true);
                find2.Arrow[1].SetActive(true);
                find2.Arrow[2].SetActive(false);
                find2.Arrow[3].SetActive(false);
                find2.Arrow[4].SetActive(false);
                find2.Arrow[5].SetActive(false);*/

                find2.Name[0].SetActive(false);
                find2.Name[1].SetActive(false);
                find2.Name[2].SetActive(false);//리베나

            }
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
            if (word.StartsWith("너"))
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

            
            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌

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

            find_s.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성

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
            if (word.StartsWith("너"))
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

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌

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

            find_s.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성

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
            if (word.StartsWith("너"))
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

            Name[0].SetActive(true);//아이네
            Name[1].SetActive(false);//휴오쟌

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

            find_s.touch_able_b[1].SetActive(true);//버튼이 들어있는 거 활성

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
            if (word.StartsWith("너"))
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


}
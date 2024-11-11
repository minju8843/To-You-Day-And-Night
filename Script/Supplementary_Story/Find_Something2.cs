using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Find_s2
{
    //public int L_Arrow_Index;//��ư �� �� ��������
    public int R_Arrow_Index;//��ư �� �� ��������

    public int Sentences_0_Index;//�� ó�� ���� �κ� �ε���
}
public class Find_Something2 : MonoBehaviour
{
    //public GameObject Typ_Dia_Total;

    public RectTransform[] lab;

    public GameObject[] Arrow;//ȭ��ǥ

    public Find_Something find_s;
    public Find_Something1 find_s1;

    public Butt_Ch butt_ch;

    public GameObject[] Name;//�̸�

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//�����ϱ� ��ư ��Ȱ��ȭ ��Ű�� ���� �ۼ�
    public Item item;


    public GameObject[] Dia;//��ġ�� ������Ʈ�� ���� ��ǳ����
    public Text[] text;//��ġ�� ������Ʈ�� ���� ��ǳ�� ���� �ؽ�Ʈ��

    //��ư �� �� �������� - ��
   // public int L_Normal_Arrow = 0;//���µǾ� ����Ʈ �� �� //Sentences_0
   // public int L_Default_Arrow = 0; // ���� ������ ����Ǿ�����//Default_Sentences_0
   // public int L_Current_Arrow = 0; // ���� ������ �ε���//Current_Sentences_0

    //��ư �� �� �������� - ��
    public int R_Normal_Arrow = 0;//���µǾ� ����Ʈ �� �� //Sentences_0
    public int R_Default_Arrow = 0; // ���� ������ ����Ǿ�����//Default_Sentences_0
    public int R_Current_Arrow = 0; // ���� ������ �ε���//Current_Sentences_0

    //�޿��� ���� ���� Ÿ���� ����
    public string[] sentences_0; // ǥ�õ� ��ȭ �����
    public int Sentences_0 =0;//���µǾ� ����Ʈ �� ��
    private bool isTyping_0 = false; // Ÿ���� ������ ����

    //���� ����
    public int Default_Sentences_0 = 0; // ���� ������ ����Ǿ�����
    public int Current_Sentences_0 = 0; // ���� ������ �ε���


    //�ſ￡ ���� ���� Ÿ���� ����
    public string[] sentences_1; // ǥ�õ� ��ȭ �����
    public int Sentences_1;//���µǾ� ����Ʈ �� ��
    private bool isTyping_1 = false; // Ÿ���� ������ ����

    //�� �ִ� å�� ���� ���� Ÿ���� ����
    public string[] sentences_2; // ǥ�õ� ��ȭ �����
    public int Sentences_2;//���µǾ� ����Ʈ �� ��
    private bool isTyping_2 = false; // Ÿ���� ������ ����

    //������ ���� ���� Ÿ���� ����
    public string[] sentences_3; // ǥ�õ� ��ȭ �����
    public int Sentences_3;//���µǾ� ����Ʈ �� ��
    private bool isTyping_3 = false; // Ÿ���� ������ ����

    //���ڿ� ���� ���� Ÿ���� ����
    public string[] sentences_4; // ǥ�õ� ��ȭ �����
    public int Sentences_4;//���µǾ� ����Ʈ �� ��
    private bool isTyping_4 = false; // Ÿ���� ������ ����

    //ħ�뿡 ���� ���� Ÿ���� ����
    public string[] sentences_5; // ǥ�õ� ��ȭ �����
    public int Sentences_5;//���µǾ� ����Ʈ �� ��
    private bool isTyping_5 = false; // Ÿ���� ������ ����

    //â���� ���� ���� Ÿ���� ����
   // public string[] sentences_6; // ǥ�õ� ��ȭ �����
    //public int Sentences_6;//���µǾ� ����Ʈ �� ��
    //private bool isTyping_6 = false; // Ÿ���� ������ ����


    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����


    //Ȱ�� ��Ȱ�� Ȯ��
    //public GameObject One;

    public void Start()
    {
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
            //��ġ�ϸ� ������ �� �Ŵϱ�
        }

        

        Name[0].SetActive(false);
        Name[1].SetActive(false);
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        if (Sentences_0 > 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            //sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 5;

            Sectences_Save_Settings();

        
        }

    }

    public void OnEnable()
    {
        Load_Sentences_0();
        R_Load_Arrow();


        if (Sentences_0 == 0 && (find_s1.Current_Sentences_0 < find_s1.sentences_0.Length
            || typ.Current_Sentences_1 < typ.sentences_1.Length
            || typ1.Current_Sentences_1 < typ1.sentences_1.Length
            || find_s.Sentences_0 < find_s.sentences_0.Length || Sentences_0 >= sentences_0.Length))
        {
            Name[0].SetActive(false);
            Name[1].SetActive(false);
            Name[2].SetActive(false);//������

            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

            Debug.Log("ȭ��ǥ üũ1");

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if (find_s1.Current_Sentences_0 >= find_s1.sentences_0.Length
            && R_Normal_Arrow == 0)
        {
            find_s.touch_able_b[2].SetActive(true);
            find_s.btn_Collection.SetActive(true);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            typ.Bg[4].SetActive(true);
            typ.Bg[3].SetActive(false);

            Debug.Log("�̰� �� ������0?");

            R_Normal_Arrow = 0;
            Arrow_Save_Settings();
        }

        else if (find_s1.Current_Sentences_0 >= find_s1.sentences_0.Length
            && R_Normal_Arrow == 1)
        {
            find_s.touch_able_b[3].SetActive(true);
            find_s.btn_Collection.SetActive(true);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            typ.Bg[4].SetActive(false);
            typ.Bg[3].SetActive(true);

            Debug.Log("�̰� �� ������1?");

            R_Normal_Arrow = 1;
            Arrow_Save_Settings();
        }

        else if (find_s1.Current_Sentences_0 >= find_s1.sentences_0.Length
            && R_Normal_Arrow == 2)
        {
            find_s.touch_able_b[3].SetActive(true);
            find_s.btn_Collection.SetActive(true);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            typ.Bg[4].SetActive(false);
            typ.Bg[3].SetActive(true);

            Debug.Log("�̰� �� ������2?");

            R_Normal_Arrow = 2;
            Arrow_Save_Settings();
        }

       
    }

    public void R_Load_Arrow()
    {
        //���̳� �濡�� ���� ����� �ҷ�����
        if (PlayerPrefs.HasKey("R_Arrow_Count_Data"))
        {
            string jsonData = PlayerPrefs.GetString("R_Arrow_Count_Data");
            GameData_Find_s2 data = JsonUtility.FromJson<GameData_Find_s2>(jsonData);

            R_Normal_Arrow = data.R_Arrow_Index;
        }

        else
        {
            R_Normal_Arrow = 0;
        }
    }

    public void Arrow_Save_Settings()
    {

        GameData_Find_s2 data1 = new GameData_Find_s2();
        data1.R_Arrow_Index = R_Normal_Arrow;
        string jsonData1 = JsonUtility.ToJson(data1);
        PlayerPrefs.SetString("R_Arrow_Count_Data", jsonData1);
        PlayerPrefs.Save();
    }

    public void Arrow_Reset_Settings()
    {
        //��ư Ƚ�� ����
       // PlayerPrefs.DeleteKey("L_Arrow_Count_Data");
        PlayerPrefs.DeleteKey("R_Arrow_Count_Data");
        PlayerPrefs.Save();
        R_Normal_Arrow = 0;

        find_s.touch_able_b[0].SetActive(false);
        find_s.touch_able_b[1].SetActive(false);
        find_s.touch_able_b[2].SetActive(false);
        find_s.touch_able_b[3].SetActive(false);

        PlayerPrefs.DeleteKey("find_Text_Data2");
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


        for(int i=0; i<typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

    }


    public void Load_Sentences_0()
    {
        if (PlayerPrefs.HasKey("find_Text_Data2"))
        {
            string jsonData = PlayerPrefs.GetString("find_Text_Data2");
            GameData_Find_s2 data = JsonUtility.FromJson<GameData_Find_s2>(jsonData);

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

                if (Sentences_0 > 4)
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

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    //find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

                }


                

                else if (Sentences_0 <= 4)
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
             

                //StartTyping(); // ��ȭ ����
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

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //����� ����
        GameData_Find_s2 data = new GameData_Find_s2();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data2", jsonData);
        PlayerPrefs.Save();


    }

    



    public void Update()
    {

        

        if (Dia[0].activeSelf==true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);
        }

        Current_Sentences_0 = Sentences_0;
        R_Current_Arrow = R_Normal_Arrow;

        if ( typ.Ch[8].activeSelf ==true && Name[0].activeSelf == true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if ((Sentences_0 == 1) && Name[2].activeSelf == true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

        }

        if (Sentences_0 == 3 && Name[2].activeSelf == true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if (Sentences_0 == 4 && Name[0].activeSelf == true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
        }

        if (Sentences_0 == 2 && Name[0].activeSelf == true)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        //0721 ��� �߰�
        if ((Arrow[0].activeSelf == true && Arrow[1].activeSelf == true
            && Arrow[2].activeSelf == false && Arrow[3].activeSelf == false
            && Arrow[4].activeSelf == false && Arrow[5].activeSelf == false) && R_Normal_Arrow == 0)
        {
            //�湮 ������ �̵�
            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);// ���� ��

            R_Normal_Arrow = 0;
            Arrow_Save_Settings();
        }

        if ((Arrow[0].activeSelf == false && Arrow[1].activeSelf == false
            && Arrow[2].activeSelf == true && Arrow[3].activeSelf == true
            && Arrow[4].activeSelf == false && Arrow[5].activeSelf == false) && R_Normal_Arrow == 1)
        {

            //�������� ���� ��
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);// ���� ��


            //423
            lab[0].anchoredPosition = new Vector2(422.0001f, 0);
            lab[1].anchoredPosition = new Vector2(422.0001f, 0);

            R_Normal_Arrow = 1;
            Arrow_Save_Settings();
        }
        if ((Arrow[0].activeSelf== false && Arrow[1].activeSelf == false
            && Arrow[2].activeSelf == false && Arrow[3].activeSelf == false
            && Arrow[4].activeSelf == true && Arrow[5].activeSelf == true) && R_Normal_Arrow == 2)
        {
            //�������� �ִ� ��
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);// ���� ��

            //-417
            lab[0].anchoredPosition = new Vector2(-417, 0);
            lab[1].anchoredPosition = new Vector2(-417, 0);

            R_Normal_Arrow = 2;
            Arrow_Save_Settings();
        }

        if (typ.Sentences_1 == 0)
        {
            Dia[0].SetActive(false);
        }

        if (find_s1.Sentences_0 > find_s1.sentences_0.Length && typ1.Sentences_1 > typ1.sentences_1.Length)
        {
            typ.Bg[2].SetActive(false);
            
        }

        if (Sentences_0 == 0 && (typ.Bg[3].activeSelf ==true || typ.Bg[4].activeSelf == true))
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

        }

        if (Sentences_0 == 0 && typ.Bg[3].activeSelf == true && typ.Ch[8].activeSelf==true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

      

        if (Sentences_0 > 0 && Sentences_0 < 5)//����0718
        {
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        //������
        Arrow_Save_Settings();

        if (find_s1.Sentences_0 <= 42 || typ2.Sentences_1 > 46)
        {
            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            //Debug.Log("ȭ��ǥ üũ2");

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }
        }


        if (find_s1.Sentences_0 > 42 && R_Normal_Arrow == 0 && typ2.Sentences_1 < 1 && find_s1.start.activeSelf==false)//0
        {
          

            if (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false
            && (sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true))
            {
                

                Arrow[0].SetActive(true);
                Arrow[1].SetActive(true);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);


                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(true);//������ �ִ� ��ž ������
                find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
                find_s.btn_Collection.SetActive(true);

                sug.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

            }

            if (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true
            && (sug.Suggest.activeSelf == false || item.Suggest.activeSelf == false))
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);

                Debug.Log("ȭ��ǥ üũ3");

                for (int i = 0; i < find_s.touch_able_b.Length; i++)
                {
                    find_s.touch_able_b[i].SetActive(false);
                }
                find_s.btn_Collection.SetActive(false);
            }


            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);//������ ���� ��ž
            typ.Bg[4].SetActive(true);//�� ��
            typ.Bg[5].SetActive(false);//�� ��
     

            typ.Bg_0 = 4;

            R_Normal_Arrow = 0;//�߰�0721
            Arrow_Save_Settings();//�߰�0721

            //find_s.touch_able_b[2].SetActive(true);//�� �湮�� ��ư

        }

        


        if (find_s1.Sentences_0 > 42 && R_Normal_Arrow == 1 && typ2.Sentences_1 < 1)//1
        {

            if (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false
            && (sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true))
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(true);
                Arrow[3].SetActive(true);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);

                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(true);
                find_s.touch_able_b[4].SetActive(false);

                //0727
                sug.Suggest.SetActive(true);
                item.Suggest.SetActive(true);


            }

            if (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true
            && (sug.Suggest.activeSelf == false || item.Suggest.activeSelf == false))
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);

                Debug.Log("ȭ��ǥ üũ4");

                for (int i = 0; i < find_s.touch_able_b.Length; i++)
                {
                    find_s.touch_able_b[i].SetActive(false);
                }
            }


            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(true);//������ ���� ��ž
            typ.Bg[4].SetActive(false);//�� ��
            typ.Bg[5].SetActive(false);//�� ��
      



            //find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư

            typ.Bg_0 = 3;

            R_Normal_Arrow = 1;//�߰�0721
            Arrow_Save_Settings();//�߰�0721
        }

        if (find_s1.Sentences_0 > 42 && R_Normal_Arrow == 2 && typ2.Sentences_1 < 1)//2
        {
            if (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false 
            && (sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true))
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(true);
                Arrow[5].SetActive(true);

                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(true);
                find_s.touch_able_b[4].SetActive(false);

                //0727
                sug.Suggest.SetActive(true);
                item.Suggest.SetActive(true);
            }

            if (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true
            && (sug.Suggest.activeSelf == false || item.Suggest.activeSelf == false))
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);

                Debug.Log("ȭ��ǥ üũ5");

                for (int i = 0; i < find_s.touch_able_b.Length; i++)
                {
                    find_s.touch_able_b[i].SetActive(false);
                }
            }

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(true);//������ ���� ��ž
            typ.Bg[4].SetActive(false);//�� ��
            typ.Bg[5].SetActive(false);//�� ��
   



            // find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư

            typ.Bg_0 = 3;

            R_Normal_Arrow = 2;//�߰�0721
            Arrow_Save_Settings();//�߰�0721
        }

        //���� ù ��° ��ҿ��� ���丮 ��簡 �� ������ Ž���� Ȱ��ȭ�ǵ���
        /*if (find_s1.Sentences_0 > 42 && typ.Bg[6].activeSelf == true)//������ �ִ� ��
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            //find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư

            //One.SetActive(true);//���ֱ�

            
            find_s.btn_Collection.SetActive(true);

            typ.Bg[3].SetActive(false);

            

            //�߰�
            //sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            find_s1.Sentences_0 = 43;

            find_s1.Sectences_Save_Settings();
        }*/

        if (find_s1.Sentences_0 > 42 && typ.Bg[4].activeSelf == true)//�� �湮 ��
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            // find_s.touch_able_b[2].SetActive(true);//�� �湮�� ��ư


            find_s.btn_Collection.SetActive(true);



            //�߰�
            // sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            find_s1.Sentences_0 = 43;

            find_s1.Sectences_Save_Settings();

        }


        //Ž������ ��ǳ���� �������� ���� �� + ���� �������� �ִ� ��Ҷ��
        if (find_s1.Sentences_0 > 42 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false) && typ.Bg[4].activeSelf == false && typ.Bg[3].activeSelf == true)
        /*(item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
        && typ.Bg[4].activeSelf == false && typ.Bg[3].activeSelf == true)*/
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(true);//������ �ִ� ��ž ������
            find_s.touch_able_b[4].SetActive(false);

            find_s.btn_Collection.SetActive(true);


            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            //Debug.Log("�̰ų�? 0714");
        }

        //Ž������ ��ǳ���� �������� ���� �� + ���� �� �湮 ���̶��
        if (find_s1.Sentences_0 > 42 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false) && typ.Bg[4].activeSelf == true && typ.Bg[3].activeSelf == false)
        /*(item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
        && typ.Bg[4].activeSelf == true && typ.Bg[3].activeSelf == false)*/
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(true);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[4].SetActive(false);

            find_s.btn_Collection.SetActive(true);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


        }

        // ���� Ž������ ��ǳ���� ���� ��
        if (find_s1.Sentences_0 > 42 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true ))/* ||
            (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true))*/
        {
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }


            find_s.btn_Collection.SetActive(false);

            if(R_Normal_Arrow == 0)
            {
                typ.Bg_0 = 4;

                typ.Bg[0].SetActive(false);// �� ������ ��
                typ.Bg[1].SetActive(false);// ���̳� ��
                typ.Bg[2].SetActive(false);// ��ž ��
                typ.Bg[3].SetActive(false);// ��ž ��
                typ.Bg[4].SetActive(true);// ��ž �� ��
                typ.Bg[5].SetActive(false);// ���� ��
            }

            if (R_Normal_Arrow == 1  || R_Normal_Arrow == 2)
            {
                typ.Bg_0 = 3;

                typ.Bg[0].SetActive(false);// �� ������ ��
                typ.Bg[1].SetActive(false);// ���̳� ��
                typ.Bg[2].SetActive(false);// ��ž ��
                typ.Bg[3].SetActive(true);// ��ž ��
                typ.Bg[4].SetActive(false);// ��ž �� ��
                typ.Bg[5].SetActive(false);// ���� ��
            }



        }


        //0��° ���� + ������
        if (Sentences_0 == 3 || Sentences_0 == 1)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);//������

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
          

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //0��° ���� + ���̳�
        if (Sentences_0 == 2 || Sentences_0 == 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            typ.Ch[8].SetActive(true);//������

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
         

        }

        //1��° ���� + ������
        if ((Sentences_1 > 2 && Sentences_1 < 7) || Sentences_1 == 8
            || (Sentences_1 > 9 && Sentences_1 < 16) || Sentences_1 == 17
             || (Sentences_1 > 18 && Sentences_1 < 24))
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
        
        }

        //1��° ���� + ���̳� + å
        if (Sentences_1 < 3 && Sentences_1 > 0)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

         

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
       

        }

        //1��° ���� + ���̳�
        if (Sentences_1 == 7
            || Sentences_1 == 9 || Sentences_1 == 16 || Sentences_1 == 18 || Sentences_1 == 24)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
         

        }

        //4��° ���� + ���̳�
        if (Sentences_4 > 0 && Sentences_4 < 3 || Sentences_4 == 4 || Sentences_4 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
 

        }

        //4��° ���� + ������
        if (Sentences_4 == 3)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
    

        }

        //5��° ���� + ������
        if (Sentences_5 == 3 || Sentences_5 == 4 || Sentences_5 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
     

        }

        //5��° ���� + ���̳�
        if (Sentences_5 == 1 || Sentences_5 == 2 || Sentences_5 == 6)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
      

        }
        

    }

  
    public void Go_Right_2()
    {
        sug.Suggest.SetActive(true);
        item.Suggest.SetActive(true);

        //3��° ��ư�� 
        R_Normal_Arrow = 2;//2

        //�������� �ִ� ��
        typ.Bg[4].SetActive(false);
        typ.Bg[3].SetActive(true);

        //-417
        lab[0].anchoredPosition = new Vector2(-417, 0);

        //
        lab[1].anchoredPosition = new Vector2(-417, 0);
     

        find_s.touch_able_b[0].SetActive(false);
        find_s.touch_able_b[1].SetActive(false);
        find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư
        find_s.touch_able_b[3].SetActive(true);
        find_s.touch_able_b[4].SetActive(false);

        find_s.btn_Collection.SetActive(true);

        Debug.Log("��� ������3");

        Debug.Log("������3 ����");

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(true);
        Arrow[5].SetActive(true);

        Arrow_Save_Settings();//�߰�0721
    }

    public void Go_Right_3()
    {
        sug.Suggest.SetActive(true);
        item.Suggest.SetActive(true);

        R_Normal_Arrow = 0;//0

        //�湮 ������ �̵�
        typ.Bg[4].SetActive(true);
        typ.Bg[3].SetActive(false);

        find_s.touch_able_b[0].SetActive(false);
        find_s.touch_able_b[1].SetActive(false);
        find_s.btn_Collection.SetActive(true);

        find_s.touch_able_b[2].SetActive(true);//�� �湮�� ��ư
        find_s.touch_able_b[3].SetActive(false);
        find_s.touch_able_b[4].SetActive(false);

        Debug.Log("��� ������2");

        Debug.Log("������ ����");

        Arrow[0].SetActive(true);
        Arrow[1].SetActive(true);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        Arrow_Save_Settings();//�߰�0721
    }

    public void Go_Right_1()//�湮�� �ִ� ������ ��ư
    {
        sug.Suggest.SetActive(true);
        item.Suggest.SetActive(true);

        R_Normal_Arrow = 1;//1

        //�������� ���� ��
        typ.Bg[4].SetActive(false);
        typ.Bg[3].SetActive(true);

        //423
        lab[0].anchoredPosition = new Vector2(422.0001f, 0);

        lab[1].anchoredPosition = new Vector2(422.0001f, 0);

        find_s.touch_able_b[0].SetActive(false);
        find_s.touch_able_b[1].SetActive(false);
        find_s.btn_Collection.SetActive(true);

        find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư

        find_s.touch_able_b[3].SetActive(true);
        find_s.touch_able_b[4].SetActive(false);

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(true);
        Arrow[3].SetActive(true);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        Debug.Log("��� ������1");

        Debug.Log("������1 ����");

        Arrow_Save_Settings();//�߰�0721
    }

    

    public void Choose_Obj_0()
    {
        Sentences_0 = 0;
        StartTyping_0();

        typ.Ch[8].SetActive(true);//������

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[0].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
   

    }

    public void Choose_Obj_1()
    {
       

        Sentences_1 = 0;
        StartTyping_1();

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[1].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


    }

    public void Choose_Obj_2()
    {
        Sentences_2 = 0;
        StartTyping_2();

        //typ1.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


    }

    public void Choose_Obj_3()
    {
        Sentences_3 = 0;
        StartTyping_3();

       // typ1.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


    }

    //4
    public void Choose_Obj_4()
    {
        Sentences_4 = 0;
        StartTyping_4();

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[4].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


    }

    public void Choose_Obj_5()
    {
        find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư

        Sentences_5 = 0;
        StartTyping_5();

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[5].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ


        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 4;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(true);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


        Debug.Log("0717?");

    }




    //0
    public void Next_Text_0()
    {
        Sectences_Save_Settings();

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
     

        if (isTyping_0)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_0();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���
            //Name[2].SetActive(false);//������


            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[0].SetActive(true);

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);


            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(true);//������ ���� ��ž
            typ.Bg[4].SetActive(false);//�� ��
            typ.Bg[5].SetActive(false);//�� ��
           

            typ.Bg_0 =3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
            item.Item_Count = 1;
        }

        else
        {
            Sectences_Save_Settings();

            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������


            //touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);


            //��� �ٲ� ���� ��ư ���� �� �ִ� �͵� �޶���
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ2.Go_2_Typing();
            
            item.Item_Count = 2;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(true);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);

            Arrow[0].SetActive(false);
            Arrow[1].SetActive(false);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);//������ ���� ��ž
            typ.Bg[4].SetActive(true);//�� ��
            typ.Bg[5].SetActive(false);//�� ��


            typ.Bg_0 = 4;

        }

    }

    void CompleteTyping_0()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[0].text = sentences_0[Sentences_0];
        isTyping_0 = false;
    }

    IEnumerator TypeSentence_0(string sentence)
    {
        isTyping_0 = true;
        text[0].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[0].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[0].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[0].text += ' ';
            }
        }

        isTyping_0 = false;
    }

    //���� �ſ��� ��ġ���� �� 1
    public void Next_Text_1()
    {
        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
     

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        if (isTyping_1)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_1();

        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//

            find_s.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            if(R_Normal_Arrow == 1)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(true);
                Arrow[3].SetActive(true);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);
            }

            if(R_Normal_Arrow == 2)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(true);
                Arrow[5].SetActive(true);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_1()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[1].text = sentences_1[Sentences_1];
        isTyping_1 = false;
    }

    IEnumerator TypeSentence_1(string sentence)
    {
        isTyping_1 = true;
        text[1].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[1].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[1].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[1].text += ' ';
            }
        }

        isTyping_1 = false;
    }

    //���� �� �ִ� å���� ��ġ���� �� 2
    public void Next_Text_2()
    {
        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
  

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        if (isTyping_2)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_2();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            if (R_Normal_Arrow == 1)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(true);
                Arrow[3].SetActive(true);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);
            }

            if (R_Normal_Arrow == 2)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(true);
                Arrow[5].SetActive(true);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_2()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[2].text = sentences_2[Sentences_2];
        isTyping_2 = false;
    }

    IEnumerator TypeSentence_2(string sentence)
    {
        isTyping_2 = true;
        text[2].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[2].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[2].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[2].text += ' ';
            }
        }

        isTyping_2 = false;
    }

    //���� ������ ��ġ���� �� 3
    public void Next_Text_3()
    {
        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
     

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        if (isTyping_3)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_3();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���
            //Name[2].SetActive(false);//������

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            if (R_Normal_Arrow == 1)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(true);
                Arrow[3].SetActive(true);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);
            }

            if (R_Normal_Arrow == 2)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(true);
                Arrow[5].SetActive(true);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_3()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[3].text = sentences_3[Sentences_3];
        isTyping_3 = false;
    }

    IEnumerator TypeSentence_3(string sentence)
    {
        isTyping_3 = true;
        text[3].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[3].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[3].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
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

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��
      

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        for (int i = 0; i < find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

        if (isTyping_4)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_4();

        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            StartTyping_4();


            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���
            //Name[2].SetActive(false);//������

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            if (R_Normal_Arrow == 1)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(true);
                Arrow[3].SetActive(true);
                Arrow[4].SetActive(false);
                Arrow[5].SetActive(false);
            }

            if (R_Normal_Arrow == 2)
            {
                Arrow[0].SetActive(false);
                Arrow[1].SetActive(false);
                Arrow[2].SetActive(false);
                Arrow[3].SetActive(false);
                Arrow[4].SetActive(true);
                Arrow[5].SetActive(true);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_4()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[4].text = sentences_4[Sentences_4];
        isTyping_4 = false;
    }

    IEnumerator TypeSentence_4(string sentence)
    {
        isTyping_4 = true;
        text[4].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[1].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[4].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
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
        typ.Bg_0 = 4;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(true);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        if (isTyping_5)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_5();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���
            //Name[2].SetActive(false);//������

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

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
        }

      

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            Arrow[0].SetActive(true);
            Arrow[1].SetActive(true);
            Arrow[2].SetActive(false);
            Arrow[3].SetActive(false);
            Arrow[4].SetActive(false);
            Arrow[5].SetActive(false);


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_5()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[5].text = sentences_5[Sentences_5];
        isTyping_5 = false;
    }

    IEnumerator TypeSentence_5(string sentence)
    {
        isTyping_5 = true;
        text[5].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[5].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[5].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[5].text += ' ';
            }
        }

        isTyping_5 = false;
    }

    //6
   /* public void Next_Text_6()
    {
        typ.Bg_0 = 3;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(true);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(false);// ���� ��


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
        find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������

        Arrow[0].SetActive(false);
        Arrow[1].SetActive(false);
        Arrow[2].SetActive(false);
        Arrow[3].SetActive(false);
        Arrow[4].SetActive(false);
        Arrow[5].SetActive(false);

        if (isTyping_6)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_6();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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
            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
            StartTyping_6();

            //Name[0].SetActive(true);//���̳�
            //Name[1].SetActive(false);//�޿���
            //Name[2].SetActive(false);//������

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            find_s.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            Arrow[0].SetActive(true);
            Arrow[1].SetActive(true);

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
        }

    }

    void CompleteTyping_6()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[6].text = sentences_6[Sentences_6];
        isTyping_6 = false;
    }

    IEnumerator TypeSentence_6(string sentence)
    {
        isTyping_6 = true;
        text[6].text = "";

        // ������ ������ �������� ������ ó��
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];

            // "��..." �κ��� ó��
            if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[6].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[6].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[6].text += ' ';
            }
        }

        isTyping_6 = false;
    }*/


}
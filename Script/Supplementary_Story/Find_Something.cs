using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���

public class GameData_Finding0
{
    //���� �� ��° Ž�������� - ���̳� ������, ��ž ������, ��ž ������
    //public int TouchAble_Index;
    public int Sentences_0_Index;//���� �߰� 0720


}

public class Find_Something : MonoBehaviour
{
    public GameObject Typ_Dia_Total;

    public GameObject Name;//�̸�

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find_s;
    public Find_Something1 find_s1;

    public Butt_Ch sug;//�����ϱ� ��ư ��Ȱ��ȭ ��Ű�� ���� �ۼ�
    public Item item;

    //Ž�� ���� �� ���� ��ư
    public GameObject btn_Collection;//��ư �� ���ִ� �θ� ������Ʈ
    public GameObject[] touch_able_b;

    //Ž�� ���� �� ���� ��ư �����Ϸ��� ���� �� 
    //���� �� ��° Ž�������� - ���̳� ������, ��ž ������, ��ž ������
    //public int Default_TouchAble = 0; // ���� ������ ����Ǿ�����
    //public int TouchAble;//���µǾ� ����Ʈ �� ��
    //public int Current_TouchAble; // ���� 

    public GameObject[] Dia;//��ġ�� ������Ʈ�� ���� ��ǳ����
    public Text[] text;//��ġ�� ������Ʈ�� ���� ��ǳ�� ���� �ؽ�Ʈ��

    //�ݻ� �п� ���� ���� Ÿ���� ����
   // public string[] sentences_0; // ǥ�õ� ��ȭ �����
    //public int Sentences_0;//���µǾ� ����Ʈ �� ��
    //private bool isTyping_0 = false; // Ÿ���� ������ ����

    //�ݻ� �п� ���� ���� Ÿ���� ����
    public string[] sentences_0; // ǥ�õ� ��ȭ �����
    public int Sentences_0 = 0;//���µǾ� ����Ʈ �� ��
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
    public string[] sentences_6; // ǥ�õ� ��ȭ �����
    public int Sentences_6;//���µǾ� ����Ʈ �� ��
    private bool isTyping_6 = false; // Ÿ���� ������ ����


    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����

    void Start()
    {
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
            //��ġ�ϸ� ������ �� �Ŵϱ�
        }

        Name.SetActive(false);


        //���� �߰� 0720
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

            Name.SetActive(false);

            //sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 5;

            Sectences_Save_Settings();

             Debug.Log("�� ��°��" + Sentences_0);
        }

        //���� �߰�
        else if (Sentences_0 == 0)
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

            Name.SetActive(false);




        }
    }

    public void Update()
    {


        //Debug.Log("�� ��°��" + Sentences_0);
        //���� �߰� 

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

            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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
            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
            Debug.Log("��0720");
        }

        if (Sentences_0 == 0 && item.Item_Count == 4
            && typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true
             && Name.activeSelf == false && typ.Bg[2].activeSelf == false)
        {
            Dia[0].SetActive(false);
            typ1.Dia.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
            Debug.Log("�ʳ�0720");


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
            Debug.Log("�ʳʳ�0720");
            typ.Ch[3].SetActive(true);

            typ1.Dia.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�

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

        //ü��
        //ħ�뿡�� Ž������ ��ǳ���� �������� ���� ��
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
            //Debug.Log("�̰ų�? 0714");

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

        //ħ�뿡�� ���� Ž������ ��ǳ���� ���� ��
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
            //Debug.Log("�̰�? 0714");
        }


        //������
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

            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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

            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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

            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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
            Sectences_Save_Settings();//���� �߰�720

            typ1.Dia.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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

            Sectences_Save_Settings();//���� �߰�720
        }


    }

    public void OnEnable()
    {
        Load_Sentences_0();//���� �߰�0720

        //�����߰� 0720
        if (Sentences_0 == 0 && (find_s1.Current_Sentences_0 < 0
           || typ.Current_Sentences_1 < typ.sentences_1.Length
           || typ1.Current_Sentences_1 < 0
           || Sentences_0 >= sentences_0.Length))
        {
            Name.SetActive(false);


            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

        }

    }

    //���� �߰�0720
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

    //���� �߰� 0720
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

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

                    Sentences_0 = 5;//���� �߰�720
                    Sectences_Save_Settings();//���� �߰�720
                    //Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    find_s.Typ_Dia_Total.SetActive(true);//0720 �߰�

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

                    Debug.Log("�� ��°��" + Sentences_0);
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

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //����� ����
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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }
        
        Dia[0].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ

        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[1].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[4].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

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

        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[5].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
    }

    public void Choose_Obj_6()
    {
        Sentences_6 = 0;
        StartTyping_6();

        // typ.Names.SetActive(true);//�̸� ���� ��
        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[6].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name.SetActive(true);
    }


    //���� �ݻ� �и� ��ġ���� �� 0
    public void Next_Text_0()
    {
        typ.Ch[3].SetActive(true);

        Sectences_Save_Settings();

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
            typ.Bg[1].SetActive(true);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            typ.Ch[3].SetActive(false);
            Name.SetActive(false);

            //touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            //�����ۿ� �ݻ� �� �߰�
            //item.small_square[1].SetActive(true);
            //item.Item_Count = 1;

            //��� �ٲ� ���� ��ư ���� �� �ִ� �͵� �޶���
            touch_able_b[0].SetActive(false);
            touch_able_b[1].SetActive(false);
            touch_able_b[2].SetActive(false);
            touch_able_b[3].SetActive(false);



            typ1.Go_1_Typing();
            


            typ.Bg_0 =2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(true);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
         
            Debug.Log("��� �ٲ���");


            item.Item_Count =1 ;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
          


            find_s.Typ_Dia_Total.SetActive(true);//0720 �߰�

        }

    }

    public void CompleteTyping_0()
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
            if (word.StartsWith("..."))
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

       
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

          
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
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

    //���� ���ڸ� ��ġ���� �� 4
    public void Next_Text_4()
    {
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

           
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[4].text += letter;
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

    //���� ħ�븦 ��ġ���� �� 5
    public void Next_Text_5()
    {
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            
            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
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

    //���� â���� ��ġ���� �� 6
    public void Next_Text_6()
    {
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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            Name.SetActive(false);

            touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
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
            if (word.StartsWith("..."))
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
    }
}
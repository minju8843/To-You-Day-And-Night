using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Find_s4
{
    public int Sentences_0_Index;//�� ó�� ���� �κ� �ε���
}
public class Find_Something4 : MonoBehaviour
{
    public SFX_Manager sfx;

    public B_Button b_btn;

    //����
    public Butterfly bty;

    public GameObject blue;
    public Blue_Fade fade;

    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;
    public Find_Something3 find_s3;

    public Butt_Ch butt_ch;

    public GameObject[] Name;//�̸�

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//�����ϱ� ��ư ��Ȱ��ȭ ��Ű�� ���� �ۼ�
    public Item item;


    public GameObject[] Dia;//��ġ�� ������Ʈ�� ���� ��ǳ����
    public Text[] text;//��ġ�� ������Ʈ�� ���� ��ǳ�� ���� �ؽ�Ʈ��


    

    //�޿��� ���� ���� Ÿ���� ����
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




    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����


    public void Start()
    {
       
        
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
            //��ġ�ϸ� ������ �� �Ŵϱ�
        }

        Name[0].SetActive(false);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��


        if (Sentences_0 > 126)
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
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            Sentences_0 = 127;

            Sectences_Save_Settings();

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
        }

    }

    public void OnEnable()
    {
        Load_Sentences_0();



        if (Sentences_0 == 0 && (find_s1.Current_Sentences_0 < find_s1.sentences_0.Length
            || typ.Current_Sentences_1 < typ.sentences_1.Length
            || typ1.Current_Sentences_1 < typ1.sentences_1.Length || typ2.Current_Sentences_1 < typ2.sentences_1.Length
            || find_s.Sentences_0 < find_s.sentences_0.Length || find_s1.Sentences_0 < find_s1.sentences_0.Length
            || find_s2.Sentences_0 < find_s2.sentences_0.Length || find_s3.Sentences_0 < find_s3.sentences_0.Length
            || Sentences_0 >= sentences_0.Length))
        {
            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��



            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

            Debug.Log("ȭ��ǥ üũ1");

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if (Sentences_0 == 0 && find_s3.Current_Sentences_0 > find_s3.sentences_0.Length)
        {
            find_s.btn_Collection.SetActive(true);

            Debug.Log("�̰� �� ������0?");

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


        }

    }



    public void Reset_Settings()
    {

        find_s.touch_able_b[5].SetActive(false);

        PlayerPrefs.DeleteKey("find_Text_Data4");
        PlayerPrefs.Save();

        Sentences_0 = 0;

        Dia[0].SetActive(false);
        Dia[1].SetActive(false);
        Dia[2].SetActive(false);
        Dia[3].SetActive(false);
        Dia[4].SetActive(false);
        Dia[5].SetActive(false);


        Name[0].SetActive(false);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��



        for (int i = 0; i < typ.Ch.Length; i++)
        {
            typ.Ch[i].SetActive(false);
        }

        find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

    }


    public void Load_Sentences_0()
    {
        if (PlayerPrefs.HasKey("find_Text_Data4"))
        {
            string jsonData = PlayerPrefs.GetString("find_Text_Data4");
            GameData_Find_s4 data = JsonUtility.FromJson<GameData_Find_s4>(jsonData);

            Sentences_0 = data.Sentences_0_Index;


            Dia[0].SetActive(false);
            Dia[1].SetActive(false);
            Dia[2].SetActive(false);
            Dia[3].SetActive(false);
            Dia[4].SetActive(false);
            Dia[5].SetActive(false);



            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                if (Sentences_0 > 126)
                {
                    typ.Ch[22].SetActive(false);

                    butt_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    Dia[0].SetActive(false);
                    Dia[1].SetActive(false);
                    Dia[2].SetActive(false);
                    Dia[3].SetActive(false);
                    Dia[4].SetActive(false);
                    Dia[5].SetActive(false);


                    Name[0].SetActive(false);//���̳�
                    Name[1].SetActive(false);//�޿���
                    Name[2].SetActive(false);//������
                    Name[3].SetActive(false);//������
                    Name[4].SetActive(false);//��

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    typ.Bg_0 = 0;

                    typ.Bg[0].SetActive(true);// �� ������ ��
                    typ.Bg[1].SetActive(false);// ���̳� ��
                    typ.Bg[2].SetActive(false);// ��ž ��
                    typ.Bg[3].SetActive(false);// ��ž ��
                    typ.Bg[4].SetActive(false);// ��ž �� ��
                    typ.Bg[5].SetActive(false);// ���� ��

                }




                else if (Sentences_0 <= 126)
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



            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

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


        }

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //����� ����
        GameData_Find_s4 data = new GameData_Find_s4();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data4", jsonData);
        PlayerPrefs.Save();


    }





    public void Update()
    {
        Current_Sentences_0 = Sentences_0;


        if (typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            item.Item_Count = 3;

            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(true);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(true);
        }

        //�ݻ� �� ������ ���
        if (Sentences_0 == 0 && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            Debug.Log("Ȯ��1");

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if (typ.Sentences_1 == 0 || typ1.Sentences_1 == 0 || typ2.Sentences_1 == 0)
        {
            Dia[0].SetActive(false);
        }

        if (Sentences_0 == 0 && typ2.Sentences_1 >= typ2.sentences_1.Length && find_s3.Sentences_0 >= find_s3.sentences_0.Length &&
            (item.Suggest.activeSelf == true || butt_ch.Suggest.activeSelf == true))
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }



        //����� �̸� ������ ���- �޿��� �׸� ����
        /*if ((Sentences_0 == 5 || Sentences_0 == 22 || Sentences_0 == 23 || 
            Sentences_0 == 33 || Sentences_0 == 53 || Sentences_0 == 55
            || Sentences_0 == 56 || Sentences_0 == 59 || Sentences_0 == 87
            || Sentences_0 == 88 || Sentences_0 == 90 || Sentences_0 == 91
            || Sentences_0 == 93 || Sentences_0 == 94 || Sentences_0 == 37) 
            && Name[1].activeSelf == true)//�޿���
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[20].SetActive(true);
        }

        //����� �̸� ������ ���- �޿��� + ��ΰ� �׸�
        if ((Sentences_0 == 25 || Sentences_0 == 26 )
            && Name[1].activeSelf == true)//�޿���
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[18].SetActive(true);
        }

        //����� �̸� ������ ���- ���̳� + �׸� ����
        if ((Sentences_0 == 1 || Sentences_0 == 2 || Sentences_0 == 3 || Sentences_0 == 11
            || Sentences_0 == 12 || Sentences_0 == 13 || Sentences_0 == 14
            ||  Sentences_0 == 16 ||Sentences_0 == 20 ||
            Sentences_0 == 21 || Sentences_0 == 24 || Sentences_0 == 29
            || Sentences_0 == 30 || Sentences_0 == 31 || Sentences_0 == 34
            || Sentences_0 == 35 || Sentences_0 == 36 || Sentences_0 == 41
            || Sentences_0 == 42 || Sentences_0 == 46
            || Sentences_0 == 48 || Sentences_0 == 51 ||
            Sentences_0 == 52 || Sentences_0 == 54 || Sentences_0 == 57
            || Sentences_0 == 58 || Sentences_0 == 60 || Sentences_0 == 61
            || Sentences_0 == 62 || Sentences_0 == 63 || Sentences_0 == 64
            || Sentences_0 == 65 || Sentences_0 == 68
            || Sentences_0 == 72 || Sentences_0 == 74 || Sentences_0 == 76
            || Sentences_0 == 81 || Sentences_0 == 84 || Sentences_0 == 85
            || Sentences_0 == 86 || Sentences_0 == 89 || Sentences_0 == 92
            || Sentences_0 == 95 || Sentences_0 == 98
            || Sentences_0 == 99 || Sentences_0 == 100 ||
            Sentences_0 == 101 || Sentences_0 == 102 || Sentences_0 == 103
            || Sentences_0 == 104 || Sentences_0 == 105 || Sentences_0 == 106
            ||  Sentences_0 == 109
            || Sentences_0 == 110 || Sentences_0 == 111
            || Sentences_0 == 112 || Sentences_0 == 113 ||
            Sentences_0 == 114 || Sentences_0 == 116 || Sentences_0 == 117
            || Sentences_0 == 118 || Sentences_0 == 120 || Sentences_0 == 121
            || Sentences_0 ==122 || Sentences_0 == 124)
            && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

        }

        //���̳� + ���
        if (Sentences_0 == 107
            && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            blue.SetActive(true);
        }

        //���̳� + ���
        if (Sentences_0 == 108
            && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            blue.SetActive(false);
        }

        //���̳� + ���̳� ���� �� 6
        if (Sentences_0 == 6 
            && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[19].SetActive(true);
        }

        //���̳� + �� �ƹ��� 7~10, 15. 17, 70, 71
        if ((Sentences_0 == 7 || Sentences_0 == 8
           || Sentences_0 == 9 || Sentences_0 == 10 
           || Sentences_0 == 15 
           || Sentences_0 == 17 
           || Sentences_0 == 70 || Sentences_0 == 71 )
           && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[16].SetActive(true);
        }

        //���̳� + �� ��Ӵ� 13~14
        if ((Sentences_0 == 13 || Sentences_0 == 14)
           && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[17].SetActive(true);
        }

        //���̳� + ��ΰ� ���̵� ��ü 29
        if (Sentences_0 == 29
            && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[18].SetActive(true);
        }

        //���̳� + ��ΰ� ���̵� Ȯ�� 30, 31
        if ((Sentences_0 == 30 || Sentences_0 == 31)
          && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[24].SetActive(true);
        }

        //���̳� + ������ ���� 63, 64, 65
        if ((Sentences_0 == 63 || Sentences_0 ==64 || Sentences_0 == 65)
          && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[21].SetActive(true);
        }

        //���̳� + ���� 101, 102
        if ((Sentences_0 == 101 || Sentences_0 == 102 )
          && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[23].SetActive(true);
        }

        //���̳� + �� �Ͼ 110, 111, 112
        if ((Sentences_0 == 110 || Sentences_0 == 111 || Sentences_0 == 112)
         && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[25].SetActive(true);
        }

        //���̳� + �� ���� 120
        if (Sentences_0 == 120 && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[22].SetActive(true);
        }

        //������ + �ٸ� �׸� ����
        if ((Sentences_0 == 4 || Sentences_0 == 18 || Sentences_0 == 19 ||
            Sentences_0 == 38 || Sentences_0 == 39 || Sentences_0 == 40
            || Sentences_0 == 43 || Sentences_0 == 44 || Sentences_0 == 45
            || Sentences_0 == 47 || Sentences_0 == 49
            || Sentences_0 == 50 || Sentences_0 == 82 || Sentences_0 == 83
            || Sentences_0 == 96)
            && Name[2].activeSelf == true)//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[6].SetActive(true);
        }

        //������ + ��ΰ� ���̵� 27, 28, 32
        if ((Sentences_0 == 27 || Sentences_0 == 28 || Sentences_0 == 32)
            && Name[2].activeSelf == true)//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[18].SetActive(true);
        }

        //������ + �ٸ� �׸� ����
        if ((Sentences_0 == 66 || Sentences_0 == 67 || Sentences_0 == 69 ||
            Sentences_0 == 73 || Sentences_0 == 75 || Sentences_0 == 77
            || Sentences_0 == 97)
            && Name[3].activeSelf == true)//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[21].SetActive(true);
        }

        //������ + �� �ƹ��� �׸� 78, 79, 80
        if (( Sentences_0 == 78 || Sentences_0 == 79 || Sentences_0 == 80)
           && Name[3].activeSelf == true)//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[16].SetActive(true);
        }

        //�� + �ƹ� �׸��� ����
        if ((Sentences_0 == 115 || Sentences_0 == 119 || Sentences_0 == 123 || Sentences_0 == 125)
           && Name[4].activeSelf == true)//��
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[22].SetActive(true);
        }*/

        if(Sentences_0>126)
        {
            typ.Ch[22].SetActive(false);

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��

            Sentences_0 = 127;
            Sectences_Save_Settings();
        }

        //�� ��
        if (find_s3.Sentences_0 <= 29)
        {
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }
        }


        //Ž������ ��ǳ���� �������� ���� ��
        if (find_s3.Sentences_0 > 29 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false) &&
            (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
            && typ.Bg[5].activeSelf == true)
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[4].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[5].SetActive(true);//������ �ִ� ��ž ������

            find_s.btn_Collection.SetActive(true);

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
            //Debug.Log("�̰ų�? 0714");
        }



        // ���� Ž������ ��ǳ���� ���� ��
        if (find_s3.Sentences_0 > 29 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
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

        if (find_s3.Sentences_0 > 29 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (Dia[0].activeSelf == true || Dia[1].activeSelf == true ||
            Dia[2].activeSelf == true || Dia[3].activeSelf == true
            || Dia[4].activeSelf == true || Dia[5].activeSelf == true) && typ.Bg[5].activeSelf == true)
        /*(item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true)
        && typ.Bg[0].activeSelf == true)*/
        {
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }


            find_s.btn_Collection.SetActive(false);
        }

        //0��° ����
        //����� �̸� ������ ���- �޿��� �׸� ����
        if ((Sentences_0 == 5 || Sentences_0 == 22 || Sentences_0 == 23 ||
            Sentences_0 == 33 || Sentences_0 == 53 || Sentences_0 == 55
            || Sentences_0 == 56 || Sentences_0 == 59 || Sentences_0 == 87
            || Sentences_0 == 88 || Sentences_0 == 90 || Sentences_0 == 91
            || Sentences_0 == 93 || Sentences_0 == 94 || Sentences_0 == 37))//�޿���
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[20].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(true);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //����� �̸� ������ ���- �޿��� + ��ΰ� �׸�
        if ((Sentences_0 == 25 || Sentences_0 == 26))//�޿���
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[18].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(true);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //����� �̸� ������ ���- ���̳� + �׸� ���� + ���� ��
        if ((Sentences_0 == 7 || Sentences_0 == 1 || Sentences_0 == 2 || Sentences_0 == 3 || Sentences_0 == 11
            || Sentences_0 == 12 || Sentences_0 == 13 || Sentences_0 == 14
            || Sentences_0 == 16 || Sentences_0 == 20 ||
            Sentences_0 == 21 || Sentences_0 == 24 || Sentences_0 == 29
            || Sentences_0 == 30 || Sentences_0 == 31 || Sentences_0 == 34
            || Sentences_0 == 35 || Sentences_0 == 36 || Sentences_0 == 41
            || Sentences_0 == 42 || Sentences_0 == 46
            || Sentences_0 == 48 || Sentences_0 == 51 ||
            Sentences_0 == 52 || Sentences_0 == 54 || Sentences_0 == 57
            || Sentences_0 == 58 || Sentences_0 == 60 || Sentences_0 == 61
            || Sentences_0 == 62 || Sentences_0 == 63 || Sentences_0 == 64
            || Sentences_0 == 65 || Sentences_0 == 68
            || Sentences_0 == 74 || Sentences_0 == 76
            || Sentences_0 == 81 || Sentences_0 == 84 || Sentences_0 == 85
            || Sentences_0 == 86 || Sentences_0 == 89 || Sentences_0 == 92
            || Sentences_0 == 95 || Sentences_0 == 98
            || Sentences_0 == 99 || Sentences_0 == 100 ||
            Sentences_0 == 101 || Sentences_0 == 102 || Sentences_0 == 103
            || Sentences_0 == 104 || Sentences_0 == 105 || Sentences_0 == 106 || Sentences_0 == 64 || Sentences_0 == 65))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

        }

        //����� �̸� ������ ���- ���̳� + �׸� ���� + ���� ħ��
        if ((Sentences_0 == 109|| Sentences_0 == 113 ||
            Sentences_0 == 114 || Sentences_0 == 115 ||  Sentences_0 == 117
            || Sentences_0 == 118 || Sentences_0 == 119 || Sentences_0 == 121
            || Sentences_0 == 122 || Sentences_0 == 123 || Sentences_0 == 125))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

        }

        //107 - �Ķ���
        if (Sentences_0 == 107)//���̳�
        {
            blue.SetActive(true);
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

  

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }



        //108 - ���̵� �����
        if (Sentences_0 == 108)//���̳�
        {
            blue.SetActive(false);
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

    

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + ���̳� ���� �� 6
        if (Sentences_0 == 6)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
           

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[19].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + �� �ƹ��� 8~10, 15. 17, 70, 71
        if (( Sentences_0 == 8
           || Sentences_0 == 9 || Sentences_0 == 10
           || Sentences_0 == 15
           || Sentences_0 == 17
           || Sentences_0 == 70 || Sentences_0 == 71 || Sentences_0 == 72))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[16].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + �� ��Ӵ� 13~14
        if ((Sentences_0 == 13 || Sentences_0 == 14))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
          

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[17].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + ��ΰ� ���̵� ��ü 29
        if (Sentences_0 == 29)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
          

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[18].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + ��ΰ� ���̵� Ȯ�� 30, 31
        if ((Sentences_0 == 30 || Sentences_0 == 31))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
           

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[24].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + ������ ���� 63, 64, 65
        if ((Sentences_0 == 63 ))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
           

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[21].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + ���� 101, 102
        if ((Sentences_0 == 101 || Sentences_0 == 102))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
           

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[23].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + �� �Ͼ 110, 111, 112
        if ((Sentences_0 == 110 || Sentences_0 == 111 || Sentences_0 == 112))//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[25].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //���̳� + �� ���� 120
        if (Sentences_0 == 121 )//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[22].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������ + �ٸ� �׸� ����
        if ((Sentences_0 == 4 || Sentences_0 == 18 || Sentences_0 == 19 ||
            Sentences_0 == 38 || Sentences_0 == 39 || Sentences_0 == 40
            || Sentences_0 == 43 || Sentences_0 == 44 || Sentences_0 == 45
            || Sentences_0 == 47 || Sentences_0 == 49
            || Sentences_0 == 50 || Sentences_0 == 82 || Sentences_0 == 83
            || Sentences_0 == 96))//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������ + ��ΰ� ���̵� 27, 28, 32
        if ((Sentences_0 == 27 || Sentences_0 == 28))//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
           

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[18].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������ + ��ΰ� ���̵� 32
        if ((Sentences_0 == 32))//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[24].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������ + �ٸ� �׸� ����
        if ((Sentences_0 == 66 || Sentences_0 == 67 || Sentences_0 == 69 ||
            Sentences_0 == 73 || Sentences_0 == 75 || Sentences_0 == 77
            || Sentences_0 == 97))//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[21].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(true);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������ + �� �ƹ��� �׸� 78, 79, 80
        if ((Sentences_0 == 78 || Sentences_0 == 79 || Sentences_0 == 80))//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[16].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(true);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //�� + �ƹ� �׸��� ����
        if ((Sentences_0 == 116 || Sentences_0 == 120 || Sentences_0 == 124))//��
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[22].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(true);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //�� ����
        //�� + �ƹ� �׸��� ����
        if ((Sentences_0 == 126))//��
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[26].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(true);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 0;

            typ.Bg[0].SetActive(true);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        //������
        //1��° ���� + ���̳� + ����
        if (Sentences_1 >= 1 && Sentences_1 <= 14)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //2�� ���� + ���̳� ����
        if (Sentences_2 == 1)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //3�� ���� ���̳�
        if (Sentences_3 >= 1 && Sentences_3 <= 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //4�� ���� ���̳�
        if (Sentences_4 == 1)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //5�� ���� ���̳� //�����ؾ� ��
        if (Sentences_5 == 1 || Sentences_5 == 2 || Sentences_5 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //5�� ���� ������
        if (Sentences_5 == 3 || Sentences_5 == 4)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

    }

    public void Choose_Obj_0()
    {
        Sentences_0 = 0;
        StartTyping_0();

        


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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


    }

    public void Choose_Obj_1()
    {

        Sentences_1 = 0;
        StartTyping_1();

        typ.Ch[9].SetActive(true);//å

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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


    }

    public void Choose_Obj_5()
    {

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
        Name[3].SetActive(false);//������
        Name[4].SetActive(false);//��

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
            if (Sentences_0 == 0)
            {
                StartTyping_0();

                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                sug.Suggest.SetActive(false);
                item.Suggest.SetActive(false);

                if (Sentences_0 == 106)//24�� ���Ƽ� ���� //24���� ��� �ٲٱ�
                {
                    fade.Fade_BE.SetActive(true);
                    fade.Fade_In_Out.SetTrigger("Go_Blue");

                }

                if (Sentences_0 == 107)
                {
                    blue.SetActive(true);
                }


                if (Sentences_0 == 108)
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

            }


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

                if (Sentences_0 == 106)//24�� ���Ƽ� ���� //24���� ��� �ٲٱ�
                {
                    fade.Fade_BE.SetActive(true);
                    fade.Fade_In_Out.SetTrigger("Go_Blue");


                }


                if (Sentences_0 ==108)
                {
                    if (Sentences_0 == 108)
                    {
                        fade.Fade_BE.SetActive(false);
                        fade.Fade_In_Out.SetTrigger("Go_Empty");
                        StartCoroutine(Bye_Fade());
                        IEnumerator Bye_Fade()
                        {
                            yield return new WaitForSeconds(1.5f);
                            fade.Fade_BE.SetActive(false);

                        }
                    }

                }

 

                if(Sentences_0 == 61)
                {
                    sfx.Book_Drop_Sound();
                }
            }
        }


        if(Sentences_0 > 126)
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��


            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            typ.Ch[26].SetActive(false);

            //����
            if (b_btn.Buf_Story_Collection.activeSelf == true)
            {
                bty.Down_Up_Butterfly_Go_Main();
                //0729
                typ.Start_Count = 1;
                typ1.Start_Count = 1;
                typ2.Start_Count = 1;
                Debug.Log("���� ����!");
            }

            if (b_btn.Buf_Story_Collection.activeSelf == false)
            {
                return;
                Debug.Log("��!");
            }


        }

        /*else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��


            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            typ.Ch[26].SetActive(false);

            //����
            if (b_btn.Buf_Story_Collection.activeSelf==true)
            {
                bty.Down_Up_Butterfly_Go_Main();

                Debug.Log("���� ����!");
            }

            if (b_btn.Buf_Story_Collection.activeSelf == false)
            {
                return;
                Debug.Log("��!");
            }
            

        }*/
        Sectences_Save_Settings();


    }


    //����

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

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

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
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

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

            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }


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
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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
            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[4].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[5].SetActive(false);//������ �ִ� ��ž ������

            StartTyping_4();


            

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
            Name[3].SetActive(false);//������
            Name[4].SetActive(false);//��

            find_s.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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
        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

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
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������
            Name[3].SetActive(false);//�޿���
            Name[4].SetActive(false);//������

            find_s.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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




}
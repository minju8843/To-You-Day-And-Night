using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ÿ���� ���õ� �� ����(�޸�, �����⿡ ���� �� �ٸ� ���� ����)


[System.Serializable]//������ ���� ���� �߰���

public class GameData_Typing2
{//����� ���� �����͸� �����ϴ� Ŭ����
    //���� �� ��° ���� �ε������� ����Ǿ����� �����ϴ� Ŭ����

    public int Sentences_1_Index;//�� ó�� ���� �κ� �ε���
}

public class Typing_2 : MonoBehaviour
{
    public SFX_Manager sfx;

    //public GameObject[] Talk;//���丮 ��ǳ�� ��ü ����

    public Typing typ;
    public Typing_1 typ1;
    public Hint hint;

    public Butt_Ch butt_ch;
    public Item item;

    public GameObject Dia;
    public GameObject Inside_Dia;

    //public GameObject Names;

    public Text dialogueText; // ��ȭâ�� ǥ�õ� �ؽ�Ʈ UI
    public string[] sentences_1; // ǥ�õ� ��ȭ �����

    public bool isTyping = false; // Ÿ���� ������ ����

    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����

    public GameObject[] Name;//ĳ���� �̸�



    //���� ������ ����Ǿ�����
    public int Default_Sentences_1 = 0; // ���� ������ ����Ǿ�����
    public int Sentences_1 = 0;//���µǾ� ����Ʈ �� ��
    public int Current_Sentences_1 = 0; // ���� ������ �ε���

    //Ž�� ����
    public GameObject start;
    public Animator Start_Ainm;


    //Ž�� ���� �� ���� ��ư �����Ϸ��� ���� �� 
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;
    public Find_Something3 find_s3;

    public int Start_Count = 0;

    public void OnEnable()
    {
        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //�Ʒ� ���� �߰�
        //Load_Sentences1();//���̳� �濡�� ���� ����� �ҷ����� ��
        Debug.Log("�ҷ��� �� �Ŵ�?");

    }

    void Start()
    {
        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        Load_Sentences1();//���� 0724

        Start_Count = 1;
    }


    public void Load_Sentences1()
    {
        //���̳� �濡�� ���� ����� �ҷ�����
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
                    //Sectences_Save_Settings();//���� �߰�720

                }

                if (Sentences_1 <= 45)
                {
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);


                    //StartTyping(); // ��ȭ ����
                    //��
                    Sentences_1--;
                    Next_Text();
                    //Sectences_Save_Settings();

                    Debug.Log("�� ��°��" + Sentences_1);
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

                StartTyping(); // ��ȭ ����

            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //���̳׹濡�� ���� ����� ����
        GameData_Typing2 data = new GameData_Typing2();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData2", jsonData);
        PlayerPrefs.Save();

    }

    public void Sectences_Reset_Settings()
    {
        //���̳� �濡�� ���� ����� ����
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

        if (Sentences_1 < sentences_1.Length && find_s2.Sentences_0 >= find_s2.sentences_0.Length)//�������� ���̳�
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

            Debug.Log("�̰�? 0714");

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
            //������
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

            typ.Ch[6].SetActive(true);//������

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

            Name[1].SetActive(true);//������
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

            typ.Ch[6].SetActive(true);//������

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

            typ.Ch[6].SetActive(true);//������

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

            typ.Ch[14].SetActive(true);//���� ������

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(false);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);//�湮 ��
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
            typ.Bg[4].SetActive(true);//�湮 ��
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

        //18 -> 39(���ȴ�! ��������)
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
            typ.Bg[4].SetActive(false);//�湮 ��
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
        //find_something���� ����� ��
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

        if (typ.Bg_0 == 5)//��ž ����� ��, ���̳� �� Ž��� ���� ���ϵ���
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
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping();

        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
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

            Debug.Log("�̰�");
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            if(Sentences_1 == 37)
            {
                sfx.Book_UnLock();//�� ��� ����
            }

            if (Sentences_1 == 40)
            {
                sfx.Door_Open();//�� ������ �Ҹ�
            }
        }

        else if (Sentences_1 > 45)
        {
            Debug.Log("��ȭ ����");
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
                //�ִϸ��̼��� ����ǰ� �� �� 0.5�� �Ŀ� ���������� ����
                start.SetActive(false);

                //Ž���� �� �ֵ��� ��� ������ �� �ִ� ��ư�� �����ֵ���
                find_s.touch_able_b[4].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }
        }


        else
        {
            Debug.Log("��ȭ ����");
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
                //�ִϸ��̼��� ����ǰ� �� �� 0.5�� �Ŀ� ���������� ����
                start.SetActive(false);

                //Ž���� �� �ֵ��� ��� ������ �� �ִ� ��ư�� �����ֵ���
                find_s.touch_able_b[4].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }

        }
        Sectences_Save_Settings();

    }

    public void CompleteTyping()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        dialogueText.text = sentences_1[Sentences_1];
        isTyping = false;


    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        dialogueText.text = "";

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
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            // "���..." �κ��� ó��
            else if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // "��Ƽ�..." �κ��� ó��
            else if (word.StartsWith("��"))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }


            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                dialogueText.text += ' ';
            }
        }

        isTyping = false;
    }
}
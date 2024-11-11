using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Find_s3
{
    public int Sentences_0_Index;//�� ó�� ���� �κ� �ε���
}
public class Find_Something3 : MonoBehaviour
{
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;

    public Butt_Ch butt_ch;

    public GameObject[] Name;//�̸�

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//�����ϱ� ��ư ��Ȱ��ȭ ��Ű�� ���� �ۼ�
    public Item item;


    public GameObject[] Dia;//��ġ�� ������Ʈ�� ���� ��ǳ����
    public Text[] text;//��ġ�� ������Ʈ�� ���� ��ǳ�� ���� �ؽ�Ʈ��


    //Ž�� ����
    public GameObject start;
    public Animator Start_Ainm;

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

        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        Name[0].SetActive(false);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������


        if (Sentences_0 > 29)
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
            Name[2].SetActive(false);//������

           

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

            Debug.Log("ȭ��ǥ üũ1");

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if (Sentences_0 == 0 && typ2.Current_Sentences_1 > typ2.sentences_1.Length)
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

        find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

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

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    //find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

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


                //StartTyping(); // ��ȭ ����
            }

           
        }

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //����� ����
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

        //�ݻ� �� ������ ���
        if (Sentences_0 == 0 && typ.Ch[9].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Debug.Log("Ȯ��1");
        }

        //�ݻ� �� ������ ���
        if (Sentences_0 == 0 && typ.Ch[9].activeSelf == false && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            Debug.Log("Ȯ��4");
        }

        /*if (typ.Ch[6].activeSelf == true && Name[2].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            Debug.Log("Ȯ��2");
        }

        if (typ.Ch[20].activeSelf == true && Name[1].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            Debug.Log("Ȯ��3");
        }*/

        if (typ.Sentences_1 == 0 || typ1.Sentences_1 == 0 || typ2.Sentences_1 == 0)
        {
            Dia[0].SetActive(false);
        }

        if (Sentences_0 == 0 && typ2.Sentences_1 >= typ2.sentences_1.Length &&
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

        if (Sentences_0 == 0 && typ.Bg[5].activeSelf == true && typ.Ch[9].activeSelf == true
            && typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            Debug.Log("Ȯ��4");

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

            sug.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        if (Sentences_0 == 0 && typ.Bg[5].activeSelf == true && typ.Ch[9].activeSelf == false
            && typ2.Sentences_1 >= typ2.sentences_1.Length)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            Debug.Log("Ȯ��4");
        }

        //����� �̸� ������ ���
        if ((Sentences_0 == 29) && Name[1].activeSelf == true)//�޿���
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[20].SetActive(true);
        }

        if ((Sentences_0 ==19 || Sentences_0 == 20
            || Sentences_0 == 23 || Sentences_0 == 24 || Sentences_0 == 25 || Sentences_0 == 28) && Name[2].activeSelf == true)//������
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[6].SetActive(true);
        }

        if ((Sentences_0 >=1 || Sentences_0 <= 18) && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if ((Sentences_0 == 21 || Sentences_0 == 22 || Sentences_0 == 26 || Sentences_0 == 27) && Name[0].activeSelf == true)//���̳�
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }
       
        


        /*if (Sentences_0 > 0 && Sentences_0 < 30)//����0718
        {
            find_s.btn_Collection.SetActive(false);
            for (int i = 1; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }*/

        //������
       

        if (typ2.Sentences_1 <= 45)
        {
           
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }
        }


       


        //Ž������ ��ǳ���� �������� ���� ��
        if (typ2.Sentences_1 > 45 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (Dia[0].activeSelf == false && Dia[1].activeSelf == false &&
            Dia[2].activeSelf == false && Dia[3].activeSelf == false
            && Dia[4].activeSelf == false && Dia[5].activeSelf == false) && typ.Bg[5].activeSelf == true)
           /* (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false)
            &&typ.Bg[5].activeSelf == true)*/
        {
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
            find_s.touch_able_b[4].SetActive(true);//������ �ִ� ��ž ������


            find_s.btn_Collection.SetActive(true);
            //Debug.Log("�̰ų�? 0714");

            //0727
            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);
        }

        

        // ���� Ž������ ��ǳ���� ���� ��
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


        //0��° ����
        if ((Sentences_0 == 29))//�޿���
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[20].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(true);//�޿���
            Name[2].SetActive(false);//������

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

        if ((Sentences_0 == 19 || Sentences_0 == 20
            || Sentences_0 == 23 || Sentences_0 == 24 || Sentences_0 == 25 || Sentences_0 == 28))//������
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

           Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
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

        if ((Sentences_0 >= 1 && Sentences_0 <= 18))//���̳�
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

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

        if ((Sentences_0 == 21 || Sentences_0 == 22 || Sentences_0 == 26 || Sentences_0 == 27))//���̳�
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

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
        

        //1��° ���� + ������
        if ( Sentences_1 == 4 || Sentences_1 == 6
            || Sentences_1 == 7 || Sentences_1 == 8 || Sentences_1 == 9)
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

            typ.Bg_0 = 5;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(true);// ���� ��

        }

        //1��° ���� + ���̳� + ����
        if (Sentences_1 == 1 || Sentences_1 == 2
            || Sentences_1 == 3)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[15].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

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

        //1��° ���� + ���̳� + ����
        if (Sentences_1 == 10 || Sentences_1 == 11 || Sentences_1 == 5)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

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

        typ.Ch[9].SetActive(true);//å


        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[0].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ

        for(int i=0; i<find_s.touch_able_b.Length; i++)
        {
            find_s.touch_able_b[i].SetActive(false);
        }

       

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

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

        typ.Bg_0 = 5;

        typ.Bg[0].SetActive(false);// �� ������ ��
        typ.Bg[1].SetActive(false);// ���̳� ��
        typ.Bg[2].SetActive(false);// ��ž ��
        typ.Bg[3].SetActive(false);// ��ž ��
        typ.Bg[4].SetActive(false);// ��ž �� ��
        typ.Bg[5].SetActive(true);// ���� ��


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
            typ.Bg[3].SetActive(false);//������ ���� ��ž
            typ.Bg[4].SetActive(false);//�� ��
            typ.Bg[5].SetActive(true);//�� ��


            typ.Bg_0 = 5;

        }

        else if (Sentences_1 > 29)
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

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
                find_s.touch_able_b[5].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }
        }


        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������


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
                find_s.touch_able_b[5].SetActive(true);
                find_s.btn_Collection.SetActive(true);

            }

        }
        Sectences_Save_Settings();

        /*else
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

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


            //��� �ٲ� ���� ��ư ���� �� �ִ� �͵� �޶���
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            //typ2.Go_2_Typing();


            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�


        }*/

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
            Name[2].SetActive(false);//

            find_s.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            find_s.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            find_s.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            find_s.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            find_s.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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
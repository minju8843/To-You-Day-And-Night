using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Find_s1
{//����� ���� �����͸� �����ϴ� Ŭ����
    //���� �� ��° ���� �ε������� ����Ǿ����� �����ϴ� Ŭ����

    public int Sentences_0_Index;//�� ó�� ���� �κ� �ε���
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

    public GameObject[] Name;//�̸�

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Butt_Ch sug;//�����ϱ� ��ư ��Ȱ��ȭ ��Ű�� ���� �ۼ�
    public Item item;

    //Ž�� ���� �� ���� ��ư �����Ϸ��� ���� �� 
    //���� �� ��° Ž�������� - ���̳� ������, ��ž ������, ��ž ������
    //public int Default_TouchAble = 0; // ���� ������ ����Ǿ�����
    //public int TouchAble;//���µǾ� ����Ʈ �� ��
    //public int Current_TouchAble; // ���� 

    public GameObject[] Dia;//��ġ�� ������Ʈ�� ���� ��ǳ����
    public Text[] text;//��ġ�� ������Ʈ�� ���� ��ǳ�� ���� �ؽ�Ʈ��

    //�޿��� ���� ���� Ÿ���� ����
    public string[] sentences_0; // ǥ�õ� ��ȭ �����
    public int Sentences_0 = 0;//���µǾ� ����Ʈ �� ��
    private bool isTyping_0 = false; // Ÿ���� ������ ����

    //�޿��� ���� ���� ����
    public int Default_Sentences_0 = 0; // ���� ������ ����Ǿ�����
    public int Current_Sentences_0 = 0 ; // ���� ������ �ε���


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
    /*public string[] sentences_4; // ǥ�õ� ��ȭ �����
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
    */


    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����


    //Ž�� ����
    public GameObject start;
    public Animator Start_Ainm;

    void Start()
    {
        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
            //��ġ�ϸ� ������ �� �Ŵϱ�
        }

        Name[0].SetActive(false);
        Name[1].SetActive(false);
        Name[2].SetActive(false);//������

        //Load_Sentences_0();


        //���� �߰�
        if (Sentences_0 > 42)
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

            for (int i = 0; i < Name.Length; i++)
            {
                Name[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }
            /*
                        Dia[0].SetActive(false);
                        Dia[1].SetActive(false);
                        Dia[2].SetActive(false);
                        Dia[3].SetActive(false);

                        Name[0].SetActive(false);//���̳�
                        Name[1].SetActive(false);//�޿���

              */

            //���
           /* typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
          **/


           // sug.Suggest.SetActive(true);
            //item.Suggest.SetActive(true);

            Sentences_0 = 43;

            Sectences_Save_Settings();

            
        }
        

    }

    public void OnEnable()
    {

        //���� ù ��° ��ҿ��� ���丮 ��簡 �� ������ Ž���� Ȱ��ȭ�ǵ���
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
            Name[2].SetActive(false);//������



            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);//�ϴ� ��ǳ�� �� ��Ȱ��
                                        //��ġ�ϸ� ������ �� �Ŵϱ�
            }

            Debug.Log("ȭ��ǥ üũ1");

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        if (Sentences_0 == 0 && typ1.Current_Sentences_1 > typ1.sentences_1.Length
            && (start.activeSelf==true || find2.Arrow[0].activeSelf==true))
        {
            find_s.btn_Collection.SetActive(true);

            Debug.Log("�̰� �� ������0?");

            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��


        }

        Load_Sentences_0();


    }

    public void Update()
    {

        if (Sentences_0 >= 42 && start.activeSelf==true && find2.Arrow[0].activeSelf==false && typ.Bg[5].activeSelf == false)
        {
            typ.Bg_0 = 4;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
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

            Debug.Log("��0720");
        }

        if (Sentences_0 == 0 && item.Item_Count == 1
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Bg[2].activeSelf == true
             && typ.Ch[4].activeSelf == false && Name[0].activeSelf == false)
        {
            Dia[0].SetActive(false);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            Debug.Log("�ʳ�0720");
        }

        if (Sentences_0 == 0 && typ.Bg[2].activeSelf == true && item.Item_Count == 1
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Ch[4].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
            Debug.Log("�ʳʳ�0720");

            typ.Bg_0 = 2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(true);//��ž �� Ȱ��ȭ
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

            Debug.Log("�ʳ�0720");
        }

        if (Sentences_0 == 0 && typ.Bg[2].activeSelf == true && item.Item_Count == 0
            && typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
            && typ.Ch[4].activeSelf == true && Name[0].activeSelf == true)
        {
            Dia[0].SetActive(false);
            Debug.Log("�ʳʳ�0720");
        }

  


        //��ž �ۿ��� Ž������ ��ǳ���� �������� ���� ��
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
            //Debug.Log("�̰ų�? 0714");
        }

        //��ž �ۿ��� ���� Ž������ ��ǳ���� ���� ��
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
            //Debug.Log("�̰�? 0714");
        }


        if (Sentences_0 > 0 && Sentences_0 < 43)//����0718
        {
            find_s.btn_Collection.SetActive(false);
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            // find_s.touch_able_b[2].SetActive(false);
            // find_s.touch_able_b[3].SetActive(false);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
        //�̰� �̻��ϸ� �����
        //Ǫ�� ����
        if (Sentences_0 == 19 || Sentences_0 == 20)
        {
            Dia[0].SetActive(true);
            find_s.Dia[0].SetActive(false);

            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[7].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(true);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
      

            Debug.Log("���� �ʴ�????");
        }

        //�޿��� �޸��
        else if (Sentences_0 < 3 && Sentences_0 > 0)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Ch[4].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(false);

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

            typ.Bg_0 = 2;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(true);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
        }


        //�޿��� ��� ��ħ
        else if (Sentences_0 == 4 || Sentences_0 == 7 || Sentences_0 == 8
            || Sentences_0 == 10 || Sentences_0 == 14 || Sentences_0 == 16
            || Sentences_0 == 17 || Sentences_0 == 21)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[5].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(true);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(true);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
           

            Debug.Log("�ƴ� �Ͱ�???");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        //�ݻ� ��
        else if (Sentences_0 == 13)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[3].SetActive(true);

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(true);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
      

            Debug.Log("��????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }



        //������
        else if (Sentences_0 == 26 || Sentences_0 == 31)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
    

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        //������
        else if (Sentences_0 == 35 
            || Sentences_0 == 37 || Sentences_0 == 38 || Sentences_0 == 39)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }
            typ.Ch[6].SetActive(true);

            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(true);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
       

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
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

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            //���
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(true);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
            

            Debug.Log("���ض�????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

        }

        else if (Sentences_0 == 36 || Sentences_0 == 40
            || Sentences_0 == 41 || Sentences_0 == 42)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            //���
            typ.Bg_0 = 4;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(true);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
  

            //Debug.Log("�̰� �� ������?");
            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�

        }

        else if (Sentences_0 == 27 || Sentences_0 == 32 || Sentences_0 == 28
            || Sentences_0 == 29 || Sentences_0 == 30 || Sentences_0 == 33 || Sentences_0 == 34)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            //���
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
           

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        else if (Sentences_0 == 24)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(true);

            //���
            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(true);// ��ž ��
            typ.Bg[3].SetActive(false);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
     

            Debug.Log("������ �����n????");

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
        }

        else if (Sentences_0 == 25)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            blue.SetActive(false);

            //���
            typ.Bg_0 = 3;

            typ.Bg[0].SetActive(false);// �� ������ ��
            typ.Bg[1].SetActive(false);// ���̳� ��
            typ.Bg[2].SetActive(false);// ��ž ��
            typ.Bg[3].SetActive(true);// ��ž ��
            typ.Bg[4].SetActive(false);// ��ž �� ��
            typ.Bg[5].SetActive(false);// ���� ��
       

            Dia[0].SetActive(true);
            find_s.Typ_Dia_Total.SetActive(false);//0721�߰��߰�
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

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

                    Next_Text_0();

                    sug.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    typ1.start.SetActive(false);

                    
                  

                    if((sug.Suggest.activeSelf==false || item.Suggest.activeSelf==false)
                        &&(find2.Dia[0].activeSelf == true || find2.Dia[1].activeSelf == true ||
            find2.Dia[2].activeSelf == true || find2.Dia[3].activeSelf == true
            || find2.Dia[4].activeSelf == true || find2.Dia[5].activeSelf == true))
                    {//�����ϱ� ��Ȱ��ȭ�� �Ǿ� �ְ� ���â�� �����ִ� ���¶��
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
                        //�����ϱⰡ Ȱ��ȭ �Ǿ��ְ�
                        //��ȭâ�� ��Ȱ��ȭ �Ǿ� �ִٸ�
                        //ȭ��ǥ�� �����ش�.
                        find2.Arrow[0].SetActive(false);
                        find2.Arrow[1].SetActive(false);
                        find2.Arrow[2].SetActive(false);
                        find2.Arrow[3].SetActive(false);
                        find2.Arrow[4].SetActive(true);
                        find2.Arrow[5].SetActive(true);

                        //���
                        typ.Bg_0 = 3;

                        typ.Bg[0].SetActive(false);// �� ������ ��
                        typ.Bg[1].SetActive(false);// ���̳� ��
                        typ.Bg[2].SetActive(false);// ��ž ��
                        typ.Bg[3].SetActive(true);// ��ž ��
                        typ.Bg[4].SetActive(false);// ��ž �� ��
                        typ.Bg[5].SetActive(false);// ���� ��
                    }

                    if ((sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true)
                        && (find2.Dia[0].activeSelf == false && find2.Dia[1].activeSelf == false &&
            find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
            && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
            && find2.R_Normal_Arrow == 0)
                    {
                        //�����ϱⰡ Ȱ��ȭ �Ǿ��ְ�
                        //��ȭâ�� ��Ȱ��ȭ �Ǿ� �ִٸ�
                        //ȭ��ǥ�� �����ش�.
                        find2.Arrow[0].SetActive(true);
                        find2.Arrow[1].SetActive(true);
                        find2.Arrow[2].SetActive(false);
                        find2.Arrow[3].SetActive(false);
                        find2.Arrow[4].SetActive(false);
                        find2.Arrow[5].SetActive(false);

                        //���
                        typ.Bg_0 = 4;

                        typ.Bg[0].SetActive(false);// �� ������ ��
                        typ.Bg[1].SetActive(false);// ���̳� ��
                        typ.Bg[2].SetActive(false);// ��ž ��
                        typ.Bg[3].SetActive(false);// ��ž ��
                        typ.Bg[4].SetActive(true);// ��ž �� ��
                        typ.Bg[5].SetActive(false);// ���� ��
                    }

                    if ((sug.Suggest.activeSelf == true || item.Suggest.activeSelf == true)
                        && (find2.Dia[0].activeSelf == false && find2.Dia[1].activeSelf == false &&
            find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
            && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false )
            && find2.R_Normal_Arrow == 1)
                    {
                        //�����ϱⰡ Ȱ��ȭ �Ǿ��ְ�
                        //��ȭâ�� ��Ȱ��ȭ �Ǿ� �ִٸ�
                        //ȭ��ǥ�� �����ش�.
                        find2.Arrow[0].SetActive(false);
                        find2.Arrow[1].SetActive(false);
                        find2.Arrow[2].SetActive(true);
                        find2.Arrow[3].SetActive(true);
                        find2.Arrow[4].SetActive(false);
                        find2.Arrow[5].SetActive(false);

                        //���
                        typ.Bg_0 = 3;

                        typ.Bg[0].SetActive(false);// �� ������ ��
                        typ.Bg[1].SetActive(false);// ���̳� ��
                        typ.Bg[2].SetActive(false);// ��ž ��
                        typ.Bg[3].SetActive(true);// ��ž ��
                        typ.Bg[4].SetActive(false);// ��ž �� ��
                        typ.Bg[5].SetActive(false);// ���� ��
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

                    typ.Bg[0].SetActive(false);// �� ������ ��
                    typ.Bg[1].SetActive(false);// ���̳� ��
                    typ.Bg[2].SetActive(false);// ��ž ��
                    typ.Bg[3].SetActive(true);// ��ž ��
                    typ.Bg[4].SetActive(false);// ��ž �� ��
                    typ.Bg[5].SetActive(false);// ���� ��
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

                //StartTyping(); // ��ȭ ����
            }

           
     
        }

        butt_ch.Suggest.SetActive(false);
        item.Suggest.SetActive(false);




    }

    public void Sectences_Save_Settings()
    {

        //����� ����
        GameData_Find_s1 data = new GameData_Find_s1();
        data.Sentences_0_Index = Sentences_0;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("find_Text_Data1", jsonData);
        PlayerPrefs.Save();


    }

    public void Sectences_Reset_Settings()
    {
        //���̳� �濡�� ���� ����� ����
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

        find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
    }

    public void FixedUpdate()
    {
       
    }


    public void Choose_Obj_0()//�޿��� �߰�
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

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������


        //typ.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[0].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ

        find_s.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������


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
        find_s.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

    }

    public void Choose_Obj_2()
    {
        Sentences_2 = 0;
        StartTyping_2();

       // typ1.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[2].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        find_s.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

    }

    public void Choose_Obj_3()
    {
        Sentences_3 = 0;
        StartTyping_3();

        //typ1.Names.SetActive(true);//�̸� ���� ��

        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }

        Dia[3].SetActive(true);//0��° ��ǳ���� Ȱ��ȭ
        find_s.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ

        //sug.Suggest.SetActive(false);//�����ϱ� ��ư ��Ȱ��ȭ

        sug.Suggest.SetActive(false);
        item.Suggest.SetActive(false);

        Name[0].SetActive(true);//���̳�
        Name[1].SetActive(false);//�޿���
        Name[2].SetActive(false);//������

    }

 

    //���� �ݻ� �и� ��ġ���� �� 0
    public void Next_Text_0()
    {
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

                if (Sentences_0 == 23)//24�� ���Ƽ� ���� //24���� ��� �ٲٱ�
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

            /*if (Sentences_0 == 23)//24�� ���Ƽ� ���� //24���� ��� �ٲٱ�
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

                if (Sentences_0 == 23)//24�� ���Ƽ� ���� //24���� ��� �ٲٱ�
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
                    typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
                    typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
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
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);

            Debug.Log("��ȭ ����");
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
                //�ִϸ��̼��� ����ǰ� �� �� 0.5�� �Ŀ� ���������� ����
                start.SetActive(false);

                //Ž���� �� �ֵ��� ��� ������ �� �ִ� ��ư�� �����ֵ���
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
                find2.Name[2].SetActive(false);//������

            }
        }


        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

            typ.Bg_0 = 4;
            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);//���̳� �� ��Ȱ��
            typ.Bg[2].SetActive(false);//��ž �� Ȱ��ȭ
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(true);
            typ.Bg[5].SetActive(false);


            Debug.Log("��� �ٲ���");

            //find2.Go_Find2();


            Name[0].SetActive(false);//���̳�
            Name[1].SetActive(false);//�޿���
            Name[2].SetActive(false);//������

            //find_s.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��

            sug.Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            
            //��� �ٲ� ���� ��ư ���� �� �ִ� �͵� �޶���
            find_s.touch_able_b[0].SetActive(false);
            find_s.touch_able_b[1].SetActive(false);
            //find_s.touch_able_b[2].SetActive(false);//�� �湮�� ��ư


            //���� �߰�
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
                find2.Name[2].SetActive(false);//������

            }
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

            
            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���

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

            find_s.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���

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

            find_s.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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

            Name[0].SetActive(true);//���̳�
            Name[1].SetActive(false);//�޿���

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

            find_s.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��

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


}
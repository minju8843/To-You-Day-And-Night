using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Butt_Ch : MonoBehaviour
{
    //ĳ���͸� �������� ��, �ݻ� �������� ���� ���ϰ�
    //���� ū �ݻ� ������ �ȿ� ĳ������ ������ ĳ������ �׸��� ��Ÿ����
    // + ĳ������ �̸��� ��Ÿ����(������Ʈ�� �ؼ� Ȱ��ȭ ��Ű�� �ɷ�)

    //�����ϱ� ��ư�� ������ �ϴ��� �÷��̾�(���̳�)�� �� ����� ���� ������ ����
    //Ÿ���� ��ũ��Ʈ �����ϱ�
    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find;
    public Find_Something1 find1;
    public Find_Something2 find2;
    public Find_Something3 find3;
    public Find_Something4 find4;

    public GameObject Suggest;//�����ϱ� ��ư Ȱ��/��Ȱ��

    public Image[] Ch_Button; //���� �̹����� ����ִ� �ݻ� ������ �� �ٲ� ����

    public GameObject[] Character;//ū �ݻ� ������ �ȿ� �� �׸�
    public GameObject[] Character_Name;//�����ι� �̸��� ���� ������Ʈ

    public GameObject Up_Button;
    public GameObject Meno;

    public RectTransform Container;//�����̳�

    //���̳׿� ���� ���� Ÿ���� ����
    public string[] sentences_0; // ǥ�õ� ��ȭ �����
    public int Sentences_0;//���µǾ� ����Ʈ �� ��

    private bool isTyping_0 = false; // Ÿ���� ������ ����

    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����

 

    public GameObject[] Dia;
    //public GameObject[] Text;
    public Text[] text;

    public Item item;

    //��
    public string[] sentences_1; // ǥ�õ� ��ȭ �����
    public int Sentences_1;//���µǾ� ����Ʈ �� ��
    private bool isTyping_1 = false; // Ÿ���� ������ ����

    //��
    public string[] sentences_2; // ǥ�õ� ��ȭ �����
    public int Sentences_2;//���µǾ� ����Ʈ �� ��
    private bool isTyping_2 = false; // Ÿ���� ������ ����

    //3
    public string[] sentences_3; // ǥ�õ� ��ȭ �����
    public int Sentences_3;//���µǾ� ����Ʈ �� ��
    private bool isTyping_3 = false; // Ÿ���� ������ ����

    //4
    public string[] sentences_4; // ǥ�õ� ��ȭ �����
    public int Sentences_4;//���µǾ� ����Ʈ �� ��
    private bool isTyping_4 = false; // Ÿ���� ������ ����

    //5
    public string[] sentences_5; // ǥ�õ� ��ȭ �����
    public int Sentences_5;//���µǾ� ����Ʈ �� ��
    private bool isTyping_5 = false; // Ÿ���� ������ ����

    //6
    public string[] sentences_6; // ǥ�õ� ��ȭ �����
    public int Sentences_6;//���µǾ� ����Ʈ �� ��
    private bool isTyping_6 = false; // Ÿ���� ������ ����

    //7
    public string[] sentences_7; // ǥ�õ� ��ȭ �����
    public int Sentences_7;//���µǾ� ����Ʈ �� ��
    private bool isTyping_7 = false; // Ÿ���� ������ ����

    //8
    public string[] sentences_8; // ǥ�õ� ��ȭ �����
    public int Sentences_8;//���µǾ� ����Ʈ �� ��
    private bool isTyping_8 = false; // Ÿ���� ������ ����

    //9
    public string[] sentences_9; // ǥ�õ� ��ȭ �����
    public int Sentences_9;//���µǾ� ����Ʈ �� ��
    private bool isTyping_9 = false; // Ÿ���� ������ ����

    //�ǳ� Ȯ��
    public int zero_0 = 0;
    public int zero_1 = 0;
    public int zero_2 = 0;
    public int zero_3 = 0;
    public int zero_4 = 0;
    public int zero_5 = 0;
    public int zero_6 = 0;
    public int zero_7 = 0;
    public int zero_8 = 0;
    public int zero_9 = 0;

    public void Start()
    {
        for (int i = 0; i < Dia.Length; i++)
        {
            Dia[i].SetActive(false);
        }
    }

    public void Think()
    {
        find2.Arrow[0].SetActive(false);
        find2.Arrow[1].SetActive(false);
        find2.Arrow[2].SetActive(false);
        find2.Arrow[3].SetActive(false);
        find2.Arrow[4].SetActive(false);
        find2.Arrow[5].SetActive(false);


        if (Character[0].activeSelf == false && Character[1].activeSelf == false && Character[2].activeSelf == false &&
            Character[3].activeSelf == false && Character[4].activeSelf == false && Character[5].activeSelf == false &&
            Character[6].activeSelf == false && Character[7].activeSelf == false && Character[8].activeSelf == false &&
            Character[9].activeSelf == false )
        {
            return;
        }

        else
        {
            Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            for (int i = 0; i < find.touch_able_b.Length; i++)
            {
                find.touch_able_b[i].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            }

            //find.touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            //find.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ

            for (int i = 0; i < find.Dia.Length; i++)
            {
                find.Dia[i].SetActive(false);//������Ʈ ����â ��Ȱ��ȭ
            }

            //0
            if (Character[0].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_0 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[0].SetActive(true);

                StartTyping_0();
            }

            //1
            if (Character[1].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_1 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[1].SetActive(true);

                StartTyping_1();
            }

            //2
            if (Character[2].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_2 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[2].SetActive(true);

                StartTyping_2();
            }

            //3
            if (Character[3].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_3 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[3].SetActive(true);

                StartTyping_3();
            }

            //4
            if (Character[4].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_4 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[4].SetActive(true);

                StartTyping_4();
            }

            //5
            if (Character[5].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_5 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[5].SetActive(true);

                StartTyping_5();
            }

            //6
            if (Character[6].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_6 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[6].SetActive(true);

                StartTyping_6();
            }

            //7
            if (Character[7].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_7 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[7].SetActive(true);

                StartTyping_7();
            }

            //8
            if (Character[8].activeSelf == true)
            {

                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_8 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[8].SetActive(true);

                StartTyping_8();
            }

            //9
            if (Character[9].activeSelf == true)
            {
                item.Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_9 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
                //typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[9].SetActive(true);

                StartTyping_9();
            }
        }
        
    }

    //0
    public void Next_Text_0()
    {
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

    void StartTyping_0()
    {
        typingCoroutine = StartCoroutine(TypeSentence_0(sentences_0[Sentences_0]));
    }

    void NextSentence_0()
    {
        Sentences_0++;
        if (Sentences_0 < sentences_0.Length)
        {
            StartTyping_0();
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[0].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }
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

    //1 ��
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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[1].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //2
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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[2].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //3
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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[3].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //4
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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[4].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //5
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
           // typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[5].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //6
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
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[6].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

          
            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
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

    //7
    public void Next_Text_7()
    {
        if (isTyping_7)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_7();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
            NextSentence_7();
        }
    }

    void StartTyping_7()
    {
        typingCoroutine = StartCoroutine(TypeSentence_7(sentences_7[Sentences_7]));
    }

    void NextSentence_7()
    {
        Sentences_7++;
        if (Sentences_7 < sentences_7.Length)
        {
            StartTyping_7();
           // typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[7].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

           // typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           // find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }
        }

    }

    void CompleteTyping_7()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[7].text = sentences_7[Sentences_7];
        isTyping_7 = false;
    }

    IEnumerator TypeSentence_7(string sentence)
    {
        isTyping_7 = true;
        text[7].text = "";

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
                    text[7].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[7].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[7].text += ' ';
            }
        }

        isTyping_7 = false;
    }

    //8
    public void Next_Text_8()
    {
        if (isTyping_8)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_8();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
            NextSentence_8();
        }
    }

    void StartTyping_8()
    {
        typingCoroutine = StartCoroutine(TypeSentence_8(sentences_8[Sentences_8]));
    }

    void NextSentence_8()
    {
        Sentences_8++;
        if (Sentences_8 < sentences_8.Length)
        {
            StartTyping_8();
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[8].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

           // typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

            //find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }
        }

    }

    void CompleteTyping_8()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[8].text = sentences_8[Sentences_8];
        isTyping_8 = false;
    }

    IEnumerator TypeSentence_8(string sentence)
    {
        isTyping_8 = true;
        text[8].text = "";

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
                    text[8].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[8].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[8].text += ' ';
            }
        }

        isTyping_8 = false;
    }

    //9
    public void Next_Text_9()
    {
        if (isTyping_9)
        {
            // Ÿ���� ���� ���� ���� Ÿ������ �Ϸ��ϰ� ���� �������� �̵�
            CompleteTyping_9();
        }
        else
        {
            // Ÿ���� ���� �ƴ� ���� ���� ������ Ÿ���� ����
            NextSentence_9();
        }
    }

    void StartTyping_9()
    {
        typingCoroutine = StartCoroutine(TypeSentence_9(sentences_9[Sentences_9]));
    }

    void NextSentence_9()
    {
        Sentences_9++;
        if (Sentences_9 < sentences_9.Length)
        {
            StartTyping_9();
            //typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[9].SetActive(true);

            Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }

        else
        {
            Debug.Log("��ȭ ����");
            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }

            //typ.Names.SetActive(false);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(false);

           // find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            Suggest.SetActive(true);
            item.Suggest.SetActive(true);

            item.Sugg_Names[0].SetActive(false);//���̳� �̸�

            //0727
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ.Bg[1].activeSelf == true && find.Sentences_0 == 0
             && find.Dia[0].activeSelf == false && find1.Sentences_1 < 1
             && typ1.Sentences_1 < 1 && find2.Sentences_0 < 1 && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[0].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //�޿���� ��ȭ�ϴ� ����
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length &&
               (find1.Sentences_3 == 0 || find1.Sentences_0 == 0 || find1.Sentences_1 == 0 || find1.Sentences_2 == 0)
               && find1.Dia[0].activeSelf == false && (find1.Dia[1].activeSelf == false || find1.Dia[2].activeSelf == false || find1.Dia[3].activeSelf == false)
                && find2.Sentences_0 < 1 && find.Sentences_0 >= find.sentences_0.Length && typ2.Sentences_1 < 1
                && (find2.Dia[0].activeSelf == false) && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {
                find.touch_able_b[1].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ

            }

            //���� ������
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length &&
                 (find2.Sentences_0 == 0 && find2.Dia[0].activeSelf == false)
                  && (find2.Dia[1].activeSelf == false || find2.Dia[2].activeSelf == false || find2.Dia[3].activeSelf == false
               || find2.Dia[4].activeSelf == false || find2.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1)
            {


                if (find2.Arrow[0].activeSelf == true && find2.Arrow[1].activeSelf == true)
                {
                    find.touch_able_b[2].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }

                if ((find2.Arrow[2].activeSelf == true && find2.Arrow[3].activeSelf == true) ||
                    (find2.Arrow[4].activeSelf == true && find2.Arrow[5].activeSelf == true))
                {
                    find.touch_able_b[3].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
                }
            }

            //å Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find4.Sentences_0 < 1 &&
                 (find3.Sentences_0 == 0 && find3.Dia[0].activeSelf == false)
                 && (find3.Dia[1].activeSelf == false || find3.Dia[2].activeSelf == false || find3.Dia[3].activeSelf == false
               || find3.Dia[4].activeSelf == false || find3.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[4].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }

            //���� �پ��ִ� �׸� Ȯ���ϼ���
            if (typ.Sentences_1 >= typ.sentences_1.Length && typ1.Sentences_1 >= typ1.sentences_1.Length
                && find.Sentences_0 >= find.sentences_0.Length
                && find1.Sentences_0 >= find1.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                 (find4.Sentences_0 == 0 && find4.Dia[0].activeSelf == false)
                 && (find4.Dia[1].activeSelf == false || find4.Dia[2].activeSelf == false || find4.Dia[3].activeSelf == false
               || find4.Dia[4].activeSelf == false || find4.Dia[5].activeSelf == false)
                  && typ2.Sentences_1 >= typ2.sentences_1.Length && find2.Sentences_0 >= find2.sentences_0.Length)
            {
                find.touch_able_b[5].SetActive(true);//��ư�� ����ִ� �� Ȱ��ȭ
            }
        }

    }

    void CompleteTyping_9()
    {
        // Ÿ���� ���̴� ���� �Ϸ��ϰ� ���� �������� �̵�
        StopCoroutine(typingCoroutine);
        text[9].text = sentences_9[Sentences_9];
        isTyping_9 = false;
    }

    IEnumerator TypeSentence_9(string sentence)
    {
        isTyping_9 = true;
        text[9].text = "";

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
                    text[9].text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }

            // �� ���� �κ��� �⺻ �ӵ��� Ÿ����
            else
            {
                foreach (char letter in word.ToCharArray())
                {
                    text[9].text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
            }

            // �ܾ� ���̿� ���� �߰�
            if (i < words.Length - 1)
            {
                text[9].text += ' ';
            }
        }

        isTyping_9 = false;
    }



    //��ư1
    //���� �޸� ��ư�� ������ ��
    //���� �ִ� ��ư�� �������� �޸� â�� ��Ÿ����(�ִϸ��̼� ����)

    public void Go_Meno()
    {
        Meno.SetActive(true);
        Up_Button.SetActive(false);

        item.Buttons[0].SetActive(true);
        item.Buttons[1].SetActive(false);

        //ū �̹����� �ִ� �׸� �� ��Ȱ��
        for (int i = 0; i < item.item.Length; i++)
        {
            item.item[i].SetActive(false);
        }

        for (int i = 0; i < item.Item_Name.Length; i++)
        {
            item.Item_Name[i].SetActive(false);
        }

        //ū �̹����� �ִ� �׸� �� ��Ȱ��
        for (int i = 0; i < Character.Length; i++)
        {
            Character[i].SetActive(false);
        }

        //�̸��� ��Ȱ��
        for (int i=0; i< Character_Name.Length; i++)
        {
            Character_Name[i].SetActive(false);
        }

        //���� �׸� ���õǾ��� ǥ���ϴ� ���� �������
        for (int i = 0; i < Ch_Button.Length; i++)
        {
            Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        //�����̳� ��ġ ����
        //-0.0002441406 ->��
        //-681.8718 ->�Ʒ�
        Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

    }

    //��ư2
    //�޸𿡼� ���� ��ư�� ������ �޸�â�� �������� ���� �ִ� ��ư�� ��Ÿ����
    public void X_Button()
    {
        Meno.SetActive(false);
        Up_Button.SetActive(true);
    }

    //��ư3
    //�ι��� �������� ��
    //0�� �ι� ����
    public void Choose_Ch_0()
    {
        zero_0++;

        if(zero_0==1)
        {
            //���̳�
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[0].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 1; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[0].SetActive(true);

            for (int i = 1; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[0].SetActive(true);
            for (int i = 1; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_0 = 0;

            //���̳�
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����


            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
  
            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
  
            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        //���̳�
        //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
        /*Ch_Button[0].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

        for (int i = 1; i < Ch_Button.Length; i++)
        {
            Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
        Character[0].SetActive(true);

        for (int i = 1; i < Character.Length; i++)
        {
            Character[i].SetActive(false);
        }

        //�̸��� ��Ÿ����. �������� ��Ȱ��
        Character_Name[0].SetActive(true);
        for (int i = 1; i < Character_Name.Length; i++)
        {
            Character_Name[i].SetActive(false);
        }*/

    }

    public void Choose_Ch_1()
    {
        //��
        zero_1++;

        if(zero_1 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[1].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 1; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 2; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 2; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 2; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_1 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Ch_2()
    {
        zero_2++;

        //��

        if(zero_2 ==1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[2].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 2; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 3; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 3; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 3; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_2 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Ch_3()
    {
        zero_3++;

        //������
        if (zero_3 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[3].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 3; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 4; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 4; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 4; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_3 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }


        
    }

    public void Choose_Ch_4()
    {
        //������
        zero_4++;

        if(zero_4 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[4].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 4; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 5; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 5; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 5; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_4 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

       
    }

    public void Choose_Ch_5()
    {
        //�Ϸ��̽�
        zero_5++;

        if(zero_5 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[5].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 5; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 6; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[5].SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 6; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[5].SetActive(true);

            for (int i = 0; i < 5; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 6; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_5 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Ch_6()
    {
        //��ü�����
        zero_6++;

        if (zero_6 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[6].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 6; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 7; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[6].SetActive(true);

            for (int i = 0; i < 6; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 7; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[6].SetActive(true);

            for (int i = 0; i < 6; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 7; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_6 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }
        
    }

    public void Choose_Ch_7()
    {
        //���ڸ�
        zero_7 ++;

        if(zero_7 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[7].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 7; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 8; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[7].SetActive(true);

            for (int i = 0; i < 7; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 8; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[7].SetActive(true);

            for (int i = 0; i < 7; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 8; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_7 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Ch_8()
    {
        //������
        zero_8 ++;

        if(zero_8 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[8].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 8; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 9; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[8].SetActive(true);

            for (int i = 0; i < 8; i++)
            {
                Character[i].SetActive(false);
            }

            for (int i = 9; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[8].SetActive(true);

            for (int i = 0; i < 8; i++)
            {
                Character_Name[i].SetActive(false);
            }

            for (int i = 9; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_8 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }
        
    }

    public void Choose_Ch_9()
    {
        //�޿���
        zero_9 ++;

        if (zero_9 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Ch_Button[9].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < Ch_Button.Length - 1; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            Character[9].SetActive(true);

            for (int i = 0; i < Character.Length - 1; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Character_Name[9].SetActive(true);
            for (int i = 0; i < Character_Name.Length - 1; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        else
        {
            zero_9 = 0;

            for (int i = 0; i < Ch_Button.Length; i++)
            {
                Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��

            for (int i = 0; i < Character.Length; i++)
            {
                Character[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��

            for (int i = 0; i < Character_Name.Length; i++)
            {
                Character_Name[i].SetActive(false);
            }
        }

        
    }



}

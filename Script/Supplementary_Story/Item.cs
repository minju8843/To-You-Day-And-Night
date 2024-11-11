using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Item//������ ������ Ȱ��ȭ�Ǿ� �ִ��� �����ϴ� ��
{
    public int Item_Index;
}

public class Item : MonoBehaviour
{
   


    public GameObject[] Sugg_Names;

    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find;
    public Find_Something1 find1;
    public Find_Something2 find2;
    public Find_Something3 find3;
    public Find_Something4 find4;


    //������ �������� ��, �ݻ� �������� ���� ���ϰ�
    //���� ū �ݻ� ������ �ȿ� �������� ������ �������� �׸��� ��Ÿ����
    // + �������� �̸��� ��Ÿ����(������Ʈ�� �ؼ� Ȱ��ȭ ��Ű�� �ɷ�)

    //�����ϱ� ��ư�� ������ �ϴ��� �÷��̾�(���̳�)�� �� �����ۿ� ���� ������ ����
    //Ÿ���� ��ũ��Ʈ �����ϱ�


    public GameObject Suggest;//�����ϱ� ��ư Ȱ��/��Ȱ��

    public Image[] Item_Button; //���� �̹����� ����ִ� �ݻ� ������ �� �ٲ� ����

    public GameObject[] item;//ū �ݻ� ������ �ȿ� �� �׸�
    public GameObject[] Item_Name;//������ �̸��� ���� ������Ʈ

    public GameObject Up_Button;
    public GameObject Meno;

    public RectTransform Container;//�����̳�

    private Coroutine typingCoroutine; // Ÿ���� Coroutine ����

    public GameObject[] Dia;
    //public GameObject[] Text;
    public Text[] text;

    public Butt_Ch ch;

    //�Ǹ��� ���� ���� ����
    public string[] sentences_0; // ǥ�õ� ��ȭ �����
    public int Sentences_0;//���µǾ� ����Ʈ �� ��
    private bool isTyping_0 = false; // Ÿ���� ������ ����

    //��ž ��
    public string[] sentences_1; // ǥ�õ� ��ȭ �����
    public int Sentences_1;//���µǾ� ����Ʈ �� ��
    private bool isTyping_1 = false; // Ÿ���� ������ ����

    //������
    public string[] sentences_2; // ǥ�õ� ��ȭ �����
    public int Sentences_2;//���µǾ� ����Ʈ �� ��
    private bool isTyping_2 = false; // Ÿ���� ������ ����

    //���� ������
    public string[] sentences_3; // ǥ�õ� ��ȭ �����
    public int Sentences_3;//���µǾ� ����Ʈ �� ��
    private bool isTyping_3 = false; // Ÿ���� ������ ����

    //����
    public string[] sentences_4; // ǥ�õ� ��ȭ �����
    public int Sentences_4;//���µǾ� ����Ʈ �� ��
    private bool isTyping_4 = false; // Ÿ���� ������ ����



    public GameObject[] Buttons;


    //�� ��° �����۱��� �ִ��� Ȱ��ȭ�ϴ� �� (�����ϴ� ��)
    public GameObject[] small_square;//������ �׸� ���� ��

    public int Default_Item_Count = 0;
    public int Item_Count;
    public int Currnet_Item_Count;

    //������ ī��Ʈ
    public int Item_0 = 0;
    public int Item_1 = 0;
    public int Item_2 = 0;
    public int Item_3 = 0;
    public int Item_4 = 0;

    public void Start()
    {
        for (int i = 0; i < Sugg_Names.Length; i++)
        {
            Sugg_Names[i].SetActive(false);
        }

    }

    public void OnEnable()
    {
        //������ ���� �� ������ ����Ǿ�����
        Item_LoadSettings();
    }

    public void Update()
    {
        Item_SaveSettings();

        Currnet_Item_Count = Item_Count;

        if (Item_Count == 0)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(false);
        }

        if (Item_Count == 1)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 2)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(true);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 3)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(true);
            small_square[2].SetActive(false);
            small_square[3].SetActive(true);
            small_square[4].SetActive(true);
        }

        if (Item_Count == 4)
        {
            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(true);
        }
    }

    public void Item_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Item_Count"))
        {
            string jsonData = PlayerPrefs.GetString("Item_Count");
            GameData_Item data = JsonUtility.FromJson<GameData_Item>(jsonData);

            Item_Count = data.Item_Index;

            if (Item_Count == 0)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(false);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(false);
            }

            if (Item_Count == 1)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 2)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(true);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 3)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(true);
                small_square[2].SetActive(false);
                small_square[3].SetActive(true);
                small_square[4].SetActive(true);
            }

            if (Item_Count == 4)
            {
                small_square[0].SetActive(true);
                small_square[1].SetActive(false);
                small_square[2].SetActive(false);
                small_square[3].SetActive(false);
                small_square[4].SetActive(true);
            }
        }

        else
        {
            Item_Count = Default_Item_Count;
            Item_Count = 0;

            small_square[0].SetActive(true);
            small_square[1].SetActive(false);
            small_square[2].SetActive(false);
            small_square[3].SetActive(false);
            small_square[4].SetActive(false);
        }
    }

    public void Item_SaveSettings()
    {
        GameData_Item Item_data = new GameData_Item();
        Item_data.Item_Index = Item_Count;

        string Item_jsonData = JsonUtility.ToJson(Item_data);
        PlayerPrefs.SetString("Item_Count", Item_jsonData);
        PlayerPrefs.Save();
    }

    public void Item_ResetSettings()
    {
        PlayerPrefs.DeleteKey("Item_Count");
        PlayerPrefs.Save();

        Item_Count = 0;

        small_square[0].SetActive(true);
        small_square[1].SetActive(false);
        small_square[2].SetActive(false);
        small_square[3].SetActive(false);
        small_square[4].SetActive(false);

        // small_square[Item_Count].SetActive(true);
    }

    public void Select_People()
    {
        Buttons[0].SetActive(true);
        Buttons[1].SetActive(false);

        for (int i = 0; i < ch.Character.Length; i++)
        {
            ch.Character[i].SetActive(false);
        }

        for (int i = 0; i < ch.Character_Name.Length; i++)
        {
            ch.Character_Name[i].SetActive(false);
        }

        //�������̾��� �� ���� ������� ��������
        for (int i = 0; i < ch.Ch_Button.Length; i++)
        {
            ch.Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        ch.Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        ch.Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        
    }

    public void Select_Item()
    {
        

        Buttons[0].SetActive(false);
        Buttons[1].SetActive(true);

        for (int i = 0; i < item.Length; i++)
        {
            item[i].SetActive(false);
        }

        for (int i = 0; i < Item_Name.Length; i++)
        {
            Item_Name[i].SetActive(false);
        }

        //�������̾��� �� ���� ������� ��������
        for (int i = 0; i < ch.Ch_Button.Length; i++)
        {
            ch.Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        }

        ch.Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
        ch.Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top

        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
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

        if (item[0].activeSelf == false && item[1].activeSelf == false &&
            item[2].activeSelf == false && item[3].activeSelf == false && item[4].activeSelf == false)
        {
            return;
        }

        else
        {
            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);

            for(int i=0; i<find.touch_able_b.Length; i++)
            {
                find.touch_able_b[i].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            }

            /*find.touch_able_b[0].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            find.touch_able_b[1].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            find.touch_able_b[2].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            find.touch_able_b[3].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            find.touch_able_b[4].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            find.touch_able_b[5].SetActive(false);//��ư�� ����ִ� �� ��Ȱ��ȭ
            */

            for (int i = 0; i < find.Dia.Length; i++)
            {
                find.Dia[i].SetActive(false);//������Ʈ ����â ��Ȱ��ȭ
            }


            //0
            if (item[0].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//���̳� �̸�

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
            if (item[1].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_1 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
               // typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[1].SetActive(true);

                StartTyping_1();
            }

            //2
            if (item[2].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//���̳� �̸�

                Sentences_2 = 0;
                Meno.SetActive(false);
                Up_Button.SetActive(true);
               // typ.Names.SetActive(true);


                for (int i = 0; i < Dia.Length; i++)
                {
                    Dia[i].SetActive(false);
                }
                Dia[2].SetActive(true);

                StartTyping_2();
            }

            //3
            if (item[3].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//���̳� �̸�

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
            if (item[4].activeSelf == true)
            {
                Sugg_Names[0].SetActive(true);//���̳� �̸�

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
        }

        

        
    }

    //0 �Ǹ��� ��
    public void Next_Text_0()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            ch.Suggest.SetActive(false);
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
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//���̳� �̸�

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
                
                
                if(find2.Arrow[0].activeSelf==true && find2.Arrow[1].activeSelf == true)
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

    //
    public void Next_Text_1()
    {
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
           // typ.Names.SetActive(true);
            typ.Name[1].SetActive(false);
            typ.Name[0].SetActive(true);

            for (int i = 0; i < Dia.Length; i++)
            {
                Dia[i].SetActive(false);
            }
            Dia[1].SetActive(true);

            Suggest.SetActive(false);
            ch.Suggest.SetActive(false);
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
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//���̳� �̸�

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
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            ch.Suggest.SetActive(false);
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
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//���̳� �̸�

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
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            ch.Suggest.SetActive(false);
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
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//���̳� �̸�

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
        Suggest.SetActive(false);
        ch.Suggest.SetActive(false);

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
            ch.Suggest.SetActive(false);
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
            ch.Suggest.SetActive(true);

            Sugg_Names[0].SetActive(false);//���̳� �̸�

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

    //��ư1
    //���� �޸� ��ư�� ������ ��
    //���� �ִ� ��ư�� �������� �޸� â�� ��Ÿ����(�ִϸ��̼� ����)

    public void Go_Meno()
    {
        Meno.SetActive(true);
        Up_Button.SetActive(false);

        //ū �̹����� �ִ� �׸� �� ��Ȱ��
        for (int i = 0; i < item.Length; i++)
        {
            item[i].SetActive(false);
        }

        //�̸��� ��Ȱ��
        for (int i = 0; i < Item_Name.Length; i++)
        {
            Item_Name[i].SetActive(false);
        }

        //���� �׸� ���õǾ��� ǥ���ϴ� ���� �������
        for (int i = 0; i < Item_Button.Length; i++)
        {
            Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
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
    public void Choose_Item_0()
    {

        Item_0 ++;

        if(Item_0 == 1)
        {
            //���̳�
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Item_Button[0].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 1; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            item[0].SetActive(true);

            for (int i = 1; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Item_Name[0].SetActive(true);
            for (int i = 1; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_0 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

    

    }

    public void Choose_Item_1()
    {
        //��
        Item_1++;

        if(Item_1 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Item_Button[1].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 1; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 2; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            item[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 2; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Item_Name[1].SetActive(true);

            for (int i = 0; i < 1; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 2; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_1 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        
    }

    public void Choose_Item_2()
    {
        //��
        Item_2++;

        if(Item_2 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Item_Button[2].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 2; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 3; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            item[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 3; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Item_Name[2].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 3; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_2 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }
        
    }

    public void Choose_Item_3()
    {
        //������
        Item_3++;

        if (Item_3 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Item_Button[3].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 3; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 4; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            item[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 4; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Item_Name[3].SetActive(true);

            for (int i = 0; i < 3; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 4; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_3 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }
            
    }

    //����
    public void Choose_Item_4()
    {
        //������
        Item_4++;

        if (Item_4 == 1)
        {
            //�̹��� �� �ٲ�� && ������ �̹��� �� ������� �ǵ�����
            Item_Button[4].color = new Color(219 / 225f, 113 / 225f, 107 / 225f);

            for (int i = 0; i < 4; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 5; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            item[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                item[i].SetActive(false);
            }

            for (int i = 5; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            Item_Name[4].SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                Item_Name[i].SetActive(false);
            }

            for (int i = 5; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

        else
        {
            Item_4 = 0;

            for (int i = 0; i < Item_Button.Length; i++)
            {
                Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            //ū �̹����� ��Ÿ����, ������ �׸��� ��Ȱ��
            for (int i = 0; i < item.Length; i++)
            {
                item[i].SetActive(false);
            }

            //�̸��� ��Ÿ����. �������� ��Ȱ��
            for (int i = 0; i < Item_Name.Length; i++)
            {
                Item_Name[i].SetActive(false);
            }
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ÿ���� ���õ� �� ����(�޸�, �����⿡ ���� �� �ٸ� ���� ����)


[System.Serializable]//������ ���� ���� �߰���

public class GameData_Typing1
{//����� ���� �����͸� �����ϴ� Ŭ����
    //���� �� ��° ���� �ε������� ����Ǿ����� �����ϴ� Ŭ����

    public int Sentences_1_Index;//�� ó�� ���� �κ� �ε���
}

public class Typing_1 : MonoBehaviour
{
    //public GameObject[] Talk;//���丮 ��ǳ�� ��ü ����

    public Typing typ;
    public Typing_2 typ2;
    public Hint hint;

    public Butt_Ch butt_ch;
    public Item item;

    public GameObject Dia;
    public GameObject Inside_Dia;

    //public GameObject Names;

    public Text dialogueText; // ��ȭâ�� ǥ�õ� �ؽ�Ʈ UI
    public string[] sentences_1; // ǥ�õ� ��ȭ �����

    public bool isTyping = false; // Ÿ���� ������ ����

    public Coroutine typingCoroutine; // Ÿ���� Coroutine ����

    public GameObject[] Name;//ĳ���� �̸�



    //���� ������ ����Ǿ�����
    public int Default_Sentences_1 = 0; // ���� ������ ����Ǿ�����
    public int Sentences_1;//���µǾ� ����Ʈ �� ��
    public int Current_Sentences_1; // ���� ������ �ε���

    //Ž�� ����
    public GameObject start;
    public Animator Start_Ainm;


    //Ž�� ���� �� ���� ��ư �����Ϸ��� ���� �� 
    public Find_Something find_s;
    public Find_Something1 find_s1;
    public Find_Something2 find_s2;

    public int Start_Count = 0;

    public void OnEnable()
    {
        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        Dia.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //�Ʒ� ���� �߰�
        //Load_Sentences1();//���̳� �濡�� ���� ����� �ҷ����� ��

    }

    void Start()
    {
        Load_Sentences1();//0724 ����

        Start_Count = 1;
    }

    
    public void Load_Sentences1()
    {
        //���̳� �濡�� ���� ����� �ҷ�����
        if (PlayerPrefs.HasKey("Typing_GameData1"))
        {
            string jsonData = PlayerPrefs.GetString("Typing_GameData1");
            GameData_Typing1 data = JsonUtility.FromJson<GameData_Typing1>(jsonData);

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

                if (Sentences_1 > 5 )
                {
                    //butt_ch.Suggest.SetActive(true);
                    //item.Suggest.SetActive(true);
                    Dia.SetActive(false);
                    //Names.SetActive(false);

                    Name[1].SetActive(false);
                    Name[0].SetActive(false);

                    if(find_s1.Dia[0].activeSelf==false)
                    {
                        find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư
                        find_s.touch_able_b[0].SetActive(false);
                        find_s.touch_able_b[1].SetActive(true);
                        find_s.touch_able_b[3].SetActive(false);//������ �ִ� ��ž ������
                        find_s.touch_able_b[2].SetActive(false);//������ �ִ� ��ž ������
                    }
                    
                    if(find_s1.Dia[0].activeSelf == true)
                    {
                        find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư
                        for (int i = 0; i < find_s.touch_able_b.Length; i++)
                        {
                            find_s.touch_able_b[i].SetActive(false);
                        }
                    }


                    //Next_Text();
                    Dia.SetActive(false);
                    Sentences_1 = 6;
                    Sectences_Save_Settings();//���� �߰�720

                }

                if (Sentences_1 <= 5)
                {
                    Dia.SetActive(true);
                    Inside_Dia.SetActive(true);
                    //butt_ch.Suggest.SetActive(false);
                    //item.Suggest.SetActive(false);
                   

                    //��
                    Sentences_1--;
                    Next_Text();
                    Sectences_Save_Settings();

                    Debug.Log("�� ��°��" + Sentences_1);

                    find_s1.Dia[0].SetActive(false);
                }

            }

        }

        else
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);


            Name[1].SetActive(false);
            Name[0].SetActive(false);

            //Names.SetActive(false);

            Sentences_1 = Default_Sentences_1;
            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                Dia.SetActive(true);
                //Talk.SetActive(true);

                Inside_Dia.SetActive(true);

                // Names.SetActive(true);
                StartTyping(); // ��ȭ ����

            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //���̳׹濡�� ���� ����� ����
        GameData_Typing1 data = new GameData_Typing1();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData1", jsonData);
        PlayerPrefs.Save();

    }

    public void Sectences_Reset_Settings()
    {
        //���̳� �濡�� ���� ����� ����
        PlayerPrefs.DeleteKey("Typing_GameData1");
        PlayerPrefs.Save();
        Load_Sentences1();
        hint.Touch_Index = 0;
        hint.Anim.SetTrigger("Up");

        //��ġ ������ ��ư �����ֱ� ��Ȱ��ȭ
        find_s.touch_able_b[0].SetActive(false);

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);

        Start_Count = 0;

    }

    private void Update()
    {
        if(Dia.activeSelf==true)
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
        }

        if (Dia.activeSelf == true && Sentences_1 ==5)
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
        }

        if (typ.Sentences_1<typ.sentences_1.Length || find_s.Sentences_0 < find_s.sentences_0.Length)
        {
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);
        
        }

        Sectences_Save_Settings();

        Current_Sentences_1 = Sentences_1;


        if (Sentences_1 <= 5 && find_s.Sentences_0>find_s.sentences_0.Length)
        {
            find_s.btn_Collection.SetActive(false);
             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }
        }

        //0
        if (Sentences_1 ==0 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);
      

            //Sectences_Save_Settings();

            Sentences_1 = 0;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);


        }

        //1
        if (Sentences_1 ==1 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 1;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //2
        if (Sentences_1 ==2 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 2;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //3
        if (Sentences_1 ==3 && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);

             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 3;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //4
        if (Sentences_1 ==4  && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }

            Sentences_1 = 4;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

        //5
        if (Sentences_1 ==5  && find_s.Sentences_0 >= find_s.sentences_0.Length)
        {
            for (int i = 0; i < typ.Ch.Length; i++)
            {
                typ.Ch[i].SetActive(false);
            }

            typ.Bg_0 = 2;

            typ.Bg[0].SetActive(false);
            typ.Bg[1].SetActive(false);
            typ.Bg[2].SetActive(true);
            typ.Bg[3].SetActive(false);
            typ.Bg[4].SetActive(false);
            typ.Bg[5].SetActive(false);


             for (int i = 0; i < find_s.touch_able_b.Length; i++)
           {
               find_s.touch_able_b[i].SetActive(false);
           }

            Sentences_1 = 5;
            Sectences_Save_Settings();

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);

            find_s1.Dia[0].SetActive(false);
        }

    }

    public void Go_1_Typing()
    {
        //find_something���� ����� ��
        //PlayerPrefs.DeleteKey("Typing_GameData1");
        //PlayerPrefs.Save();

        StartTyping();

        Dia.SetActive(false);
        Inside_Dia.SetActive(false);
        Name[1].SetActive(false);
        Name[0].SetActive(false);
        Load_Sentences1();
    }

    private void FixedUpdate()
    {
        
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

            //0721�߰�
            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(true);
        }

        else if (Sentences_1 > 5)
        {
            Debug.Log("��ȭ ����");
            Dia.SetActive(false);
            Inside_Dia.SetActive(false);

            Name[1].SetActive(false);
            Name[0].SetActive(false);

            butt_ch.Suggest.SetActive(true);
            item.Suggest.SetActive(true);


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
                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
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
                find_s.touch_able_b[0].SetActive(false);
                find_s.touch_able_b[1].SetActive(true);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);

                find_s.btn_Collection.SetActive(true);

            }

        }

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
            if (word.StartsWith("��..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.3f);
                }
            }
            // "���..." �κ��� ó��
            else if (word.StartsWith("���..."))
            {
                foreach (char letter in word.ToCharArray())
                {
                    dialogueText.text += letter;
                    yield return new WaitForSeconds(0.2f);
                }
            }
            // "��Ƽ�..." �κ��� ó��
            else if (word.StartsWith("��Ƽ�..."))
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
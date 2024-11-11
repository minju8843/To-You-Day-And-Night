using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ÿ���� ���õ� �� ����(�޸�, �����⿡ ���� �� �ٸ� ���� ����)


[System.Serializable]//������ ���� ���� �߰���

public class GameData_Typing
{//����� ���� �����͸� �����ϴ� Ŭ����
    //���� �� ��° ���� �ε������� ����Ǿ����� �����ϴ� Ŭ����

    public int Sentences_1_Index;//�� ó�� ���� �κ� �ε���



    public int Bg_Index;//�� ��° �������
}

public class Typing : MonoBehaviour
{
    //public GameObject[] Talk;//���丮 ��ǳ�� ��ü ����

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
    public GameObject[] Ch;//ĳ���� ���� �� �̹���
    public GameObject[] Bg;//���

    //��� �� ��° ����
    public int Default_Bg_0 = 0; // ���� ������ ����Ǿ�����
    public int Bg_0;//���µǾ� ����Ʈ �� ��
    public int Current_Bg_0; // ���� ������ �ε���


    //���� ������ ����Ǿ�����
    public int Default_Sentences_1 = 0; // ���� ������ ����Ǿ�����
    public int Sentences_1;//���µǾ� ����Ʈ �� ��
    public int Current_Sentences_1; // ���� ������ �ε���

    //Ž�� ����
    public GameObject start;
    public Animator Start_Ainm;


    //Ž�� ���� �� ���� ��ư �����Ϸ��� ���� �� 
    public Find_Something find_s;
    public Find_Something find_s1;


    public int Start_Count = 1;




    public void OnEnable()
    {
        start.SetActive(false);//Ž�� ���� �̹��� ��Ȱ��

        //Names.SetActive(false);

        Name[1].SetActive(false);
        Name[0].SetActive(false);

        //�Ʒ� ���� �߰�
        //Load_Sentences1();//���̳� �濡�� ���� ����� �ҷ����� ��
        //Load_Bg_0();

        /*if (Bg[0].activeSelf == true && Sentences_1 == 0)
        {
            Load_Sentences1();//0724 ����
            Load_Bg_0();//0724 ����

            StartCoroutine(Show_B_Story());
            IEnumerator Show_B_Story()
            {
                yield return new WaitForSeconds(2.0f);

                Dia.SetActive(true);
                //Talk.SetActive(true);

                Inside_Dia.SetActive(true);

                // Names.SetActive(true);
                //StartTyping(); // ��ȭ ����
                find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
            }
        }*/
    }

    public void Start()
    {
        Load_Sentences1();//0724 ����
        Load_Bg_0();//0724 ����

        Start_Count = 1;

    }

    public void Load_Bg_0()
    {
        if (PlayerPrefs.HasKey("Bg_GameData"))
        {
            string jsonData = PlayerPrefs.GetString("Bg_GameData");
            GameData_Typing data = JsonUtility.FromJson<GameData_Typing>(jsonData);

            Bg_0 = data.Bg_Index;

            foreach (GameObject Back_ground in Bg)
            {
                Back_ground.SetActive(false);
            }

            Bg[Bg_0].SetActive(true);

            if(Sentences_1 >= 17 && typ1.Sentences_1 < 1 && find_s.Sentences_0 < 1 && find_s1.Sentences_0 < 1 )//���� �߰�
            {
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);

                find_s.btn_Collection.SetActive(true);
            }

        }

        else
        {
            find_s.touch_able_b[0].SetActive(false);
            Bg_0 = Default_Bg_0;

        }
    }
    
    public void Load_Sentences1()
    {
        //���̳� �濡�� ���� ����� �ҷ�����
        if (PlayerPrefs.HasKey("Typing_GameData"))
        {
            string jsonData = PlayerPrefs.GetString("Typing_GameData");
            GameData_Typing data = JsonUtility.FromJson<GameData_Typing>(jsonData);

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

                if(Sentences_1 > 17)
                {
                    butt_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                    Dia.SetActive(false);
                    //Names.SetActive(false);

                    Name[1].SetActive(false);
                    Name[0].SetActive(false);

                    find_s.btn_Collection.SetActive(true);//���̳� �� Ž�� ��ư

        
                }

                if (Sentences_1 <= 17)
                {
                    find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

                    Dia.SetActive(true);
                    //Talk.SetActive(true);

                    Inside_Dia.SetActive(true);
                   // Names.SetActive(true);
                    butt_ch.Suggest.SetActive(false);
                    item.Suggest.SetActive(false);
                    StartTyping(); // ��ȭ ����

                   /* if(Sentences_1==11)
                    {

                    }*/
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
                find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
            }

            butt_ch.Suggest.SetActive(false);
            item.Suggest.SetActive(false);
        }
    }

    public void Sectences_Save_Settings()
    {
        //���̳׹濡�� ���� ����� ����
        GameData_Typing data = new GameData_Typing();
        data.Sentences_1_Index = Sentences_1;
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("Typing_GameData", jsonData);
        PlayerPrefs.Save();

        //���
       GameData_Typing bg_data = new GameData_Typing();
        bg_data.Bg_Index = Bg_0;
        string bg_jsonData = JsonUtility.ToJson(bg_data);
        PlayerPrefs.SetString("Bg_GameData", bg_jsonData);
        PlayerPrefs.Save();
       

    }

    public void Sectences_Reset_Settings()
    {
        //���̳� �濡�� ���� ����� ����
        PlayerPrefs.DeleteKey("Typing_GameData");
        PlayerPrefs.Save();
        Load_Sentences1();
        hint.Touch_Index = 0;
        hint.Anim.SetTrigger("Up");

        //��ġ ������ ��ư �����ֱ� ��Ȱ��ȭ
        find_s.touch_able_b[0].SetActive(false);

        //���̳� �濡�� ���� ����� ����
        PlayerPrefs.DeleteKey("Bg_GameData");
        PlayerPrefs.Save();
        Bg_0 = 0;
        for(int i=0; i<Bg.Length; i++)
        {
            Bg[i].SetActive(false);
        }
        Bg[0].SetActive(true);
       
        Load_Bg_0();

        
        Name[1].SetActive(false);
        Name[0].SetActive(true);

        //Names.SetActive(true);
        find_s.Typ_Dia_Total.SetActive(true);//0720 �߰�

        Start_Count = 0;
    }

    public void Update()
    {

       

        if (Sentences_1 == 5)//�� ��
        {
            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[0].SetActive(true);
        }

        if (Sentences_1 == 7)
        {
            item.small_square[0].SetActive(true);
            item.small_square[1].SetActive(false);
            item.small_square[2].SetActive(false);
            item.small_square[3].SetActive(false);
            item.small_square[4].SetActive(true);
            item.Item_Count = 4;

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[27].SetActive(true);
        }

        if (Sentences_1 == 11)//�� �ڰ� �ִ� �� ������
        {

            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
            Ch[1].SetActive(true);
        }

        //������
        if (Sentences_1 == 5)//�� �̸� ��������
        {
            Name[1].SetActive(true);
            Name[0].SetActive(false);
        }




        if (Sentences_1 != 5 && Sentences_1 < sentences_1.Length)//�������� ���̳�
        {
            Name[1].SetActive(false);
            Name[0].SetActive(true);
        }

        Sectences_Save_Settings();

        Current_Sentences_1 = Sentences_1;

        Current_Bg_0 = Bg_0;

        if(Sentences_1 < sentences_1.Length)
        {
            find_s.btn_Collection.SetActive(false);
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
        }


        if (Sentences_1 < sentences_1.Length && (Sentences_1 != 11 && Sentences_1 != 5 && Sentences_1 != 7))
        {
            for (int i = 0; i < Ch.Length; i++)
            {
                Ch[i].SetActive(false);
            }
        }


        //��� ����
        if (Sentences_1 >= 0 && Sentences_1 <= 15)//���̳� �̸�, [16]���� ��� ����
        {
            Bg_0 = 0;

            Bg[0].SetActive(true);
            Bg[1].SetActive(false);
            Bg[2].SetActive(false);
            Bg[3].SetActive(false);
            Bg[4].SetActive(false);
            Bg[5].SetActive(false);

        }

        if (Sentences_1 > 15 && item.Item_Count == 4)//���̳� �̸�, [16]���� ��� ����
        {
            Bg_0 = 1;

            Bg[0].SetActive(false);
            Bg[1].SetActive(true);
            Bg[2].SetActive(false);
            Bg[3].SetActive(false);
            Bg[4].SetActive(false);
            Bg[5].SetActive(false);

        }

        //���̳� ħ�뿡�� Ž������ ��ǳ���� �������� ���� ��
        if (Sentences_1 >= 17 && item.Item_Count == 0 && butt_ch.Suggest.activeSelf == true && item.Suggest.activeSelf == true
             && (find_s.Dia[0].activeSelf == false && find_s.Dia[1].activeSelf == false &&
            find_s.Dia[2].activeSelf == false && find_s.Dia[3].activeSelf == false &&
            find_s.Dia[4].activeSelf == false && find_s.Dia[5].activeSelf == false &&
            find_s.Dia[6].activeSelf == false) &&
            (item.Dia[0].activeSelf == false || item.Dia[1].activeSelf == false || item.Dia[2].activeSelf == false || item.Dia[3].activeSelf == false || item.Dia[4].activeSelf == false))
        {
            find_s.touch_able_b[0].SetActive(true);
            find_s.touch_able_b[1].SetActive(false);
            find_s.touch_able_b[2].SetActive(false);
            find_s.touch_able_b[3].SetActive(false);
            find_s.touch_able_b[4].SetActive(false);

            //Debug.Log("�̰ų�? 0714");
        }

        //���̳� ħ�뿡�� ���� Ž������ ��ǳ���� ���� ��
        if (Sentences_1 >= 17 && item.Item_Count == 0 && butt_ch.Suggest.activeSelf == false && item.Suggest.activeSelf == false
            && (find_s.Dia[0].activeSelf == true || find_s.Dia[1].activeSelf == true ||
            find_s.Dia[2].activeSelf == true || find_s.Dia[3].activeSelf == true ||
            find_s.Dia[4].activeSelf == true || find_s.Dia[5].activeSelf == true ||
            find_s.Dia[6].activeSelf == true) ||
            (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true || item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true || item.Dia[4].activeSelf == true))
        {
            for (int i = 0; i < find_s.touch_able_b.Length; i++)
            {
                find_s.touch_able_b[i].SetActive(false);
            }
            //Debug.Log("�̰�? 0714");
        }


        if (Sentences_1 > 17 && Bg[1].activeSelf == true)
        {
            Dia.SetActive(false);


        }

        if (Bg_0 == 2)//��ž ����� ��, ���̳� �� Ž��� ���� ���ϵ���
        {
            find_s.touch_able_b[0].SetActive(false);

        }



    }

    private void FixedUpdate()
    {
        
        

    }

    public void Next_Text()
    {
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

            

        }

        else if(Sentences_1 > 17)
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
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
                find_s.btn_Collection.SetActive(true);

            }

            find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
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
                find_s.touch_able_b[0].SetActive(true);
                find_s.touch_able_b[1].SetActive(false);
                find_s.touch_able_b[2].SetActive(false);
                find_s.touch_able_b[3].SetActive(false);
                find_s.touch_able_b[4].SetActive(false);
                find_s.btn_Collection.SetActive(true);

                find_s.Typ_Dia_Total.SetActive(false);//0720 �߰�
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
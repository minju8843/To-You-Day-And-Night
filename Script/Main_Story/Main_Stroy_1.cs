using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Main_Story_1
{//����� ���� �����͸� �����ϴ� Ŭ����
    public int First_Side_Story;//���� �� ��° ���丮�� Ȱ��ȭ�Ǿ� �ִ��� 1, 1-1, 1-2
    public int First_Page_What_Page;//ù ��° �̾߱��� �� ��° ���������� �����ߴ���

    public int Page_1_Index;
    public int Page_2_Index;
    public int Page_3_Index;
    public int Page_4_Index;
    public int Page_5_Index;
    public int Page_6_Index;
    public int Page_7_Index;
    public int Page_8_Index;
    public int Page_9_Index;
    public int Page_10_Index;

    public int Star_Index;

}


public class Main_Stroy_1 : MonoBehaviour
{
    //�̾߱⸦ �������ּ���!
    public GameObject Continue;//�̾߱⸦ �������ּ���
    public Fade fade;
    public Main_Stroy_2 main_story2;


    public Main_Story_S mss;


    public SFX_Manager sfx;

    //����
    public Bag bag;

    //�ֿ��ι�
    public Ch ch;

    //������
    public Letter letter;

    //�ٓ� �ر�
    public Album album;

    //��� ����
    public GameObject[] Four_Page_Background;
    public GameObject[] Five_Page_Background;

    //5��
    public int Main_Story_1_Object_Index;
    public int Default_Main_Story_1_Object_Index;

    public GameObject[] Main_Story_1_Object;

    public RectTransform[] Main_Story_1_Object_trans;
    private Vector3 Main_Story_1_Frame_Position = new Vector3(0, 0, 0);

    //public Main_Stroy_1_1 Main_Story_1_1;
    //���ν��丮 1ȭ
    public M_S_1_1 Main_Story_1_1;
    public M_S_1_2 Main_Story_1_2;

    //public Side_Story_1_2 Main_Story_1_2;

    public GameObject[] Main_Story_1_Stars;


    public Slider Main_Story_1_Slider;
    public int Default_Story_Page = 1;//���� �� ����������
    public int Reset_Story_Page;//����Ʈ ������(������ ���� �ʾҴٸ� ����Ʈ ������)
    public int Current_Story_Page;//1, 1-1, 1-2 �߿��� ���� �������� ����


    public Text Left_Page;


    public GameObject[] Main_story;//���������� �־�� ��

    public GameObject[] Page_1;//ù ��° �������� ��Ÿ�� Ui�� ���� ��
    public GameObject[] Page_2;
    public GameObject[] Page_3;
    public GameObject[] Page_4;
    public GameObject[] Page_5;
    public GameObject[] Page_6;
    public GameObject[] Page_7;
    public GameObject[] Page_8;
    public GameObject[] Page_9;
    public GameObject[] Page_10;

    public GameObject[] Page_Button;

    public int Default_Page_Count_1 = 0;//���� �� ����������    
    // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
    public int Page_Count_1;//���µǾ� ����Ʈ �� ��
    // -> �����̴��� ���� �Ŷ�� �����ϱ�
    public int Currnet_Page_Count_1;//���� �������� ����  
    // -> ���� �����̶�� �����ϱ�


    public int Default_Page_Count_2 = 0;
    public int Page_Count_2;
    public int Currnet_Page_Count_2;

    public int Default_Page_Count_3 = 0;
    public int Page_Count_3;
    public int Currnet_Page_Count_3;

    public int Default_Page_Count_4 = 0;
    public int Page_Count_4;
    public int Currnet_Page_Count_4;

    public int Default_Page_Count_5 = 0;
    public int Page_Count_5;
    public int Currnet_Page_Count_5;

    public int Default_Page_Count_6 = 0;
    public int Page_Count_6;
    public int Currnet_Page_Count_6;

    public int Default_Page_Count_7 = 0;
    public int Page_Count_7;
    public int Currnet_Page_Count_7;

    public int Default_Page_Count_8 = 0;
    public int Page_Count_8;
    public int Currnet_Page_Count_8;

    public int Default_Page_Count_9 = 0;
    public int Page_Count_9;
    public int Currnet_Page_Count_9;

    public int Default_Page_Count_10 = 0;
    public int Page_Count_10;
    public int Currnet_Page_Count_10;

    public int Star_B_Count = 0;
    public int Star_Count_5;
    public int Currnet_Star_Count_5;





    public Animator Main_Story_1_R_L;
    public Animator Button_Main_1_Story_R_L;

    //
    public bool next=false;
    public bool back = false;


    public void Go_Next_Button()
    {
        next = true;
        back = false;

        //������ ������
        if(Main_Story_1_Object[0].activeSelf == true && Main_story[28].activeSelf==true)
        {
            //����
            //�̾߱⸦ �������ּ���.
            Continue.SetActive(true);
        }

        //1, 2 Ȱ��ȭ �Ǿ� �ִµ� ������ �������� ������ ��簡 ������ �ʾҴٸ�
        if(Main_Story_1_Object[1].activeSelf == true && Main_Story_1_1.Main_story[28].activeSelf == true
            && Main_Story_1_1.Page_29[2].activeSelf==false)
        {
            //�̾߱⸦ �������ּ���.
            Continue.SetActive(true);
        }

        if(Main_Story_1_Object[2].activeSelf == true && Main_Story_1_2.Main_story[28].activeSelf == true
            && Main_Story_1_2.Page_29[2].activeSelf == false)
        {
            //�̾߱⸦ �������ּ���
            Continue.SetActive(true);
        }

        //������ �������� ������ ��簡 ���Դٸ�
        if (Main_Story_1_Object[1].activeSelf == true && Main_Story_1_1.Main_story[28].activeSelf == true
            && Main_Story_1_1.Page_29[2].activeSelf == true)
        {
            //���� �̾߱�� �Ѿ
            fade.Fade_BE.SetActive(true);
            fade.Fade_In_Out.SetTrigger("Go_Black");

            StartCoroutine(Show_Story());

            IEnumerator Show_Story()
            {
                yield return new WaitForSeconds(0.8f);
                //���� ���丮 1 ���������� �̵�
                main_story2.Go_Main_Story_2();//���ν��丮2 ��Ÿ���� ��
                Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Right");
                Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Right");
                Main_Story_1_R_L.SetTrigger("Go_Right");
                Button_Main_1_Story_R_L.SetTrigger("Go_Right");

                Main_Story_1_1.Main_Story_1_R_L.enabled = true;
                Main_Story_1_2.Main_Story_1_R_L.enabled = true;
            }   

            StartCoroutine(Go_Main_Black_Empty());

            IEnumerator Go_Main_Black_Empty()
            {
                yield return new WaitForSeconds(1.6f);
                fade.Fade_In_Out.SetTrigger("Go_Empty");
            }

            StartCoroutine(Bye_Fade());
            IEnumerator Bye_Fade()
            {
                yield return new WaitForSeconds(2.6f);
                fade.Fade_BE.SetActive(false);

            }
        }

        if (Main_Story_1_Object[2].activeSelf == true && Main_Story_1_2.Main_story[28].activeSelf == true
            && Main_Story_1_2.Page_29[2].activeSelf == true)
        {
            //���� �̾߱�� �Ѿ
            //���� �̾߱�� �Ѿ
            fade.Fade_BE.SetActive(true);
            fade.Fade_In_Out.SetTrigger("Go_Black");

            StartCoroutine(Show_Story());

            IEnumerator Show_Story()
            {
                yield return new WaitForSeconds(0.8f);
                //���� ���丮 1 ���������� �̵�
                main_story2.Go_Main_Story_2();//���ν��丮2 ��Ÿ���� ��
                Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Right");
                Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Right");
                Main_Story_1_R_L.SetTrigger("Go_Right");
                Button_Main_1_Story_R_L.SetTrigger("Go_Right");

                Main_Story_1_1.Main_Story_1_R_L.enabled = true;
                Main_Story_1_2.Main_Story_1_R_L.enabled = true;
            }

            StartCoroutine(Go_Main_Black_Empty());

            IEnumerator Go_Main_Black_Empty()
            {
                yield return new WaitForSeconds(1.6f);
                fade.Fade_In_Out.SetTrigger("Go_Empty");
            }

            StartCoroutine(Bye_Fade());
            IEnumerator Bye_Fade()
            {
                yield return new WaitForSeconds(2.6f);
                fade.Fade_BE.SetActive(false);

            }
        }
    }

    public void Closed_Continue()
    {
        Continue.SetActive(false);
    }




    public void Go_Back_Button()
    {
        back = true;
        next = false;
    }

    //���� ���丮 1ȭ
    public void Go_Main_Story_1()
    {
        if (Main_Story_1_Object[0].activeSelf == true)
        {
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Left");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Left");
            //side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Main_Story_1_R_L.SetTrigger("Go_Left");
            Button_Main_1_Story_R_L.SetTrigger("Go_Left");

            //side_1_2.Side_Story_R_L.enabled = true;

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

        else if (Main_Story_1_Object[1].activeSelf == true)
        {
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Left");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Left");
            //side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Main_Story_1_R_L.SetTrigger("Go_Left");
            Button_Main_1_Story_R_L.SetTrigger("Go_Left");

            //side_1_2.Side_Story_R_L.enabled = true;

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

        else if (Main_Story_1_Object[2].activeSelf == true)
        {
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Left");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Left");
            //side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Main_Story_1_R_L.SetTrigger("Go_Left");
            Button_Main_1_Story_R_L.SetTrigger("Go_Left");

            //side_1_2.Side_Story_R_L.enabled = true;

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

        mss.Text_Count = 0;
        mss.text[0].SetActive(true);
        mss.text[1].SetActive(false);
        mss.text[2].SetActive(false);


    }

    

    public void Go_Main()
    {
        if (Main_Story_1_Object[0].activeSelf == true)
        {
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_R_L.SetTrigger("Go_Right");
            Button_Main_1_Story_R_L.SetTrigger("Go_Right");

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

        else if (Main_Story_1_Object[1].activeSelf == true)
        {
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_R_L.SetTrigger("Go_Right");
            Button_Main_1_Story_R_L.SetTrigger("Go_Right");

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

        else if (Main_Story_1_Object[2].activeSelf == true)
        {
            //side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
            Main_Story_1_1.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_2.Main_Story_1_R_L.SetTrigger("Go_Right");
            Main_Story_1_R_L.SetTrigger("Go_Right");
            Button_Main_1_Story_R_L.SetTrigger("Go_Right");

            //side_1_2.Side_Story_R_L.enabled = true;

            Main_Story_1_1.Main_Story_1_R_L.enabled = true;
            Main_Story_1_2.Main_Story_1_R_L.enabled = true;
        }

    }

    private void Start()
    {
        //side_1_2.Side_Story_R_L.enabled = true;

        //Stars[0].SetActive(true);
        //Stars[1].SetActive(false);

        for (int i = 0; i < Main_Story_1_Object.Length; i++)
        {
            Main_Story_1_Object[i].SetActive(false);
        }

        Continue.SetActive(false);//�̾߱⸦ �������ּ���
    }

    public void OnEnable()
    {
        




        Main_Story_1_LoadSettings();//��ũ��Ʈ�� Ȱ��ȭ �Ǿ� ���� ��

        Main_Story_What_Page_LoadSettings();

        //�ؽ�Ʈ ����
        Page_1_Text_LoadSettings();//���⿡ ���� ����
        Page_2_Text_LoadSettings();
        Page_3_Text_LoadSettings();
        Page_4_Text_LoadSettings();
        Page_5_Text_LoadSettings();
        Page_6_Text_LoadSettings();
        Page_7_Text_LoadSettings();
        Page_8_Text_LoadSettings();
        Page_9_Text_LoadSettings();
        Page_10_Text_LoadSettings();

        Star_Load_Setting();

    }

    public void Update()
    {
        


        //���⿡ �ٹ� ���� ����
        if (Page_2[1].activeSelf == true)
        {
            album.Album_1[0].SetActive(false);
            album.Album_1[1].SetActive(true);
        }

        if(Page_2[1].activeSelf == false)
        {
            album.Album_1[0].SetActive(true);
            album.Album_1[1].SetActive(false);
        }

        //������
        if(Page_6[0].activeSelf == true)
        {
            letter.First_Letter.SetActive(true);
        }

        if (Page_6[0].activeSelf == false)
        {
            letter.First_Letter.SetActive(false);
        }

        

        //�ֿ��ι� ���̳�
        if (Page_4[5].activeSelf == true)
        {
            ch.One_Ch_Inside_1[0].SetActive(false);//���� �ִ°�
            ch.One_Ch_Inside_1[1].SetActive(true);//���� �� ������ ��

            //ch.One_Ch_Inside_1[2].SetActive(true);//���� �ִ� ��
            //ch.One_Ch_Inside_1[3].SetActive(false);//���� �� ������ ��

            //ch.One_Ch_Inside_1[4].SetActive(true);//���� �ִ� ��
            //ch.One_Ch_Inside_1[5].SetActive(false);//���� �� ������ ��
        }

        if (Page_4[5].activeSelf == false)
        {
            ch.One_Ch_Inside_1[0].SetActive(true);//���� �ִ� ��
            ch.One_Ch_Inside_1[1].SetActive(false);//���� �� ������ ��

           // ch.One_Ch_Inside_1[2].SetActive(true);//���� �ִ� ��
           // ch.One_Ch_Inside_1[3].SetActive(false);//���� �� ������ ��

            //ch.One_Ch_Inside_1[4].SetActive(true);//���� �ִ� ��
            //ch.One_Ch_Inside_1[5].SetActive(false);//���� �� ������ ��
        }

        //�ֿ��ι� ���������� � ���̳׷� �̹��� ���� & �ι����� ���̳� �߰�
        if (Page_5[4].activeSelf == true)
        {
            ch.Aine_Change[1].SetActive(true);
            ch.Aine_Change[0].SetActive(false);

            bag.Ch_Inform_Select_1[0].SetActive(true);//����
           bag.Ch_Inform_Select_1[1].SetActive(false);//����

        }

        if (Page_5[4].activeSelf == false)
        {
            ch.Aine_Change[0].SetActive(true);
            ch.Aine_Change[1].SetActive(false);

            bag.Ch_Inform_Select_1[0].SetActive(false);//����
            bag.Ch_Inform_Select_1[1].SetActive(true);//����

        }

        //�ι����� ������Ʈ
        if (Page_6[0].activeSelf == true)
        {
            bag.Ch_1_Text[0].SetActive(false);
            bag.Ch_1_Text[1].SetActive(true);

            bag.Ch_1_Image[0].color = new Color(255, 255, 255 / 255);
        }

        if (Page_6[7].activeSelf == true)
        {
            bag.Ch_1_Text[2].SetActive(false);
            bag.Ch_1_Text[3].SetActive(true);

            bag.Ch_1_Image[1].color = new Color(255, 255, 255 / 255);

        }

        if (Page_7[0].activeSelf == true)
        {
            bag.Ch_1_Text[4].SetActive(false);
            bag.Ch_1_Text[5].SetActive(true);

            bag.Ch_1_Image[2].color = new Color(255, 255, 255 / 255);

        }

        if (Page_6[0].activeSelf == false)
        {
            bag.Ch_1_Text[0].SetActive(true);
            bag.Ch_1_Text[1].SetActive(false);

            bag.Ch_1_Image[0].color = new Color(0, 0, 0 / 255);
        }

        if (Page_6[7].activeSelf == false)
        {
            bag.Ch_1_Text[2].SetActive(true);
            bag.Ch_1_Text[3].SetActive(false);

            bag.Ch_1_Image[1].color = new Color(0, 0, 0 / 255);

        }

        if (Page_7[0].activeSelf == false)
        {
            bag.Ch_1_Text[4].SetActive(true);
            bag.Ch_1_Text[5].SetActive(false);

            bag.Ch_1_Image[2].color = new Color(0, 0, 0 / 255);

        }

        //�Ʒ��� 0724�� �߰�
        //����
        if (Page_Count_1 >= Page_1.Length && Page_2[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[0].activeSelf == true || Main_story[1].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[9].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ

            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[1].SetActive(true);
 
        }

        if (Page_Count_2 >= Page_2.Length && Page_3[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[1].activeSelf == true || Main_story[2].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[9].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[2].SetActive(true);
        }

        if (Page_Count_3 >= Page_3.Length && Page_4[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[2].activeSelf == true || Main_story[3].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[9].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
            Page_Button[3].SetActive(true);
        }

        if (Page_Count_4 >= Page_4.Length && Page_5[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[3].activeSelf == true || Main_story[4].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[9].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[4].SetActive(true);
        }

        //4, 5
        if (Page_Count_5 >= Page_5.Length && Page_6[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[4].activeSelf == true || Main_story[5].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[9].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[5].SetActive(true);
        }

        //5, 6
        if (Page_Count_6 >= Page_6.Length && Page_7[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[5].activeSelf == true || Main_story[6].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[9].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[6].SetActive(true);
        }

        //6, 7
        if (Page_Count_7 >= Page_7.Length && Page_8[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[6].activeSelf == true || Main_story[7].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[9].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[7].SetActive(true);
        }

        //7, 8
        if (Page_Count_8 >= Page_8.Length && Page_9[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[7].activeSelf == true || Main_story[8].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[9].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[8].SetActive(true);
        }

        //8, 9
        if (Page_Count_9 >= Page_9.Length && Page_10[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[8].activeSelf == true || Main_story[9].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[9].SetActive(true);
        }

        //8, 9
        /*if (Page_Count_9 >= Page_9.Length && Page_10[0].activeSelf == false &&//�ڿ� �ִ� ���ڰ� �տ�, �� ������ �� �ڿ� �ִ� ���� +1
            (Main_story[9].activeSelf == true)

            //�ڿ� �ִ� ���� ����
            && Main_story[0].activeSelf == false && Main_story[1].activeSelf == false && Main_story[2].activeSelf == false
             && Main_story[3].activeSelf == false && Main_story[4].activeSelf == false && Main_story[5].activeSelf == false
              && Main_story[6].activeSelf == false && Main_story[7].activeSelf == false && Main_story[8].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }

            Page_Button[9].SetActive(true);
        }*/


        //������� 0724 �߰�


        //��ư ������ �ϴ� ����
        if (Page_Count_1 < Page_1.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 1; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_2 < Page_2.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 2; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_3 < Page_3.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 3; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_4 < Page_4.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 4; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_5 < Page_5.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 5; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_6 < Page_6.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 6; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_7 < Page_7.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 7; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_8 < Page_8.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 8; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_9 < Page_9.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 9; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        if (Page_Count_10 < Page_10.Length)// <=
        {
            //������ ��ư �� ��Ȱ��
            for (int i = 10; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        


        Current_Story_Page = (int)Main_Story_1_Slider.value;
        Left_Page.text = Current_Story_Page.ToString();


        //���� �������� ����
        if (next)
        {

            if(Main_Story_1_Object[0].activeSelf==true)
            {
                Current_Story_Page++;

                if (Current_Story_Page > Main_story.Length)
                {
                    Current_Story_Page = Main_story.Length;
                }
                Main_Story_1_Slider.value = Current_Story_Page;
                Left_Page.text = Main_Story_1_Slider.value.ToString();
                Debug.Log("������ �� �� ����������" + Current_Story_Page);
            }

            if (Main_Story_1_Object[1].activeSelf == true)
            {
                Main_Story_1_1.Current_Story_Page++;

                if (Main_Story_1_1.Current_Story_Page > Main_Story_1_1.Main_story.Length)
                {
                    Main_Story_1_1.Current_Story_Page = Main_Story_1_1.Main_story.Length;
                }
                Main_Story_1_1.Main_Story_Slider.value = Main_Story_1_1.Current_Story_Page;
                Main_Story_1_1.Left_Page.text = Main_Story_1_1.Main_Story_Slider.value.ToString();
                Debug.Log("ù ��° ������ �� �� ����������" + Main_Story_1_1.Current_Story_Page);
            }

            if (Main_Story_1_Object[2].activeSelf == true)
            {
                Main_Story_1_2.Current_Story_Page++;

                if  (Main_Story_1_2.Current_Story_Page > Main_Story_1_2.Main_story.Length)
                {
                    Main_Story_1_2.Current_Story_Page = Main_Story_1_2.Main_story.Length;
                }
                Main_Story_1_2.Main_Story_Slider.value = Main_Story_1_2.Current_Story_Page;
                Main_Story_1_2.Left_Page.text = Main_Story_1_2.Main_Story_Slider.value.ToString();
                Debug.Log("�� ��° ������ �� �� ����������" + Main_Story_1_2.Current_Story_Page);

            }

            next = false;
        }

        if (back)
        {

            if (Main_Story_1_Object[0].activeSelf == true)
            {
                Current_Story_Page--;

                if (Current_Story_Page < 1)
                {
                    Current_Story_Page = 1;
                }
                Main_Story_1_Slider.value = Current_Story_Page;
                Left_Page.text = Main_Story_1_Slider.value.ToString();
                Debug.Log("������ �� �� ����������" + Current_Story_Page);
            }

            if (Main_Story_1_Object[1].activeSelf == true)
            {
                Main_Story_1_1.Current_Story_Page--;

                if (Main_Story_1_1.Current_Story_Page < 1)
                {
                    Main_Story_1_1.Current_Story_Page = 1;
                }
                Main_Story_1_1.Main_Story_Slider.value = Main_Story_1_1.Current_Story_Page;
                Main_Story_1_1.Left_Page.text = Main_Story_1_1.Main_Story_Slider.value.ToString();
                Debug.Log("ù ��° ������ �� �� ����������" + Main_Story_1_1.Current_Story_Page);
            }

            if (Main_Story_1_Object[2].activeSelf == true)
            {
                Main_Story_1_2.Current_Story_Page--;

                if (Main_Story_1_2.Current_Story_Page < 1)
                {
                    Main_Story_1_2.Current_Story_Page = 1;
                }
                Main_Story_1_2.Main_Story_Slider.value = Main_Story_1_2.Current_Story_Page;
                Main_Story_1_2.Left_Page.text = Main_Story_1_2.Main_Story_Slider.value.ToString();
                Debug.Log("�� ��° ������ �� �� ����������" + Main_Story_1_2.Current_Story_Page);

            }

            back = false;
        }

        //���� 1�������� �ƹ��͵� ������


        foreach (GameObject Story_Page in Main_story)
        {
            Story_Page.SetActive(false);
        }

        Main_story[Current_Story_Page - 1].SetActive(true);


        foreach (GameObject First_Main_Story_Object_1 in Main_Story_1_Object)
        {
            First_Main_Story_Object_1.SetActive(false);
        }

        Main_Story_1_Object[Main_Story_1_Object_Index].SetActive(true);

        Main_Story_1_SaveSettings();

        Currnet_Page_Count_1 = Page_Count_1;
        Currnet_Page_Count_2 = Page_Count_2;
        Currnet_Page_Count_3 = Page_Count_3;
        Currnet_Page_Count_4 = Page_Count_4;
        Currnet_Page_Count_5 = Page_Count_5;
        Currnet_Page_Count_6 = Page_Count_6;
        Currnet_Page_Count_7 = Page_Count_7;
        Currnet_Page_Count_8 = Page_Count_8;
        Currnet_Page_Count_9 = Page_Count_9;
        Currnet_Page_Count_10 = Page_Count_10;

        Currnet_Star_Count_5 = Star_Count_5;

    }

    private void FixedUpdate()
    {

        


        //5, 6, 7, 8, 9, 10, 11, 12, 13, 14�� �� ������
       /* if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length)
        && (Page_Count_6 > Page_6.Length) && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length)
        && (Page_Count_9 > Page_9.Length) && (Page_Count_10 > Page_10.Length))
        {//10������ ����
            for (int i = 0; i < Page_Button.Length; i++)
            {
                Page_Button[i].SetActive(false);
            } 
        }

        //5, 6, 7, 8, 9, 10, 11, 12, 13�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length)
        && (Page_Count_6 > Page_6.Length) && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length)
        && (Page_Count_9 > Page_9.Length))
        {//9���������� �� ������
            //9
            for (int i = 0; i < Page_Button.Length-1; i++)
            {
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10, 11, 12�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length)
        && (Page_Count_6 > Page_6.Length) && (Page_Count_7 > Page_7.Length) && (Page_Count_8 > Page_8.Length))
        {//5������ ����
            for (int i = 0; i < 8; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 9; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10, 11�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length)
        && (Page_Count_6 > Page_6.Length) && (Page_Count_7 > Page_7.Length))
        {//5������ ����
            for (int i = 0; i < 7; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 8; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9, 10�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length)
        && (Page_Count_6 > Page_6.Length))
        {//5������ ����
            for (int i = 0; i < 6; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 7; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8, 9�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length) && (Page_Count_5 > Page_5.Length))
        {//5������ ����
            for (int i = 0; i < 5; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 6; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7, 8�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length))
        {//5������ ����
            for (int i = 0; i < 4; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 5; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6, 7�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
        && (Page_Count_3 > Page_3.Length))
        {//5������ ����

            for (int i = 0; i < 3; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 4; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5, 6�� �� ������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length))
        {//5������ ����

            for (int i = 0; i < 2; i++)
            {
                Page_Button[i].SetActive(false);
            }

            for (int i = 3; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        //5�� �� ������
        else if ((Page_Count_1 > Page_1.Length))
        {//5������ ���� 

            for (int i = 0; i < 1; i++)
            {//0(1������)
                Page_Button[i].SetActive(false); //0
            }

            //5, 6, 7 // 0, 1, 2
            for (int i = 2; i < Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }
        }

        /*else
        {
            for (int i = 1; i < Page_Button.Length; i++)
            {//0(1������)
                Page_Button[i].SetActive(false); //0
            }

            Page_Button[0].SetActive(true);
        }*/

        if (Star_Count_5 == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Main_Story_1_Stars[i].SetActive(false);
            }

            Main_Story_1_Stars[Star_Count_5].SetActive(true);
            //  Debug.Log("�� �̰� �Ǵ�-���");
        }

        if (Star_Count_5 == 1)
        {


            for (int i = 0; i < 2; i++)
            {
                Main_Story_1_Stars[i].SetActive(false);
            }

            Main_Story_1_Stars[Star_Count_5].SetActive(true);
            // Debug.Log("�� �̰� �Ǵ�-���");
        }

        if (Page_Count_4 > 1)
        {
            Four_Page_Background[0].SetActive(false);
            Four_Page_Background[1].SetActive(true);
        }

        if(Page_Count_4 <= 1)
        {
            Four_Page_Background[0].SetActive(true);
            Four_Page_Background[1].SetActive(false);
        }


        if (Page_Count_5 > 6)
        {
            Five_Page_Background[0].SetActive(true);
            Five_Page_Background[1].SetActive(false);
        }

        if(Page_Count_5 <= 6)
        {
            Five_Page_Background[0].SetActive(false);
            Five_Page_Background[1].SetActive(true);
        }


    }

    public void Star_Load_Setting()
    {

        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        if (PlayerPrefs.HasKey("Main_Story_1_Star"))
        {
            string jsonData = PlayerPrefs.GetString("Main_Story_1_Star");
            GameData_Main_Story_1 data = JsonUtility.FromJson<GameData_Main_Story_1>(jsonData);

            Star_Count_5 = data.Star_Index;
            Main_Story_1_Stars[Star_Count_5].SetActive(true);

            // Debug.Log("��� ���� �����ִ�" + Star_Count_5);
        }

        else
        {
            Star_Count_5 = Star_B_Count;
            Main_Story_1_Stars[Star_Count_5].SetActive(true);
        }

    }


    private void Main_Story_1_SaveSettings()//�ϴ� ù ��° ���̵� ���丮�� �� ��°����(1, 1-1, 1-2��)
    {
        //������ʹ� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        GameData_Main_Story_1 data = new GameData_Main_Story_1();
        data.First_Side_Story = Main_Story_1_Object_Index;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("MainStory_1", jsonData);
        PlayerPrefs.Save();


        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        GameData_Main_Story_1 What_Page_First_Page_data = new GameData_Main_Story_1();
        What_Page_First_Page_data.First_Page_What_Page = (int)Main_Story_1_Slider.value;

        string What_Page_First_Page_jsonData = JsonUtility.ToJson(What_Page_First_Page_data);
        PlayerPrefs.SetString("MainStory_1_What_Page", What_Page_First_Page_jsonData);
        PlayerPrefs.Save();

        //������ʹ� ù ��° �̾߱��� �� ��° �ؽ�Ʈ�� ���Դ���

        //1�� ������
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        GameData_Main_Story_1 Page_1_Text_data = new GameData_Main_Story_1();
        Page_1_Text_data.Page_1_Index = Page_Count_1;

        string Page_1_Text_jsonData = JsonUtility.ToJson(Page_1_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_1_Text", Page_1_Text_jsonData);
        PlayerPrefs.Save();

        //2��
        GameData_Main_Story_1 Page_2_Text_data = new GameData_Main_Story_1();
        Page_2_Text_data.Page_2_Index = Page_Count_2;

        string Page_2_Text_jsonData = JsonUtility.ToJson(Page_2_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_2_Text", Page_2_Text_jsonData);
        PlayerPrefs.Save();

        //3��
        GameData_Main_Story_1 Page_3_Text_data = new GameData_Main_Story_1();
        Page_3_Text_data.Page_3_Index = Page_Count_3;

        string Page_3_Text_jsonData = JsonUtility.ToJson(Page_3_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_3_Text", Page_3_Text_jsonData);
        PlayerPrefs.Save();

        //4��
        GameData_Main_Story_1 Page_4_Text_data = new GameData_Main_Story_1();
        Page_4_Text_data.Page_4_Index = Page_Count_4;

        string Page_4_Text_jsonData = JsonUtility.ToJson(Page_4_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_4_Text", Page_4_Text_jsonData);
        PlayerPrefs.Save();

        //5��
        GameData_Main_Story_1 Page_5_Text_data = new GameData_Main_Story_1();
        Page_5_Text_data.Page_5_Index = Page_Count_5;

        string Page_5_Text_jsonData = JsonUtility.ToJson(Page_5_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_5_Text", Page_5_Text_jsonData);
        PlayerPrefs.Save();

        //6��
        GameData_Main_Story_1 Page_6_Text_data = new GameData_Main_Story_1();
        Page_6_Text_data.Page_6_Index = Page_Count_6;

        string Page_6_Text_jsonData = JsonUtility.ToJson(Page_6_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_6_Text", Page_6_Text_jsonData);
        PlayerPrefs.Save();

        //7��
        GameData_Main_Story_1 Page_7_Text_data = new GameData_Main_Story_1();
        Page_7_Text_data.Page_7_Index = Page_Count_7;

        string Page_7_Text_jsonData = JsonUtility.ToJson(Page_7_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_7_Text", Page_7_Text_jsonData);
        PlayerPrefs.Save();

        //8��
        GameData_Main_Story_1 Page_8_Text_data = new GameData_Main_Story_1();
        Page_8_Text_data.Page_8_Index = Page_Count_8;

        string Page_8_Text_jsonData = JsonUtility.ToJson(Page_8_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_8_Text", Page_8_Text_jsonData);
        PlayerPrefs.Save();

        //9��
        GameData_Main_Story_1 Page_9_Text_data = new GameData_Main_Story_1();
        Page_9_Text_data.Page_9_Index = Page_Count_9;

        string Page_9_Text_jsonData = JsonUtility.ToJson(Page_9_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_9_Text", Page_9_Text_jsonData);
        PlayerPrefs.Save();

        //10��
        GameData_Main_Story_1 Page_10_Text_data = new GameData_Main_Story_1();
        Page_10_Text_data.Page_10_Index = Page_Count_10;

        string Page_10_Text_jsonData = JsonUtility.ToJson(Page_10_Text_data);
        PlayerPrefs.SetString("Main_Story_1_Page_10_Text", Page_10_Text_jsonData);
        PlayerPrefs.Save();

        //��
        GameData_Main_Story_1 Star_data = new GameData_Main_Story_1();
        Star_data.Star_Index = Star_Count_5;

        string Star_jsonData = JsonUtility.ToJson(Star_data);
        PlayerPrefs.SetString("Main_Story_1_Star", Star_jsonData);
        PlayerPrefs.Save();

    }

    private void Page_1_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_1_Text"))
        {
            string Page_1_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_1_Text");
            GameData_Main_Story_1 Page_1_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_1_Text_jsonData);

            Page_Count_1 = Page_1_Text_data.Page_1_Index;


            if (Page_Count_1 > 0)
            {

                foreach (GameObject Page_1_Text in Page_1)
                {
                    Page_1_Text.SetActive(true);
                }


                for (int i = Page_Count_1; i < Page_1.Length; i++)
                {
                    Page_1[i].SetActive(false);//���⵵ ����

                    if (Page_Count_1 > Page_1.Length)
                    {
                        Page_Button[0].SetActive(false);
                    }

                    else
                    {
                        Page_Button[0].SetActive(true);
                    }
                }
                if (Page_Count_1 > Page_1.Length)
                {
                    Page_Button[0].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[0].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }

            }

            else
            { 
                foreach (GameObject Page_1_Text in Page_1)
                {
                    Page_1_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_1.Length; i++)
                {
                    Page_1[i].SetActive(false);
                }
            }

        }

        else
        {
            Page_Count_1 = Default_Page_Count_1;
        }

    }

    //2�� �ؽ�Ʈ
    private void Page_2_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_2_Text"))
        {
            string Page_2_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_2_Text");
            GameData_Main_Story_1 Page_2_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_2_Text_jsonData);

            Page_Count_2 = Page_2_Text_data.Page_2_Index;


            if (Page_Count_2 > 0)
            {
                foreach (GameObject Page_2_Text in Page_2)
                {
                    Page_2_Text.SetActive(true);
                }


                for (int i = Page_Count_2; i < Page_2.Length; i++)
                {
                    Page_2[i].SetActive(false);//���⵵ ����

                    if (Page_Count_2 > Page_2.Length)
                    {
                        Page_Button[1].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[1].SetActive(true);
                        //Page_Button[4].SetActive(false);
                    }
                }


                if (Page_Count_2 > Page_2.Length)
                {
                    Page_Button[1].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[1].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }

            }

            else
            {
                foreach (GameObject Page_2_Text in Page_2)
                {
                    Page_2_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_2.Length; i++)
                {
                    Page_2[i].SetActive(false);
                }
            }
            //  Debug.Log("2��° ����Ǵ�");
        }

        else
        {
            Page_Count_2 = Default_Page_Count_2;
        }

    }

    //3�� �׽�Ʈ
    private void Page_3_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_3_Text"))
        {
            string Page_3_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_3_Text");
            GameData_Main_Story_1 Page_3_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_3_Text_jsonData);

            Page_Count_3 = Page_3_Text_data.Page_3_Index;


            if (Page_Count_3 > 0)
            {
                foreach (GameObject Page_3_Text in Page_3)
                {
                    Page_3_Text.SetActive(true);
                }


                for (int i = Page_Count_3; i < Page_3.Length; i++)
                {
                    Page_3[i].SetActive(false);//���⵵ ����

                    if (Page_Count_3 > Page_3.Length)
                    {
                        Page_Button[2].SetActive(false);
                        // Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[2].SetActive(true);
                        //Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_3 > Page_3.Length)
                {
                    Page_Button[2].SetActive(false);
                    // Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[2].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }



            }

            else
            {
                foreach (GameObject Page_3_Text in Page_3)
                {
                    Page_3_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_3.Length; i++)
                {
                    Page_3[i].SetActive(false);
                }
            }
            //  Debug.Log("3��° ����Ǵ�");
        }

        else
        {
            Page_Count_3 = Default_Page_Count_3;
        }

    }

    //4��
    private void Page_4_Text_LoadSettings()
    {
        //4������ �� ��° �ؽ�Ʈ ���Դ���

        if (PlayerPrefs.HasKey("Main_Story_1_Page_4_Text"))
        {
            string Page_4_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_4_Text");
            GameData_Main_Story_1 Page_4_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_4_Text_jsonData);

            Page_Count_4 = Page_4_Text_data.Page_4_Index;


            if (Page_Count_4 > 0)
            {
                foreach (GameObject Page_4_Text in Page_4)
                {
                    Page_4_Text.SetActive(true);
                }


                for (int i = Page_Count_4; i < Page_4.Length; i++)
                {
                    Page_4[i].SetActive(false);//���⵵ ����

                    if (Page_Count_4 > Page_4.Length)
                    {
                        Page_Button[3].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[3].SetActive(true);
                        // Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_4 > Page_4.Length)
                {
                    Page_Button[3].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[3].SetActive(true);
                    // Page_Button[4].SetActive(false);
                }


            }

            else
            {
                foreach (GameObject Page_4_Text in Page_4)
                {
                    Page_4_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_4.Length; i++)
                {
                    Page_4[i].SetActive(false);
                }
            }
            //  Debug.Log("4��° ����Ǵ�");
        }

        else
        {
            Page_Count_4 = Default_Page_Count_4;
        }

    }

    //5
    private void Page_5_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_5_Text"))
        {
            string Page_5_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_5_Text");
            GameData_Main_Story_1 Page_5_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_5_Text_jsonData);

            Page_Count_5 = Page_5_Text_data.Page_5_Index;


            if (Page_Count_5 > 0)
            {

                foreach (GameObject Page_5_Text in Page_5)
                {
                    Page_5_Text.SetActive(true);
                }


                for (int i = Page_Count_5; i < Page_5.Length; i++)
                {
                    Page_5[i].SetActive(false);//���⵵ ����

                    if (Page_Count_5 > Page_5.Length)
                    {
                        Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[4].SetActive(true);
                    }
                }
                if (Page_Count_5 > Page_5.Length)
                {
                    Page_Button[4].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[4].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }

            }

            else
            {
                foreach (GameObject Page_5_Text in Page_5)
                {
                    Page_5_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_5.Length; i++)
                {
                    Page_5[i].SetActive(false);
                }
            }

        }

        else
        {
            Page_Count_5 = Default_Page_Count_5;
        }

    }

    //6�� �ؽ�Ʈ
    private void Page_6_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_6_Text"))
        {
            string Page_6_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_6_Text");
            GameData_Main_Story_1 Page_6_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_6_Text_jsonData);

            Page_Count_6 = Page_6_Text_data.Page_6_Index;


            if (Page_Count_6 > 0)
            {
                foreach (GameObject Page_6_Text in Page_6)
                {
                    Page_6_Text.SetActive(true);
                }


                for (int i = Page_Count_6; i < Page_6.Length; i++)
                {
                    Page_6[i].SetActive(false);//���⵵ ����

                    if (Page_Count_6 > Page_6.Length)
                    {
                        Page_Button[5].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[5].SetActive(true);
                        //Page_Button[4].SetActive(false);
                    }
                }


                if (Page_Count_6 > Page_6.Length)
                {
                    Page_Button[5].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[5].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }

            }

            else
            {
                foreach (GameObject Page_6_Text in Page_6)
                {
                    Page_6_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_6.Length; i++)
                {
                    Page_6[i].SetActive(false);
                }
            }
            //  Debug.Log("2��° ����Ǵ�");
        }

        else
        {
            Page_Count_6 = Default_Page_Count_6;
        }

    }

    //7�� �׽�Ʈ
    private void Page_7_Text_LoadSettings()
    {
        //1������ �� ��° �ؽ�Ʈ ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�

        if (PlayerPrefs.HasKey("Main_Story_1_Page_7_Text"))
        {
            string Page_7_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_7_Text");
            GameData_Main_Story_1 Page_7_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_7_Text_jsonData);

            Page_Count_7 = Page_7_Text_data.Page_7_Index;


            if (Page_Count_7 > 0)
            {
                foreach (GameObject Page_7_Text in Page_7)
                {
                    Page_7_Text.SetActive(true);
                }


                for (int i = Page_Count_7; i < Page_7.Length; i++)
                {
                    Page_7[i].SetActive(false);//���⵵ ����

                    if (Page_Count_7 > Page_7.Length)
                    {
                        Page_Button[6].SetActive(false);
                        // Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[6].SetActive(true);
                        //Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_7 > Page_7.Length)
                {
                    Page_Button[6].SetActive(false);
                    // Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[6].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }



            }

            else
            {
                foreach (GameObject Page_7_Text in Page_7)
                {
                    Page_7_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_7.Length; i++)
                {
                    Page_7[i].SetActive(false);
                }
            }
            //  Debug.Log("3��° ����Ǵ�");
        }

        else
        {
            Page_Count_7 = Default_Page_Count_7;
        }

    }

    //8��
    private void Page_8_Text_LoadSettings()
    {
        //4������ �� ��° �ؽ�Ʈ ���Դ���

        if (PlayerPrefs.HasKey("Main_Story_1_Page_8_Text"))
        {
            string Page_8_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_8_Text");
            GameData_Main_Story_1 Page_8_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_8_Text_jsonData);

            Page_Count_8 = Page_8_Text_data.Page_8_Index;


            if (Page_Count_8 > 0)
            {
                foreach (GameObject Page_8_Text in Page_8)
                {
                    Page_8_Text.SetActive(true);
                }


                for (int i = Page_Count_8; i < Page_8.Length; i++)
                {
                    Page_8[i].SetActive(false);//���⵵ ����

                    if (Page_Count_8 > Page_8.Length)
                    {
                        Page_Button[7].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[7].SetActive(true);
                        // Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_8 > Page_8.Length)
                {
                    Page_Button[7].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[7].SetActive(true);
                    // Page_Button[4].SetActive(false);
                }


            }

            else
            {
                foreach (GameObject Page_8_Text in Page_8)
                {
                    Page_8_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_8.Length; i++)
                {
                    Page_8[i].SetActive(false);
                }
            }
            //  Debug.Log("4��° ����Ǵ�");
        }

        else
        {
            Page_Count_8 = Default_Page_Count_8;
        }

    }

    //9
    private void Page_9_Text_LoadSettings()
    {
        //4������ �� ��° �ؽ�Ʈ ���Դ���

        if (PlayerPrefs.HasKey("Main_Story_1_Page_9_Text"))
        {
            string Page_9_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_9_Text");
            GameData_Main_Story_1 Page_9_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_9_Text_jsonData);

            Page_Count_9 = Page_9_Text_data.Page_9_Index;


            if (Page_Count_9 > 0)
            {
                foreach (GameObject Page_9_Text in Page_9)
                {
                    Page_9_Text.SetActive(true);
                }


                for (int i = Page_Count_9; i < Page_9.Length; i++)
                {
                    Page_9[i].SetActive(false);//���⵵ ����

                    if (Page_Count_9 > Page_9.Length)
                    {
                        Page_Button[8].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[8].SetActive(true);
                        // Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_9 > Page_9.Length)
                {
                    Page_Button[8].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[8].SetActive(true);
                    // Page_Button[4].SetActive(false);
                }


            }

            else
            {
                foreach (GameObject Page_9_Text in Page_9)
                {
                    Page_9_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_9.Length; i++)
                {
                    Page_9[i].SetActive(false);
                }
            }
            //  Debug.Log("4��° ����Ǵ�");
        }

        else
        {
            Page_Count_9 = Default_Page_Count_9;
        }

    }

    //10��°
    private void Page_10_Text_LoadSettings()
    {
        //5������ �� ��° �ؽ�Ʈ ���Դ���

        if (PlayerPrefs.HasKey("Main_Story_1_Page_10_Text"))
        {
            string Page_10_Text_jsonData = PlayerPrefs.GetString("Main_Story_1_Page_10_Text");
            GameData_Main_Story_1 Page_10_Text_data = JsonUtility.FromJson<GameData_Main_Story_1>(Page_10_Text_jsonData);

            Page_Count_10 = Page_10_Text_data.Page_10_Index;


            if (Page_Count_10 > 0)
            {
                foreach (GameObject Page_5_Text in Page_10)
                {
                    Page_5_Text.SetActive(true);
                }


                for (int i = Page_Count_10; i < Page_10.Length; i++)
                {
                    Page_10[i].SetActive(false);//���⵵ ����

                    if (Page_Count_10 > Page_10.Length)
                    {
                        Page_Button[9].SetActive(false);
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[9].SetActive(true);
                        //Page_Button[4].SetActive(false);
                    }

                }
                if (Page_Count_10 > Page_10.Length)
                {
                    Page_Button[9].SetActive(false);
                    //Page_Button[4].SetActive(false);
                }

                else
                {
                    Page_Button[9].SetActive(true);
                    //Page_Button[4].SetActive(false);
                }



            }

            else
            {
                foreach (GameObject Page_10_Text in Page_10)
                {
                    Page_10_Text.SetActive(false);
                }




                //Default_Page_Count_1 = 0;
                for (int i = 0; i < Page_10.Length; i++)
                {
                    Page_10[i].SetActive(false);
                }
            }
            //  Debug.Log("5��° ����Ǵ�");
        }

        else
        {
            Page_Count_10 = Default_Page_Count_10;
        }

    }

    private void Main_Story_1_LoadSettings()
    {
        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        if (PlayerPrefs.HasKey("MainStory_1"))
        {
            string jsonData = PlayerPrefs.GetString("MainStory_1");
            GameData_Main_Story_1 data = JsonUtility.FromJson<GameData_Main_Story_1>(jsonData);

            Main_Story_1_Object_Index = data.First_Side_Story;


        }

        else
        {
            Main_Story_1_Object_Index = Default_Main_Story_1_Object_Index;
        }


    }

    private void Main_Story_What_Page_LoadSettings()
    {
        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        if (PlayerPrefs.HasKey("MainStory_1_What_Page"))
        {
            string What_Page_First_Page_jsonData = PlayerPrefs.GetString("MainStory_1_What_Page");
            GameData_Main_Story_1 What_Page_First_Page_data = JsonUtility.FromJson<GameData_Main_Story_1>(What_Page_First_Page_jsonData);


            Main_Story_1_Slider.value = What_Page_First_Page_data.First_Page_What_Page;
            Current_Story_Page = (int)Main_Story_1_Slider.value;




        }

        else
        {
            Main_Story_1_Slider.value = Reset_Story_Page;

            Current_Story_Page = (int)Main_Story_1_Slider.value;

            Main_story[0].SetActive(true);

            for (int i = 1; i < Main_story.Length; i++)
            {
                Main_story[i].SetActive(false);
            }
        }
    }



    public void Main_Story_1_ResetSettings()
    {
        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        PlayerPrefs.DeleteKey("MainStory_1");
        PlayerPrefs.Save();

        Main_Story_1_Object_Index = Default_Main_Story_1_Object_Index;
        foreach (GameObject first_side_story in Main_Story_1_Object)
        {
            first_side_story.SetActive(false);
        }

        Main_Story_1_R_L.SetTrigger("Go_Right");
        //side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
        //side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
        Button_Main_1_Story_R_L.SetTrigger("Go_Right");

        Main_Story_1_Object[Main_Story_1_Object_Index].SetActive(true);

        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        PlayerPrefs.DeleteKey("MainStory_1_What_Page");
        PlayerPrefs.Save();

        Main_Story_1_Slider.value = Reset_Story_Page;
        Current_Story_Page = (int)Main_Story_1_Slider.value;
        foreach (GameObject first_side_story_Page in Main_story)
        {
            first_side_story_Page.SetActive(false);
        }

        Main_story[Current_Story_Page].SetActive(true);



        //1�� ������ �� ��° �ؽ�Ʈ���� ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�
        PlayerPrefs.DeleteKey("Main_Story_1_Page_1_Text");
        PlayerPrefs.Save();
        Page_Count_1 = Default_Page_Count_1;
        foreach (GameObject Page_1_Text in Page_1)
        {
            Page_1_Text.SetActive(false);
        }

        //2������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_2_Text");
        PlayerPrefs.Save();
        Page_Count_2 = Default_Page_Count_2;
        foreach (GameObject Page_2_Text in Page_2)
        {
            Page_2_Text.SetActive(false);
        }

        //3������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_3_Text");
        PlayerPrefs.Save();
        Page_Count_3 = Default_Page_Count_3;
        foreach (GameObject Page_3_Text in Page_3)
        {
            Page_3_Text.SetActive(false);
        }

        //4������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_4_Text");
        PlayerPrefs.Save();
        Page_Count_4 = Default_Page_Count_4;
        foreach (GameObject Page_4_Text in Page_4)
        {
            Page_4_Text.SetActive(false);
        }

        //5������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_5_Text");
        PlayerPrefs.Save();
        Page_Count_5 = Default_Page_Count_5;
        foreach (GameObject Page_5_Text in Page_5)
        {
            Page_5_Text.SetActive(false);
        }

        //6������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_6_Text");
        PlayerPrefs.Save();
        Page_Count_6 = Default_Page_Count_6;
        foreach (GameObject Page_6_Text in Page_6)
        {
            Page_6_Text.SetActive(false);
        }

        //7������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_7_Text");
        PlayerPrefs.Save();
        Page_Count_7 = Default_Page_Count_7;
        foreach (GameObject Page_7_Text in Page_7)
        {
            Page_7_Text.SetActive(false);
        }

        //8������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_8_Text");
        PlayerPrefs.Save();
        Page_Count_8 = Default_Page_Count_8;
        foreach (GameObject Page_8_Text in Page_8)
        {
            Page_8_Text.SetActive(false);
        }

        //9������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_9_Text");
        PlayerPrefs.Save();
        Page_Count_9 = Default_Page_Count_9;
        foreach (GameObject Page_9_Text in Page_9)
        {
            Page_9_Text.SetActive(false);
        }

        //10������
        PlayerPrefs.DeleteKey("Main_Story_1_Page_10_Text");
        PlayerPrefs.Save();
        Page_Count_10 = Default_Page_Count_10;
        foreach (GameObject Page_10_Text in Page_10)
        {
            Page_10_Text.SetActive(false);
        }

        //��
        PlayerPrefs.DeleteKey("Main_Story_1_Star");
        PlayerPrefs.Save();
        Star_Count_5 = Star_B_Count;
        foreach (GameObject Star in Main_Story_1_Stars)
        {
            Star.SetActive(false);
        }
        Main_Story_1_Stars[0].SetActive(true);

        /*GameData_Side_Story Star_data = new GameData_Side_Story();
        Page_5_Text_data.Star_Index = Star_Count_5;

        string Star_jsonData = JsonUtility.ToJson(Star_data);
        PlayerPrefs.SetString("Side_Story_1_Star", Star_jsonData);
        PlayerPrefs.Save();*/

        /* public int Star_B_Count = 0;
          public int Star_Count_5;
          public int Currnet_Star_Count_5;*/
        //Star_Index


        //��ư
        for (int i = 1; i < Page_Button.Length; i++)
        {
            Page_Button[i].SetActive(false);
        }

        Page_Button[0].SetActive(true);

    }

    public void Star_Go_White()
    {
        //Star_Count_5++;
        Star_Count_5 = 0;
        Main_Story_1_Stars[Star_Count_5].SetActive(true);
        Main_Story_1_Stars[1].SetActive(false);
    }

    public void Star_Go_Yellow()
    {
        Star_Count_5 = 1;
        Main_Story_1_Stars[0].SetActive(false);
        Main_Story_1_Stars[Star_Count_5].SetActive(true);
        //Debug.Log("��������� ��");
    }

    public void One_Page()
    {
        //���̴� 11

        if (Page_Count_1 <= Page_1.Length)
        {
            Page_1[0].SetActive(true);

            //Page_1[Page_Count_1].SetActive(true);
            //Debug.Log("ù ��° ������");




            if (Page_Count_1 == Page_1.Length)
            {
                Page_Count_1 = Page_1.Length + 1;
            }

            else if(Page_Count_1 == 0)
            {
                sfx.SFX_Tire();
            }

            else if (Page_Count_1 == 1)
            {
                Page_1[1].SetActive(true);
                
            }


            else
            {
                Page_1[Page_Count_1].SetActive(true);
                //  Debug.Log("�ǳ�?");
            }

            Page_Count_1++;
            Debug.Log(Page_Count_1);
            if (Page_Count_1 > Page_1.Length)
            {//11���� Ŀ����?

                Main_story[0].SetActive(false);
                Page_Button[0].SetActive(false);

                Main_story[1].SetActive(true);
                Page_Button[1].SetActive(true);
                //  Debug.Log("�ƾ�Page_Count_1 > Page_1.Length");

                Main_Story_1_Slider.value = 2;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_2 = 1;
                //Page_Count_2++;
                Page_2[0].SetActive(true);

            }


        }


    }

    public void Two_Page()
    {

        if (Page_Count_2 <= Page_2.Length)
        {

            if (Page_Count_2 == Page_2.Length)
            {
                Page_Count_2 = Page_2.Length + 1;
            }

            else if (Page_Count_2 == 1)
            {
                Page_2[1].SetActive(true);
            }


            else
            {
                Page_2[Page_Count_2].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_2++;
            Debug.Log(Page_Count_2);
            if (Page_Count_2 > Page_2.Length)
            {//11���� Ŀ����?

                Main_story[1].SetActive(false);
                Page_Button[1].SetActive(false);

                Main_story[2].SetActive(true);
                Page_Button[2].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 3;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_3 = 1;
                Page_3[0].SetActive(true);

                

            }


        }
    }

    public void Three_Page()
    {
        if (Page_Count_3 <= Page_3.Length)
        {

            if (Page_Count_3 == Page_3.Length)
            {
                Page_Count_3 = Page_3.Length + 1;
            }

            else if (Page_Count_3 == 4)
            {
                Page_3[4].SetActive(true);
                //�� �Ҹ�
                sfx.Explosion_Tire();
            }

            else if (Page_Count_3 == 6)
            {
                Page_3[6].SetActive(true);
                //������ �Ҹ�
                sfx.Break_Down_Tire();
            }

            else
            {
                Page_3[Page_Count_3].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_3++;
            Debug.Log(Page_Count_3);
            if (Page_Count_3 > Page_3.Length)
            {//11���� Ŀ����?

                Main_story[2].SetActive(false);
                Page_Button[2].SetActive(false);

                Main_story[3].SetActive(true);
                Page_Button[3].SetActive(true);
                //  Debug.Log("�ƾ�Page_Count_3 > Page_3.Length");

                Main_Story_1_Slider.value = 4;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_4 = 1;
                Page_4[0].SetActive(true);

            }


        }
    }

    //4
    public void Four_Page()
    {
        if (Page_Count_4 <= Page_4.Length)
        {

            if (Page_Count_4 == Page_4.Length)
            {
                Page_Count_4 = Page_4.Length + 1;
            }

            else if (Page_Count_4 == 3)
            {
                Page_4[3].SetActive(true);
                //�� �Ҹ�
                sfx.Bird_Sound();
            }

            else if (Page_Count_4 == 4)
            {
                Page_4[4].SetActive(true);
                //�� �Ҹ�
                sfx.Walk_Sound();
            }


            else
            {
                Page_4[Page_Count_4].SetActive(true);
                //Debug.Log("�ǳ�?");

       
            }

            Page_Count_4++;
            Debug.Log(Page_Count_4);
            if (Page_Count_4 > Page_4.Length)
            {//11���� Ŀ����?

                Main_story[3].SetActive(false);
                Page_Button[3].SetActive(false);

                Main_story[4].SetActive(true);
                Page_Button[4].SetActive(true);
                // Debug.Log("Page_Count_4 > Page_4.Length");

                Main_Story_1_Slider.value = 5;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_5 = 1;
                Page_5[0].SetActive(true);

            }


        }
    }

    //5
    public void Five_Page()
    {

        if (Page_Count_5 <= Page_5.Length)
        {

            if (Page_Count_5 == Page_5.Length)
            {
                Page_Count_5 = Page_5.Length + 1;
            }

            else if (Page_Count_5 == 1)
            {
                Page_5[1].SetActive(true);
            }

       

            else
            {
                Page_5[Page_Count_5].SetActive(true);
                // Debug.Log("�ǳ�?");

     
            }

            Page_Count_5++;
            Debug.Log(Page_Count_5);
            if (Page_Count_5 > Page_5.Length)
            {//11���� Ŀ����?

                Main_story[4].SetActive(false);
                Page_Button[4].SetActive(false);

                Main_story[5].SetActive(true);
                Page_Button[5].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 6;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_6 = 1;
                Page_6[0].SetActive(true);

            }


        }
    }

    //6
    public void Six_Page()
    {

        if (Page_Count_6 <= Page_6.Length)
        {

            if (Page_Count_6 == Page_6.Length)
            {
                Page_Count_6 = Page_6.Length + 1;
            }

            else if (Page_Count_6 == 1)
            {
                Page_6[1].SetActive(true);
            }


            else
            {
                Page_6[Page_Count_6].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_6++;
            Debug.Log(Page_Count_6);
            if (Page_Count_6 > Page_6.Length)
            {//11���� Ŀ����?

                Main_story[5].SetActive(false);
                Page_Button[5].SetActive(false);

                Main_story[6].SetActive(true);
                Page_Button[6].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 7;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_7 = 1;
                Page_7[0].SetActive(true);

            }


        }
    }

    //7
    public void Seven_Page()
    {

        if (Page_Count_7 <= Page_7.Length)
        {

            if (Page_Count_7 == Page_7.Length)
            {
                Page_Count_7 = Page_7.Length + 1;
            }

            else if (Page_Count_7 == 1)
            {
                Page_7[1].SetActive(true);
            }


            else
            {
                Page_7[Page_Count_7].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_7++;
            Debug.Log(Page_Count_7);
            if (Page_Count_7 > Page_7.Length)
            {//11���� Ŀ����?

                Main_story[6].SetActive(false);
                Page_Button[6].SetActive(false);

                Main_story[7].SetActive(true);
                Page_Button[7].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 8;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_8 = 1;
                Page_8[0].SetActive(true);

            }


        }
    }

    //8
    public void Eight_Page()
    {

        if (Page_Count_8 <= Page_8.Length)
        {

            if (Page_Count_8 == Page_8.Length)
            {
                Page_Count_8 = Page_8.Length + 1;
            }

            else if (Page_Count_8 == 1)
            {
                Page_8[1].SetActive(true);
            }


            else
            {
                Page_8[Page_Count_8].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_8++;
            Debug.Log(Page_Count_8);
            if (Page_Count_8 > Page_8.Length)
            {//11���� Ŀ����?

                Main_story[7].SetActive(false);
                Page_Button[7].SetActive(false);

                Main_story[8].SetActive(true);
                Page_Button[8].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 9;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_9 = 1;
                Page_9[0].SetActive(true);

            }


        }
    }

    //9
    public void Nine_Page()
    {

        if (Page_Count_9 <= Page_9.Length)
        {

            if (Page_Count_9 == Page_9.Length)
            {
                Page_Count_9 = Page_9.Length + 1;
            }

            else if (Page_Count_9 == 1)
            {
                Page_9[1].SetActive(true);
            }


            else
            {
                Page_9[Page_Count_9].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_9++;
            Debug.Log(Page_Count_9);
            if (Page_Count_9 > Page_9.Length)
            {//11���� Ŀ����?

                Main_story[8].SetActive(false);
                Page_Button[8].SetActive(false);

                Main_story[9].SetActive(true);
                Page_Button[9].SetActive(true);
                // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Main_Story_1_Slider.value = 10;

                Current_Story_Page = (int)Main_Story_1_Slider.value;
                Left_Page.text = Current_Story_Page.ToString();

                Page_Count_10 = 1;
                Page_10[0].SetActive(true);

            }


        }
    }

    //10
    public void Ten_Page()
    {


        if (Page_Count_10 <= Page_10.Length)
        {

            if (Page_Count_10 == Page_10.Length)
            {
                Page_Count_10 = Page_10.Length + 1;
            }

            else if (Page_Count_10 == 0)
            {
                Page_10[0].SetActive(true);
            }


            else
            {
                Page_10[Page_Count_10].SetActive(true);
                // Debug.Log("�ǳ�?");
            }

            Page_Count_10++;
            Debug.Log(Page_Count_10);
            if (Page_Count_10 > Page_10.Length)
            {//11���� Ŀ����?

                //Side_story[4].SetActive(false);
                //Page_Button[4].SetActive(false);
                Page_10[0].SetActive(true);
                // Debug.Log("Page_Count_5 > Page_5.Length");
                return;


            }


        }
    }


    public void Go_Select_Main_Story_1_1()
    {
        Main_Story_1_Object[0].SetActive(false);
        Main_Story_1_Object[1].SetActive(true);
        Main_Story_1_Object[2].SetActive(false);

        Main_Story_1_Object_Index = 1;
        Main_Story_1_1.Main_Story_1_R_L.enabled = false;
        Main_Story_1_Object_trans[1].anchoredPosition3D = Main_Story_1_Frame_Position;
        //Side_Story_1_SaveSettings();
        Main_Story_1_1.Page_Button[0].SetActive(true);


    }

    public void Go_Select_Main_Story_1_2()
    {
        Main_Story_1_Object[0].SetActive(false);
        Main_Story_1_Object[1].SetActive(false);
        Main_Story_1_Object[2].SetActive(true);

        Main_Story_1_Object_Index = 2;
        Main_Story_1_2.Main_Story_1_R_L.enabled = false;
        Main_Story_1_Object_trans[2].anchoredPosition3D = Main_Story_1_Frame_Position;
        //Side_Story_1_SaveSettings();
        Main_Story_1_2.Page_Button[0].SetActive(true); ;
    }


}

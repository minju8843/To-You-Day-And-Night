using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Side_Story
{//����� ���� �����͸� �����ϴ� Ŭ����
    public int First_Side_Story;//���� �� ��° ���丮�� Ȱ��ȭ�Ǿ� �ִ��� 1, 1-1, 1-2
    public int First_Page_What_Page;//ù ��° �̾߱��� �� ��° ���������� �����ߴ���

    public int Page_1_Index;
    public int Page_2_Index;
    public int Page_3_Index;
    public int Page_4_Index;
    public int Page_5_Index;

    public int Star_Index;

}


public class Side_Story : MonoBehaviour
{
    public Main_Story_S mss;


    //5��
    public int First_Side_Story_Object_Index;
    public int Default_First_Side_Story_Object_Index;

    public GameObject[] First_Side_Story_Object;

    public RectTransform[] First_Side_Story_Object_trans;
    private Vector3 Side_1_Frame_Position = new Vector3(0, 0, 0);
    //private Vector3 Default_Side_1_Frame_Position = new Vector3(1080, 0, 0);

    public Side_Story_1_1 side_1_1;
    public Side_Story_1_2 side_1_2;

    public GameObject[] Stars;


    public Slider Side_Story_Slider;
    public int Default_Story_Page = 1;//���� �� ����������
    public int Reset_Story_Page;//����Ʈ ������(������ ���� �ʾҴٸ� ����Ʈ ������)
    public int Current_Story_Page;//1, 1-1, 1-2 �߿��� ���� �������� ����
    
    
    public Text Left_Page;


    public GameObject[] Side_story;//���������� �־�� ��

    public GameObject[] Page_1;//ù ��° �������� ��Ÿ�� Ui�� ���� ��
    public GameObject[] Page_2;
    public GameObject[] Page_3;
    public GameObject[] Page_4;
    public GameObject[] Page_5;

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

    public int Star_B_Count = 0;
    public int Star_Count_5;
    public int Currnet_Star_Count_5;

    public Animator Side_Story_R_L;
    public Animator Button_Side_Story_R_L;


    public Book_Mark book_mark;

    public SFX_Manager sfx;

    //
    public bool next = false;
    public bool back = false;

    public void Go_Next_Button()
    {
        next = true;
        back = false;
    }

    public void Go_Back_Button()
    {
        back = true;
        next = false;
    }

    public void Go_Side_Story()
    {
        

        if (First_Side_Story_Object[0].activeSelf==true)
        {
            side_1_1.Side_Story_R_L.SetTrigger("Go_Left");
            side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Side_Story_R_L.SetTrigger("Go_Left");
            Button_Side_Story_R_L.SetTrigger("Go_Left");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;

        }

        else if(First_Side_Story_Object[1].activeSelf == true)
        {
           side_1_1.Side_Story_R_L.SetTrigger("Go_Left");
            side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Side_Story_R_L.SetTrigger("Go_Left");
            Button_Side_Story_R_L.SetTrigger("Go_Left");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;
        }

        else if (First_Side_Story_Object[2].activeSelf == true)
        {
            side_1_1.Side_Story_R_L.SetTrigger("Go_Left");
            side_1_2.Side_Story_R_L.SetTrigger("Go_Left");
            Side_Story_R_L.SetTrigger("Go_Left");
            Button_Side_Story_R_L.SetTrigger("Go_Left");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;
        }

        mss.Text_Count = 2;
        mss.text[0].SetActive(false);
        mss.text[1].SetActive(false);
        mss.text[2].SetActive(true);

    }

    public void Go_Main()
    {
        


        if (First_Side_Story_Object[0].activeSelf == true)
        {
            side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
            side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
            Side_Story_R_L.SetTrigger("Go_Right");
            Button_Side_Story_R_L.SetTrigger("Go_Right");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;



        }

        else if (First_Side_Story_Object[1].activeSelf == true)
        {
            side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
            side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
            Side_Story_R_L.SetTrigger("Go_Right");
            Button_Side_Story_R_L.SetTrigger("Go_Right");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;
        }

        else if (First_Side_Story_Object[2].activeSelf == true)
        {
            side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
            side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
            Side_Story_R_L.SetTrigger("Go_Right");
            Button_Side_Story_R_L.SetTrigger("Go_Right");

            side_1_2.Side_Story_R_L.enabled = true;

            side_1_1.Side_Story_R_L.enabled = true;
        }

    }

    private void Start()
    {
        side_1_2.Side_Story_R_L.enabled = true;

        for (int i = 0; i < First_Side_Story_Object.Length; i++)
        {
            First_Side_Story_Object[i].SetActive(false);
        }
    }

    public void OnEnable()
    {
        

        Side_Story_1_LoadSettings();//��ũ��Ʈ�� Ȱ��ȭ �Ǿ� ���� ��

        Side_Story_What_Page_LoadSettings();
        
        //�ؽ�Ʈ ����
        Page_1_Text_LoadSettings();//���⿡ ���� ����
        Page_2_Text_LoadSettings();
        Page_3_Text_LoadSettings();
        Page_4_Text_LoadSettings();
        Page_5_Text_LoadSettings();

        Star_Load_Setting();

    }

    public void Update()
    {
        //����
        if (Page_Count_1 >= Page_1.Length && Page_2[0].activeSelf == false && 
            (Side_story[1].activeSelf == true || Side_story[0].activeSelf == true)
            && Side_story[2].activeSelf == false && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
             && Side_story[0].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(true);
            Page_Button[2].SetActive(false);
            Page_Button[3].SetActive(false);
            Page_Button[4].SetActive(false);
        }

        if (Page_Count_2 >= Page_2.Length && Page_3[0].activeSelf == false && 
            (Side_story[1].activeSelf == true || Side_story[2].activeSelf == true)
            && Side_story[1].activeSelf == false && Side_story[3].activeSelf == false && Side_story[4].activeSelf == false
             && Side_story[0].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(false);
            Page_Button[2].SetActive(true);
            Page_Button[3].SetActive(false);
            Page_Button[4].SetActive(false);
        }

        if (Page_Count_3 >= Page_3.Length && Page_4[0].activeSelf == false &&
            (Side_story[2].activeSelf == true || Side_story[3].activeSelf == true)
            && Side_story[2].activeSelf == false && Side_story[1].activeSelf == false && Side_story[4].activeSelf == false
             && Side_story[0].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(false);
            Page_Button[2].SetActive(false);
            Page_Button[3].SetActive(true);
            Page_Button[4].SetActive(false);
        }

        if (Page_Count_4 >= Page_4.Length && Page_5[0].activeSelf == false &&
            (Side_story[3].activeSelf == true || Side_story[4].activeSelf == true)

            && Side_story[2].activeSelf == false && Side_story[3].activeSelf == false && Side_story[1].activeSelf == false
             && Side_story[0].activeSelf == false)
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(false);
            Page_Button[2].SetActive(false);
            Page_Button[3].SetActive(false);
            Page_Button[4].SetActive(true);
        }

        /*if (Page_Count_4 >= Page_4.Length && Page_5[0].activeSelf == false && Side_story[4].activeSelf == true
            && (Side_story[2].activeSelf == false && Side_story[3].activeSelf == false && Side_story[1].activeSelf == false
             && Side_story[0].activeSelf == false))
        {
            //�� ��° ���������� ��� �۾��� �� ���Դٸ�
            //�� ��° ��ư Ȱ��ȭ (�� ��° �������� �۾��� �ϳ��� ������ �ʾҴٸ�)
            //�� ��° ������ ��ư ��Ȱ��ȭ
            Page_Button[0].SetActive(false);
            Page_Button[1].SetActive(false);
            Page_Button[2].SetActive(false);
            Page_Button[3].SetActive(false);
            Page_Button[4].SetActive(true);

            Debug.Log("5������ ��ư Ȱ��ȭ");
        }*/
        //������� 0724 �߰�


        //��ư ������ �ϴ� ����
        if (Page_Count_1 < Page_1.Length) // <=
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

        //������� ��ư ������ ���� ���� �ڵ�


        Current_Story_Page = (int)Side_Story_Slider.value;
        Left_Page.text = Current_Story_Page.ToString();

        //���� �������� ����
        if (next)
        {

            if (First_Side_Story_Object[0].activeSelf==true)
            {
                Current_Story_Page++;

                if (Current_Story_Page > Side_story.Length)
                {
                    Current_Story_Page = Side_story.Length;
                }
                Side_Story_Slider.value = Current_Story_Page;
                Left_Page.text = Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 ������ �� �� ����������" + Current_Story_Page);
            }

            if (First_Side_Story_Object[1].activeSelf == true)
            {
                side_1_1.Current_Story_Page++;

                if (side_1_1.Current_Story_Page > side_1_1.Side_story.Length)
                {
                    side_1_1.Current_Story_Page = side_1_1.Side_story.Length;
                }
                side_1_1.Side_Story_Slider.value = side_1_1.Current_Story_Page;
                side_1_1.Left_Page.text = side_1_1.Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 ù ��° ������ �� �� ����������" + side_1_1.Current_Story_Page);
            }

            if (First_Side_Story_Object[2].activeSelf == true)
            {
                side_1_2.Current_Story_Page++;

                if (side_1_2.Current_Story_Page > side_1_2.Side_story.Length)
                {
                    side_1_2.Current_Story_Page = side_1_2.Side_story.Length;
                }
                side_1_2.Side_Story_Slider.value = side_1_2.Current_Story_Page;
                side_1_2.Left_Page.text = side_1_2.Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 �� ��° ������ �� �� ����������" + side_1_2.Current_Story_Page);

            }

            next = false;
        }

        if (back)
        {

            if (First_Side_Story_Object[0].activeSelf == true)
            {
                Current_Story_Page--;

                if (Current_Story_Page < 1)
                {
                    Current_Story_Page = 1;
                }
                Side_Story_Slider.value = Current_Story_Page;
                Left_Page.text = Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 ������ �� �� ����������" + Current_Story_Page);
            }

            if (First_Side_Story_Object[1].activeSelf == true)
            {
                side_1_1.Current_Story_Page--;

                if (side_1_1.Current_Story_Page < 1)
                {
                    side_1_1.Current_Story_Page = 1;
                }
                side_1_1.Side_Story_Slider.value = side_1_1.Current_Story_Page;
                side_1_1.Left_Page.text = side_1_1.Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 ù ��° ������ �� �� ����������" + side_1_1.Current_Story_Page);
            }

            if (First_Side_Story_Object[2].activeSelf == true)
            {
                side_1_2.Current_Story_Page--;

                if (side_1_2.Current_Story_Page < 1)
                {
                    side_1_2.Current_Story_Page = 1;
                }
                side_1_2.Side_Story_Slider.value = side_1_2.Current_Story_Page;
                side_1_2.Left_Page.text = side_1_2.Side_Story_Slider.value.ToString();
                Debug.Log("���̵� ���丮 �� ��° ������ �� �� ����������" + side_1_2.Current_Story_Page);

            }

            back = false;
        }

        //���� 1�������� �ƹ��͵� ������


        foreach (GameObject Story_Page in Side_story)
        {
            Story_Page.SetActive(false);
        }

        Side_story[Current_Story_Page-1].SetActive(true);

        


        foreach (GameObject First_Side_Story_Object_1 in First_Side_Story_Object)
        {
            First_Side_Story_Object_1.SetActive(false);
        }

        First_Side_Story_Object[First_Side_Story_Object_Index].SetActive(true);

        Side_Story_1_SaveSettings();

        Currnet_Page_Count_1 = Page_Count_1;
        Currnet_Page_Count_2 = Page_Count_2;
        Currnet_Page_Count_3 = Page_Count_3;
        Currnet_Page_Count_4 = Page_Count_4;
        Currnet_Page_Count_5 = Page_Count_5;

        Currnet_Star_Count_5 = Star_Count_5;


    }

    private void FixedUpdate()
    {

        //1, 2, 3, 4������
        /*if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
            && (Page_Count_3 > Page_3.Length) && (Page_Count_4 > Page_4.Length))
        {
            //5������
            for (int i = 0; i < Page_Button.Length-1; i++)
            {
                Page_Button[i].SetActive(false);
            }

        }

        //1, 2, 3������
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length)
            && (Page_Count_3 > Page_3.Length))
        {
            //4������
            for (int i = 0; i < Page_Button.Length - 2; i++)//3
            {//0, 1, 2
                Page_Button[i].SetActive(false);
            }

            for (int i = 4; i < Page_Button.Length; i++)
            {
                //4
                Page_Button[i].SetActive(false);
            }

        }

        //1, 2
        else if ((Page_Count_1 > Page_1.Length) && (Page_Count_2 > Page_2.Length))
        {
            //3������ �� ���
            for (int i = 0; i < Page_Button.Length - 3; i++)//2
            {//0(1������)
                Page_Button[i].SetActive(false);
            }

            for(int i=3; i< Page_Button.Length; i++)
            {
                //
                Page_Button[i].SetActive(false);
            }

        }

        //1
        else if (Page_Count_1 > Page_1.Length)
        {//2�������� ���
            for (int i = 0; i < 1; i++)
            {//0(1������)
                Page_Button[i].SetActive(false); //0
            }

            for(int i=2; i< Page_Button.Length; i++)
            {
                //2(3������)
                Page_Button[i].SetActive(false);
            }

        }*/

        if (Star_Count_5 == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                Stars[i].SetActive(false);
            }

            Stars[Star_Count_5].SetActive(true);
          //  Debug.Log("�� �̰� �Ǵ�-���");
        }

        if (Star_Count_5 == 1)
        {
            

            for(int i=0; i<2; i++)
            {
                Stars[i].SetActive(false);
            }

            Stars[Star_Count_5].SetActive(true);
           // Debug.Log("�� �̰� �Ǵ�-���");
        }


    }

    public void Star_Load_Setting()
    {

        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        if (PlayerPrefs.HasKey("Side_Story_1_Star"))
        {
            string jsonData = PlayerPrefs.GetString("Side_Story_1_Star");
            GameData_Side_Story data = JsonUtility.FromJson<GameData_Side_Story>(jsonData);

            Star_Count_5 = data.Star_Index;
            Stars[Star_Count_5].SetActive(true);

           // Debug.Log("��� ���� �����ִ�" + Star_Count_5);
        }

        else
        {
            Star_Count_5 = Star_B_Count;
            Stars[Star_Count_5].SetActive(true);
        }

    }


    private void Side_Story_1_SaveSettings()//�ϴ� ù ��° ���̵� ���丮�� �� ��°����(1, 1-1, 1-2��)
    {
        //������ʹ� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        GameData_Side_Story data = new GameData_Side_Story();
        data.First_Side_Story = First_Side_Story_Object_Index;

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("SideStory_1", jsonData);
        PlayerPrefs.Save();

  
        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        GameData_Side_Story What_Page_First_Page_data = new GameData_Side_Story();
        What_Page_First_Page_data.First_Page_What_Page = (int)Side_Story_Slider.value;

        string What_Page_First_Page_jsonData = JsonUtility.ToJson(What_Page_First_Page_data);
        PlayerPrefs.SetString("SideStory_1_What_Page", What_Page_First_Page_jsonData);
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

        GameData_Side_Story Page_1_Text_data = new GameData_Side_Story();
        Page_1_Text_data.Page_1_Index = Page_Count_1;

        string Page_1_Text_jsonData = JsonUtility.ToJson(Page_1_Text_data);
        PlayerPrefs.SetString("Page_1_Text", Page_1_Text_jsonData);
        PlayerPrefs.Save();

        //2��
        GameData_Side_Story Page_2_Text_data = new GameData_Side_Story();
        Page_2_Text_data.Page_2_Index = Page_Count_2;

        string Page_2_Text_jsonData = JsonUtility.ToJson(Page_2_Text_data);
        PlayerPrefs.SetString("Page_2_Text", Page_2_Text_jsonData);
        PlayerPrefs.Save();

        //3��
        GameData_Side_Story Page_3_Text_data = new GameData_Side_Story();
        Page_3_Text_data.Page_3_Index = Page_Count_3;

        string Page_3_Text_jsonData = JsonUtility.ToJson(Page_3_Text_data);
        PlayerPrefs.SetString("Page_3_Text", Page_3_Text_jsonData);
        PlayerPrefs.Save();

        //4��
        GameData_Side_Story Page_4_Text_data = new GameData_Side_Story();
        Page_4_Text_data.Page_4_Index = Page_Count_4;

        string Page_4_Text_jsonData = JsonUtility.ToJson(Page_4_Text_data);
        PlayerPrefs.SetString("Page_4_Text", Page_4_Text_jsonData);
        PlayerPrefs.Save();

        //5��
        GameData_Side_Story Page_5_Text_data = new GameData_Side_Story();
        Page_5_Text_data.Page_5_Index = Page_Count_5;

        string Page_5_Text_jsonData = JsonUtility.ToJson(Page_5_Text_data);
        PlayerPrefs.SetString("Page_5_Text", Page_5_Text_jsonData);
        PlayerPrefs.Save();

        //��
        GameData_Side_Story Star_data = new GameData_Side_Story();
        Star_data.Star_Index = Star_Count_5;

        string Star_jsonData = JsonUtility.ToJson(Star_data);
        PlayerPrefs.SetString("Side_Story_1_Star", Star_jsonData);
        PlayerPrefs.Save();
       // Debug.Log("�� ����ǳ�?");

        /* public int Star_B_Count = 0;
          public int Star_Count_5;
          public int Currnet_Star_Count_5;*/
        //Star_Index


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

        if (PlayerPrefs.HasKey("Page_1_Text"))
        {
            string Page_1_Text_jsonData = PlayerPrefs.GetString("Page_1_Text");
            GameData_Side_Story Page_1_Text_data = JsonUtility.FromJson<GameData_Side_Story>(Page_1_Text_jsonData);

            Page_Count_1 = Page_1_Text_data.Page_1_Index;


            if(Page_Count_1>0)
            {

                foreach (GameObject Page_1_Text in Page_1)
                {
                    Page_1_Text.SetActive(true);
                }

                //Page_1[0].SetActive(true);




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

        if (PlayerPrefs.HasKey("Page_2_Text"))
        {
            string Page_2_Text_jsonData = PlayerPrefs.GetString("Page_2_Text");
            GameData_Side_Story Page_2_Text_data = JsonUtility.FromJson<GameData_Side_Story>(Page_2_Text_jsonData);

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
                        //�� ��° ���������� ��� �۾��� �� ���Դٸ�
                        //�� ��° ������ ��ư ��Ȱ��ȭ
                        Page_Button[1].SetActive(false);
                    }

                    

                    else
                    {
                        Page_Button[1].SetActive(true);
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

        if (PlayerPrefs.HasKey("Page_3_Text"))
        {
            string Page_3_Text_jsonData = PlayerPrefs.GetString("Page_3_Text");
            GameData_Side_Story Page_3_Text_data = JsonUtility.FromJson<GameData_Side_Story>(Page_3_Text_jsonData);

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

        if (PlayerPrefs.HasKey("Page_4_Text"))
        {
            string Page_4_Text_jsonData = PlayerPrefs.GetString("Page_4_Text");
            GameData_Side_Story Page_4_Text_data = JsonUtility.FromJson<GameData_Side_Story>(Page_4_Text_jsonData);

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

    //5��°
    private void Page_5_Text_LoadSettings()
    {
        //5������ �� ��° �ؽ�Ʈ ���Դ���

        if (PlayerPrefs.HasKey("Page_5_Text"))
        {
            string Page_5_Text_jsonData = PlayerPrefs.GetString("Page_5_Text");
            GameData_Side_Story Page_5_Text_data = JsonUtility.FromJson<GameData_Side_Story>(Page_5_Text_jsonData);

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
                        //Page_Button[4].SetActive(false);
                    }

                    else
                    {
                        Page_Button[4].SetActive(true);
                        //Page_Button[4].SetActive(false);
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
          //  Debug.Log("5��° ����Ǵ�");
        }

        else
        {
            Page_Count_5 = Default_Page_Count_5;
        }

    }

    private void Side_Story_1_LoadSettings()
    {
        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        if (PlayerPrefs.HasKey("SideStory_1"))
        {
            string jsonData = PlayerPrefs.GetString("SideStory_1");
            GameData_Side_Story data = JsonUtility.FromJson<GameData_Side_Story>(jsonData);

            First_Side_Story_Object_Index = data.First_Side_Story;

            
        }

        else
        {
            First_Side_Story_Object_Index = Default_First_Side_Story_Object_Index;
        }

        
    }

    private void Side_Story_What_Page_LoadSettings()
    {
        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        if (PlayerPrefs.HasKey("SideStory_1_What_Page"))
        {
            string What_Page_First_Page_jsonData = PlayerPrefs.GetString("SideStory_1_What_Page");
            GameData_Side_Story What_Page_First_Page_data = JsonUtility.FromJson<GameData_Side_Story>(What_Page_First_Page_jsonData);

            
            Side_Story_Slider.value = What_Page_First_Page_data.First_Page_What_Page;
            Current_Story_Page = (int)Side_Story_Slider.value;




        }

        else
        {
            Side_Story_Slider.value = Reset_Story_Page;

            Current_Story_Page = (int)Side_Story_Slider.value;

            Side_story[0].SetActive(true);

            for (int i = 1; i < Side_story.Length; i++)
            {
                Side_story[i].SetActive(false);
            }
        }
    }

    

    public void Side_Story_1_ResetSettings()
    {
        //����� ���� 1, 1-1, 1-2 �߿��� ������ ������ �ڵ�
        PlayerPrefs.DeleteKey("SideStory_1");
        PlayerPrefs.Save();

        First_Side_Story_Object_Index = Default_First_Side_Story_Object_Index;
        foreach(GameObject first_side_story in First_Side_Story_Object)
        {
            first_side_story.SetActive(false);
        }

        Side_Story_R_L.SetTrigger("Go_Right");
        side_1_1.Side_Story_R_L.SetTrigger("Go_Right");
        side_1_2.Side_Story_R_L.SetTrigger("Go_Right");
        Button_Side_Story_R_L.SetTrigger("Go_Right");

        First_Side_Story_Object[First_Side_Story_Object_Index].SetActive(true);

        //������ʹ� ù ��° �̾߱��� �� ��° ���������� �����ߴ���
        PlayerPrefs.DeleteKey("SideStory_1_What_Page");
        PlayerPrefs.Save();

        Side_Story_Slider.value = Reset_Story_Page;
        Current_Story_Page = (int)Side_Story_Slider.value;
        foreach (GameObject first_side_story_Page in Side_story)
        {
            first_side_story_Page.SetActive(false);
        }

        Side_story[Current_Story_Page].SetActive(true);

        

        //1�� ������ �� ��° �ؽ�Ʈ���� ���Դ���
        //Page_1_Index -> �� ������ ���� �Ŷ�� �����ϱ�
        //public int Default_Page_Count_1 = 0;//���� �� ����������    
        // -> ����Ʈ ������ ���� �Ŷ�� �����ϱ�
        //public int Page_Count_1;//���µǾ� ����Ʈ �� ��
        // -> �����̴��� ���� �Ŷ�� �����ϱ�
        //public int Currnet_Page_Count_1;//���� �������� ����  
        // -> ���� �����̶�� �����ϱ�
        PlayerPrefs.DeleteKey("Page_1_Text");
        PlayerPrefs.Save();
        Page_Count_1 = Default_Page_Count_1;
        foreach (GameObject Page_1_Text in Page_1)
        {
            Page_1_Text.SetActive(false);
        }

        //2������
        PlayerPrefs.DeleteKey("Page_2_Text");
        PlayerPrefs.Save();
        Page_Count_2 = Default_Page_Count_2;
        foreach (GameObject Page_2_Text in Page_2)
        {
            Page_2_Text.SetActive(false);
        }

        //3������
        PlayerPrefs.DeleteKey("Page_3_Text");
        PlayerPrefs.Save();
        Page_Count_3 = Default_Page_Count_3;
        foreach (GameObject Page_3_Text in Page_3)
        {
            Page_3_Text.SetActive(false);
        }

        //4������
        PlayerPrefs.DeleteKey("Page_4_Text");
        PlayerPrefs.Save();
        Page_Count_4 = Default_Page_Count_4;
        foreach (GameObject Page_4_Text in Page_4)
        {
            Page_4_Text.SetActive(false);
        }

        //5������
        PlayerPrefs.DeleteKey("Page_5_Text");
        PlayerPrefs.Save();
        Page_Count_5 = Default_Page_Count_5;
        foreach (GameObject Page_5_Text in Page_5)
        {
            Page_5_Text.SetActive(false);
        }

        //��
        PlayerPrefs.DeleteKey("Side_Story_1_Star");
        PlayerPrefs.Save();
        Star_Count_5 = Star_B_Count;
        foreach (GameObject Star in Stars)
        {
            Star.SetActive(false);
        }
        Stars[0].SetActive(true);

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
        Star_Count_5 =0;
        Stars[Star_Count_5].SetActive(true);
        Stars[1].SetActive(false);
    }

    public void Star_Go_Yellow()
    {
        Star_Count_5 =1;
        Stars[0].SetActive(false);
        Stars[Star_Count_5].SetActive(true);
        //Debug.Log("��������� ��");
    }

    public void One_Page()
    {
        //���̴� 11

        if(Page_Count_1 <= Page_1.Length)
        {
            Page_1[0].SetActive(true);



            
            

            if(Page_Count_1 == Page_1.Length)
            {
                Page_Count_1 = Page_1.Length + 1;
            }

            else if(Page_Count_1 == 1)
            {
                Page_1[1].SetActive(true);
            }

            else if (Page_Count_1 == 9)
            {
                Page_1[9].SetActive(true);
                sfx.Bell_Sound();
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

                Side_story[0].SetActive(false);
                Page_Button[0].SetActive(false);

                Side_story[1].SetActive(true);
                Page_Button[1].SetActive(true);
              //  Debug.Log("�ƾ�Page_Count_1 > Page_1.Length");

                Side_Story_Slider.value = 2;

                Current_Story_Page = (int)Side_Story_Slider.value;
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

                Side_story[1].SetActive(false);
                Page_Button[1].SetActive(false);

                Side_story[2].SetActive(true);
                Page_Button[2].SetActive(true);
               // Debug.Log("�ƾ�Page_Count_2 > Page_2.Length");

                Side_Story_Slider.value = 3;

                Current_Story_Page = (int)Side_Story_Slider.value;
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

            else if (Page_Count_3 == 1)
            {
                Page_3[1].SetActive(true);
            }


            else if(Page_Count_3==2)
            {
                Page_3[2].SetActive(true);
                sfx.Wood_Walk_Sound();
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

                Side_story[2].SetActive(false);
                Page_Button[2].SetActive(false);

                Side_story[3].SetActive(true);
                Page_Button[3].SetActive(true);
              //  Debug.Log("�ƾ�Page_Count_3 > Page_3.Length");

                Side_Story_Slider.value = 4;

                Current_Story_Page = (int)Side_Story_Slider.value;
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

            else if (Page_Count_4 == 1)
            {
                Page_4[1].SetActive(true);
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

                Side_story[3].SetActive(false);
                Page_Button[3].SetActive(false);

                Side_story[4].SetActive(true);
                Page_Button[4].SetActive(true);
               // Debug.Log("Page_Count_4 > Page_4.Length");

                Side_Story_Slider.value = 5;

                Current_Story_Page = (int)Side_Story_Slider.value;
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

                //Side_story[4].SetActive(false);
                //Page_Button[4].SetActive(false);
                Page_5[1].SetActive(true);
               // Debug.Log("Page_Count_5 > Page_5.Length");
                return;
  

            }


        }
    }

    public void Go_Select_1_1()
    {
        First_Side_Story_Object[0].SetActive(false);
        First_Side_Story_Object[1].SetActive(true);
        First_Side_Story_Object[2].SetActive(false);

        First_Side_Story_Object_Index = 1;
        side_1_1.Side_Story_R_L.enabled = false;
        First_Side_Story_Object_trans[1].anchoredPosition3D = Side_1_Frame_Position;
        //Side_Story_1_SaveSettings();
        side_1_1.Page_Button[0].SetActive(true);


    }

    public void Go_Select_1_2()
    {
        First_Side_Story_Object[0].SetActive(false);
        First_Side_Story_Object[1].SetActive(false);
        First_Side_Story_Object[2].SetActive(true);

        First_Side_Story_Object_Index = 2;
        side_1_2.Side_Story_R_L.enabled = false;
        First_Side_Story_Object_trans[2].anchoredPosition3D = Side_1_Frame_Position;
        side_1_2.Page_Button[0].SetActive(true);
        //Debug.Log("�̰� ����Ǵ��� Ȯ��");
        //Debug.Log(First_Side_Story_Object_trans[2].anchoredPosition3D);

        //Side_Story_1_SaveSettings();
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

[System.Serializable]
public class GameData_User_Name_1
{//����� ���� �����͸� �����ϴ� Ŭ����
    public string Your_Name_1;//���� �̸���
                              //public int Show_Text;//������ �̸� �� ��°�� �ִ���

    public int Show_Name_Length;//�̸��� ��� ������Ʈ
}


public class Player_N_1_1 : MonoBehaviour
{
    public string Current_Name_1;
    public string Default_Name_1 = "";
    public string Name_1;

    public Side_Story_1_1 side_1_1;
    //public Side_Story_1_2 side_1_2;

    public GameObject[] side_1;//1-1, 1-2�� �� �ִ� ��

    public GameObject Input_Name;//�̸� �Է¹��� ��

    public GameObject[] Name_Length;//1���� ~ 4���ڱ����� ��ǳ��
    public int Name_length;
    public int Default_Name_length;

    public Text obj_text;
    public Text[] show_text_1;//1���� ~ 4���ڿ� ���� ������ �ؽ�Ʈ

    public GameObject[] Show_text;//1���� ~ 4���ڿ� ���� ������ �ؽ�Ʈ
    public int Default_Show_text;
    public int Show_Text;
    public int Currnet_Show_text;

    public InputField display;


    private void Start()
    {
        //obj_text.text = PlayerPrefs.GetString("user_name");

    }

    public void OnEnable()
    {
        Load_Your_Name();

        Load_Show_Text();
        //Load_Your_Name_Length();


    }

    private void Update()
    {
        if(side_1_1.Page_Count_6 == 5)
        {
            Input_Name.SetActive(true);
            side_1_1.Page_6[4].SetActive(true);
        }

        

        else if (side_1_1.Page_6[5].activeSelf == true || side_1_1.Page_Count_6 == 6)//�Է�â ������ Ȱ��ȭ
        {
            Debug.Log("Current_Name_1 �� ����: " + Current_Name_1.Length);

            if (Current_Name_1.Length == 4)
            {
                Show_text[0].SetActive(true);
                Name_Length[0].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                Input_Name.SetActive(false);
                side_1_1.Page_6[4].SetActive(false);
                //side_1_1.Six_Page();
            }

            else if (Current_Name_1.Length == 5)
            {
                Show_text[1].SetActive(true);
                Name_Length[1].SetActive(true);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                Input_Name.SetActive(false);
                side_1_1.Page_6[4].SetActive(false);
                //side_1_1.Six_Page();
            }

            else if (Current_Name_1.Length == 6)
            {
                Show_text[2].SetActive(true);
                Name_Length[2].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                Input_Name.SetActive(false);
                side_1_1.Page_6[4].SetActive(false);
                //side_1_1.Six_Page();
            }

            else if (Current_Name_1.Length == 7)
            {
                Show_text[3].SetActive(true);
                Name_Length[3].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                Input_Name.SetActive(false);
                side_1_1.Page_6[4].SetActive(false);
                //side_1_1.Six_Page();
            }


        }

        /*if (side_1_1.Page_6[5].activeSelf == true)//�Է�â ������ Ȱ��ȭ
        {
            if (Current_Name_1.Length == 4)
            {
                Show_text[0].SetActive(true);
                Name_Length[0].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                side_1_1.Page_6[4].SetActive(false);
            }

            else if (Current_Name_1.Length == 5)
            {
                Show_text[1].SetActive(true);
                Name_Length[1].SetActive(true);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                side_1_1.Page_6[4].SetActive(false);
            }

            else if (Current_Name_1.Length == 6)
            {
                Show_text[2].SetActive(true);
                Name_Length[2].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                Show_text[3].SetActive(false);
                Name_Length[3].SetActive(false);

                side_1_1.Page_6[4].SetActive(false);
            }

            else if (Current_Name_1.Length == 7)
            {
                Show_text[3].SetActive(true);
                Name_Length[3].SetActive(true);

                Show_text[1].SetActive(false);
                Name_Length[1].SetActive(false);

                Show_text[2].SetActive(false);
                Name_Length[2].SetActive(false);

                Show_text[0].SetActive(false);
                Name_Length[0].SetActive(false);

                side_1_1.Page_6[4].SetActive(false);
            }

          

        }*/


        foreach (Text Story_Page in show_text_1)
        {
            Current_Name_1 = Story_Page.text;
        }
        Name_1 = Current_Name_1;

        if (display.text.Length > 4)
        {
            display.text = display.text.Substring(0, 4);
        }

        Save_Your_Name();




        Currnet_Show_text = Show_Text;

    }





    public void Load_Show_Text()
    {
        if (PlayerPrefs.HasKey("Show_Text_2"))
        {
            string jsonData = PlayerPrefs.GetString("Show_Text_2");
            GameData_User_Name_1 data = JsonUtility.FromJson<GameData_User_Name_1>(jsonData);

            Show_Text = data.Show_Name_Length;


            //Show_text[Show_Text].SetActive(true);
            //Name_Length[Show_Text].SetActive(true);//��� ����
        }

        else
        {
            Show_Text = Default_Show_text;
            for (int i = 0; i < Show_text.Length; i++)
            {
                Show_text[i].SetActive(false);
            }

        }
    }

    public void Load_Your_Name()
    {
        if (PlayerPrefs.HasKey("user_name_1"))
        {
            string jsonData = PlayerPrefs.GetString("user_name_1");
            GameData_User_Name_1 data = JsonUtility.FromJson<GameData_User_Name_1>(jsonData);


            for (int i = 0; i < show_text_1.Length; i++)
            {
                show_text_1[i].text = data.Your_Name_1;
            }


        }

        else
        {


            Name_1 = Default_Name_1;

            show_text_1[0].text = Name_1;
            show_text_1[1].text = Name_1;
            show_text_1[2].text = Name_1;
            show_text_1[3].text = Name_1;


        }
    }

    public void Save_Your_Name()
    {
        GameData_User_Name_1 data = new GameData_User_Name_1();
        data.Your_Name_1 = Name_1;//���� �̸��� ����

        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("user_name_1", jsonData);
        PlayerPrefs.Save();

        //������ Ȱ��, ��Ȱ��
        GameData_User_Name_1 Page_6_Text_data = new GameData_User_Name_1();
        Page_6_Text_data.Show_Name_Length = Show_Text;

        string Page_6_Text_jsonData = JsonUtility.ToJson(Page_6_Text_data);
        PlayerPrefs.SetString("Show_Text_2", Page_6_Text_jsonData);
        PlayerPrefs.Save();

    }

    public void Side_Story_1_ResetSettings()
    {
        PlayerPrefs.DeleteKey("user_name_1");
        PlayerPrefs.Save();

        Name_1 = Default_Name_1;

        show_text_1[0].text = Name_1;
        show_text_1[1].text = Name_1;
        show_text_1[2].text = Name_1;
        show_text_1[3].text = Name_1;

        //�ؽ�Ʈ �����a
        PlayerPrefs.DeleteKey("Show_Text_2");
        PlayerPrefs.Save();
        Show_Text = Default_Show_text;
        foreach (GameObject Page_5_Text in Show_text)
        {
            Page_5_Text.SetActive(false);
        }


    }

    public void Create()
    {
        obj_text.text = display.text;
        //PlayerPrefs.SetString("Name1", obj_text.text);
        //PlayerPrefs.Save();

        //�Ʒ� for���� �� �Ȱ��� ��� �ּ�
        for (int i = 0; i < show_text_1.Length; i++)
        {
            show_text_1[i].text = display.text + "...";

        }





        //show_text[0].text = display.text+"...";

        /*if (side_1[0].activeSelf==true)
        {
            //�����ϱ� 01/15
            //side_1_1.Page_Count_6++;
            //side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Six_Page();//�� �Ǹ� �����
        }*/

        if (side_1[0].activeSelf == true)
        {
            //side_1_2.Page_Count_6++;
            //side_1_2.Page_Count_6 = 6;
            //side_1_2.Currnet_Page_Count_6 = side_1_2.Page_Count_6;
            //side_1_2.Page_6[6].SetActive(true);

            side_1_1.Page_Button[1].SetActive(true);
            //side_1_1.Six_Page();//�� �Ǹ� �����




        }



    }




    public void Input_My_Name()
    {
        //�̸��� �Է��ϰ� '�Է�'��ư�� ������ ���

        //���� �� ���ڷ� �Է����� �ʾ��� ���
        if (display.text.Length == 0)
        {
            return;
        }

        //1���� �Է����� ���
        else if (display.text.Length == 1)
        {
            Input_Name.SetActive(false);

            foreach (GameObject name_length in Name_Length)
            {
                name_length.SetActive(false);
            }


            Name_Length[display.text.Length - 1].SetActive(true);

            /*if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);
            }*/

            if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);


            }

            Current_Name_1 = Default_Name_1;
            show_text_1[0].text = Current_Name_1;

            side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Six_Page();//�� �Ǹ� �����

            //side_1_1.Page_Button[1].SetActive(true);
            //side_1_1.Six_Page();//�� �Ǹ� �����

            Show_text[0].SetActive(true);


        }

        else if (display.text.Length == 2)
        {
            Input_Name.SetActive(false);

            foreach (GameObject name_length in Name_Length)
            {
                name_length.SetActive(false);
            }


            Name_Length[display.text.Length - 1].SetActive(true);

            /*if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);
            }*/

            if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);


            }

            Current_Name_1 = Default_Name_1;
            //show_text_1[0].text = Current_Name_1;
            show_text_1[1].text = Current_Name_1;
            //show_text_1[2].text = Current_Name_1;
            //show_text_1[3].text = Current_Name_1;

            //side_1_2.Page_Count_6 = 6;
            //side_1_2.Currnet_Page_Count_6 = side_1_2.Page_Count_6;
            //side_1_2.Page_6[6].SetActive(true);
            side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Six_Page();//�� �Ǹ� �����

            //side_1_1.Page_Button[1].SetActive(true);
            //side_1_1.Six_Page();//�� �Ǹ� �����

            Show_text[1].SetActive(true);


        }

        //3���� �Է����� ���
        else if (display.text.Length == 3)
        {
            Input_Name.SetActive(false);
            foreach (GameObject name_length in Name_Length)
            {
                name_length.SetActive(false);
            }

            Name_Length[display.text.Length - 1].SetActive(true);

            /*if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);
            }*/


            if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);


            }
            Current_Name_1 = Default_Name_1;
            show_text_1[0].text = Current_Name_1;
            show_text_1[1].text = Current_Name_1;
            show_text_1[2].text = Current_Name_1;
            show_text_1[3].text = Current_Name_1;

            side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Six_Page();//�� �Ǹ� �����

            //side_1_1.Page_Button[1].SetActive(true);
            //side_1_1.Six_Page();//�� �Ǹ� �����

            Show_text[2].SetActive(true);


        }

        //4���� �Է����� ���
        else if (display.text.Length == 4)
        {
            Input_Name.SetActive(false);
            foreach (GameObject name_length in Name_Length)
            {
                name_length.SetActive(false);
            }

            Name_Length[display.text.Length - 1].SetActive(true);

            /*if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);
            }*/


            if (side_1[0].activeSelf == true)
            {
                side_1_1.Page_6[4].SetActive(false);
                side_1_1.Page_6[5].SetActive(true);


            }
            Current_Name_1 = Default_Name_1;
            show_text_1[0].text = Current_Name_1;
            show_text_1[1].text = Current_Name_1;
            show_text_1[2].text = Current_Name_1;
            show_text_1[3].text = Current_Name_1;

            side_1_1.Page_Button[1].SetActive(true);
            side_1_1.Six_Page();//�� �Ǹ� �����

            //side_1_1.Page_Button[1].SetActive(true);
            //side_1_1.Six_Page();//�� �Ǹ� �����

            Show_text[3].SetActive(true);


        }

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//������ ���� ���� �߰���
public class Text_Data
{
    public int Text_Index;
}

public class Main_Story_S : MonoBehaviour
{
    public B_Button b_btn;

    public GameObject[] text;
    public int Default_Text_Count = 0;
    public int Text_Count;
    public int Current_Text_Count;


    public GameObject Aine_X_Button;//é�� 1����
    public GameObject Aine_Touch_Start;
    public Animator Aine_Size_Up_Down;
    public Animator Main_Story_Go;

    public GameObject Aine_Fade_Obj;
    public Fade fade;

    public Main_Stroy_1 main_story1;
    public M_S_1_1 m_s_1_1;
    public M_S_1_2 m_s_1_2;

    public Main_Stroy_2 main_story2;
    public Side_Story side_story2;

    //public Recent_Key save_key;


    //���̳� �ִ� å ��ư ������ ������Ʈ Ȱ��ȭ�ϰ� ���� Ŀ���� �ִϸ��̼� ����

    //�ִϸ��̼� ���� ��, X�ϰ� ���� ��ư ������ �� Ȱ��ȭ�ϱ�

    //���̳� ������ é�� 1�� 20ȭ���� �� ������ �� ���̰�
    //é���� ȭ�� ������ �ش� ȭ���� �ٷ� ������(���̵� ����)
    //�ش� ȭ���� �ڷΰ��� ������ é�� 1 ȭ�� �������� ���ư�����

    //é��1 ȭ�� ���ý�, �����̳� ��ġ�� �ʱ�ȭ
    //��: -6.103516e-05  ��: 0.0002441406
    //������: 6.103516e-05 �Ʒ�: -2671.605

    //é�� 1 ȭ�� ���� �� �����ֱ�
    //public GameObject Ch_1;
    public RectTransform Container;

    //���� �������Դϴ� ȭ��
    public GameObject[] Not_Open;

    //é�� �����ϴ� ������ ���ư�
    public Animator Select_Main_Story_Ch;

    private void Start()
    {
        //Ch_1.SetActive(false);
        Not_Open[0].SetActive(false);
        Not_Open[1].SetActive(false);
    }


    public void OnEnable()
    {
        Load_Text();
    }

    public void Update()
    {
        Save_Text();
    }

    public void Save_Text()
    {
        Text_Data text_data = new Text_Data();
        text_data.Text_Index = Text_Count;

        string text_jsonData = JsonUtility.ToJson(text_data);
        PlayerPrefs.SetString("Text_Data", text_jsonData);
        PlayerPrefs.Save();
    }

    public void Load_Text()
    {
        if (PlayerPrefs.HasKey("Text_Data"))
        {
            string Text_Index_jsonData = PlayerPrefs.GetString("Text_Data");
            Text_Data Text_Index_data = JsonUtility.FromJson<Text_Data>(Text_Index_jsonData);

            Text_Count = Text_Index_data.Text_Index;

            if(Text_Count==0)
            {
                text[0].SetActive(true);
                text[1].SetActive(false);
                text[2].SetActive(false);
            }

            else if(Text_Count == 1)
            {
                text[0].SetActive(false);
                text[1].SetActive(true);
                text[2].SetActive(false);
            }

            else
            {
                text[0].SetActive(false);
                text[1].SetActive(false);
                text[2].SetActive(true);
            }

        }

        else
        {
            Text_Count = Default_Text_Count;
            text[0].SetActive(true);
            text[1].SetActive(false);
            text[2].SetActive(false);
            Debug.Log("����1");
        }
    }

    public void Reset_Text()
    {
        PlayerPrefs.DeleteKey("Text_Data");
        PlayerPrefs.Save();
        Text_Count = Default_Text_Count;

        text[0].SetActive(true);
        text[1].SetActive(false);
        text[2].SetActive(false);
    }

        public void Select_Ch()
    {
        //é�� �����ϴ� ������ ���ư�
        Select_Main_Story_Ch.SetTrigger("Go_Right");//
    }

    public void Go_Main_Story_1()
    {
        Main_Story_Go.SetTrigger("Go_Left");

        b_btn.Hide_Bty();//0723�߰�
    }

    public void Go_Main()
    {
        Main_Story_Go.SetTrigger("Go_Right");
    }

    public void Main_Aine_Story_X()
    {//X������ �޿��� å �ִ� �׸� �ٽ� �پ��� �ϱ�
        Aine_Size_Up_Down.SetTrigger("Size_Down");
    }

    public void Aine_Go_Size_Up()
    {
        Aine_Size_Up_Down.SetTrigger("Size_Up");
    }

    public void Aine_Go_Back_Select_Side_Story()
    {
        main_story1.Go_Main();
    }

    public void Main_Story_1_Fade_In()
    {
        fade.Fade_BE.SetActive(true);
        fade.Fade_In_Out.SetTrigger("Go_Black");

        StartCoroutine(Show_Main());
        IEnumerator Show_Main()
        {
            yield return new WaitForSeconds(1.0f);
            Aine_Size_Up_Down.SetTrigger("Size_Down");

            //Ch_1.SetActive(true);//���ν��丮 ȭ�� ��Ÿ��
            Select_Main_Story_Ch.SetTrigger("Go_Left");

            //��: -6.103516e-05  ��: 0.0002441406
            //������: 6.103516e-05 �Ʒ�: -2671.605
            Container.offsetMin = new Vector2(-6.103516e-05f, -2671.605f);//left, bottom
            Container.offsetMax = new Vector2(-6.103516e-05f, -0.0002441406f);//-right, -top
        }

        StartCoroutine(Go_Main_Black_Empty());

        IEnumerator Go_Main_Black_Empty()
        {
            yield return new WaitForSeconds(1.5f);
            fade.Fade_In_Out.SetTrigger("Go_Empty");
        }

        StartCoroutine(Bye_Fade());
        IEnumerator Bye_Fade()
        {
            yield return new WaitForSeconds(3.5f);
            fade.Fade_BE.SetActive(false);

        }
    }

    //���� ���丮 1ȭ
    public void Go_Ch_1_1_Story()
    {
        b_btn.Hide_Bty();//0723�߰�;

        if (text[0].activeSelf==true)
        {
            main_story1.Go_Main_Story_1();//���ν��丮 ��Ÿ���� ��
            Debug.Log("1ȭ ���Ͷ�");
        }
        

        else if (text[1].activeSelf == true)
        {
            main_story2.Go_Main_Story_2();//���ν��丮 ��Ÿ���� ��
            Debug.Log("2ȭ ���Ͷ�");
        }

        else if (text[2].activeSelf == true)
        {
            side_story2.Go_Side_Story();//���̵� ���丮 ��Ÿ���� ��
        }
        Debug.Log("�ϼҿ� ���Ͷ�");
    }

    //���ν��丮 2ȭ
    /*public void Go_Ch_2_1_Story()
    {
        if (save_key.Save_Story[1].activeSelf == true)
        {
            main_story2.Go_Main_Story_2();//���ν��丮 ��Ÿ���� ��
        }
        Debug.Log("2ȭ ���Ͷ�");
    }

    //���̵� ���丮  - �ϼҿ�
    public void Go_Side_Story()
    {
        if (save_key.Save_Story[2].activeSelf == true)
        {
            side_story2.Go_Side_Story();//���̵� ���丮 ��Ÿ���� ��
        }
        Debug.Log("�ϼҿ� ���Ͷ�");
    }*/

    public void Go_Ch_1_2()//2ȭ�� ���� ��ư ������ ��
    {
        if(m_s_1_1.Page_Count_29 >= m_s_1_1.Page_29.Length || m_s_1_2.Page_Count_29 >= m_s_1_1.Page_29.Length)
        {
            //���� ���� 1ȭ�� �� �� ���¶��
            //����ȭ�� �������ּ��� ������ �ʵ���
            Not_Open[1].SetActive(false);
            main_story2.Go_Main_Story_2();
        }

        else
        {
            //���� ���� 1ȭ�� �� ���� ���� ���¶��
            //����ȭ�� �������ּ��� ���̵���
            Not_Open[1].SetActive(true);
        }
    }

    public void Closed_Ch_1_2()//����ȭ�� �������ּ��� ���߱�
    {
        Not_Open[1].SetActive(false);
    }


    public void Go_Ch_Else_Story()
    {
        //���� �������Դϴ�! ���� ������Ʈ ������
        Not_Open[0].SetActive(true);
    }

    public void Go_Ch_Else_Story_Ok()
    {
        //���� �������Դϴ�! ���� ������Ʈ Ȯ�� ��ư ������ �� ���ֱ�
        Not_Open[0].SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bag : MonoBehaviour
{
    public B_Button b_btn;

    //ĳ���� ���� ����
    public GameObject[] Ch_Inform_Select_1;//���̳�
    public GameObject[] Ch_Inform_Select_2;//��
    public GameObject[] Ch_Inform_Select_3;//�Ϸ��̽�
    public GameObject[] Ch_Inform_Select_4;//��ü�����
    public GameObject[] Ch_Inform_Select_5;//��ž��
    public GameObject[] Ch_Inform_Select_6;//������


    public GameObject[] Collection;
    public GameObject bag;

    public Animator bag_anim;
    
    public Animator[] Inside_anim;
    public GameObject[] Collection_Inside;

    public RectTransform[] bag_slider;
    public RectTransform[] inside_Slider;//�����̳�

    public Image[] Ch_1_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    //Ch_1�� 0 ~ 5���� ����
    public GameObject[] Ch_1_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������
    //Ch_1�� 0 ~ 11���� ����

    public Image[] Ch_2_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    public GameObject[] Ch_2_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������

    public Image[] Ch_3_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    public GameObject[] Ch_3_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������

    public Image[] Ch_4_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    public GameObject[] Ch_4_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������

    public Image[] Ch_5_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    public GameObject[] Ch_5_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������

    public Image[] Ch_6_Image;//�ι� ���� ���� ȸ�� �̹��� ���� �ٲ� ��
    public GameObject[] Ch_6_Text;//�ι� ���� ���� �۾� �����ϰ� �� ������

    //������ʹ� ���� ������ ���� �̾߱�
    //public RectTransform bag_Obj_slider;

    public GameObject[] Obj_Inform_Select_1;//���� //����, ����
    public GameObject[] Obj_Inform_Select_2;//�尩 //����, ����

    public GameObject[] Show_Inside_Object;//���� ���빰()

    public Animator[] Obj_Inside_Black_anim;//�ȿ� ���� ��
    public Animator[] Obj_Inform_Text_anim;//�ȿ� �ؽ�Ʈ


    public void Start()
    {
        //���� �尩 �ݱ�
        Obj_Inform_Select_2[0].SetActive(false);//����
        Obj_Inform_Select_2[1].SetActive(true);//����


        // <������ �����°� - �̰Ŵ� ���� �����ϴ� �� �ϸ� ��ġ ����� ����>

        //��
        Ch_Inform_Select_2[0].SetActive(false);//����
        Ch_Inform_Select_2[1].SetActive(true);//����
        //�Ϸ��̽�
        Ch_Inform_Select_3[0].SetActive(false);//����
        Ch_Inform_Select_3[1].SetActive(true);//����
        //��ü�����
        Ch_Inform_Select_4[0].SetActive(false);//����
        Ch_Inform_Select_4[1].SetActive(true);//����
        //��ž��
        Ch_Inform_Select_5[0].SetActive(false);//����
        Ch_Inform_Select_5[1].SetActive(true);//����
        //������
        Ch_Inform_Select_6[0].SetActive(false);//����
        Ch_Inform_Select_6[1].SetActive(true);//����



        //bag.SetActive(false);
        Collection[1].SetActive(false);//�ι��� 1
        Collection[0].SetActive(true);   //������0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);

        //���̳�
        for(int i=0; i< Ch_1_Image.Length; i++)
        {
            Ch_1_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for(int i=0; i< Ch_1_Text.Length/2; i++)
        {
            Ch_1_Text[i*2].SetActive(true);
        }

        for (int i = 0; i < Ch_1_Text.Length/2; i++)
        {
            Ch_1_Text[i * 2 + 1].SetActive(false);
        }

        //��
        for (int i = 0; i < Ch_2_Image.Length; i++)
        {
            Ch_2_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_2_Text.Length / 2; i++)
        {
            Ch_2_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_2_Text.Length / 2; i++)
        {
            Ch_2_Text[i * 2 + 1].SetActive(false);
        }

        //�Ϸ��̽�
        for (int i = 0; i < Ch_3_Image.Length; i++)
        {
            Ch_3_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_3_Text.Length / 2; i++)
        {
            Ch_3_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_3_Text.Length / 2; i++)
        {
            Ch_3_Text[i * 2 + 1].SetActive(false);
        }

        //��ü�����
        for (int i = 0; i < Ch_4_Image.Length; i++)
        {
            Ch_4_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_4_Text.Length / 2; i++)
        {
            Ch_4_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_4_Text.Length / 2; i++)
        {
            Ch_4_Text[i * 2 + 1].SetActive(false);
        }

        //��
        for (int i = 0; i < Ch_5_Image.Length; i++)
        {
            Ch_5_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_5_Text.Length / 2; i++)
        {
            Ch_5_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_5_Text.Length / 2; i++)
        {
            Ch_5_Text[i * 2 + 1].SetActive(false);
        }

        //������
        for (int i = 0; i < Ch_6_Image.Length; i++)
        {
            Ch_6_Image[i].color = new Color(0, 0, 0 / 255);
        }

        for (int i = 0; i < Ch_6_Text.Length / 2; i++)
        {
            Ch_6_Text[i * 2].SetActive(true);
        }

        for (int i = 0; i < Ch_6_Text.Length / 2; i++)
        {
            Ch_6_Text[i * 2 + 1].SetActive(false);
        }

        //���� ���� Ŭ������ ��, ���� ���� â�� �۾� ����ִ°� ��Ȱ��
        Show_Inside_Object[0].SetActive(false);
        Show_Inside_Object[1].SetActive(false);

    }


    public void Go_Glass_Bead()
    {
        //��������
        StartCoroutine(Glass_Bead());
        IEnumerator Glass_Bead()
        {
            Show_Inside_Object[0].SetActive(true);
            Obj_Inside_Black_anim[0].SetTrigger("On");
            Obj_Inform_Text_anim[0].SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);

            Debug.Log("�̰� �Ǵ��� Ȯ��2");
        }

    }

    public void Go_Back_Glass_Bead()
    {
        //������������ �ٽ� ��������
        StartCoroutine(Back_Glass_Bead());
        IEnumerator Back_Glass_Bead()
        {
            Obj_Inside_Black_anim[0].SetTrigger("Off");
            Obj_Inform_Text_anim[0].SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Show_Inside_Object[0].SetActive(false);
            Debug.Log("�̰� �Ǵ��� Ȯ��");
        }
    }

    public void Go_Black_Gloves()
    {
        //�尩
        StartCoroutine(Black_Gloves());
        IEnumerator Black_Gloves()
        {
            Show_Inside_Object[1].SetActive(true);
            Obj_Inside_Black_anim[1].SetTrigger("On");
            Obj_Inform_Text_anim[1].SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);

            Debug.Log("�̰� �Ǵ��� Ȯ��2");
        }
    }

    public void Go_Back_Black_Gloves()
    {
        //�尩���� �ٽ� ��������
        StartCoroutine(Back_Black_Gloves());
        IEnumerator Back_Black_Gloves()
        {
            Obj_Inside_Black_anim[1].SetTrigger("Off");
            Obj_Inform_Text_anim[1].SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Show_Inside_Object[1].SetActive(false);
            Debug.Log("�̰� �Ǵ��� Ȯ��");
        }
    }



    public void Go_Bag()
    {
        b_btn.Hide_Bty();//0723�߰�

        bag.SetActive(true);
        bag_anim.SetTrigger("Go_Left");

        bag_slider[0].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

        bag_slider[1].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[1].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

        Collection[1].SetActive(false);//�ι��� 1
        Collection[0].SetActive(true);   //������0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);
    }

        //���̳�
        public void Go_1_Inside()
    {
        Inside_anim[0].SetTrigger("Go_Left");

        inside_Slider[0].offsetMin = new Vector2(0, -767.9815f);//left, bottom
        inside_Slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

    }

    public void Go_Back_1()
    {
        Inside_anim[0].SetTrigger("Go_Right");
    }

    //��
    public void Go_2_Inside()
    {
        Inside_anim[1].SetTrigger("Go_Left");

        inside_Slider[1].offsetMin = new Vector2(0, -1799.048f);//left, bottom
        inside_Slider[1].offsetMax = new Vector2(0, -6.103516e-05f);//-right, -top

    }

    public void Go_Back_2()
    {
        Inside_anim[1].SetTrigger("Go_Right");
    }

    //�Ϸ��̽�
    public void Go_3_Inside()
    {
        Inside_anim[2].SetTrigger("Go_Left");

        inside_Slider[2].offsetMin = new Vector2(0, -245.0295f);//left, bottom
        inside_Slider[2].offsetMax = new Vector2(0, -0.0004959106f);//-right, -top

    }

    public void Go_Back_3()
    {
        Inside_anim[2].SetTrigger("Go_Right");
    }

    //��ü�����
    public void Go_4_Inside()
    {
        Inside_anim[3].SetTrigger("Go_Left");

        inside_Slider[3].offsetMin = new Vector2(0, -514.2539f);//left, bottom
        inside_Slider[3].offsetMax = new Vector2(0, -0.0001525879f);//-right, -top

    }

    public void Go_Back_4()
    {
        Inside_anim[3].SetTrigger("Go_Right");
    }

    //��
    public void Go_5_Inside()
    {
        Inside_anim[4].SetTrigger("Go_Left");

        inside_Slider[4].offsetMin = new Vector2(0, -261.906f);//left, bottom
        inside_Slider[4].offsetMax = new Vector2(0, 0f);//-right, -top

    }

    public void Go_Back_5()
    {
        Inside_anim[4].SetTrigger("Go_Right");
    }

    //������
    public void Go_6_Inside()
    {
        Inside_anim[5].SetTrigger("Go_Left");

        inside_Slider[5].offsetMin = new Vector2(0, -767.9815f);//left, bottom
        inside_Slider[5].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top

    }

    public void Go_Back_6()
    {
        Inside_anim[5].SetTrigger("Go_Right");
    }

    public void Go_Back_Main()
    {
        //bag.SetActive(false);
        bag_anim.SetTrigger("Go_Right");
    }

    public void Go_Ch_Information()
    {
        Collection[1].SetActive(true);//�ι��� 1
        Collection[0].SetActive(false);   //������0

        Collection_Inside[1].SetActive(true);
        Collection_Inside[0].SetActive(false);

        bag_slider[0].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[0].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top
    }

    public void Go_Obj_Information()
    {
        Collection[1].SetActive(false);//�ι��� 1
        Collection[0].SetActive(true);   //������0

        Collection_Inside[1].SetActive(false);
        Collection_Inside[0].SetActive(true);

        bag_slider[1].offsetMin = new Vector2(0, -598.049f);//left, bottom
        bag_slider[1].offsetMax = new Vector2(0, -0.0001220703f);//-right, -top
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch : MonoBehaviour
{
    public B_Button b_btn;

    public GameObject[] Aine_Change;


    public RectTransform ch;//�����̳�

    public Animator Ch_R_L;
    public Animator[] Ch_R_L_Inside;//ĳ���� ������ ��, ĳ���� ������ �� �� �ְ� �ϴ� ��


    public GameObject One;//���̳�
    public GameObject Two;//��
    public GameObject Three;//��
    public GameObject Four;//������
    public GameObject Five;//�Ϸ��̽�
    public GameObject Six;//��ü�����
    public GameObject Seven;//���ڸ�
    public GameObject Eight;//������

    public GameObject[] Ch_Hide;//���� �������� �ʾ� �� �� ���� ĳ����

    public GameObject[] One_Ch_Inside;//ĳ���ͺ��� �Ⱦ� ����ִ� �ι� �Ұ� ������ ���� �ٸ�
    public GameObject[] Two_Ch_Inside;
    public GameObject[] Three_Ch_Inside;
    public GameObject[] Four_Ch_Inside;
    public GameObject[] Five_Ch_Inside;
    public GameObject[] Six_Ch_Inside;
    public GameObject[] Seven_Ch_Inside;
    public GameObject[] Eight_Ch_Inside;

    public GameObject[] One_Ch_Inside_1;//���̳� �׸�
    public GameObject[] One_Ch_Inside_2;//�� �׸�
    public GameObject[] One_Ch_Inside_3;//�� �׸�
    public GameObject[] One_Ch_Inside_4;//������ �׸�
    public GameObject[] One_Ch_Inside_5;//�Ϸ��̽� �׸�
    public GameObject[] One_Ch_Inside_6;//��ü����� �׸�
    public GameObject[] One_Ch_Inside_7;//���ڸ� �׸�
    public GameObject[] One_Ch_Inside_8;//������ �׸�


    public int First_currentIndex = 0;
    public int Two_currentIndex = 0;
    public int Three_currentIndex = 0;
    public int Four_currentIndex = 0;
    public int Five_currentIndex = 0;
    public int Six_currentIndex = 0;
    public int Seven_currentIndex = 0;
    public int Eight_currentIndex = 0;


    public GameObject One_Ch_Inside_L_Button;
    public GameObject One_Ch_Inside_R_Button;

    public GameObject Two_Ch_Inside_L_Button;//��
    public GameObject Two_Ch_Inside_R_Button;

    public GameObject Three_Ch_Inside_L_Button;
    public GameObject Three_Ch_Inside_R_Button;//��

    public GameObject Four_Ch_Inside_L_Button;
    public GameObject Four_Ch_Inside_R_Button;//������

    public GameObject Six_Ch_Inside_L_Button;//��ü�����
    public GameObject Six_Ch_Inside_R_Button;


    public void Update()
    {

        if(One_Ch_Inside[0].activeSelf==true|| One_Ch_Inside[1].activeSelf == true|| One_Ch_Inside[2].activeSelf == true|| One_Ch_Inside_1[4].activeSelf == true)
        {
            One_Ch_Inside_1[6].SetActive(false);
        }

        else if(One_Ch_Inside_1[5].activeSelf==true)
        {
            One_Ch_Inside_1[6].SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (First_currentIndex == One_Ch_Inside.Length - 1)
        {
            //����3, ���� ����� 4-1

            One_Ch_Inside_R_Button.SetActive(false);
            One_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("�ǳ� Ȯ��");

            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
        }

        else if (First_currentIndex <= 0)
        {
            One_Ch_Inside_L_Button.SetActive(false);
            One_Ch_Inside_R_Button.SetActive(true);
            First_currentIndex = 0;

            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
        }

        else if (First_currentIndex < One_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            One_Ch_Inside_R_Button.SetActive(true);
            One_Ch_Inside_L_Button.SetActive(true);
        }

        else if (First_currentIndex > One_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            One_Ch_Inside_R_Button.SetActive(false);
            One_Ch_Inside_L_Button.SetActive(true);

        }

        else if (First_currentIndex > 0)
        {
            One_Ch_Inside_L_Button.SetActive(true);
            //����3. ���� ���� ���� ���̴�4
        }


        //��


        //����� ��

        // 1) �ε����� 0�̰ų� 0���� �۴ٸ� -> ���� ��ư ���ֱ�
        // 2) �ε����� ���� �����س��� ����-1�� ���ų� ũ�ٸ� -> ������ ��ư ���ֱ�
        // 3) �ε����� ���� �����س��� ���̺��� �۴ٸ�


        if (Two_currentIndex == Two_Ch_Inside.Length - 1)
        {
            //����3, ���� ����� 4-1

            Two_Ch_Inside_R_Button.SetActive(false);
            Two_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("�ǳ� Ȯ��");

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }

        else if (Two_currentIndex <= 0)
        {
            Two_Ch_Inside_L_Button.SetActive(false);
            Two_Ch_Inside_R_Button.SetActive(true);
            Two_currentIndex = 0;

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }

        else if (Two_currentIndex < Two_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            Two_Ch_Inside_R_Button.SetActive(true);
            Two_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Two_currentIndex > Two_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            Two_Ch_Inside_R_Button.SetActive(false);
            Two_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Two_currentIndex > 0)
        {
            Two_Ch_Inside_L_Button.SetActive(true);
            //����3. ���� ���� ���� ���̴�4
        }

        //��
        if (Three_currentIndex == Three_Ch_Inside.Length - 1)
        {
            //����3, ���� ����� 4-1

            Three_Ch_Inside_R_Button.SetActive(false);
            Three_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("�ǳ� Ȯ��");

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }

        else if (Three_currentIndex <= 0)
        {
            Three_Ch_Inside_L_Button.SetActive(false);
            Three_Ch_Inside_R_Button.SetActive(true);
            Three_currentIndex = 0;

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }

        else if (Three_currentIndex < Three_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            Three_Ch_Inside_R_Button.SetActive(true);
            Three_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Three_currentIndex > Three_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            Three_Ch_Inside_R_Button.SetActive(false);
            Three_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Three_currentIndex > 0)
        {
            Three_Ch_Inside_L_Button.SetActive(true);
            //����3. ���� ���� ���� ���̴�4
        }

        //������
        if (Four_currentIndex == Four_Ch_Inside.Length - 1)
        {
            //����3, ���� ����� 4-1

            Four_Ch_Inside_R_Button.SetActive(false);
            Four_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("�ǳ� Ȯ��");

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }

        else if (Four_currentIndex <= 0)
        {
            Four_Ch_Inside_L_Button.SetActive(false);
            Four_Ch_Inside_R_Button.SetActive(true);
            Four_currentIndex = 0;

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }

        else if (Four_currentIndex < Four_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            Four_Ch_Inside_R_Button.SetActive(true);
            Four_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Four_currentIndex > Four_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            Four_Ch_Inside_R_Button.SetActive(false);
            Four_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Four_currentIndex > 0)
        {
            Four_Ch_Inside_L_Button.SetActive(true);
            //����3. ���� ���� ���� ���̴�4
        }

        //��ü�����
        if (Six_currentIndex == Six_Ch_Inside.Length - 1)
        {
            //����3, ���� ����� 4-1

            Six_Ch_Inside_R_Button.SetActive(false);
            Six_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("�ǳ� Ȯ��");

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }

        else if (Six_currentIndex <= 0)
        {
            Six_Ch_Inside_L_Button.SetActive(false);
            Six_Ch_Inside_R_Button.SetActive(true);
            Six_currentIndex = 0;

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }

        else if (Six_currentIndex < Six_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            Six_Ch_Inside_R_Button.SetActive(true);
            Six_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Six_currentIndex > Six_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            Six_Ch_Inside_R_Button.SetActive(false);
            Six_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Six_currentIndex > 0)
        {
            Six_Ch_Inside_L_Button.SetActive(true);
            //����3. ���� ���� ���� ���̴�4
        }

    }

    //�������
    public void Go_Character()
    {
        b_btn.Hide_Bty();//0723�߰�

        Ch_R_L.SetTrigger("Go_Left");

        ch.offsetMin = new Vector2(0, -882.4295f);//left, bottom
        ch.offsetMax = new Vector2(0, 0.001525879f);//-right, -top
    }

    public void Go_Main()
    {
        Ch_R_L.SetTrigger("Go_Right");
    }

    //��������� ����������
    
    public void Go_Ch_Select_1()
    {
        Ch_R_L_Inside[0].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_2()
    {
        Ch_R_L_Inside[1].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_3()
    {
        Ch_R_L_Inside[2].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_4()
    {
        Ch_R_L_Inside[3].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_5()
    {
        Ch_R_L_Inside[4].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_6()
    {
        Ch_R_L_Inside[5].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_7()
    {
        Ch_R_L_Inside[6].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_8()
    {
        Ch_R_L_Inside[7].SetTrigger("Go_Right");

    }

    public void Go_Five_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[4].SetTrigger("Go_Left");
        Five_Ch_Inside[0].SetActive(true);
        Five_currentIndex = 0;
    }

    public void Go_Seven_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[6].SetTrigger("Go_Left");
        Seven_Ch_Inside[0].SetActive(true);
        Seven_currentIndex = 0;
    }

    public void Go_Eight_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[7].SetTrigger("Go_Left");
        Eight_Ch_Inside[0].SetActive(true);
        Eight_currentIndex = 0;
    }


    public void Go_First_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[0].SetTrigger("Go_Left");

        One_Ch_Inside[0].SetActive(true);
        First_currentIndex = 0;

        for(int i=1; i<One_Ch_Inside.Length; i++)
        {
            One_Ch_Inside[i].SetActive(false);
        }

        One_Ch_Inside_L_Button.SetActive(false);
        One_Ch_Inside_R_Button.SetActive(true);

    }

    public void First_Right_Inside()//���������� �� �� �ִϸ��̼�
    {
        if(First_currentIndex < One_Ch_Inside.Length-1)//���� �ε����� �迭�� ���̺��� ������
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            First_currentIndex++;

            foreach(GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
            //���� �ε����� �ش�Ǵ� �͸� Ȱ��ȭ

            if (One_Ch_Inside_1[5].activeSelf == true && One_Ch_Inside[3].activeSelf==true)
            {
                One_Ch_Inside_1[6].SetActive(true);//���� ���°�
            }

            //
           
        }

        else if(First_currentIndex > One_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            First_currentIndex = One_Ch_Inside.Length-1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);

           
        }


    }

    public void First_Left_Inside()//�������� �� �� �ִϸ��̼�
    {
        if (First_currentIndex < One_Ch_Inside.Length)//���� �ε����� �迭�� ���̺��� ������
        {



            if(First_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //����3. ���� ���� ���� ���̴�4

                First_currentIndex--;

                foreach (GameObject obj in One_Ch_Inside)
                {
                    obj.SetActive(false);//���빰 ��� ��Ȱ��
                }

                One_Ch_Inside[First_currentIndex].SetActive(true);
            }

            


        }

        

        else if(First_currentIndex > One_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //����5, ���� ���� �� 4
            First_currentIndex = One_Ch_Inside.Length - 1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);

        }
    }

    //��
    public void Go_Second_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[1].SetTrigger("Go_Left");

        Two_Ch_Inside[0].SetActive(true);
        Two_currentIndex = 0;

        for (int i = 1; i < Two_Ch_Inside.Length; i++)
        {
            Two_Ch_Inside[i].SetActive(false);
        }

        Two_Ch_Inside_L_Button.SetActive(false);
        Two_Ch_Inside_R_Button.SetActive(true);

    }

    public void Two_Right_Inside()//���������� �� �� �ִϸ��̼�
    {
        if (Two_currentIndex < Two_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex++;

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
            //���� �ε����� �ش�Ǵ� �͸� Ȱ��ȭ
        }

        else if (Two_currentIndex > Two_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }


    }

    public void Two_Left_Inside()//�������� �� �� �ִϸ��̼�
    {
        if (Two_currentIndex < Two_Ch_Inside.Length)//���� �ε����� �迭�� ���̺��� ������
        {

            if (Two_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //����3. ���� ���� ���� ���̴�4

                Two_currentIndex--;

                foreach (GameObject obj in Two_Ch_Inside)
                {
                    obj.SetActive(false);//���빰 ��� ��Ȱ��
                }

                Two_Ch_Inside[Two_currentIndex].SetActive(true);
            }


        }



        else if (Two_currentIndex > Two_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //����5, ���� ���� �� 4
            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);

        }

        else if (Two_currentIndex == Two_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Two_Ch_Inside[First_currentIndex].SetActive(true);
        }
    }

    //��
    public void Go_Three_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[2].SetTrigger("Go_Left");

        Three_Ch_Inside[0].SetActive(true);
        Three_currentIndex = 0;

        for (int i = 1; i < Three_Ch_Inside.Length; i++)
        {
            Three_Ch_Inside[i].SetActive(false);
        }

        Three_Ch_Inside_L_Button.SetActive(false);
        Three_Ch_Inside_R_Button.SetActive(true);

    }

    public void Three_Right_Inside()//���������� �� �� �ִϸ��̼�
    {
        if (Three_currentIndex < Three_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Three_currentIndex++;

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
            //���� �ε����� �ش�Ǵ� �͸� Ȱ��ȭ
        }

        else if (Three_currentIndex > Three_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Three_currentIndex = Three_Ch_Inside.Length - 1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }


    }

    public void Three_Left_Inside()//�������� �� �� �ִϸ��̼�
    {
        if (Three_currentIndex < Three_Ch_Inside.Length)//���� �ε����� �迭�� ���̺��� ������
        {



            if (Three_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //����3. ���� ���� ���� ���̴�4

                Three_currentIndex--;

                foreach (GameObject obj in Three_Ch_Inside)
                {
                    obj.SetActive(false);//���빰 ��� ��Ȱ��
                }

                Three_Ch_Inside[Three_currentIndex].SetActive(true);
            }




        }



        else if (Three_currentIndex > Three_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //����5, ���� ���� �� 4
            Three_currentIndex = Three_Ch_Inside.Length - 1;


            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Three_Ch_Inside[First_currentIndex].SetActive(true);

        }
    }

    //������
    public void Go_Four_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[3].SetTrigger("Go_Left");

        Four_Ch_Inside[0].SetActive(true);
        Four_currentIndex = 0;

        for (int i = 1; i < Four_Ch_Inside.Length; i++)
        {
            Four_Ch_Inside[i].SetActive(false);
        }

        Four_Ch_Inside_L_Button.SetActive(false);
        Four_Ch_Inside_R_Button.SetActive(true);

    }

    public void Four_Right_Inside()//���������� �� �� �ִϸ��̼�
    {
        if (Four_currentIndex < Four_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Four_currentIndex++;

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
            //���� �ε����� �ش�Ǵ� �͸� Ȱ��ȭ
        }

        else if (Four_currentIndex > Four_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Four_currentIndex = Four_Ch_Inside.Length - 1;


            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }


    }

    public void Four_Left_Inside()//�������� �� �� �ִϸ��̼�
    {
        if (Four_currentIndex < Four_Ch_Inside.Length)//���� �ε����� �迭�� ���̺��� ������
        {



            if (Four_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //����3. ���� ���� ���� ���̴�4

                Four_currentIndex--;

                foreach (GameObject obj in Four_Ch_Inside)
                {
                    obj.SetActive(false);//���빰 ��� ��Ȱ��
                }

                Four_Ch_Inside[Four_currentIndex].SetActive(true);
            }




        }



        else if (Four_currentIndex > Four_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //����5, ���� ���� �� 4
            Four_currentIndex = Four_Ch_Inside.Length - 1;


            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);

        }
    }

    //��ü����� Six
    public void Go_Six_Inside()//ù ��° ĳ���� ���� �� �� �ִϸ��̼�
    {
        Ch_R_L_Inside[5].SetTrigger("Go_Left");

        Six_Ch_Inside[0].SetActive(true);
        Six_currentIndex = 0;

        for (int i = 1; i < Six_Ch_Inside.Length; i++)
        {
            Six_Ch_Inside[i].SetActive(false);
        }

        Six_Ch_Inside_L_Button.SetActive(false);
        Six_Ch_Inside_R_Button.SetActive(true);

    }

    public void Six_Right_Inside()//���������� �� �� �ִϸ��̼�
    {
        if (Six_currentIndex < Six_Ch_Inside.Length - 1)//���� �ε����� �迭�� ���̺��� ������
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Six_currentIndex++;

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
            //���� �ε����� �ش�Ǵ� �͸� Ȱ��ȭ
        }

        else if (Six_currentIndex > Six_Ch_Inside.Length - 1)
        {
            //����4, ���� ����� 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Six_currentIndex = Six_Ch_Inside.Length - 1;


            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }


    }

    public void Six_Left_Inside()//�������� �� �� �ִϸ��̼�
    {
        if (Six_currentIndex < Six_Ch_Inside.Length)//���� �ε����� �迭�� ���̺��� ������
        {



            if (Six_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //����3. ���� ���� ���� ���̴�4

                Six_currentIndex--;

                foreach (GameObject obj in Six_Ch_Inside)
                {
                    obj.SetActive(false);//���빰 ��� ��Ȱ��
                }

                Six_Ch_Inside[Six_currentIndex].SetActive(true);
            }




        }



        else if (Six_currentIndex > Six_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //����5, ���� ���� �� 4
            Six_currentIndex = Six_Ch_Inside.Length - 1;


            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//���빰 ��� ��Ȱ��
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butterfly : MonoBehaviour
{
    public GameObject[] objectArray;
    public GameObject[] objectArray1;

    public int numberOfObjects = 409;
    public int numberOfObjects1 = 409;

    public float delayBetweenSpawns = 0.002f;
    public float delayBetweenSpawns1 = 0.004f;

    public int currentIndex = 0;
    public int currentIndex1 = 0;

    public GameObject Main;
    public GameObject Supplementary_Story;//�����̶�� �ܾ���
    public B_Button b_btn;

    public GameObject Y_B;//���� �� ����
    public GameObject Y_B_1;//���ٶ� ����


    //��������
    public void Go_Main()
    {
        CancelInvoke("Erease_Object");//InvokeRepeating�� ����
        CancelInvoke("ShowObject");//InvokeRepeating�� ����
        InvokeRepeating("Show", 0f, delayBetweenSpawns);

        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }

    private void Show()
    {
       

        if (currentIndex < numberOfObjects)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {

            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray[currentIndex];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(true);

            currentIndex++;
        }
        else//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {
            // numberOfObjects�� ��� �����Ǹ� InvokeRepeating ����
            CancelInvoke("Show");//InvokeRepeating�� ����
            Main.SetActive(true);
            Supplementary_Story.SetActive(false);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_B();

            }

        }
    }
    public void False_Up_B()
    {
        InvokeRepeating("E_Object", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //ȣ���� �Լ��� �̸�, �Լ� ȣ����� ��ٸ��� �ð�, �Լ� ȣ�� ������ ����
    }

    private void E_Object()
    {
        if (currentIndex1 < numberOfObjects1)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {

            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray1[currentIndex1];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("E_Object");//InvokeRepeating�� ����

        }
    }

    //�� 408������ �����δ� 409��







    // ***** ������ʹ� ���� ���� ��
    public void Down_Up_Butterfly()
    {
        CancelInvoke("Show");
        CancelInvoke("E_Object");
        InvokeRepeating("ShowObject", 0f, delayBetweenSpawns);
        //ȣ���� �Լ��� �̸�, �Լ� ȣ����� ��ٸ��� �ð�, �Լ� ȣ�� ������ ����
        
        Supplementary_Story.SetActive(false);
        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }


    //���⼭ ���� ���� ��Ȱ��ȭ ���Ѿ���
    private void ShowObject()
    {
        if (currentIndex < numberOfObjects)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {
            
            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray[currentIndex];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(true);

            currentIndex++;
        }
        else//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {
            // numberOfObjects�� ��� �����Ǹ� InvokeRepeating ����
            CancelInvoke("ShowObject");//InvokeRepeating�� ����
            Main.SetActive(false);
            Supplementary_Story.SetActive(true);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_Butterfly();



            }
             
        }
    }

    //���⼭ ������ ���� �� ��Ȱ��ȭ ���Ѿ���
    public void False_Up_Butterfly()
    {
        InvokeRepeating("Erease_Object", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //ȣ���� �Լ��� �̸�, �Լ� ȣ����� ��ٸ��� �ð�, �Լ� ȣ�� ������ ����
    }

    private void Erease_Object()
    {
        if (currentIndex1 < numberOfObjects1)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {

            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray1[currentIndex1];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("Erease_Object");//InvokeRepeating�� ����

        }
    }


    //���� �� �����, �ٽ� ���� ����. �̶� ���� ȭ�� ��� ���� ȭ���� ���δ�.

    //�׸��� ���� �����ϸ� ���� ȭ���� �������� �ٽ� ���� ȭ���� ���δ�.


    //0722 ������ �� ������ ����ȭ������ ���ư���
    //���⼭ ���� ���� ��Ȱ��ȭ ���Ѿ���
    public void Down_Up_Butterfly_Go_Main()
    {
        CancelInvoke("Show_Go_Main");
        CancelInvoke("E_Object_Go_Main");
        InvokeRepeating("ShowObject_Go_Main", 0f, delayBetweenSpawns);
        //ȣ���� �Լ��� �̸�, �Լ� ȣ����� ��ٸ��� �ð�, �Լ� ȣ�� ������ ����

        b_btn.Buf_Story_Collection.SetActive(true);
        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }

    private void ShowObject_Go_Main()
    {
        if (currentIndex < numberOfObjects)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {

            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray[currentIndex];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(true);

            currentIndex++;
        }
        else//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {
            // numberOfObjects�� ��� �����Ǹ� InvokeRepeating ����
            CancelInvoke("ShowObject_Go_Main");//InvokeRepeating�� ����
            Main.SetActive(true);
            b_btn.Buf_Story_Collection.SetActive(false);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_Butterfly_Go_Main();



            }

        }
    }

    //���⼭ ������ ���� �� ��Ȱ��ȭ ���Ѿ���
    public void False_Up_Butterfly_Go_Main()
    {
        InvokeRepeating("Erease_Object_Go_Main", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //ȣ���� �Լ��� �̸�, �Լ� ȣ����� ��ٸ��� �ð�, �Լ� ȣ�� ������ ����
    }

    private void Erease_Object_Go_Main()
    {
        if (currentIndex1 < numberOfObjects1)//���� ������ ������Ʈ ������ ������ �� ������Ʈ�� ������ ���� ���
        {

            // �迭���� ������Ʈ ��������
            GameObject obj = objectArray1[currentIndex1];//�迭���� ���� �ε����� �ش��ϴ� ������Ʈ�� �����ͼ� ������ �Ҵ�

            // ������Ʈ Ȱ��ȭ
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("Erease_Object_Go_Main");//InvokeRepeating�� ����

        }
    }
}

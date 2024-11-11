using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    //������ �ι�, ����� �� �������� ��κ� �״�� ������ ���� ����� ������ �ִ�
    //�����ε� ���丮

    //���ɿ����� ������ ���� ��� �� �ϳ��� �Ϻθ� �����Ͽ� ������ ���ο� ��ǰ�� ����
    //(���༼��)

    public GameObject Title;

    public GameObject Main;//����ȭ��
    public GameObject Letter;//����
   // public GameObject Bag;//����
    //public GameObject Album;//�ٹ�
   // public GameObject Person;//�ι�
    //public GameObject Story;//���丮
    public GameObject Supplementary;//���̵� ���丮 -> ����
    public GameObject Spin_Off;//����-> ���ɿ���(����)

    public GameObject Brown;//����
    public GameObject Black;//������

    private void FixedUpdate()
    {
        if(Title.activeSelf==false && Main.activeSelf==true)
        {
            Brown.SetActive(true);
            Black.SetActive(false);
            //����

        }
        
        else if (Title.activeSelf == true)
        {
            //������
            Brown.SetActive(false);
            Black.SetActive(true);
        }

        else
        {
            Brown.SetActive(true);
            Black.SetActive(false);
        }
    }
}

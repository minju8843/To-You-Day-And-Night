using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_All : MonoBehaviour
{
    //���� ����� �ſ����� �� ���� ������
    //���� �� �Ʊ���� ���� ������� �� ��ó��� �� �� �ְ� ���ִ� ��ũ��Ʈ

    //����(����, �ι�)
    public Bag bag;

    //����
    public Letter letter;
    
    //�����ι�
    public Ch ch;

    public GameObject[] Will_Show;//�� ���̴��� ���̰� �� ����, ������ ����
    public GameObject[] Show_Text;

    //���� �ؾ� �� ��
    //1ȭ�� �� ������ 2ȭ�� �� �� �ְ� �ϱ�
    //�����̴�? �� �¿쿡 �ִ� ȭ��ǥ�� ���� ȭ, ���� ȭ�� �� �� �ִ� �ɷ� ����
    //���� ��� ȭ ���� �ô��� ���� ȭ�鿡�� �� �� �ְ�, �ٷ� �� ȭ���� �� �� �ְ� �ϱ�
    //���� ���丮, ������ ȿ���� �ֱ�

    public void FixedUpdate()
    {
        if (letter.Four_Letter.activeSelf == false)
        {
            //���� �������� �ʾƾ� �� �� �ϳ��� �������� ������
            Show_Text[0].SetActive(true);//�����ֱ�
            Show_Text[1].SetActive(false);//���߱�
        }

        else if (letter.Four_Letter.activeSelf == true)
        {
            //���� �ϳ��� ������ �ʾƾ� �� �� ������ �ʴ´ٸ�
            Show_Text[0].SetActive(false);
            Show_Text[1].SetActive(true);
        }
    }

    public void Show_Or_Not()
    {
        if(letter.Four_Letter.activeSelf==false)
        {
            //���� �������� �ʾƾ� �� �� �ϳ��� �������� ������
            Will_Show[0].SetActive(true);//�����ֱ�
            Will_Show[1].SetActive(false);//���߱�
        }

        else if (letter.Four_Letter.activeSelf == true)
        {
            //���� �ϳ��� ������ �ʾƾ� �� �� ������ �ʴ´ٸ�
            Will_Show[0].SetActive(false);
            Will_Show[1].SetActive(true);
        }
    }

    public void Show_all_Yes()
    {
        //���� ���� �� �� ��������
        //���丮 �����ϸ� �رݵ� �� �ִ� �� ����

        //����
        letter.Three_Letter.SetActive(true);
        letter.Four_Letter.SetActive(true);
        letter.Five_Letter.SetActive(true);
        letter.Six_Letter.SetActive(true);
        letter.Seven_Letter.SetActive(true);

        //���� - �尩
        bag.Obj_Inform_Select_2[0].SetActive(true);
        bag.Obj_Inform_Select_2[1].SetActive(false);

        //���� - ���̳� ����
        bag.Ch_1_Text[6].SetActive(false);//4
        bag.Ch_1_Text[7].SetActive(true);
        bag.Ch_1_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_1_Text[8].SetActive(false);//5
        bag.Ch_1_Text[9].SetActive(true);
        bag.Ch_1_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_1_Text[10].SetActive(false);//6
        bag.Ch_1_Text[11].SetActive(true);
        bag.Ch_1_Image[5].color = new Color(255, 255, 255 / 255);

        //���� - �� ����
        bag.Ch_2_Text[2].SetActive(false);//2
        bag.Ch_2_Text[3].SetActive(true);
        bag.Ch_2_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[4].SetActive(false);//3
        bag.Ch_2_Text[5].SetActive(true);
        bag.Ch_2_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[6].SetActive(false);//4
        bag.Ch_2_Text[7].SetActive(true);
        bag.Ch_2_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[8].SetActive(false);//5
        bag.Ch_2_Text[9].SetActive(true);
        bag.Ch_2_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[10].SetActive(false);//6
        bag.Ch_2_Text[11].SetActive(true);
        bag.Ch_2_Image[5].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[12].SetActive(false);//7
        bag.Ch_2_Text[13].SetActive(true);
        bag.Ch_2_Image[6].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[14].SetActive(false);//8
        bag.Ch_2_Text[15].SetActive(true);
        bag.Ch_2_Image[7].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[16].SetActive(false);//9
        bag.Ch_2_Text[17].SetActive(true);
        bag.Ch_2_Image[8].color = new Color(255, 255, 255 / 255);

        bag.Ch_2_Text[18].SetActive(false);//10
        bag.Ch_2_Text[19].SetActive(true);
        bag.Ch_2_Image[9].color = new Color(255, 255, 255 / 255);

        //���� - �Ϸ��̽� ����
        bag.Ch_Inform_Select_3[0].SetActive(true);//����
        bag.Ch_Inform_Select_3[1].SetActive(false);//����

        bag.Ch_3_Text[0].SetActive(false);//1
        bag.Ch_3_Text[1].SetActive(true);
        bag.Ch_3_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[2].SetActive(false);//2
        bag.Ch_3_Text[3].SetActive(true);
        bag.Ch_3_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[4].SetActive(false);//3
        bag.Ch_3_Text[5].SetActive(true);
        bag.Ch_3_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_3_Text[6].SetActive(false);//4
        bag.Ch_3_Text[7].SetActive(true);
        bag.Ch_3_Image[3].color = new Color(255, 255, 255 / 255);

        //���� - ��ü����� ����
        bag.Ch_Inform_Select_4[0].SetActive(true);//����
        bag.Ch_Inform_Select_4[1].SetActive(false);//����

        bag.Ch_4_Text[0].SetActive(false);//1
        bag.Ch_4_Text[1].SetActive(true);
        bag.Ch_4_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[2].SetActive(false);//2
        bag.Ch_4_Text[3].SetActive(true);
        bag.Ch_4_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[4].SetActive(false);//3
        bag.Ch_4_Text[5].SetActive(true);
        bag.Ch_4_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[6].SetActive(false);//4
        bag.Ch_4_Text[7].SetActive(true);
        bag.Ch_4_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_4_Text[8].SetActive(false);//4
        bag.Ch_4_Text[9].SetActive(true);
        bag.Ch_4_Image[4].color = new Color(255, 255, 255 / 255);

        //���� - ��ž�� ����
        bag.Ch_Inform_Select_5[0].SetActive(true);//����
        bag.Ch_Inform_Select_5[1].SetActive(false);//����

        bag.Ch_5_Text[0].SetActive(false);//1
        bag.Ch_5_Text[1].SetActive(true);
        bag.Ch_5_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[2].SetActive(false);//2
        bag.Ch_5_Text[3].SetActive(true);
        bag.Ch_5_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[4].SetActive(false);//3
        bag.Ch_5_Text[5].SetActive(true);
        bag.Ch_5_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_5_Text[6].SetActive(false);//4
        bag.Ch_5_Text[7].SetActive(true);
        bag.Ch_5_Image[3].color = new Color(255, 255, 255 / 255);

        //���� - ������ ����
        bag.Ch_Inform_Select_6[0].SetActive(true);//����
        bag.Ch_Inform_Select_6[1].SetActive(false);//����

        bag.Ch_6_Text[0].SetActive(false);//1
        bag.Ch_6_Text[1].SetActive(true);
        bag.Ch_6_Image[0].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[2].SetActive(false);//2
        bag.Ch_6_Text[3].SetActive(true);
        bag.Ch_6_Image[1].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[4].SetActive(false);//3
        bag.Ch_6_Text[5].SetActive(true);
        bag.Ch_6_Image[2].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[6].SetActive(false);//4
        bag.Ch_6_Text[7].SetActive(true);
        bag.Ch_6_Image[3].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[8].SetActive(false);//3
        bag.Ch_6_Text[9].SetActive(true);
        bag.Ch_6_Image[4].color = new Color(255, 255, 255 / 255);

        bag.Ch_6_Text[10].SetActive(false);//4
        bag.Ch_6_Text[11].SetActive(true);
        bag.Ch_6_Image[5].color = new Color(255, 255, 255 / 255);

        //�����ι�
        ch.Ch_Hide[0].SetActive(false);//��
        ch.Ch_Hide[2].SetActive(false);//������
        ch.Ch_Hide[3].SetActive(false);//�Ϸ��̽�
        ch.Ch_Hide[4].SetActive(false);//��ü�����
        ch.Ch_Hide[5].SetActive(false);//���ڸ�
        ch.Ch_Hide[6].SetActive(false);//������

        ch.Two.SetActive(true);//��
        ch.Four.SetActive(true);//������
        ch.Five.SetActive(true);//�Ϸ��̽�
        ch.Six.SetActive(true);//��ü�����
        ch.Seven.SetActive(true);//���ڸ�
        ch.Eight.SetActive(true);//������

        //���̳� - ������ ����,�Ǹ� ����
        ch.One_Ch_Inside_1[2].SetActive(false);//���� �� �����°�
        ch.One_Ch_Inside_1[3].SetActive(true);//���� �� ���°�
        ch.One_Ch_Inside_1[4].SetActive(false);//���� �����°�
        ch.One_Ch_Inside_1[5].SetActive(true);//���� ���°�
       

        //�� - ��ü ������ ��
        ch.One_Ch_Inside_2[0].SetActive(false);//�����°�
        ch.One_Ch_Inside_2[1].SetActive(true);//���°�

        //�� - ������ ����, ��ü ������ ��
        ch.One_Ch_Inside_3[0].SetActive(false);//�����°�
        ch.One_Ch_Inside_3[1].SetActive(true);//���°�
        ch.One_Ch_Inside_3[2].SetActive(false);// �����°�
        ch.One_Ch_Inside_3[3].SetActive(true);// ���°�

        //������ - ���� ��
        ch.One_Ch_Inside_4[0].SetActive(false);//�����°�
        ch.One_Ch_Inside_4[1].SetActive(true);//���°�

        //��ü����� - ������
        ch.One_Ch_Inside_6[0].SetActive(false);//�����°�
        ch.One_Ch_Inside_6[1].SetActive(true);//���°�

        Will_Show[0].SetActive(false);
    }

    public void Return_all_Yes()
    {

        //�ٽ� �� ���̴� �� �Ⱥ��̰� �����

        //����
        letter.Three_Letter.SetActive(false);
        letter.Four_Letter.SetActive(false);
        letter.Five_Letter.SetActive(false);
        letter.Six_Letter.SetActive(false);
        letter.Seven_Letter.SetActive(false);

        //���� - �尩
        bag.Obj_Inform_Select_2[0].SetActive(false);
        bag.Obj_Inform_Select_2[1].SetActive(true);

        //���� - ���̳� ����
        bag.Ch_1_Text[6].SetActive(true);//4
        bag.Ch_1_Text[7].SetActive(false);
        bag.Ch_1_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_1_Text[8].SetActive(true);//5
        bag.Ch_1_Text[9].SetActive(false);
        bag.Ch_1_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_1_Text[10].SetActive(true);//6
        bag.Ch_1_Text[11].SetActive(false);
        bag.Ch_1_Image[5].color = new Color(0, 0, 0 / 255);

        //���� - �� ����
        bag.Ch_2_Text[2].SetActive(true);//2
        bag.Ch_2_Text[3].SetActive(false);
        bag.Ch_2_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[4].SetActive(true);//3
        bag.Ch_2_Text[5].SetActive(false);
        bag.Ch_2_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[6].SetActive(true);//4
        bag.Ch_2_Text[7].SetActive(false);
        bag.Ch_2_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[8].SetActive(true);//5
        bag.Ch_2_Text[9].SetActive(false);
        bag.Ch_2_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[10].SetActive(true);//6
        bag.Ch_2_Text[11].SetActive(false);
        bag.Ch_2_Image[5].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[12].SetActive(true);//7
        bag.Ch_2_Text[13].SetActive(false);
        bag.Ch_2_Image[6].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[14].SetActive(true);//8
        bag.Ch_2_Text[15].SetActive(false);
        bag.Ch_2_Image[7].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[16].SetActive(true);//9
        bag.Ch_2_Text[17].SetActive(false);
        bag.Ch_2_Image[8].color = new Color(0, 0, 0 / 255);

        bag.Ch_2_Text[18].SetActive(true);//10
        bag.Ch_2_Text[19].SetActive(false);
        bag.Ch_2_Image[9].color = new Color(0, 0, 0 / 255);

        //���� - �Ϸ��̽� ����
        bag.Ch_Inform_Select_3[0].SetActive(false);//����
        bag.Ch_Inform_Select_3[1].SetActive(true);//����

        bag.Ch_3_Text[0].SetActive(true);//1
        bag.Ch_3_Text[1].SetActive(false);
        bag.Ch_3_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[2].SetActive(true);//2
        bag.Ch_3_Text[3].SetActive(false);
        bag.Ch_3_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[4].SetActive(true);//3
        bag.Ch_3_Text[5].SetActive(false);
        bag.Ch_3_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_3_Text[6].SetActive(true);//4
        bag.Ch_3_Text[7].SetActive(false);
        bag.Ch_3_Image[3].color = new Color(0, 0, 0 / 255);

        //���� - ��ü����� ����
        bag.Ch_Inform_Select_4[0].SetActive(false);//����
        bag.Ch_Inform_Select_4[1].SetActive(true);//����

        bag.Ch_4_Text[0].SetActive(true);//1
        bag.Ch_4_Text[1].SetActive(false);
        bag.Ch_4_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[2].SetActive(true);//2
        bag.Ch_4_Text[3].SetActive(false);
        bag.Ch_4_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[4].SetActive(true);//3
        bag.Ch_4_Text[5].SetActive(false);
        bag.Ch_4_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[6].SetActive(true);//4
        bag.Ch_4_Text[7].SetActive(false);
        bag.Ch_4_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_4_Text[8].SetActive(true);//4
        bag.Ch_4_Text[9].SetActive(false);
        bag.Ch_4_Image[4].color = new Color(0, 0, 0 / 255);

        //���� - ��ž�� ����
        bag.Ch_Inform_Select_5[0].SetActive(false);//����
        bag.Ch_Inform_Select_5[1].SetActive(true);//����

        bag.Ch_5_Text[0].SetActive(true);//1
        bag.Ch_5_Text[1].SetActive(false);
        bag.Ch_5_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[2].SetActive(true);//2
        bag.Ch_5_Text[3].SetActive(false);
        bag.Ch_5_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[4].SetActive(true);//3
        bag.Ch_5_Text[5].SetActive(false);
        bag.Ch_5_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_5_Text[6].SetActive(true);//4
        bag.Ch_5_Text[7].SetActive(false);
        bag.Ch_5_Image[3].color = new Color(0, 0, 0 / 255);

        //���� - ������ ����
        bag.Ch_Inform_Select_6[0].SetActive(false);//����
        bag.Ch_Inform_Select_6[1].SetActive(true);//����

        bag.Ch_6_Text[0].SetActive(true);//1
        bag.Ch_6_Text[1].SetActive(false);
        bag.Ch_6_Image[0].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[2].SetActive(true);//2
        bag.Ch_6_Text[3].SetActive(false);
        bag.Ch_6_Image[1].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[4].SetActive(true);//3
        bag.Ch_6_Text[5].SetActive(false);
        bag.Ch_6_Image[2].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[6].SetActive(true);//4
        bag.Ch_6_Text[7].SetActive(false);
        bag.Ch_6_Image[3].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[8].SetActive(true);//3
        bag.Ch_6_Text[9].SetActive(false);
        bag.Ch_6_Image[4].color = new Color(0, 0, 0 / 255);

        bag.Ch_6_Text[10].SetActive(true);//4
        bag.Ch_6_Text[11].SetActive(false);
        bag.Ch_6_Image[5].color = new Color(0, 0, 0 / 255);

        //�����ι�
        ch.Ch_Hide[0].SetActive(true);//��
        ch.Ch_Hide[2].SetActive(true);//������
        ch.Ch_Hide[3].SetActive(true);//�Ϸ��̽�
        ch.Ch_Hide[4].SetActive(true);//��ü�����
        ch.Ch_Hide[5].SetActive(true);//���ڸ�
        ch.Ch_Hide[6].SetActive(true);//������

        ch.Two.SetActive(false);//��
        ch.Four.SetActive(false);//������
        ch.Five.SetActive(false);//�Ϸ��̽�
        ch.Six.SetActive(false);//��ü�����
        ch.Seven.SetActive(false);//���ڸ�
        ch.Eight.SetActive(false);//������

        //���̳� - ������ ����,�Ǹ� ����
        ch.One_Ch_Inside_1[2].SetActive(true);//���� �� �����°�
        ch.One_Ch_Inside_1[3].SetActive(false);//���� �� ���°�
        ch.One_Ch_Inside_1[4].SetActive(true);//���� �����°�
        ch.One_Ch_Inside_1[5].SetActive(false);//���� ���°�
        ch.One_Ch_Inside_1[6].SetActive(false);//���� ���°�

        //�� - ��ü ������ ��
        ch.One_Ch_Inside_2[0].SetActive(true);//�����°�
        ch.One_Ch_Inside_2[1].SetActive(false);//���°�

        //�� - ������ ����, ��ü ������ ��
        ch.One_Ch_Inside_3[0].SetActive(true);//�����°�
        ch.One_Ch_Inside_3[1].SetActive(false);//���°�
        ch.One_Ch_Inside_3[2].SetActive(true);// �����°�
        ch.One_Ch_Inside_3[3].SetActive(false);// ���°�

        //������ - ���� ��
        ch.One_Ch_Inside_4[0].SetActive(true);//�����°�
        ch.One_Ch_Inside_4[1].SetActive(false);//���°�

        //��ü����� - ������
        ch.One_Ch_Inside_6[0].SetActive(true);//�����°�
        ch.One_Ch_Inside_6[1].SetActive(false);//���°�

        Will_Show[1].SetActive(false);
    }
}

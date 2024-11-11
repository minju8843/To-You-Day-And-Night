using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Side_S_T : MonoBehaviour
{
    public B_Button b_btn;

    public GameObject Huo_X_Button;
    public GameObject Huo_Touch_Start;
    public Animator Size_Up_Down;
    public Animator Size_Story_Go;

    public GameObject Fade_Obj;
    public Fade fade;

    public Side_Story side_story;

    //�޿��� �ִ� å ��ư ������ ������Ʈ Ȱ��ȭ�ϰ� ���� Ŀ���� �ִϸ��̼� ����

    //�ִϸ��̼� ���� ��, X�ϰ� ���� ��ư ������ �� Ȱ��ȭ�ϱ�
    public void Go_Side_Story()
    {
        b_btn.Hide_Bty();//0723�߰�
        Size_Story_Go.SetTrigger("Go_Left");
    }

    public void Go_Main()
    {
        Size_Story_Go.SetTrigger("Go_Right");
    }

    public void Side_Story_X()
    {//X������ �޿��� å �ִ� �׸� �ٽ� �پ��� �ϱ�
        Size_Up_Down.SetTrigger("Size_Down");
    }

    public void Go_Size_Up()
    {
        Size_Up_Down.SetTrigger("Size_Up");
    }

    public void Go_Back_Select_Side_Story()
    {
        side_story.Go_Main();
    }

    public void Side_Fade_In()
    {
        fade.Fade_BE.SetActive(true);
        fade.Fade_In_Out.SetTrigger("Go_Black");

        StartCoroutine(Show_Main());
        IEnumerator Show_Main()
        {
            yield return new WaitForSeconds(1.0f);
            Size_Up_Down.SetTrigger("Size_Down");

            side_story.Go_Side_Story();
            //Main.SetActive(true);//��Ÿ���� �� �� // ���̵� ���丮
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
}

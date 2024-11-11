using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public B_Button b_btn;

    public Animator Setting_Anim;

    public GameObject[] menuSet;//�Ϲ�, ����
    public GameObject bty;//������ Ȱ��ȭ �Ǿ��ִ���

    public GameObject Title;


    public void Start()
    {
        menuSet[0].SetActive(false);
        menuSet[1].SetActive(false);
    }

    public void Update()
    {
        if(Title.activeSelf==true)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if(bty.activeSelf==true)
                {
                    menuSet[0].SetActive(false);
                    menuSet[1].SetActive(false);
                }

                else
                {
                    menuSet[0].SetActive(false);
                    menuSet[1].SetActive(false);
                }
                
            }
        }

        else
        {
            if (Input.GetButtonDown("Cancel"))//ESC������ �޴� ���̵���
            {
                if (menuSet[0].activeSelf==true || menuSet[1].activeSelf==true)//�޴��� ���� �ִٸ�
                {
                    menuSet[0].SetActive(false);//�ٽ� ��������
                    menuSet[1].SetActive(false);//�ٽ� ��������
                }

                else if (menuSet[0].activeSelf==false || menuSet[1].activeSelf==false)//�޴��� ���� �ִٸ�
                {
                    if(bty.activeSelf == true)
                    {
                        menuSet[0].SetActive(false);
                        menuSet[1].SetActive(true);
                    }

                    else
                    {
                        menuSet[0].SetActive(true);
                        menuSet[1].SetActive(false);
                    }
                    
                }
            }
        }

        
    }

    public void Go_Setting()
    {
        b_btn.Hide_Bty();//0723�߰�

        Setting_Anim.SetTrigger("Go_Left");
    }

    public void Go_Back()
    {
        Setting_Anim.SetTrigger("Go_Right");
    }

    public void End_Game()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public B_Button b_btn;

    public Animator Setting_Anim;

    public GameObject[] menuSet;//일반, 외전
    public GameObject bty;//외전이 활성화 되어있는지

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
            if (Input.GetButtonDown("Cancel"))//ESC누르면 메뉴 보이도록
            {
                if (menuSet[0].activeSelf==true || menuSet[1].activeSelf==true)//메뉴가 켜져 있다면
                {
                    menuSet[0].SetActive(false);//다시 꺼지도록
                    menuSet[1].SetActive(false);//다시 꺼지도록
                }

                else if (menuSet[0].activeSelf==false || menuSet[1].activeSelf==false)//메뉴가 꺼져 있다면
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
        b_btn.Hide_Bty();//0723추가

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
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    
}

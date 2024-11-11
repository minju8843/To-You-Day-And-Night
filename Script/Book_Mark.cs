using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book_Mark : MonoBehaviour
{
    public B_Button b_btn;

    public Side_Story side_story;
    public Main_Stroy_1 Main_story_1;
    public Main_Stroy_2 Main_story_2;
    public GameObject[] Story;//북마크 한 스토리들

    public Animator Book_Mark_Anim;
    public GameObject mark;
    public void Go_Side_Story2()
    {
        side_story.Go_Side_Story();//휴오쟌 사이드 스토리 불러오는 거

        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
            //Go_Back_Main();
        }

        
    }

    public void Go_Main_Story1()
    {
        Main_story_1.Go_Main_Story_1();//메인스토리 1화 불러오는 거
        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
            //Go_Back_Main();
        }
    }

    public void Go_Main_Story2()
    {
        Main_story_2.Go_Main_Story_2();//메인스토리 2화 불러오는 거
        StartCoroutine(Closed_G_B_Main());

        IEnumerator Closed_G_B_Main()
        {
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void FixedUpdate()
    {
        //만약 휴오쟌의 별이 노란색이라면
        //
        if(side_story.Stars[1].activeSelf==true)
        {
            //0번째는 휴오쟌 사이드 스토리
            Story[2].SetActive(true);
        }

        if (side_story.Stars[0].activeSelf == true)
        {
            //하얀색이라면
            Story[2].SetActive(false);
        }


        //메인 스토리1화 별
        if (Main_story_1.Main_Story_1_Stars[1].activeSelf == true)
        {
            //1번째는 1화
            Story[0].SetActive(true);
        }

        if (Main_story_1.Main_Story_1_Stars[0].activeSelf == true)
        {
            //하얀색이라면
            Story[0].SetActive(false);
        }

        //메인 스토리2화 별
        if (Main_story_2.Main_Story_2_Stars[1].activeSelf == true)
        {
            //2번째는 2화
            Story[1].SetActive(true);
        }

        if (Main_story_2.Main_Story_2_Stars[0].activeSelf == true)
        {
            //하얀색이라면
            Story[1].SetActive(false);
        }

    }

    public void Show_Book_Mark()
    {
        //북마크로 들어가는 거
        Book_Mark_Anim.SetTrigger("Go_Left");
        mark.SetActive(true);

        b_btn.Hide_Bty();//0723추가
    }

    public void Go_Back_Main()
    {
        //북마크에서 메인으로 들어가는 거
        Book_Mark_Anim.SetTrigger("Go_Right");
        //mark.SetActive(false);
    }
}

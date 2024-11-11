using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Side1_5_Button : MonoBehaviour
{
    public Side_Story side_story;
    public Side_Story_1_1 side_story_1_1;
    public Side_Story_1_2 side_story_1_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //별 버튼에 대한 것




        //5페이지 버튼에 대한 거
        if (side_story.First_Side_Story_Object[0].activeSelf == true && (side_story.Current_Story_Page < 5 || side_story.Current_Story_Page > 5))
        {
            side_story.Page_5[1].SetActive(false);
            //Debug.Log("버튼 1");
        }

        else if (side_story.First_Side_Story_Object[0].activeSelf == true && side_story.Currnet_Page_Count_5 > 1)
        {
            side_story.Page_5[1].SetActive(true);

            //Debug.Log("버튼 3");
            if (side_story.Current_Story_Page < 5 || side_story.Current_Story_Page > 5)
            {
                side_story.Page_5[1].SetActive(false);
                //Debug.Log("버튼 3-1");
            }
        }

        else if (side_story.First_Side_Story_Object[0].activeSelf == false)
        {
            side_story.Page_5[1].SetActive(false);
        }

        //1-1
        if (side_story.First_Side_Story_Object[1].activeSelf == true && (side_story_1_1.Current_Story_Page < 16 || side_story_1_1.Current_Story_Page > 16) && side_story_1_1.Currnet_Page_Count_16 > 4)
        {
            side_story_1_1.Page_16[3].SetActive(false);
            //Debug.Log("버튼 16");
        }

        if (side_story_1_1.Current_Story_Page == 16 && side_story.First_Side_Story_Object[1].activeSelf == true && side_story_1_1.Currnet_Page_Count_16 == 4)
        {
            side_story_1_1.Page_16[3].SetActive(true);
            side_story_1_1.Page_Button[11].SetActive(false);
            //Debug.Log("버튼 16");
        }

        //이거 추가함
        if (side_story_1_1.Current_Story_Page == 16 && side_story.First_Side_Story_Object[1].activeSelf == true && (side_story_1_1.Currnet_Page_Count_16 > 4 && side_story_1_1.Currnet_Page_Count_16 < 9))
        {
            side_story_1_1.Page_16[3].SetActive(false);
            side_story_1_1.Page_Button[11].SetActive(true);
           // Debug.Log("버튼 8");
        }

        if (side_story_1_1.Page_16[3].activeSelf == true)
        {
            side_story_1_1.Page_Button[11].SetActive(false);
            //Debug.Log("버튼 16");
        }

        if (side_story_1_1.Current_Story_Page < 16 || side_story_1_1.Current_Story_Page > 16)
        {
            side_story_1_1.Page_16[3].SetActive(false);
            //Debug.Log("버튼 16");
        }

        if (side_story_1_1.Currnet_Page_Count_16 > 4)
        {
            side_story_1_1.Page_16[3].SetActive(false);
            //Debug.Log("버튼 16");
        }






        //1-2
        if (side_story.First_Side_Story_Object[2].activeSelf == true && (side_story_1_2.Current_Story_Page < 16 || side_story_1_2.Current_Story_Page > 16) && side_story_1_2.Currnet_Page_Count_16 > 4)
        {
            side_story_1_2.Page_16[3].SetActive(false);
            //Debug.Log("버튼 2-1-1");
        }

        if (side_story_1_2.Current_Story_Page == 16 && side_story.First_Side_Story_Object[2].activeSelf == true && side_story_1_2.Currnet_Page_Count_16 == 4)
        {
            side_story_1_2.Page_16[3].SetActive(true);
            side_story_1_2.Page_Button[11].SetActive(false);
            //Debug.Log("버튼 2-1-2");
        }

        //이거 추가함
        if (side_story_1_2.Current_Story_Page == 16 && side_story.First_Side_Story_Object[2].activeSelf == true && (side_story_1_2.Currnet_Page_Count_16 > 4 && side_story_1_2.Currnet_Page_Count_16 < 9))
        {
            side_story_1_2.Page_16[3].SetActive(false);
            side_story_1_2.Page_Button[11].SetActive(true);
            //Debug.Log("버튼 2-1-3");
        }

        if (side_story_1_2.Page_16[3].activeSelf == true)
        {
            side_story_1_2.Page_Button[11].SetActive(false);
            //Debug.Log("버튼 2-1-4");
        }

        if (side_story_1_2.Current_Story_Page < 16 || side_story_1_2.Current_Story_Page > 16)
        {
            side_story_1_2.Page_16[3].SetActive(false);
          //  Debug.Log("버튼 2-1-5");
        }

        if (side_story_1_2.Currnet_Page_Count_16 > 4)
        {
            side_story_1_2.Page_16[3].SetActive(false);
            //Debug.Log("버튼 2-1-6");
        }


    }

    
}

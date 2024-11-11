using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Main_S_1 : MonoBehaviour
{
    public Main_Stroy_1 main_story_1;

    // Update is called once per frame
    void Update()
    {
        //5페이지 버튼에 대한 거
        if (main_story_1.Main_Story_1_Object[0].activeSelf == true && (main_story_1.Current_Story_Page < 10 || main_story_1.Current_Story_Page > 10))
        {
            main_story_1.Page_10[0].SetActive(false);
            //Debug.Log("버튼 1");
        }

        else if (main_story_1.Main_Story_1_Object[0].activeSelf == true && main_story_1.Currnet_Page_Count_10 > 0)
        {
            main_story_1.Page_10[0].SetActive(true);

            //Debug.Log("버튼 3");
            if (main_story_1.Current_Story_Page < 10 || main_story_1.Current_Story_Page > 10)
            {
                main_story_1.Page_10[0].SetActive(false);
                //Debug.Log("버튼 3-1");
            }
        }

        else if (main_story_1.Main_Story_1_Object[0].activeSelf == false)
        {
            main_story_1.Page_10[0].SetActive(false);
        }
    }
}

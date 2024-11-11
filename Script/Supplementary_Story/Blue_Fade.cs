using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blue_Fade : MonoBehaviour
{
    public Animator Fade_In_Out;
    public GameObject Fade_BE;



  
    public void Go_Main_Blue_Empty()
    {
        Fade_BE.SetActive(true);
        Fade_In_Out.SetTrigger("Go_Blue");

        StartCoroutine(Show_Main());
        IEnumerator Show_Main()
        {
            yield return new WaitForSeconds(1.0f);
            
        }

        StartCoroutine(Go_Main_Blue_Empty());

        IEnumerator Go_Main_Blue_Empty()
        {
            yield return new WaitForSeconds(1.5f);
            Fade_In_Out.SetTrigger("Go_Empty");
        }

        StartCoroutine(Bye_Fade());
        IEnumerator Bye_Fade()
        {
            yield return new WaitForSeconds(3.5f);
            Fade_BE.SetActive(false);

        }
    }
}

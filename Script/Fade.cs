using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Animator Fade_In_Out;
    public GameObject Main;
    public GameObject Title;
    public GameObject Fade_BE;

    public Animator B_1;
    public Animator B_2;
    public Animator B_3;
    public Animator B_4;

    public GameObject B_1_obj;
    public GameObject B_2_obj;
    public GameObject B_3_obj;
    public GameObject B_4_obj;

    public GameObject Text_obj;


    public void Start()
    {
        Main.SetActive(false);
        Fade_BE.SetActive(false);

        B_1_obj.SetActive(true);
        B_1.SetTrigger("Show_B");
        StartCoroutine(Show_B_2());
        IEnumerator Show_B_2()
        {
            yield return new WaitForSeconds(0.5f);
            B_2_obj.SetActive(true);
            B_2.SetTrigger("Show_B");
            StartCoroutine(Show_B_3());
        }

        IEnumerator Show_B_3()
        {
            yield return new WaitForSeconds(0.5f);
            B_3_obj.SetActive(true);
            B_3.SetTrigger("Show_B");
            StartCoroutine(Show_B_4());


        }

        IEnumerator Show_B_4()
        {
            yield return new WaitForSeconds(0.5f);
            B_4_obj.SetActive(true);
            B_4.SetTrigger("Show_B");
            StartCoroutine(Show_Text());

        }

        IEnumerator Show_Text()
        {
            yield return new WaitForSeconds(0.5f);
            Text_obj.SetActive(true);


        }
    }

    public void Go_Main_Black_Empty()
    {
        Fade_BE.SetActive(true);
        Fade_In_Out.SetTrigger("Go_Black");

        StartCoroutine(Show_Main());
        IEnumerator Show_Main()
        {
            yield return new WaitForSeconds(1.0f);
            Title.SetActive(false);
            Main.SetActive(true);
        }

        StartCoroutine(Go_Main_Black_Empty());
        
        IEnumerator Go_Main_Black_Empty()
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

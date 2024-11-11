using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Letter : MonoBehaviour
{
    public B_Button b_btn;

    //오른쪽에서 왼쪽으로 오는 애니메이션
    public Animator Letter_R_L;

    public GameObject Inside_First_Letter;
    public GameObject Inside_Two_Letter;
    public GameObject Inside_Three_Letter;
    public GameObject Inside_Four_Letter;
    public GameObject Inside_Five_Letter;
    public GameObject Inside_Six_Letter;
    public GameObject Inside_Seven_Letter;

    public GameObject First_Letter;

    public GameObject Two_Letter;

    public GameObject Three_Letter;
    public GameObject Four_Letter;
    public GameObject Five_Letter;
    public GameObject Six_Letter;
    public GameObject Seven_Letter;

    //위치 좌표 얻어내고자..
    public RectTransform Letter_Frame;

    public RectTransform Letter_One;
    public RectTransform Letter_Two;
    public RectTransform Letter_Three;
    public RectTransform Letter_Four;
    public RectTransform Letter_Five;
    public RectTransform Letter_Six;
    public RectTransform Letter_Seven;



    private Vector3 Letter_One_Position = new Vector3(-17.9999f, 590.8f, 0);
    
    private Vector3 Letter_Two1_Position = new Vector3(-17.9999f, 362.3f, 0);
   
    private Vector3 Letter_Three_Position = new Vector3(-17.9999f, 136.9f, 0);
    private Vector3 Letter_Four_Position = new Vector3(-17.9999f, -92.2999f, 0);
    private Vector3 Letter_Five_Position = new Vector3(-17.9999f, -319.6f, 0);
    private Vector3 Letter_Six_Position = new Vector3(-17.9999f, -548.9998f, 0);
    private Vector3 Letter_Seven_Position = new Vector3(-17.9999f, -774.9999f, 0);


    public void Start()
    {
        Inside_First_Letter.SetActive(false);
        Inside_Two_Letter.SetActive(false);
        Inside_Three_Letter.SetActive(false);
        Inside_Four_Letter.SetActive(false);
        Inside_Five_Letter.SetActive(false);
        Inside_Six_Letter.SetActive(false);
        Inside_Seven_Letter.SetActive(false);



        //테스트중
        First_Letter.SetActive(true);
        Two_Letter.SetActive(false);

        Three_Letter.SetActive(false);
        Four_Letter.SetActive(false);
        Five_Letter.SetActive(false);
        Six_Letter.SetActive(false);
        Seven_Letter.SetActive(false);
    }

    public void Test()
    {
        //우편함 새로운 편지 나올 때마다 그게 위로 가게 하기

        //예시
        //우편함의 위치가 0, 0, 0일경우
        //1초마다 새로운 우편함 내용물이 생김
        //새로운 편지 나올 때마다 그게 위로 가게 하기

        StartCoroutine(One());
        IEnumerator One()
        {
            yield return new WaitForSeconds(1.0f);
            Two_Letter.SetActive(true);


            Letter_One.anchoredPosition3D = Letter_Two1_Position;
            Letter_Two.anchoredPosition3D = Letter_One_Position;


        }

        StartCoroutine(Two());
        IEnumerator Two()
        {
            yield return new WaitForSeconds(2.0f);
            Three_Letter.SetActive(true);

            Letter_One.anchoredPosition3D = Letter_Three_Position;
            Letter_Two.anchoredPosition3D = Letter_Two1_Position;
            Letter_Three.anchoredPosition3D = Letter_One_Position;
        }

        StartCoroutine(Three());
        IEnumerator Three()
        {
            yield return new WaitForSeconds(3.0f);
            Four_Letter.SetActive(true);

            Letter_One.anchoredPosition3D = Letter_Four_Position;
            Letter_Two.anchoredPosition3D = Letter_Three_Position;
            Letter_Three.anchoredPosition3D = Letter_Two1_Position;
            Letter_Four.anchoredPosition3D = Letter_One_Position;
        }

        StartCoroutine(Four());
        IEnumerator Four()
        {
            yield return new WaitForSeconds(4.0f);
            Five_Letter.SetActive(true);

            Letter_One.anchoredPosition3D = Letter_Five_Position;
            Letter_Two.anchoredPosition3D = Letter_Four_Position;
            Letter_Three.anchoredPosition3D = Letter_Three_Position;
            Letter_Four.anchoredPosition3D = Letter_Two1_Position;
            Letter_Five.anchoredPosition3D = Letter_One_Position;
        }

        StartCoroutine(Five());
        IEnumerator Five()
        {
            yield return new WaitForSeconds(5.0f);
            Six_Letter.SetActive(true);

            Letter_One.anchoredPosition3D = Letter_Six_Position;
            Letter_Two.anchoredPosition3D = Letter_Five_Position;
            Letter_Three.anchoredPosition3D = Letter_Four_Position;
            Letter_Four.anchoredPosition3D = Letter_Three_Position;
            Letter_Five.anchoredPosition3D = Letter_Two1_Position;
            Letter_Six.anchoredPosition3D = Letter_One_Position;
        }

        StartCoroutine(Six());
        IEnumerator Six()
        {
            yield return new WaitForSeconds(6.0f);
            Seven_Letter.SetActive(true);

            Letter_One.anchoredPosition3D = Letter_Seven_Position;
            Letter_Two.anchoredPosition3D = Letter_Six_Position;
            Letter_Three.anchoredPosition3D = Letter_Five_Position;
            Letter_Four.anchoredPosition3D = Letter_Four_Position;
            Letter_Five.anchoredPosition3D = Letter_Three_Position;
            Letter_Six.anchoredPosition3D = Letter_Two1_Position;
            Letter_Seven.anchoredPosition3D = Letter_One_Position;
        }
    }
   

    public void Go_Letter()
    {
        b_btn.Hide_Bty();//0723추가

        Letter_R_L.SetTrigger("Go_Left");
        Inside_First_Letter.SetActive(false);
        Inside_Two_Letter.SetActive(false);
        Inside_Three_Letter.SetActive(false);
        Inside_Four_Letter.SetActive(false);
        Inside_Five_Letter.SetActive(false);
        Inside_Six_Letter.SetActive(false);
        Inside_Seven_Letter.SetActive(false);
    }

    public void Go_Main()
    {
        Letter_R_L.SetTrigger("Go_Right");
    }


    public void Go_Back_Letter()
    {
        Inside_First_Letter.SetActive(false);
        Inside_Two_Letter.SetActive(false);
        Inside_Three_Letter.SetActive(false);
        Inside_Four_Letter.SetActive(false);
        Inside_Five_Letter.SetActive(false);
        Inside_Six_Letter.SetActive(false);
        Inside_Seven_Letter.SetActive(false);

    }

    public void Go_One_Letter()
    {
        Inside_First_Letter.SetActive(true);
    }

    public void Go_Two_Letter()
    {
        Inside_Two_Letter.SetActive(true);
    }

    public void Go_Three_Letter()
    {
        Inside_Three_Letter.SetActive(true);
    }

    public void Go_Four_Letter()
    {
        Inside_Four_Letter.SetActive(true);
    }

    public void Go_Five_Letter()
    {
        Inside_Five_Letter.SetActive(true);
    }

    public void Go_Six_Letter()
    {
        Inside_Six_Letter.SetActive(true);
    }

    public void Go_Seven_Letter()
    {
        Inside_Seven_Letter.SetActive(true);
    }
}

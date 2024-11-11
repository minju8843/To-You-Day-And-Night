using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butterfly : MonoBehaviour
{
    public GameObject[] objectArray;
    public GameObject[] objectArray1;

    public int numberOfObjects = 409;
    public int numberOfObjects1 = 409;

    public float delayBetweenSpawns = 0.002f;
    public float delayBetweenSpawns1 = 0.004f;

    public int currentIndex = 0;
    public int currentIndex1 = 0;

    public GameObject Main;
    public GameObject Supplementary_Story;//외전이라는 단어임
    public B_Button b_btn;

    public GameObject Y_B;//생길 때 쓸거
    public GameObject Y_B_1;//없앨때 쓸거


    //메인으로
    public void Go_Main()
    {
        CancelInvoke("Erease_Object");//InvokeRepeating을 멈춤
        CancelInvoke("ShowObject");//InvokeRepeating을 멈춤
        InvokeRepeating("Show", 0f, delayBetweenSpawns);

        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }

    private void Show()
    {
       

        if (currentIndex < numberOfObjects)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {

            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray[currentIndex];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(true);

            currentIndex++;
        }
        else//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 많은 경우
        {
            // numberOfObjects가 모두 생성되면 InvokeRepeating 중지
            CancelInvoke("Show");//InvokeRepeating을 멈춤
            Main.SetActive(true);
            Supplementary_Story.SetActive(false);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_B();

            }

        }
    }
    public void False_Up_B()
    {
        InvokeRepeating("E_Object", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //호출할 함수의 이름, 함수 호출까지 기다리는 시간, 함수 호출 사이의 간격
    }

    private void E_Object()
    {
        if (currentIndex1 < numberOfObjects1)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {

            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray1[currentIndex1];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("E_Object");//InvokeRepeating을 멈춤

        }
    }

    //총 408번까지 개수로는 409개







    // ***** 여기부터는 외전 들어갔을 때
    public void Down_Up_Butterfly()
    {
        CancelInvoke("Show");
        CancelInvoke("E_Object");
        InvokeRepeating("ShowObject", 0f, delayBetweenSpawns);
        //호출할 함수의 이름, 함수 호출까지 기다리는 시간, 함수 호출 사이의 간격
        
        Supplementary_Story.SetActive(false);
        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }


    //여기서 예비 나비 비활성화 시켜야함
    private void ShowObject()
    {
        if (currentIndex < numberOfObjects)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {
            
            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray[currentIndex];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(true);

            currentIndex++;
        }
        else//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 많은 경우
        {
            // numberOfObjects가 모두 생성되면 InvokeRepeating 중지
            CancelInvoke("ShowObject");//InvokeRepeating을 멈춤
            Main.SetActive(false);
            Supplementary_Story.SetActive(true);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_Butterfly();



            }
             
        }
    }

    //여기서 위에거 나비 다 비활성화 시켜야함
    public void False_Up_Butterfly()
    {
        InvokeRepeating("Erease_Object", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //호출할 함수의 이름, 함수 호출까지 기다리는 시간, 함수 호출 사이의 간격
    }

    private void Erease_Object()
    {
        if (currentIndex1 < numberOfObjects1)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {

            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray1[currentIndex1];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("Erease_Object");//InvokeRepeating을 멈춤

        }
    }


    //나비가 다 생기고, 다시 나비 후퇴. 이때 메인 화면 대신 외전 화면이 보인다.

    //그리고 나비가 후퇴하면 외전 화면이 없어지고 다시 메인 화면이 보인다.


    //0722 외전이 다 끝나면 메인화면으로 돌아간다
    //여기서 예비 나비 비활성화 시켜야함
    public void Down_Up_Butterfly_Go_Main()
    {
        CancelInvoke("Show_Go_Main");
        CancelInvoke("E_Object_Go_Main");
        InvokeRepeating("ShowObject_Go_Main", 0f, delayBetweenSpawns);
        //호출할 함수의 이름, 함수 호출까지 기다리는 시간, 함수 호출 사이의 간격

        b_btn.Buf_Story_Collection.SetActive(true);
        Y_B.SetActive(true);
        Y_B_1.SetActive(false);

        currentIndex = 0;
    }

    private void ShowObject_Go_Main()
    {
        if (currentIndex < numberOfObjects)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {

            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray[currentIndex];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(true);

            currentIndex++;
        }
        else//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 많은 경우
        {
            // numberOfObjects가 모두 생성되면 InvokeRepeating 중지
            CancelInvoke("ShowObject_Go_Main");//InvokeRepeating을 멈춤
            Main.SetActive(true);
            b_btn.Buf_Story_Collection.SetActive(false);


            Y_B.SetActive(false);
            Y_B_1.SetActive(true);


            for (int i = 0; i < 340; i++)
            {
                objectArray[i].SetActive(false);
            }

            for (int i = 0; i < 340; i++)
            {
                objectArray1[i].SetActive(true);
            }



            StartCoroutine(Wait_Second());
            IEnumerator Wait_Second()
            {
                yield return new WaitForSeconds(0.5f);

                False_Up_Butterfly_Go_Main();



            }

        }
    }

    //여기서 위에거 나비 다 비활성화 시켜야함
    public void False_Up_Butterfly_Go_Main()
    {
        InvokeRepeating("Erease_Object_Go_Main", 0f, delayBetweenSpawns1);
        currentIndex1 = 0;
        //호출할 함수의 이름, 함수 호출까지 기다리는 시간, 함수 호출 사이의 간격
    }

    private void Erease_Object_Go_Main()
    {
        if (currentIndex1 < numberOfObjects1)//현재 생성된 오브젝트 개수가 설정된 총 오브젝트의 수보다 작은 경우
        {

            // 배열에서 오브젝트 가져오기
            GameObject obj = objectArray1[currentIndex1];//배열에서 현재 인덱스에 해당하는 오브젝트를 가져와서 변수에 할당

            // 오브젝트 활성화
            obj.SetActive(false);

            currentIndex1++;
        }

        else
        {
            CancelInvoke("Erease_Object_Go_Main");//InvokeRepeating을 멈춤

        }
    }
}

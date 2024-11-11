using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class All_Loading : MonoBehaviour
{
    public Text targetTxt; //현재 텍스트
    public int defaultLength; //텍스트의 길이



    void Start()
    {

        StartCoroutine(LoadMainScene());
        defaultLength = targetTxt.text.Length; //현재 텍스트의 길이
        StartCoroutine(OnTyping()); //코루틴 부르기
        Debug.Log(defaultLength);
    }

    IEnumerator LoadMainScene()
    {
        //yield return null;
        //SceneManager.LoadScene("Main");

        //나중에 볼륨이 커질 때, 아래 거 해보자

        // 비동기적으로 Main 씬을 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            yield return new WaitForSeconds(2.0f);
            //yield return null;

            // 로딩이 거의 완료되면 활성화
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                yield break;
            }


            yield return null;
        }
    }




    IEnumerator OnTyping()
    {
        StringBuilder str = new StringBuilder(); // StringBuilder로 수정
        str.Append(targetTxt.text); //현재 텍스트 입력
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (str.Length > defaultLength + 2) //찍은 점들의 길이와 최대로 찍을 점의 개수
            {
                str.Remove(defaultLength, 3); //현재 텍스트를 제외하고 나머지 지우기
            }
            else
            {
                str.Append("."); //초마다 찍을 점
                targetTxt.text = str.ToString(); //텍스트에 표현
            }
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class All_Loading : MonoBehaviour
{

    
    public Text targetTxt; //현재 텍스트
    public int defaultLength; //텍스트의 길이

    void Start()
    {

        StartCoroutine(LoadMainScene());
        //defaultLength = targetTxt.text.Length; //현재 텍스트의 길이
        StartCoroutine(OnTyping()); //코루틴 부르기
    }

        IEnumerator LoadMainScene()
    {
        //yield return null;
        //SceneManager.LoadScene("Main");

        //나중에 볼륨이 커질 때, 아래 거 해보자

        // 비동기적으로 Main 씬을 로드
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            yield return new WaitForSeconds(5.0f);

            // 로딩이 거의 완료되면 활성화
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                yield break;
            }


           yield return null;
        }
    }




     IEnumerator OnTyping()
     {
         StringBuilder str = new StringBuilder(); // StringBuilder로 수정
        defaultLength = targetTxt.text.Length;
        str.Append(targetTxt.text); //현재 텍스트 입력
         while (true)
         {
             yield return new WaitForSeconds(0.5f);
             if (str.Length > defaultLength + 2) //찍은 점들의 길이와 최대로 찍을 점의 개수
             {
                 str.Remove(defaultLength, 3); //현재 텍스트를 제외하고 나머지 지우기
             }
             else
             {
                 str.Append("."); //초마다 찍을 점
                 targetTxt.text = str.ToString(); //텍스트에 표현
             }
         }
     }
}*/

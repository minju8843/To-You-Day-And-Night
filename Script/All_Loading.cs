using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class All_Loading : MonoBehaviour
{
    public Text targetTxt; //���� �ؽ�Ʈ
    public int defaultLength; //�ؽ�Ʈ�� ����



    void Start()
    {

        StartCoroutine(LoadMainScene());
        defaultLength = targetTxt.text.Length; //���� �ؽ�Ʈ�� ����
        StartCoroutine(OnTyping()); //�ڷ�ƾ �θ���
        Debug.Log(defaultLength);
    }

    IEnumerator LoadMainScene()
    {
        //yield return null;
        //SceneManager.LoadScene("Main");

        //���߿� ������ Ŀ�� ��, �Ʒ� �� �غ���

        // �񵿱������� Main ���� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Title");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            yield return new WaitForSeconds(2.0f);
            //yield return null;

            // �ε��� ���� �Ϸ�Ǹ� Ȱ��ȭ
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
        StringBuilder str = new StringBuilder(); // StringBuilder�� ����
        str.Append(targetTxt.text); //���� �ؽ�Ʈ �Է�
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (str.Length > defaultLength + 2) //���� ������ ���̿� �ִ�� ���� ���� ����
            {
                str.Remove(defaultLength, 3); //���� �ؽ�Ʈ�� �����ϰ� ������ �����
            }
            else
            {
                str.Append("."); //�ʸ��� ���� ��
                targetTxt.text = str.ToString(); //�ؽ�Ʈ�� ǥ��
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

    
    public Text targetTxt; //���� �ؽ�Ʈ
    public int defaultLength; //�ؽ�Ʈ�� ����

    void Start()
    {

        StartCoroutine(LoadMainScene());
        //defaultLength = targetTxt.text.Length; //���� �ؽ�Ʈ�� ����
        StartCoroutine(OnTyping()); //�ڷ�ƾ �θ���
    }

        IEnumerator LoadMainScene()
    {
        //yield return null;
        //SceneManager.LoadScene("Main");

        //���߿� ������ Ŀ�� ��, �Ʒ� �� �غ���

        // �񵿱������� Main ���� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            yield return new WaitForSeconds(5.0f);

            // �ε��� ���� �Ϸ�Ǹ� Ȱ��ȭ
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
         StringBuilder str = new StringBuilder(); // StringBuilder�� ����
        defaultLength = targetTxt.text.Length;
        str.Append(targetTxt.text); //���� �ؽ�Ʈ �Է�
         while (true)
         {
             yield return new WaitForSeconds(0.5f);
             if (str.Length > defaultLength + 2) //���� ������ ���̿� �ִ�� ���� ���� ����
             {
                 str.Remove(defaultLength, 3); //���� �ؽ�Ʈ�� �����ϰ� ������ �����
             }
             else
             {
                 str.Append("."); //�ʸ��� ���� ��
                 targetTxt.text = str.ToString(); //�ؽ�Ʈ�� ǥ��
             }
         }
     }
}*/

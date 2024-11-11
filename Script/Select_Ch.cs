using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]//������ ���� ���� �߰���
public class GameData_Select_Ch
{//����� ���� �����͸� �����ϴ� Ŭ����
    public int Aine_Index;
    public int Ren_Index;
    public int Jin_Index;
    public int Aiselle_Index;

}


public class Select_Ch : MonoBehaviour
{
    public B_Button b_btn;//0723 �߰�

    public Animator Black;
    public Animator Size;


    public GameObject Ch_Select;


    public RectTransform Jin_T;
    public RectTransform Aine_T;
    public RectTransform Ren_T;
    public RectTransform Aiselle_T;//������

    public Button Jin;
    public Button Aine;
    public Button Ren;
    public Button Aiselle;//������

    public Image Jin_Img;
    public Image Aine_Img;
    public Image Ren_Img;
    public Image Aiselle_Img;

    public GameObject Jin_Main;
    public GameObject Aine_Main;
    public GameObject Ren_Main;
    public GameObject Aiselle_Main;//������


    public Animator Aine_Anim;//����Ͽ����� ȣ���� ������ ���ܼ� �̰ɷ� �ٽ�
    public Animator Jin_Anim;
    public Animator Ren_Anim;
    public Animator Aiselle_Anim;

    //���� ����� ����...
    public int Aine_Default_Count = 0;
    public int Aine_Count;
    public int Current_Aine_Count;

    public int Jin_Default_Count = 0;
    public int Jin_Count;
    public int Current_Jin_Count;

    public int Ren_Default_Count = 0;
    public int Ren_Count;
    public int Current_Ren_Count;

    public int Aiselle_Default_Count = 0;
    public int Aiselle_Count;
    public int Current_Aiselle_Count;

    public void Select_Ch_ResetSettings()
    {
        PlayerPrefs.DeleteKey("Jin_Picture");
        PlayerPrefs.Save();
        Jin_Count = Jin_Default_Count;

        PlayerPrefs.DeleteKey("Ren_Picture");
        PlayerPrefs.Save();
        Ren_Count = Ren_Default_Count;

        PlayerPrefs.DeleteKey("Aine_Picture");
        PlayerPrefs.Save();
        Aine_Count = Aine_Default_Count;

        PlayerPrefs.DeleteKey("Aiselle_Picture");
        PlayerPrefs.Save();
        Aiselle_Count = Aiselle_Default_Count;

        if (Aiselle_Count == 0 && Jin_Count == 0 && Ren_Count == 0 && Aine_Count == 0)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

    }

    private void Start()
    {
        Ch_Select.SetActive(false);
        //�ϴ� ĳ���͵��� ���� �������� ������ο��� ��.
        /*Aine_Anim.SetTrigger("Stay");
        Jin_Anim.SetTrigger("Stay");
        Ren_Anim.SetTrigger("Stay");
        Aiselle_Anim.SetTrigger("Stay");
        */
        //1�϶��� ���ø� �Ǿ��� ��
        //2�� ���� �����ϰ� ��ư ������ ��

    }

    public void OnEnable()
    {
        Aine_LoadSettings();
        Jin_LoadSettings();
        Ren_LoadSettings();
        Aiselle_LoadSettings();

        if (Aine_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            //�������� 0�̳� 1�� ���

            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if (Ren_Count == 2 && (Aine_Count == 0 || Aine_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Jin_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Aine_Count == 0 || Aine_Count == 1) && (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Aiselle_Count == 2 && (Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aine_Count == 0 || Aine_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }

        if(Aiselle_Count == 0 && Jin_Count == 0 && Ren_Count == 0 && Aine_Count == 0)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if ((Ren_Count == 0 || Ren_Count == 1) && (Jin_Count == 0 || Jin_Count == 1) && (Aine_Count == 0 || Aine_Count == 1)&& (Aiselle_Count == 0 || Aiselle_Count == 1))
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }
    }

    public void Update()
    {
        Ch_Select_SaveSettings();

        Current_Aiselle_Count = Aiselle_Count;
        Current_Aine_Count = Aine_Count;
        Current_Ren_Count = Ren_Count;
        Current_Jin_Count = Jin_Count;
    }

    private void FixedUpdate()
    {
        /*if (Aine_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        if (Ren_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Jin_Count == 1)
        {
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        if (Aiselle_Count == 1)
        {
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }*/
    }


    public void Ch_Select_SaveSettings()
    {
        //���̳�
        GameData_Select_Ch Aine_data = new GameData_Select_Ch();
        Aine_data.Aine_Index = Aine_Count;

        string Aine_jsonData = JsonUtility.ToJson(Aine_data);
        PlayerPrefs.SetString("Aine_Picture", Aine_jsonData);
        PlayerPrefs.Save();

        //��
        GameData_Select_Ch Jin_data = new GameData_Select_Ch();
        Jin_data.Jin_Index = Jin_Count;

        string Jin_jsonData = JsonUtility.ToJson(Jin_data);
        PlayerPrefs.SetString("Jin_Picture", Jin_jsonData);
        PlayerPrefs.Save();

        //��
        GameData_Select_Ch Ren_data = new GameData_Select_Ch();
        Ren_data.Ren_Index = Ren_Count;

        string Ren_jsonData = JsonUtility.ToJson(Ren_data);
        PlayerPrefs.SetString("Ren_Picture", Ren_jsonData);
        PlayerPrefs.Save();

        //������
        GameData_Select_Ch Aiselle_data = new GameData_Select_Ch();
        Aiselle_data.Aiselle_Index = Aiselle_Count;

        string Aiselle_jsonData = JsonUtility.ToJson(Aiselle_data);
        PlayerPrefs.SetString("Aiselle_Picture", Aiselle_jsonData);
        PlayerPrefs.Save();
    }

    public void Aine_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Aine_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Aine_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Aine_Count = data.Aine_Index;
            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Aine_Count = Aine_Default_Count;
            //Aine_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Ren_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Ren_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Ren_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Ren_Count = data.Ren_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Ren_Count = Ren_Default_Count;
            //Ren_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Aiselle_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Aiselle_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Aiselle_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Aiselle_Count = data.Aiselle_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Aiselle_Count = Aiselle_Default_Count;
            //Aiselle_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }

    public void Jin_LoadSettings()
    {
        if (PlayerPrefs.HasKey("Jin_Picture"))
        {
            string jsonData = PlayerPrefs.GetString("Jin_Picture");
            GameData_Select_Ch data = JsonUtility.FromJson<GameData_Select_Ch>(jsonData);

            Jin_Count = data.Jin_Index;

            //Stars[Star_Count_5].SetActive(true);
        }

        else
        {
            Jin_Count = Jin_Default_Count;
            //Jin_Anim.SetTrigger("Stay");
            //Stars[Star_Count_5].SetActive(true);
        }

    }


    public void Select_Character()//ĳ���� �����ϸ� �� ĳ���� �޴��� ����
    {

        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Black.SetTrigger("Off");
            Size.SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);

            Ch_Select.SetActive(false);
            Debug.Log("�̰� �Ǵ��� Ȯ��");
        }
        //Ch_Select.SetActive(false);



        if (Mathf.Approximately(Aine_Img.color.r, 128 / 225f) && Mathf.Approximately(Aine_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Aine_Img.color.b, 96 / 225f))
        {
            //���̳װ� ���õǾ��ٸ�
            Aine_Count =2;

            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Ren_Img.color.r, 128 / 225f) && Mathf.Approximately(Ren_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Ren_Img.color.b, 96 / 225f))
        {
            Ren_Count = 2;

            //���� ���õǾ��ٸ�
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Jin_Img.color.r, 128 / 225f) && Mathf.Approximately(Jin_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Jin_Img.color.b, 96 / 225f))
        {
            Jin_Count = 2;

            //���� ���õǾ��ٸ�
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
        }

        else if (Mathf.Approximately(Aiselle_Img.color.r, 128 / 225f) && Mathf.Approximately(Aiselle_Img.color.g, 113 / 225f) &&
            Mathf.Approximately(Aiselle_Img.color.b, 96 / 225f))
        {
            Aiselle_Count = 2;

            //�������� ���õǾ��ٸ�
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
        }
    }

    public void Go_Select_Color()//��ư �ƹ��͵� ������ �ʾ��� ��, ���� ������ ����
    {
        b_btn.Hide_Bty();//0723�߰�


        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Ch_Select.SetActive(true);
            Black.SetTrigger("On");
            Size.SetTrigger("Up");
            yield return new WaitForSeconds(0.06f);
            
            
            Debug.Log("�̰� �Ǵ��� Ȯ��2");
        }

        //ĳ���� ���� â���� ���� ��
        //Black.SetTrigger("On");
        //Size.SetTrigger("Up");


        Aine_Count = 0;
        Jin_Count = 0;
        Ren_Count = 0;
        Aiselle_Count = 0;

        //Ch_Select.SetActive(true);

        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;
    }

    public void Go_Back()
    {

        StartCoroutine(Wait());
        IEnumerator Wait()
        {
            Black.SetTrigger("Off");
            Size.SetTrigger("Down");
            yield return new WaitForSeconds(0.05f);
            
            Ch_Select.SetActive(false);
            Debug.Log("�̰� �Ǵ��� Ȯ��");
        }

        

        
        //���� ȭ�鿡 ���� ���� �ִ� �Ÿ� �׷��� �����ϸ鼭
        //�ش� ĳ������ �ε����� 2�� ����
        //�׸��� �ִϸ��̼� �� �����̷� ����

        if(Aine_Main.activeSelf==true)
        {
            Aine_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(true);
            Aiselle_Main.SetActive(false);
           // Aine_Anim.SetTrigger("Stay");
           // Jin_Anim.SetTrigger("Stay");
           // Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Jin_Main.activeSelf == true)
        {
            Jin_Count = 2;
            Jin_Main.SetActive(true);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Ren_Main.activeSelf == true)
        {
            Ren_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(true);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(false);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }

        if (Aiselle_Main.activeSelf == true)
        {
            Aiselle_Count = 2;
            Jin_Main.SetActive(false);
            Ren_Main.SetActive(false);
            Aine_Main.SetActive(false);
            Aiselle_Main.SetActive(true);
            //Aine_Anim.SetTrigger("Stay");
            //Jin_Anim.SetTrigger("Stay");
            //Ren_Anim.SetTrigger("Stay");
            //Aiselle_Anim.SetTrigger("Stay");
        }


        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;
    }

    public void Coose_Jin()
    {

        //���� ������ ��
        //ī��Ʈ 1�� �����
        //������ ��� ī��Ʈ 0���� �����

        //���� ������ �ϳ� ī��Ʈ�� 1�̾�����, �װ� 0���� ����鼭
        //ũ�� �پ��� �ִϸ��̼� ���
        Jin_Count = 1;

        if(Ren_Count==1)
        {
            Jin_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Ren_Count = 0;
        }

        if (Aine_Count == 1)
        {
            Jin_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Jin_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 1)
        {
            Jin_Count = 1;
            Jin_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Jin_Count = 1;
            Jin_Anim.SetTrigger("Up");
        }


        //����� ������ ��� �ڵ�
        /*if(Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Ren_Anim.SetTrigger("Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Down");
            Jin_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)&&
            Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Jin_Anim.SetTrigger("Up");
        }*/


        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Jin_Img.color;

        Jin_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Jin = Aine_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //���� �� ��ư �� �ٲ�

        //�ٸ� �� ���� ������ ���ƿ�
        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
        Jin.colors = color_Jin;


        //
        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;


        if (Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Jin1 = Jin.colors;
            color_Jin1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
            Jin.colors = color_Jin1;

            //


           /* Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);

            */
            

            //

            /*ColorBlock color_Ren = Ren.colors;
            color_Ren.highlightedColor = new Color(192, 176, 157, 225);
            Ren.colors = color_Ren;

            ColorBlock color_Aiselle = Aiselle.colors;
            color_Aiselle.highlightedColor = new Color(192, 176, 157, 225);
            Aiselle.colors = color_Aiselle;

            ColorBlock color_Aine = Aine.colors;
            color_Aine.highlightedColor = new Color(192, 176, 157, 225);
            Aine.colors = color_Aine;*/
        }


    }


    public void Coose_Aine()
    {
        Aine_Count = 1;

        if (Ren_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Debug.Log("���̾��ٰ� ���̳� ����ǳ�?");
            Ren_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Debug.Log("���̾��ٰ� ���̳� ����ǳ�?");
            Jin_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Aine_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Debug.Log("�������̾��ٰ� ���̳� ����ǳ�?");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 1
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aine_Count = 1;
            Aine_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aine_Count = 1;
            Aine_Anim.SetTrigger("Up");
        }

        /* if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Jin_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Ren_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
         {
             Aiselle_Anim.SetTrigger("Down");
             Aine_Anim.SetTrigger("Size_Up");
         }

         else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
             && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
             && Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
         {
             Aine_Anim.SetTrigger("Size_Up");
         }*/

        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Aine_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //���� �� ��ư �� �ٲ�

        //�ٸ� �� ���� ������ ���ƿ�
        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
        Aine.colors = color_Aine;


        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;


        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;



        if (Mathf.Approximately(ImageColor_Jin.r, 255/225f)&& Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) && 
            Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Aine1 = Aine.colors;
            color_Aine1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
            Aine.colors = color_Aine1;

            /*ColorBlock color_Jin = Jin.colors;
            color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);//�̰� ���̶���Ʈ ��
            Jin.colors = color_Jin;

            ColorBlock color_Ren = Ren.colors;
            color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
            Ren.colors = color_Ren;

            ColorBlock color_Aiselle = Aiselle.colors;
            color_Aiselle.highlightedColor = new Color(192/ 225f, 176 / 225f, 157 / 225f, 225 / 225f);
            Aiselle.colors = color_Aiselle;*/
        }

        
    }

    

        public void Coose_Ren()
    {
        Ren_Count = 1;

        if (Aine_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Jin_Count = 0;
        }

        if (Aiselle_Count == 1)
        {
            Ren_Anim.SetTrigger("Up");
            Aiselle_Anim.SetTrigger("Down");
            Aiselle_Count = 0;
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 1 && Jin_Count == 0)
        {
            Ren_Count = 1;
            Ren_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Ren_Count = 1;
            Ren_Anim.SetTrigger("Up");
        }

        /*if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Jin_Anim.SetTrigger("Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Down");
            Ren_Anim.SetTrigger("Up");
        }

        else if (Aiselle_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Ren_Anim.SetTrigger("Up");
        }*/



        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Ren_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Aiselle_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //���� �� ��ư �� �ٲ�

        //�ٸ� �� ���� ������ ���ƿ�
        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
        Ren.colors = color_Ren;

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aiselle.colors = color_Aiselle;

        if (Mathf.Approximately(ImageColor_Jin.r, 255 / 225f) && Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aine.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aiselle.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aiselle.b, 255 / 225f))
        {
            ColorBlock color_Ren1 = Ren.colors;
            color_Ren1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
            Ren.colors = color_Ren1;

        }


    }

    public void Coose_Aiselle()
    {
        Aiselle_Count = 1;

        if (Aine_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Aine_Anim.SetTrigger("Down");
            Aine_Count = 0;
        }

        if (Jin_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Jin_Anim.SetTrigger("Down");
            Jin_Count = 0;
        }

        if (Ren_Count == 1)
        {
            Aiselle_Anim.SetTrigger("Up");
            Ren_Anim.SetTrigger("Down");
            Ren_Count = 0;
        }

        if (Aiselle_Count == 1 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aiselle_Count = 1;
            Aiselle_Anim.SetTrigger("Up");
        }

        if (Aiselle_Count == 0 && Aine_Count == 0
            && Ren_Count == 0 && Jin_Count == 0)
        {
            Aiselle_Count = 1;
            Aiselle_Anim.SetTrigger("Up");
        }

        /*if (Jin_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Jin_Anim.SetTrigger("Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if (Aine_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Aine_Anim.SetTrigger("Size_Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if (Ren_T.localScale == new Vector3(0.8f, 0.8f, 1.0f))
        {
            Ren_Anim.SetTrigger("Down");
            Aiselle_Anim.SetTrigger("Up");
        }

        else if(Ren_T.localScale == new Vector3(0.7f, 0.7f, 1.0f) && Jin_T.localScale == new Vector3(0.7f, 0.7f, 1.0f)
            && Aine_T.localScale == new Vector3(0.7f, 0.7f, 1.0f))
        {
            Aiselle_Anim.SetTrigger("Up");
        }*/



        Jin_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Jin = Jin_Img.color;

        Ren_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Ren = Ren_Img.color;

        Aine_Img.color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
        Color ImageColor_Aine = Aine_Img.color;

        Aiselle_Img.color = new Color(128 / 225f, 113 / 225f, 96 / 225f);
        Color ImageColor_Aiselle = Aiselle_Img.color;

        //���� �� ��ư �� �ٲ�

        //�ٸ� �� ���� ������ ���ƿ�
        ColorBlock color_Aiselle = Aiselle.colors;
        color_Aiselle.highlightedColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
        Aiselle.colors = color_Aiselle;

        ColorBlock color_Jin = Jin.colors;
        color_Jin.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Jin.colors = color_Jin;

        ColorBlock color_Aine = Aine.colors;
        color_Aine.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Aine.colors = color_Aine;

        ColorBlock color_Ren = Ren.colors;
        color_Ren.highlightedColor = new Color(192 / 225f, 176 / 225f, 157 / 225f, 225 / 225f);
        Ren.colors = color_Ren;


        if (Mathf.Approximately(ImageColor_Jin.r, 255 / 225f) && Mathf.Approximately(ImageColor_Jin.g, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Jin.b, 255 / 225f) &&
            Mathf.Approximately(ImageColor_Aine.r, 255 / 225f) && Mathf.Approximately(ImageColor_Aine.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Aine.b, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.r, 255 / 225f) && Mathf.Approximately(ImageColor_Ren.g, 255 / 225f)
            && Mathf.Approximately(ImageColor_Ren.b, 255 / 225f))
        {
            ColorBlock color_Aiselle1 = Aiselle.colors;
            color_Aiselle1.normalColor = new Color(128 / 225f, 113 / 225f, 96 / 225f, 225 / 225f);//�̰� ������ �� ����
            Aiselle.colors = color_Aiselle1;

   
        }


    }


}

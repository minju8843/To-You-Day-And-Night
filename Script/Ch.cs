using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch : MonoBehaviour
{
    public B_Button b_btn;

    public GameObject[] Aine_Change;


    public RectTransform ch;//컨테이너

    public Animator Ch_R_L;
    public Animator[] Ch_R_L_Inside;//캐릭터 눌렀을 때, 캐릭터 설명을 볼 수 있게 하는 거


    public GameObject One;//아이네
    public GameObject Two;//렌
    public GameObject Three;//진
    public GameObject Four;//아이젤
    public GameObject Five;//하레이스
    public GameObject Six;//루시세리나
    public GameObject Seven;//아자르
    public GameObject Eight;//리베나

    public GameObject[] Ch_Hide;//아직 등장하지 않아 볼 수 없는 캐릭터

    public GameObject[] One_Ch_Inside;//캐릭터별로 안애 들어있는 인물 소개 페이지 수가 다름
    public GameObject[] Two_Ch_Inside;
    public GameObject[] Three_Ch_Inside;
    public GameObject[] Four_Ch_Inside;
    public GameObject[] Five_Ch_Inside;
    public GameObject[] Six_Ch_Inside;
    public GameObject[] Seven_Ch_Inside;
    public GameObject[] Eight_Ch_Inside;

    public GameObject[] One_Ch_Inside_1;//아이네 그림
    public GameObject[] One_Ch_Inside_2;//렌 그림
    public GameObject[] One_Ch_Inside_3;//진 그림
    public GameObject[] One_Ch_Inside_4;//아이젤 그림
    public GameObject[] One_Ch_Inside_5;//하레이스 그림
    public GameObject[] One_Ch_Inside_6;//루시세리나 그림
    public GameObject[] One_Ch_Inside_7;//아자르 그림
    public GameObject[] One_Ch_Inside_8;//리베나 그림


    public int First_currentIndex = 0;
    public int Two_currentIndex = 0;
    public int Three_currentIndex = 0;
    public int Four_currentIndex = 0;
    public int Five_currentIndex = 0;
    public int Six_currentIndex = 0;
    public int Seven_currentIndex = 0;
    public int Eight_currentIndex = 0;


    public GameObject One_Ch_Inside_L_Button;
    public GameObject One_Ch_Inside_R_Button;

    public GameObject Two_Ch_Inside_L_Button;//렌
    public GameObject Two_Ch_Inside_R_Button;

    public GameObject Three_Ch_Inside_L_Button;
    public GameObject Three_Ch_Inside_R_Button;//진

    public GameObject Four_Ch_Inside_L_Button;
    public GameObject Four_Ch_Inside_R_Button;//아이젤

    public GameObject Six_Ch_Inside_L_Button;//루시세리나
    public GameObject Six_Ch_Inside_R_Button;


    public void Update()
    {

        if(One_Ch_Inside[0].activeSelf==true|| One_Ch_Inside[1].activeSelf == true|| One_Ch_Inside[2].activeSelf == true|| One_Ch_Inside_1[4].activeSelf == true)
        {
            One_Ch_Inside_1[6].SetActive(false);
        }

        else if(One_Ch_Inside_1[5].activeSelf==true)
        {
            One_Ch_Inside_1[6].SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (First_currentIndex == One_Ch_Inside.Length - 1)
        {
            //현재3, 내가 만든것 4-1

            One_Ch_Inside_R_Button.SetActive(false);
            One_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("되나 확인");

            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
        }

        else if (First_currentIndex <= 0)
        {
            One_Ch_Inside_L_Button.SetActive(false);
            One_Ch_Inside_R_Button.SetActive(true);
            First_currentIndex = 0;

            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
        }

        else if (First_currentIndex < One_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            One_Ch_Inside_R_Button.SetActive(true);
            One_Ch_Inside_L_Button.SetActive(true);
        }

        else if (First_currentIndex > One_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            One_Ch_Inside_R_Button.SetActive(false);
            One_Ch_Inside_L_Button.SetActive(true);

        }

        else if (First_currentIndex > 0)
        {
            One_Ch_Inside_L_Button.SetActive(true);
            //현재3. 내가 만든 것의 길이는4
        }


        //렌


        //경우의 수

        // 1) 인덱스가 0이거나 0보다 작다면 -> 왼쪽 버튼 없애기
        // 2) 인덱스가 내가 설정해놓은 길이-1와 같거나 크다면 -> 오른쪽 버튼 없애기
        // 3) 인덱스가 내가 설정해놓은 길이보다 작다면


        if (Two_currentIndex == Two_Ch_Inside.Length - 1)
        {
            //현재3, 내가 만든것 4-1

            Two_Ch_Inside_R_Button.SetActive(false);
            Two_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("되나 확인");

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }

        else if (Two_currentIndex <= 0)
        {
            Two_Ch_Inside_L_Button.SetActive(false);
            Two_Ch_Inside_R_Button.SetActive(true);
            Two_currentIndex = 0;

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }

        else if (Two_currentIndex < Two_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            Two_Ch_Inside_R_Button.SetActive(true);
            Two_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Two_currentIndex > Two_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            Two_Ch_Inside_R_Button.SetActive(false);
            Two_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Two_currentIndex > 0)
        {
            Two_Ch_Inside_L_Button.SetActive(true);
            //현재3. 내가 만든 것의 길이는4
        }

        //진
        if (Three_currentIndex == Three_Ch_Inside.Length - 1)
        {
            //현재3, 내가 만든것 4-1

            Three_Ch_Inside_R_Button.SetActive(false);
            Three_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("되나 확인");

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }

        else if (Three_currentIndex <= 0)
        {
            Three_Ch_Inside_L_Button.SetActive(false);
            Three_Ch_Inside_R_Button.SetActive(true);
            Three_currentIndex = 0;

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }

        else if (Three_currentIndex < Three_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            Three_Ch_Inside_R_Button.SetActive(true);
            Three_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Three_currentIndex > Three_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            Three_Ch_Inside_R_Button.SetActive(false);
            Three_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Three_currentIndex > 0)
        {
            Three_Ch_Inside_L_Button.SetActive(true);
            //현재3. 내가 만든 것의 길이는4
        }

        //아이젤
        if (Four_currentIndex == Four_Ch_Inside.Length - 1)
        {
            //현재3, 내가 만든것 4-1

            Four_Ch_Inside_R_Button.SetActive(false);
            Four_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("되나 확인");

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }

        else if (Four_currentIndex <= 0)
        {
            Four_Ch_Inside_L_Button.SetActive(false);
            Four_Ch_Inside_R_Button.SetActive(true);
            Four_currentIndex = 0;

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }

        else if (Four_currentIndex < Four_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            Four_Ch_Inside_R_Button.SetActive(true);
            Four_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Four_currentIndex > Four_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            Four_Ch_Inside_R_Button.SetActive(false);
            Four_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Four_currentIndex > 0)
        {
            Four_Ch_Inside_L_Button.SetActive(true);
            //현재3. 내가 만든 것의 길이는4
        }

        //루시세리나
        if (Six_currentIndex == Six_Ch_Inside.Length - 1)
        {
            //현재3, 내가 만든것 4-1

            Six_Ch_Inside_R_Button.SetActive(false);
            Six_Ch_Inside_L_Button.SetActive(true);
            Debug.Log("되나 확인");

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }

        else if (Six_currentIndex <= 0)
        {
            Six_Ch_Inside_L_Button.SetActive(false);
            Six_Ch_Inside_R_Button.SetActive(true);
            Six_currentIndex = 0;

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }

        else if (Six_currentIndex < Six_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            Six_Ch_Inside_R_Button.SetActive(true);
            Six_Ch_Inside_L_Button.SetActive(true);
        }

        else if (Six_currentIndex > Six_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            Six_Ch_Inside_R_Button.SetActive(false);
            Six_Ch_Inside_L_Button.SetActive(true);

        }

        else if (Six_currentIndex > 0)
        {
            Six_Ch_Inside_L_Button.SetActive(true);
            //현재3. 내가 만든 것의 길이는4
        }

    }

    //여기부터
    public void Go_Character()
    {
        b_btn.Hide_Bty();//0723추가

        Ch_R_L.SetTrigger("Go_Left");

        ch.offsetMin = new Vector2(0, -882.4295f);//left, bottom
        ch.offsetMax = new Vector2(0, 0.001525879f);//-right, -top
    }

    public void Go_Main()
    {
        Ch_R_L.SetTrigger("Go_Right");
    }

    //여기까지는 수정하지마
    
    public void Go_Ch_Select_1()
    {
        Ch_R_L_Inside[0].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_2()
    {
        Ch_R_L_Inside[1].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_3()
    {
        Ch_R_L_Inside[2].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_4()
    {
        Ch_R_L_Inside[3].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_5()
    {
        Ch_R_L_Inside[4].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_6()
    {
        Ch_R_L_Inside[5].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_7()
    {
        Ch_R_L_Inside[6].SetTrigger("Go_Right");

    }

    public void Go_Ch_Select_8()
    {
        Ch_R_L_Inside[7].SetTrigger("Go_Right");

    }

    public void Go_Five_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[4].SetTrigger("Go_Left");
        Five_Ch_Inside[0].SetActive(true);
        Five_currentIndex = 0;
    }

    public void Go_Seven_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[6].SetTrigger("Go_Left");
        Seven_Ch_Inside[0].SetActive(true);
        Seven_currentIndex = 0;
    }

    public void Go_Eight_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[7].SetTrigger("Go_Left");
        Eight_Ch_Inside[0].SetActive(true);
        Eight_currentIndex = 0;
    }


    public void Go_First_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[0].SetTrigger("Go_Left");

        One_Ch_Inside[0].SetActive(true);
        First_currentIndex = 0;

        for(int i=1; i<One_Ch_Inside.Length; i++)
        {
            One_Ch_Inside[i].SetActive(false);
        }

        One_Ch_Inside_L_Button.SetActive(false);
        One_Ch_Inside_R_Button.SetActive(true);

    }

    public void First_Right_Inside()//오른쪽으로 갈 때 애니메이션
    {
        if(First_currentIndex < One_Ch_Inside.Length-1)//현재 인덱스가 배열의 길이보다 작으면
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            First_currentIndex++;

            foreach(GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);
            //현재 인덱스에 해당되는 것만 활성화

            if (One_Ch_Inside_1[5].activeSelf == true && One_Ch_Inside[3].activeSelf==true)
            {
                One_Ch_Inside_1[6].SetActive(true);//전생 보는거
            }

            //
           
        }

        else if(First_currentIndex > One_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            First_currentIndex = One_Ch_Inside.Length-1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);

           
        }


    }

    public void First_Left_Inside()//왼쪽으로 갈 때 애니메이션
    {
        if (First_currentIndex < One_Ch_Inside.Length)//현재 인덱스가 배열의 길이보다 작으면
        {



            if(First_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //현재3. 내가 만든 것의 길이는4

                First_currentIndex--;

                foreach (GameObject obj in One_Ch_Inside)
                {
                    obj.SetActive(false);//내용물 모두 비활성
                }

                One_Ch_Inside[First_currentIndex].SetActive(true);
            }

            


        }

        

        else if(First_currentIndex > One_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //현재5, 내가 만든 거 4
            First_currentIndex = One_Ch_Inside.Length - 1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            One_Ch_Inside[First_currentIndex].SetActive(true);

        }
    }

    //렌
    public void Go_Second_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[1].SetTrigger("Go_Left");

        Two_Ch_Inside[0].SetActive(true);
        Two_currentIndex = 0;

        for (int i = 1; i < Two_Ch_Inside.Length; i++)
        {
            Two_Ch_Inside[i].SetActive(false);
        }

        Two_Ch_Inside_L_Button.SetActive(false);
        Two_Ch_Inside_R_Button.SetActive(true);

    }

    public void Two_Right_Inside()//오른쪽으로 갈 때 애니메이션
    {
        if (Two_currentIndex < Two_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex++;

            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
            //현재 인덱스에 해당되는 것만 활성화
        }

        else if (Two_currentIndex > Two_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);
        }


    }

    public void Two_Left_Inside()//왼쪽으로 갈 때 애니메이션
    {
        if (Two_currentIndex < Two_Ch_Inside.Length)//현재 인덱스가 배열의 길이보다 작으면
        {

            if (Two_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //현재3. 내가 만든 것의 길이는4

                Two_currentIndex--;

                foreach (GameObject obj in Two_Ch_Inside)
                {
                    obj.SetActive(false);//내용물 모두 비활성
                }

                Two_Ch_Inside[Two_currentIndex].SetActive(true);
            }


        }



        else if (Two_currentIndex > Two_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //현재5, 내가 만든 거 4
            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[Two_currentIndex].SetActive(true);

        }

        else if (Two_currentIndex == Two_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Two_currentIndex = Two_Ch_Inside.Length - 1;


            foreach (GameObject obj in Two_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Two_Ch_Inside[First_currentIndex].SetActive(true);
        }
    }

    //진
    public void Go_Three_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[2].SetTrigger("Go_Left");

        Three_Ch_Inside[0].SetActive(true);
        Three_currentIndex = 0;

        for (int i = 1; i < Three_Ch_Inside.Length; i++)
        {
            Three_Ch_Inside[i].SetActive(false);
        }

        Three_Ch_Inside_L_Button.SetActive(false);
        Three_Ch_Inside_R_Button.SetActive(true);

    }

    public void Three_Right_Inside()//오른쪽으로 갈 때 애니메이션
    {
        if (Three_currentIndex < Three_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Three_currentIndex++;

            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
            //현재 인덱스에 해당되는 것만 활성화
        }

        else if (Three_currentIndex > Three_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Three_currentIndex = Three_Ch_Inside.Length - 1;


            foreach (GameObject obj in One_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Three_Ch_Inside[Three_currentIndex].SetActive(true);
        }


    }

    public void Three_Left_Inside()//왼쪽으로 갈 때 애니메이션
    {
        if (Three_currentIndex < Three_Ch_Inside.Length)//현재 인덱스가 배열의 길이보다 작으면
        {



            if (Three_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //현재3. 내가 만든 것의 길이는4

                Three_currentIndex--;

                foreach (GameObject obj in Three_Ch_Inside)
                {
                    obj.SetActive(false);//내용물 모두 비활성
                }

                Three_Ch_Inside[Three_currentIndex].SetActive(true);
            }




        }



        else if (Three_currentIndex > Three_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //현재5, 내가 만든 거 4
            Three_currentIndex = Three_Ch_Inside.Length - 1;


            foreach (GameObject obj in Three_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Three_Ch_Inside[First_currentIndex].SetActive(true);

        }
    }

    //아이젤
    public void Go_Four_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[3].SetTrigger("Go_Left");

        Four_Ch_Inside[0].SetActive(true);
        Four_currentIndex = 0;

        for (int i = 1; i < Four_Ch_Inside.Length; i++)
        {
            Four_Ch_Inside[i].SetActive(false);
        }

        Four_Ch_Inside_L_Button.SetActive(false);
        Four_Ch_Inside_R_Button.SetActive(true);

    }

    public void Four_Right_Inside()//오른쪽으로 갈 때 애니메이션
    {
        if (Four_currentIndex < Four_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Four_currentIndex++;

            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
            //현재 인덱스에 해당되는 것만 활성화
        }

        else if (Four_currentIndex > Four_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Four_currentIndex = Four_Ch_Inside.Length - 1;


            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);
        }


    }

    public void Four_Left_Inside()//왼쪽으로 갈 때 애니메이션
    {
        if (Four_currentIndex < Four_Ch_Inside.Length)//현재 인덱스가 배열의 길이보다 작으면
        {



            if (Four_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //현재3. 내가 만든 것의 길이는4

                Four_currentIndex--;

                foreach (GameObject obj in Four_Ch_Inside)
                {
                    obj.SetActive(false);//내용물 모두 비활성
                }

                Four_Ch_Inside[Four_currentIndex].SetActive(true);
            }




        }



        else if (Four_currentIndex > Four_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //현재5, 내가 만든 거 4
            Four_currentIndex = Four_Ch_Inside.Length - 1;


            foreach (GameObject obj in Four_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Four_Ch_Inside[Four_currentIndex].SetActive(true);

        }
    }

    //루시세리나 Six
    public void Go_Six_Inside()//첫 번째 캐릭터 내부 들어갈 때 애니메이션
    {
        Ch_R_L_Inside[5].SetTrigger("Go_Left");

        Six_Ch_Inside[0].SetActive(true);
        Six_currentIndex = 0;

        for (int i = 1; i < Six_Ch_Inside.Length; i++)
        {
            Six_Ch_Inside[i].SetActive(false);
        }

        Six_Ch_Inside_L_Button.SetActive(false);
        Six_Ch_Inside_R_Button.SetActive(true);

    }

    public void Six_Right_Inside()//오른쪽으로 갈 때 애니메이션
    {
        if (Six_currentIndex < Six_Ch_Inside.Length - 1)//현재 인덱스가 배열의 길이보다 작으면
        {
            //One_Ch_Inside_R_Button.SetActive(true);
            //One_Ch_Inside_L_Button.SetActive(true);

            Six_currentIndex++;

            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
            //현재 인덱스에 해당되는 것만 활성화
        }

        else if (Six_currentIndex > Six_Ch_Inside.Length - 1)
        {
            //현재4, 내가 만든것 4-1

            //One_Ch_Inside_R_Button.SetActive(false);
            //One_Ch_Inside_L_Button.SetActive(true);

            Six_currentIndex = Six_Ch_Inside.Length - 1;


            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);
        }


    }

    public void Six_Left_Inside()//왼쪽으로 갈 때 애니메이션
    {
        if (Six_currentIndex < Six_Ch_Inside.Length)//현재 인덱스가 배열의 길이보다 작으면
        {



            if (Six_currentIndex > 0)
            {
                //One_Ch_Inside_L_Button.SetActive(true);
                //현재3. 내가 만든 것의 길이는4

                Six_currentIndex--;

                foreach (GameObject obj in Six_Ch_Inside)
                {
                    obj.SetActive(false);//내용물 모두 비활성
                }

                Six_Ch_Inside[Six_currentIndex].SetActive(true);
            }




        }



        else if (Six_currentIndex > Six_Ch_Inside.Length)
        {
            //One_Ch_Inside_L_Button.SetActive(true);

            //현재5, 내가 만든 거 4
            Six_currentIndex = Six_Ch_Inside.Length - 1;


            foreach (GameObject obj in Six_Ch_Inside)
            {
                obj.SetActive(false);//내용물 모두 비활성
            }

            Six_Ch_Inside[Six_currentIndex].SetActive(true);

        }
    }

}

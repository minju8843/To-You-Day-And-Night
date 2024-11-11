using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Button : MonoBehaviour
{
    public Butterfly bty;//��ư �ٷ� Ŭ���ϸ� ���� �ٷ� �� ���̰�

    public Fade fade;
    public GameObject Buf_Main_Collection;//����ȭ�� �׸���
    public GameObject Buf_Story_Collection;//���� ���丮 ���빰��

    //���丮 ���õ� ��
    public Typing typ;
    public Typing_1 typ1;
    public Typing_2 typ2;

    public Find_Something find;
    public Find_Something1 find1;
    public Find_Something2 find2;
    public Find_Something3 find3;
    public Find_Something4 find4;

    public Item item;
    public Butt_Ch b_ch;

    //���� ���� �� ������ ����ȭ������ ���ư��� ��
    public void Hide_Bty()
    {

        for (int i = 0; i < bty.objectArray1.Length; i++)
        {
            bty.objectArray1[i].SetActive(false);
        }

        for (int i = 0; i < bty.objectArray.Length; i++)
        {
            bty.objectArray[i].SetActive(false);
        }

        bty.Y_B.SetActive(false);
        bty.Y_B_1.SetActive(true);
    }


    //���� ����
    public void Go_B_Story()
    {
        //���⿡ �����ϴ� �� ����� ��
        //Buf_Main_Collection -> ���� ���� ȭ��(���̳� ��, ��)
        //Buf_Story_Collection -> ���� ���丮 ��ũ��Ʈ �ִ� ��(���� ������ Ȱ��ȭ ���Ѿ� �ϴ� ��)

        Debug.Log("Go_Story");

        fade.Fade_BE.SetActive(true);
        fade.Fade_In_Out.SetTrigger("Go_Black");

     

        StartCoroutine(Show_B_Story());
        IEnumerator Show_B_Story()
        {
            yield return new WaitForSeconds(1.0f);
            Buf_Main_Collection.SetActive(false);//���� ���� ȭ��
            Buf_Story_Collection.SetActive(true);//���� ���丮 ��ũ��Ʈ �ִ� ��

            //���� find4�� 
            //find4.Sentences_0 >126�̶�� ��� ���½�Ų��

            /*public Typing typ;
   public Typing_1 typ1;
   public Typing_2 typ2;

   public Find_Something find;
   public Find_Something1 find1;
   public Find_Something2 find2;
   public Find_Something3 find3;
   public Find_Something4 find4;*/

            


        }

        StartCoroutine(Go_B_Main_Black_Empty());

        IEnumerator Go_B_Main_Black_Empty()
        {
            yield return new WaitForSeconds(1.5f);
            fade.Fade_In_Out.SetTrigger("Go_Empty");
            
            for(int i=0; i<bty.objectArray1.Length; i++)
            {
                bty.objectArray1[i].SetActive(false);
            }
        }

        StartCoroutine(Bye_Fade());
        IEnumerator Bye_Fade()
        {
            yield return new WaitForSeconds(3.5f);
            fade.Fade_BE.SetActive(false);

           
        }

        if (find4.Sentences_0 > 126)
        {

            

            typ.Sectences_Reset_Settings();//
            typ1.Sectences_Reset_Settings();//
            typ2.Sectences_Reset_Settings();//

            find.Reset_Settings();//
            find1.Sectences_Reset_Settings();//
            find2.Arrow_Reset_Settings();//
            find3.Reset_Settings();
            find4.Reset_Settings();

            item.Item_ResetSettings();//



            //typ.Load_Sentences1();//0724 ����
            //typ.Load_Bg_0();//0724 ����

            Debug.Log("���� Ȯ��");

            /* typ.Inside_Dia.SetActive(false);

             if (typ.Bg[0].activeSelf == true && typ.Sentences_1 == 0)
             {
                 typ.Inside_Dia.SetActive(false);

                 StartCoroutine(Show_Story());
                 IEnumerator Show_Story()
                 {
                     yield return new WaitForSeconds(2.0f);

                     typ.Dia.SetActive(true);



                     if (typ.Start_Count == 1)
                     {
                         //typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                         typ.Load_Sentences1();//0724 ����
                         typ.Load_Bg_0();//0724 ����
                     }

                     typ.Inside_Dia.SetActive(true);
                     //typ.Load_Sentences1();//0724 ����
                     //typ.Load_Bg_0();//0724 ����

                     //typ.StartTyping(); // ��ȭ ����
                     typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                 }
             }*/

            // typ.Dia.SetActive(true);
            // typ.Inside_Dia.SetActive(true);
            if (typ.Bg[0].activeSelf == true && typ.Sentences_1 == 0)
            {
                /* typ.Dia.SetActive(true);
                 typ.Inside_Dia.SetActive(true);
                 typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                 typ.Load_Sentences1();//0724 ����
                 typ.Load_Bg_0();//0724 ����

                 typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                */

                typ.Dia.SetActive(false);
                typ.Inside_Dia.SetActive(false);

                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(2.0f);

                    typ.Dia.SetActive(true);
                    //typ.Inside_Dia.SetActive(true);


                    if (typ.Start_Count == 0)
                    {
                        typ.Inside_Dia.SetActive(true);
                        //typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                        typ.Load_Sentences1();//0724 ����
                        typ.Load_Bg_0();//0724 ����
                    }

                    typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }

        }

        else
        {
            //�̾߱� ���� ���丮 �ܿ� ������ ���� ���� ����

            //ĳ���� �����ߴ� �� ��Ȱ�� �� ����


/*
            find.StartTyping_0();
            find1.StartTyping_0();
            find2.StartTyping_0();
            find3.StartTyping_0();
            find4.StartTyping_0();
            
            */
            if (typ.Bg[0].activeSelf == true && typ.Sentences_1 == 0)
            {
                /* typ.Dia.SetActive(true);
                 typ.Inside_Dia.SetActive(true);
                 typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                 typ.Load_Sentences1();//0724 ����
                 typ.Load_Bg_0();//0724 ����

                 typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                */

                typ.Dia.SetActive(false);
                typ.Inside_Dia.SetActive(false);

                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(3.0f);

                    typ.Dia.SetActive(true);
                    //typ.Inside_Dia.SetActive(true);


                    if (typ.Start_Count == 0)
                    {
                        typ.Inside_Dia.SetActive(true);
                        typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                    }

                    typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }
                

            /*if (typ.Bg[0].activeSelf == true && typ.Sentences_1 == 0)
            {
               

                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(2.0f);

                    typ.Dia.SetActive(true);
                    //Talk.SetActive(true);

                    typ.Inside_Dia.SetActive(true);

                    // Names.SetActive(true);
                   

                    if(typ.Start_Count == 0)
                    {
                       // typ.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                        typ.Load_Sentences1();//0724 ����
                        typ.Load_Bg_0();//0724 ����
                    }

                   //if (typ.Start_Count == 1)
                   // {
                     //   typ.StartTyping(); // ��ȭ ����
                        //typ.Load_Sentences1();//0724 ����
                        //typ.Load_Bg_0();//0724 ����

                    //}

                    typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }*/
            
            //ĳ���� �����ߴ� �� ��Ȱ�� �� ����
            /*if (typ.Bg[2].activeSelf == true && typ1.Sentences_1 == 0)
            {


                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(2.0f);

                    typ1.Dia.SetActive(true);
                    //Talk.SetActive(true);

                    typ1.Inside_Dia.SetActive(true);

                    // Names.SetActive(true);


                    if (typ1.Start_Count == 0)
                    {
                        typ1.StartTyping(); // ��ȭ ����
                        typ1.Load_Sentences1();//0724 ����
                    }

                    if (typ1.Start_Count == 1)
                    {
                        typ1.StartTyping(); // ��ȭ ����
                       // typ1.Load_Sentences1();//0724 ����
                    }

                    typ1.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }*/

            if (typ.Bg[2].activeSelf == true && typ1.Sentences_1 == 0)
            {
                typ1.Dia.SetActive(false);
                typ1.Inside_Dia.SetActive(false);

                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(3.0f);

                    typ1.Dia.SetActive(true);
                    //typ.Inside_Dia.SetActive(true);


                    if (typ1.Start_Count == 0)
                    {
                        typ1.Inside_Dia.SetActive(true);
                        typ1.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                    }

                    typ1.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }

            //ĳ���� �����ߴ� �� ��Ȱ�� �� ����
            /*if (typ.Bg[4].activeSelf == true && typ2.Sentences_1 == 0)
            {


                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(2.0f);

                    typ2.Dia.SetActive(true);
                    //Talk.SetActive(true);

                    typ2.Inside_Dia.SetActive(true);

                    // Names.SetActive(true);


                    if (typ2.Start_Count == 0)
                    {
                        typ2.StartTyping(); // ��ȭ ����
                        typ2.Load_Sentences1();//0724 ����

                    }

                    //if (typ2.Start_Count == 1)
                   // {
                        //typ2.StartTyping(); // ��ȭ ����
                     //   typ2.Load_Sentences1();//0724 ����
                    }

                    typ.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }*/

            if (typ.Bg[4].activeSelf == true && typ2.Sentences_1 == 0)
            {
                typ2.Dia.SetActive(false);
                typ2.Inside_Dia.SetActive(false);

                StartCoroutine(Show_S_Story());
                IEnumerator Show_S_Story()
                {
                    yield return new WaitForSeconds(3.0f);

                    typ2.Dia.SetActive(true);
                    //typ.Inside_Dia.SetActive(true);


                    if (typ2.Start_Count == 0)
                    {
                        typ2.Inside_Dia.SetActive(true);
                        typ2.StartTyping(); // ��ȭ ���� -> �̰͸� ���� ���� �ȵ�(�����ϰ� �ٷ� ������ ���)
                    }

                    typ2.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
                }
            }

            if (b_ch.Dia[0].activeSelf==true || b_ch.Dia[1].activeSelf == true ||
                b_ch.Dia[2].activeSelf == true || b_ch.Dia[3].activeSelf == true ||
                b_ch.Dia[4].activeSelf == true || b_ch.Dia[5].activeSelf == true ||
                b_ch.Dia[6].activeSelf == true || b_ch.Dia[7].activeSelf == true ||
                b_ch.Dia[8].activeSelf == true || b_ch.Dia[9].activeSelf == true )
            {

                //Ž�� �����ϰ�



                //find
                if ((find.Sentences_0 >= 0 && find.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 < 1 && typ2.Sentences_1 < 1
                    && typ.Sentences_1 >= typ.sentences_1.Length && find1.Sentences_0 < 1 && find2.Sentences_0 < 1 && find3.Sentences_0 < 1
                    && find4.Sentences_0 < 1)

                {
                    find.touch_able_b[0].SetActive(true);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(false);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

 
                }

                //find1
                if ((find1.Sentences_0 >= 0 && find1.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 < 1
                    && find.Sentences_0 >= find.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length
                    && find2.Sentences_0 < 1 && find3.Sentences_0 < 1 && find4.Sentences_0 < 1
                    && (find1.Dia[1].activeSelf == false && find1.Dia[2].activeSelf == false && find1.Dia[3].activeSelf == false))
                {
                    find.touch_able_b[0].SetActive(false);
                    find.touch_able_b[1].SetActive(true);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(false);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                }

                //find2 - ������
                if ((find2.Sentences_0 >= 0 && find2.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 < 1
                    && find.Sentences_0 >= find.sentences_0.Length &&
                    find1.Sentences_0 >= find1.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length && find3.Sentences_0 < 1 && find4.Sentences_0 < 1
                    && (find2.Dia[1].activeSelf == false && find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
                   && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
                   && find2.R_Normal_Arrow == 1)
                {
                    find.touch_able_b[0].SetActive(false);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(true);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    find2.Arrow[0].SetActive(false);
                    find2.Arrow[1].SetActive(false);
                    find2.Arrow[2].SetActive(true);
                    find2.Arrow[3].SetActive(true);
                    find2.Arrow[4].SetActive(false);
                    find2.Arrow[5].SetActive(false);

                    
                }

                if ((find2.Sentences_0 >= 0 && find2.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 < 1
                    && find.Sentences_0 >= find.sentences_0.Length &&
                    find1.Sentences_0 >= find1.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length && find3.Sentences_0 < 1 && find4.Sentences_0 < 1
                    && (find2.Dia[1].activeSelf == false && find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
                   && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
                   && find2.R_Normal_Arrow == 2)
                {
                    find.touch_able_b[0].SetActive(false);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(true);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    find2.Arrow[0].SetActive(false);
                    find2.Arrow[1].SetActive(false);
                    find2.Arrow[2].SetActive(false);
                    find2.Arrow[3].SetActive(false);
                    find2.Arrow[4].SetActive(true);
                    find2.Arrow[5].SetActive(true);
                }

                //find2 - �� ��
                if ((find2.Sentences_0 >= 0 && find2.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 < 1
                    && find.Sentences_0 >= find.sentences_0.Length &&
                    find1.Sentences_0 >= find1.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length && find3.Sentences_0 < 1 && find4.Sentences_0 < 1
                    && (find2.Dia[1].activeSelf == false && find2.Dia[2].activeSelf == false && find2.Dia[3].activeSelf == false
                   && find2.Dia[4].activeSelf == false && find2.Dia[5].activeSelf == false)
                    && find2.R_Normal_Arrow == 0)
                {
                    find.touch_able_b[0].SetActive(false);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(true);
                    find.touch_able_b[3].SetActive(false);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);

                    find2.Arrow[0].SetActive(true);
                    find2.Arrow[1].SetActive(true);
                    find2.Arrow[2].SetActive(false);
                    find2.Arrow[3].SetActive(false);
                    find2.Arrow[4].SetActive(false);
                    find2.Arrow[5].SetActive(false);
                }

                //find3
                if ((find3.Sentences_0 >= 0 && find3.Dia[0].activeSelf == false)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 >= typ2.sentences_1.Length
                    && find.Sentences_0 >= find.sentences_0.Length &&
                    find1.Sentences_0 >= find1.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length &&
                    find2.Sentences_0 >= find2.sentences_0.Length && find4.Sentences_0 < 1 &&
                    (find3.Dia[1].activeSelf == false && find3.Dia[2].activeSelf == false && find3.Dia[3].activeSelf == false
                  && find3.Dia[4].activeSelf == false && find3.Dia[5].activeSelf == false))
                {
                    find.touch_able_b[0].SetActive(true);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(false);
                    find.touch_able_b[4].SetActive(true);
                    find.touch_able_b[5].SetActive(false);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                }

                //find4
                if ((find4.Sentences_0 >= 0 && find4.Dia[0].activeSelf == true && find4.Sentences_0 < 126)
                     && typ1.Sentences_1 >= typ1.sentences_1.Length && typ2.Sentences_1 >= typ2.sentences_1.Length
                    && find.Sentences_0 >= find.sentences_0.Length &&
                    find1.Sentences_0 >= find1.sentences_0.Length && typ.Sentences_1 >= typ.sentences_1.Length &&
                    find2.Sentences_0 >= find2.sentences_0.Length && find3.Sentences_0 >= find3.sentences_0.Length &&
                    (find4.Dia[1].activeSelf == false && find4.Dia[2].activeSelf == false && find4.Dia[3].activeSelf == false
                  && find4.Dia[4].activeSelf == false && find4.Dia[5].activeSelf == false))
                {
                    find.touch_able_b[0].SetActive(true);
                    find.touch_able_b[1].SetActive(false);
                    find.touch_able_b[2].SetActive(false);
                    find.touch_able_b[3].SetActive(false);
                    find.touch_able_b[4].SetActive(false);
                    find.touch_able_b[5].SetActive(true);
                    find.btn_Collection.SetActive(true);

                    b_ch.Suggest.SetActive(true);
                    item.Suggest.SetActive(true);
                }



                b_ch.Sentences_0 = 0;
                b_ch.Sentences_1 = 0;
                b_ch.Sentences_2 = 0;
                b_ch.Sentences_3 = 0;
                b_ch.Sentences_4 = 0;
                b_ch.Sentences_5 = 0;
                b_ch.Sentences_6 = 0;
                b_ch.Sentences_7 = 0;
                b_ch.Sentences_8 = 0;
                b_ch.Sentences_9 = 0;

                for (int i = 0; i < b_ch.Dia.Length; i++)
                {
                    b_ch.Dia[i].SetActive(false);
                }

                //b_ch.Suggest.SetActive(true);
                //item.Suggest.SetActive(true);

                b_ch.zero_0 = 0;
                b_ch.zero_1 = 0;
                b_ch.zero_2 = 0;
                b_ch.zero_3 = 0;
                b_ch.zero_4 = 0;
                b_ch.zero_5 = 0;
                b_ch.zero_6 = 0;
                b_ch.zero_7 = 0;
                b_ch.zero_8 = 0;
                b_ch.zero_9 = 0;

                b_ch.Container.offsetMin = new Vector2(0, -681.8718f);//left, bottom
                b_ch.Container.offsetMax = new Vector2(0, 0.0002441406f);//-right, -top
            }

            b_ch.Meno.SetActive(false);
            b_ch.Up_Button.SetActive(true);

            for(int i=0; i<b_ch.Character.Length; i++)
            {
                b_ch.Character[i].SetActive(false);
            }

            for (int i = 0; i < b_ch.Ch_Button.Length; i++)
            {
                b_ch.Ch_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 4; i < b_ch.Character_Name.Length; i++)
            {
                b_ch.Character_Name[i].SetActive(false);
            }
            //������� ĳ���� ���� ����



            //������� ������ ���� ����
            for (int i = 0; i < item.Sugg_Names.Length; i++)
            {
                item.Sugg_Names[i].SetActive(false);
            }

            for (int i = 0; i < item.Item_Button.Length; i++)
            {
                item.Item_Button[i].color = new Color(225 / 225f, 225 / 225f, 225 / 225f);
            }

            for (int i = 0; i < item.Item_Name.Length; i++)
            {
                item.Item_Name[i].SetActive(false);
            }

            item.Meno.SetActive(false);
            item.Up_Button.SetActive(true);



            if (item.Dia[0].activeSelf == true || item.Dia[1].activeSelf == true ||
               item.Dia[2].activeSelf == true || item.Dia[3].activeSelf == true || item.Dia[4].activeSelf == true)
            {
                item.Item_0 = 0;
                item.Item_1 = 0;
                item.Item_2 = 0;
                item.Item_3 = 0;
                item.Item_4 = 0;

                for (int i = 0; i < item.Dia.Length; i++)
                {
                    item.Dia[i].SetActive(false);
                }

               // b_ch.Suggest.SetActive(true);
                //item.Suggest.SetActive(true);
            }

            //��������� ������

            if(typ.Dia.activeSelf==true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            if (typ1.Dia.activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            if (typ2.Dia.activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            //find
            if (find.Dia[0].activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }


            if (find.Dia[1].activeSelf == true || find.Dia[2].activeSelf == true
                 || find.Dia[3].activeSelf == true || find.Dia[4].activeSelf == true
                 || find.Dia[5].activeSelf == true || find.Dia[6].activeSelf == true)
            {
                PlayerPrefs.DeleteKey("find_Text_Data0");
                PlayerPrefs.Save();

                for (int i = 1; i < find.Dia.Length; i++)
                {
                    find.Dia[i].SetActive(false);
                }

                find.Dia[1].SetActive(false);
                find.Dia[2].SetActive(false);
                find.Dia[3].SetActive(false);
                find.Dia[4].SetActive(false);
                find.Dia[5].SetActive(false);
                find.Dia[6].SetActive(false);

                find.Name.SetActive(false);

                //find.Dia[0].SetActive(false);

                find.touch_able_b[0].SetActive(true);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(false);
                find.touch_able_b[3].SetActive(false);
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }


                find.Sentences_1 = 0;
                find.Sentences_2 = 0;
                find.Sentences_3 = 0;
                find.Sentences_4 = 0;
                find.Sentences_5 = 0;
                find.Sentences_6 = 0;
            }

            //find1
            if (find1.Dia[0].activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            if (find1.Dia[1].activeSelf == true || find1.Dia[2].activeSelf == true
                || find1.Dia[3].activeSelf == true)
            {
                find1.Sentences_1 = 0;
                find1.Sentences_2 = 0;
                find1.Sentences_3 = 0;

                PlayerPrefs.DeleteKey("find_Text_Data1");
                PlayerPrefs.Save();

                for (int i = 0; i < find1.Name.Length; i++)
                {
                    find1.Name[i].SetActive(false);
                }

                for (int i = 1; i < find1.Dia.Length; i++)
                {
                    find1.Dia[i].SetActive(false);
                }


                find1.find_s.Typ_Dia_Total.SetActive(true);//0721�߰��߰�

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(true);
                find.touch_able_b[2].SetActive(false);
                find.touch_able_b[3].SetActive(false);
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }
            }


            //find2
            if (find2.Dia[0].activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            //���� ȭ��ǥ�� 
            // -> ������ �ִ� �� ��ư Ȱ��
            if ( find2.R_Normal_Arrow == 1
                && (find2.Dia[1].activeSelf == true || find2.Dia[2].activeSelf == true
                 || find2.Dia[3].activeSelf == true || find2.Dia[4].activeSelf == true
                 || find2.Dia[5].activeSelf == true))
            {
                for (int i = 0; i < find2.Name.Length; i++)
                {
                    find2.Name[i].SetActive(false);
                }

                for (int i = 1; i < find2.Dia.Length; i++)
                {
                    find2.Dia[i].SetActive(false);
                }

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(false);//�湮
                find.touch_able_b[3].SetActive(true);//������ �ִ� ��
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                PlayerPrefs.DeleteKey("find_Text_Data2");
                PlayerPrefs.Save();

                find2.Sentences_1 = 0;
                find2.Sentences_2 = 0;
                find2.Sentences_3 = 0;
                find2.Sentences_4 = 0;
                find2.Sentences_5 = 0;

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }

                find.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
            }

            if (find2.R_Normal_Arrow == 2
                && (find2.Dia[1].activeSelf == true || find2.Dia[2].activeSelf == true
                 || find2.Dia[3].activeSelf == true || find2.Dia[4].activeSelf == true
                 || find2.Dia[5].activeSelf == true))
            {
                for (int i = 0; i < find1.Name.Length; i++)
                {
                    find2.Name[i].SetActive(false);
                }

                for (int i = 1; i < find2.Dia.Length; i++)
                {
                    find2.Dia[i].SetActive(false);
                }

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(false);//�湮
                find.touch_able_b[3].SetActive(true);//������ �ִ� ��
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                PlayerPrefs.DeleteKey("find_Text_Data2");
                PlayerPrefs.Save();

                find2.Sentences_1 = 0;
                find2.Sentences_2 = 0;
                find2.Sentences_3 = 0;
                find2.Sentences_4 = 0;
                find2.Sentences_5 = 0;

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }

                find.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
            }

            //���� ȭ��ǥ�� 
            // -> �� �ִ� �� ��ư Ȱ��
            if (find2.R_Normal_Arrow == 0
                && (find2.Dia[1].activeSelf == true || find2.Dia[2].activeSelf == true
                 || find2.Dia[3].activeSelf == true || find2.Dia[4].activeSelf == true
                 || find2.Dia[5].activeSelf == true ))
            {
                for (int i = 0; i < find1.Name.Length; i++)
                {
                    find2.Name[i].SetActive(false);
                }

                for (int i = 1; i < find2.Dia.Length; i++)
                {
                    find2.Dia[i].SetActive(false);
                }

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(true);//�湮
                find.touch_able_b[3].SetActive(false);//������ �ִ� ��
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                PlayerPrefs.DeleteKey("find_Text_Data2");
                PlayerPrefs.Save();

                find2.Sentences_1 = 0;
                find2.Sentences_2 = 0;
                find2.Sentences_3 = 0;
                find2.Sentences_4 = 0;
                find2.Sentences_5 = 0;

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }

                find.Typ_Dia_Total.SetActive(true);//0721�߰��߰�
            }

            //find3
            if (find3.Dia[0].activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            if (find3.Dia[1].activeSelf == true || find3.Dia[2].activeSelf == true
                 || find3.Dia[3].activeSelf == true || find3.Dia[4].activeSelf == true
                 || find3.Dia[5].activeSelf == true)
            {
                for (int i = 0; i < find3.Name.Length; i++)
                {
                    find3.Name[i].SetActive(false);
                }

                for (int i = 1; i < find3.Dia.Length; i++)
                {
                    find3.Dia[i].SetActive(false);
                }

                find3.Sentences_1 = 0;
                find3.Sentences_2 = 0;
                find3.Sentences_3 = 0;
                find3.Sentences_4 = 0;
                find3.Sentences_5 = 0;

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(false);
                find.touch_able_b[3].SetActive(false);
                find.touch_able_b[4].SetActive(true);
                find.touch_able_b[5].SetActive(false);
                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                PlayerPrefs.DeleteKey("find_Text_Data3");
                PlayerPrefs.Save();

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }
            }

            //find4
            if (find4.Dia[0].activeSelf == true)
            {
                b_ch.Suggest.SetActive(false);
                item.Suggest.SetActive(false);
            }

            if (find4.Dia[1].activeSelf == true || find4.Dia[2].activeSelf == true
                 || find4.Dia[3].activeSelf == true || find4.Dia[4].activeSelf == true
                 || find4.Dia[5].activeSelf == true)
            {
                for (int i = 0; i < find4.Name.Length; i++)
                {
                    find4.Name[i].SetActive(false);
                }

                find4.Sentences_1 = 0;
                find4.Sentences_2 = 0;
                find4.Sentences_3 = 0;
                find4.Sentences_4 = 0;
                find4.Sentences_5 = 0;

                for (int i = 1; i < find4.Dia.Length; i++)
                {
                    find4.Dia[i].SetActive(false);
                }

                find.touch_able_b[0].SetActive(false);
                find.touch_able_b[1].SetActive(false);
                find.touch_able_b[2].SetActive(false);
                find.touch_able_b[3].SetActive(false);
                find.touch_able_b[4].SetActive(false);
                find.touch_able_b[5].SetActive(true);

                find.btn_Collection.SetActive(true);

                b_ch.Suggest.SetActive(true);
                item.Suggest.SetActive(true);

                for (int i = 0; i < typ.Ch.Length; i++)
                {
                    typ.Ch[i].SetActive(false);
                }

                PlayerPrefs.DeleteKey("find_Text_Data4");
                PlayerPrefs.Save();
            }
        }

    }

    public void Hint()
    {
        Debug.Log("Show_Hint");
    }

    /*public void Memo()
    {
        Debug.Log("Show_Meno");
    }*/
}

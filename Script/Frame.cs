using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    //외전은 인물, 세계관 등 설정들을 대부분 그대로 따르며 원래 서사와 접점이 있는
    //비하인드 스토리

    //스핀오프는 원작의 구성 요소 중 하나나 일부를 차용하여 별개의 새로운 작품을 구성
    //(평행세계)

    public GameObject Title;

    public GameObject Main;//메인화면
    public GameObject Letter;//편지
   // public GameObject Bag;//가방
    //public GameObject Album;//앨범
   // public GameObject Person;//인물
    //public GameObject Story;//스토리
    public GameObject Supplementary;//사이드 스토리 -> 외전
    public GameObject Spin_Off;//외전-> 스핀오프(나비)

    public GameObject Brown;//갈색
    public GameObject Black;//검은색

    private void FixedUpdate()
    {
        if(Title.activeSelf==false && Main.activeSelf==true)
        {
            Brown.SetActive(true);
            Black.SetActive(false);
            //갈색

        }
        
        else if (Title.activeSelf == true)
        {
            //검은색
            Brown.SetActive(false);
            Black.SetActive(true);
        }

        else
        {
            Brown.SetActive(true);
            Black.SetActive(false);
        }
    }
}

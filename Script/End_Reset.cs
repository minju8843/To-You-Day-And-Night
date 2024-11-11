using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_Reset : MonoBehaviour
{
    public GameObject Game_Reset;

    public void Start()
    {
        Game_Reset.SetActive(false);
    }


    public void Do_Game_Reset()
    {
        Game_Reset.SetActive(true);
    }

    public void Reset_Button_Y_N()
    {
        Game_Reset.SetActive(false);
    }
}

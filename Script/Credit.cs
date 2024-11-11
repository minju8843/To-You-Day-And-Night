using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public Animator Credit_Anim;
    public RectTransform credit_rect;//컨테이너

    public void Go_Credit()
    {
        Credit_Anim.SetTrigger("Go_Left");
        credit_rect.offsetMin = new Vector2(0, -2713.29f);//left, bottom
        credit_rect.offsetMax = new Vector2(0, 0.005493164f);//-right, -top
    }

    public void Go_Back()
    {
        Credit_Anim.SetTrigger("Go_Right");
    }
}

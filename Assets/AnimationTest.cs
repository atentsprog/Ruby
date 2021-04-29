using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Animator>().enabled = true;
    }

    void Update()
    {
        //GetComponent<Animation>()/// ¿¹Àü²¨, ¿¿³¯²¨. ¿äÁò¿¡ ¾È½á¿ä, 
        if(Input.GetKeyDown(KeyCode.Alpha1))
            GetComponent<Animator>().Play("move");
    }
}

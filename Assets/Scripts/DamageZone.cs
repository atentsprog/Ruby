using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    //public int damage = -2;

    //https://docs.unity3d.com/kr/530/ScriptReference/MonoBehaviour.html
    private void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            //Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start는 처음 시작되는 부분 - Git테스트중
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        transform.position = position;
    }
}

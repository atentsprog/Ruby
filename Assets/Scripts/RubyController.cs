using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start는 처음 시작되는 부분 - Git테스트중
    // 가사가 다시 수정
    void Start()
    {
        
    }

    // 화면 갱신될때마다 호출됨 - git테스트중
    void Update()
    {
        //float horizontal = 0;
        //if (Input.GetKey(KeyCode.A))
        //{
        //    horizontal = -1;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    horizontal = 1;
        //}

        //float vertical = 0;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    vertical = 1;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    vertical = -1;
        //}

        //Debug.Log(horizontal + "그리고 다른 부분을 추가 수정했다 - git test중");

        //Vector2 position = transform.position;
        //position.x = position.x + 0.1f * horizontal;
        //position.y = position.y + 0.1f * vertical;
        //transform.position = position;


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start는 처음 시작되는 부분 - Git테스트중
    void Start()
    {
        
    }

    // 강사는 다른 설명을 했다. 그래서 충돌 날것이다.
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal + "그리고 다른 부분을 추가 수정했다 - git test중");

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        transform.position = position;
    }
}

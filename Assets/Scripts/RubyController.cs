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
        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal + "그리고 다른 부분을 추가 수정했다 - git test중");

        Vector2 position = transform.position;
        position.x = position.x + 0.1f * horizontal;
        transform.position = position;
    }
}

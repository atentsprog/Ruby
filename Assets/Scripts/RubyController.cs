using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    private new Rigidbody2D rigidbody2D;

    public float timeInvincible = 2.0f;
    public bool isInvincible = false;
    private float invincibleTimer;

    public enum InvincibleType
    {
        Invincible,
        NotInvincible,
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // 화면 갱신될때마다 호출됨 - git테스트중
    private void Update()
    {
        #region 체력 변경하는 테스트 로직

        //GetKeyDown <- 키를 눌렀을때 최초 1회
        //GetKey    <- 키를 누르고 있는동안
        //GetKeyUp  <- 키를 땔때 최초 1회
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeHealth(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeHealth(-2);
        }

        #endregion 체력 변경하는 테스트 로직

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2D.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);

        if (isInvincible)
        {
            //Debug.Log($"Time.deltaTime : {Time.deltaTime}");
            invincibleTimer -= Time.deltaTime; // 60 : 1 / 60 = 0.01666 * 60 = 1
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public float speed = 3.0f;

    // 음수일때, 무적아니라면
    //// -> 한번 데미지 입고 나면 2초간 무적으로 만들어줘야지

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        int originalHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        //Debug.Log(currentHealth + "/" + maxHealth);
        Debug.Log($"루비의 체력 변화 {originalHealth}-> {currentHealth}, 최대체력 {maxHealth}");
        // 5 -> 4 , 최대체력 5
    }
}
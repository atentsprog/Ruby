using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    public Vector2 direction = new Vector2(1, 0);
    public float force = 1;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
            rigidbody2d.AddForce(direction * force);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            rigidbody2d.Sleep();
    }
}

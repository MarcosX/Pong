using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed = 30.0f;
    public string axisInput = "Vertical";
    public float scaleFactor = 0.25f;
    public float speedDecrease = 1.5f;

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw(axisInput);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalInput) * speed;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "Ball")
        {
            if (transform.localScale.y <= 4)
                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + scaleFactor);

            if (speed > 5)
                speed -= speedDecrease;
        }
    }
}

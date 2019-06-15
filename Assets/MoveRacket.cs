using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed = 30;
    public string axisInput = "Vertical";

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxisRaw(axisInput);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalInput) * speed;
    }
}

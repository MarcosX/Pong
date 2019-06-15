using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "RacketLeft")
        {
            float yDirection = hitFactor(transform.position, collisionInfo.transform.position, collisionInfo.collider.bounds.size.y);
            Vector2 direction = new Vector2(1, yDirection).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        if (collisionInfo.gameObject.name == "RacketRight")
        {
            float yDirection = hitFactor(transform.position, collisionInfo.transform.position, collisionInfo.collider.bounds.size.y);
            Vector2 direction = new Vector2(-1, yDirection).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }
}

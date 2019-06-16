using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    public GameObject scoreLeft;

    public GameObject scoreRight;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized * speed;
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
        if (collisionInfo.gameObject.name == "WallRight")
        {
            int newScore = intParseFast(scoreLeft.GetComponent<Text>().text) + 1;
            scoreLeft.GetComponent<Text>().text = "" + newScore;
        }
        if (collisionInfo.gameObject.name == "WallLeft")
        {
            int newScore = intParseFast(scoreRight.GetComponent<Text>().text) + 1;
            scoreRight.GetComponent<Text>().text = "" + newScore;
        }
    }

    float hitFactor(Vector2 ballPosition, Vector2 racketPosition, float racketHeight)
    {
        return (ballPosition.y - racketPosition.y) / racketHeight;
    }

    public static int intParseFast(string value)
    {
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return result;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 1f;
    float radius;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector2.one.normalized;
        radius = this.transform.localScale.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(dir * speed * Time.deltaTime);

        //make him bounce of top and bot screen by invertig the current y vec
        if(this.transform.position.y < GameManager.Left.y + radius && dir.y < 0) dir.y = -dir.y; 
        if(this.transform.position.y > GameManager.Right.y - radius && dir.y > 0) dir.y = -dir.y; 

        // make check for collision on screen to score points
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Paddle")
        {
            bool isRight = other.GetComponent<Paddle>().isRight;

            //if hitting right paddle change dir
            if(isRight && dir.x > 0)
            {
                dir.x = -dir.x;
            }
            //if hitting left paddle
            if(!isRight && dir.x < 0)
            {
                dir.x = -dir.x;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    float height;            // for collision detection

    public bool isRight = false;
    string inputStr;

    void Start()
    {
        height = this.transform.localScale.y;
    }

    void Update()
    {
        float move = Input.GetAxis(inputStr) * speed * Time.deltaTime;

        //restrict movement with screen
        //
        if(transform.position.y < GameManager.Left.y + height / 2 && move < 0)
        {
            move = 0 ;
        }
        if(transform.position.y > GameManager.Right.y - height / 2 && move > 0)
        {
            move = 0 ;
        }

        transform.Translate(move * Vector2.up);


    }

    ///<summary> set Paddle position. true = right, false = left </summary>
    public void Init(bool isRightPaddle)
    {   
        isRight = isRightPaddle;

        Vector2 pos = Vector2.zero;
        if(isRightPaddle)
        {
            pos = new Vector2(GameManager.Right.x ,0);
            pos -= Vector2.right * this.transform.localScale.x;
            inputStr = "PaddleRight";
        }
        else
        {
            pos = new Vector2(GameManager.Left.x ,0);          
            pos += Vector2.right * this.transform.localScale.x;
            inputStr = "PaddleLeft";
        }

        this.transform.position = pos;
        this.transform.name = inputStr; // easier to see in inspector which is which 
    }

}

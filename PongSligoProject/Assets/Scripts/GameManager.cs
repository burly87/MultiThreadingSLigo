using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    // Gamerelated Objects
    public Ball ball;
    public Paddle paddle;

    public static Vector2 Left;
    public static Vector2 Right;

    // MultiThreating related
    Thread gameRef = new Thread(StartGameRef);
    Thread p1, p2;

    // UI related
    public static Text scoreText;
    void Start()
    {
        // Convert Screen pixel Coords into game coords
        Left = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        Right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        //Create Ball
        Instantiate(ball);

        //Create both paddles
        Paddle paddle0 = Instantiate(paddle) as Paddle;
        Paddle paddle1 = Instantiate(paddle) as Paddle;

        //set Position of paddles 
        paddle0.Init(true);
        paddle1.Init(false);

        // ---- multithreating ---

        gameRef.Start();
        // p1.Start();
        // p2.Start();

        // UI
        
    }

    public static void StartGameRef()
    { 
        scoreText.enabled = true;
        Debug.Log("Test Start");
    }

}

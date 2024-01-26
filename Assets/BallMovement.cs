using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMovement : MonoBehaviour
{
    public static BallMovement instance;

    public float speed = 15;
    public int maxScore = 2147483647;
    private float shakeAmount = 0.5f;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip scoreEffect;
    [SerializeField] public GameObject leftPaddle;
    [SerializeField] public GameObject rightPaddle;
     
    public string leftName = "Left";
    public string rightName = "Right";

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector2(0, 0);
        WinningScreen.instance.winningMenu.SetActive(false);
        PauseMenu.instance.gameObject.SetActive(false);
        SecondMenu.instance.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    void Update()
    {
        // checks if space was pressed - starts the game
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 1;
            GetComponent<Rigidbody2D>().velocity = Vector2.right.normalized * speed;
        }

        // initaites pause menu through the menu script
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.instance.pauseMenu.SetActive(true);
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        if (col.gameObject.name == "LeftPaddle")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            SoundEffects.instance.playSF(clip, this.transform, 1f);
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RightPaddle")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            SoundEffects.instance.playSF(clip, this.transform, 1f);
        }

        if (col.gameObject.name == "TopWall" || col.gameObject.name == "BottomWall")
        {
            SoundEffects.instance.playSF(clip, this.transform, 1f);
        }

        if (col.gameObject.name == "LeftGoal")
        {
            ScoreManager.instance.addRight();
            SoundEffects.instance.playSF(scoreEffect, this.transform, 1f);
            GameObject.Find("RightSideAnimation").GetComponent<Animator>().Play("RightGoalAnimation", -1 , 0f);
            if (ScoreManager.instance.rightNum == maxScore)
            {
                WinningScreen.instance.winner(rightName + " Wins!");
            }
            else
            {
                this.gameObject.SetActive(false);
                leftPaddle.GetComponent<Rigidbody2D>().position = new Vector2(-8, 0);
                rightPaddle.GetComponent<Rigidbody2D>().position = new Vector2(8, 0);
                Invoke("resetGame", 1);
            }
        }

        if (col.gameObject.name == "RightGoal")
        {
            SoundEffects.instance.playSF(scoreEffect, this.transform, 1f);
            ScoreManager.instance.addLeft();
            GameObject.Find("LeftSideAnimation").GetComponent<Animator>().Play("LeftIdle", -1, 0f);
            if (ScoreManager.instance.leftNum == maxScore)
            {
                WinningScreen.instance.winner(leftName + " Wins!");
            }
            else
            {
                this.gameObject.SetActive(false);
                leftPaddle.GetComponent<Rigidbody2D>().position = new Vector2(-8, 0);
                rightPaddle.GetComponent<Rigidbody2D>().position = new Vector2(8, 0);
                Invoke("resetGame", 1);
            }
        }
    }

    void resetGame()
    {
        this.gameObject.SetActive(true);
        this.transform.position = new Vector2(0, 0);
        int random = Random.Range(-1, 2);
        while (random == 0)
        {
            random = Random.Range(-1, 2);
        }
        float random2 = Random.Range(-1f, 2f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(random, random2).normalized * speed;
    }

}

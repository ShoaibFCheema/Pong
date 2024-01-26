using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class WinningScreen : MonoBehaviour
{
    public static WinningScreen instance;
    [SerializeField] public GameObject winningMenu;
    [SerializeField] public Text winnerText;

    private void Awake()
    {
        instance = this;
    }

    public void winner(string winner)
    {
        Time.timeScale = 0;
        winningMenu.SetActive(true);
        winnerText.text = winner;
    }

    public void onPlayAgain()
    {
        Time.timeScale = 1;
        winningMenu.SetActive(false);
        ScoreManager.instance.reset();
        GameObject.Find("LeftPaddle").transform.position = new Vector2(-8, 0);
        GameObject.Find("RightPaddle").transform.position = new Vector2(8, 0);
        GameObject.Find("Ball").transform.position = new Vector2(0, 0);
        GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void onQuitWinning()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

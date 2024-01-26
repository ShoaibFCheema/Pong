using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public GameObject scoreText;
    // Start is called before the first frame update
    public int leftNum = 0;
    public int rightNum = 0;
    public Text leftScore;
    public Text rightScore;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.SetActive(true);
        leftScore.text = leftNum.ToString();
        rightScore.text = rightNum.ToString();
    }


    public void addLeft()
    {
        leftNum++;
        leftScore.text = leftNum.ToString();
    }

    public void addRight()
    {
        rightNum++;
        rightScore.text = rightNum.ToString();
    }

    public void reset()
    {
        rightNum = 0;
        leftNum = 0;
        Start();
    }
}

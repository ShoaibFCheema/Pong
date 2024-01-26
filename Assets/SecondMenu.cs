using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMenu : MonoBehaviour
{
    public static SecondMenu instance;
    [SerializeField] public GameObject secondMenu;

    public void Start()
    {
        ColorPicker.instance.canvas.SetActive(false);
        ScoreManager.instance.scoreText.SetActive(false);
    }
    private void Awake()
    {
        instance = this;
    }

    public void onFive()
    {
        BallMovement.instance.maxScore = 5;
        secondMenu.SetActive(false);
        ScoreManager.instance.scoreText.SetActive(true);
    }

    public void onTen()
    {
        BallMovement.instance.maxScore = 10;
        secondMenu.SetActive(false);
        ScoreManager.instance.scoreText.SetActive(true);
    }

    public void onInfinite()
    {
        BallMovement.instance.maxScore = 2147483647;
        secondMenu.SetActive(false);
        ScoreManager.instance.scoreText.SetActive(true);
    }

    public void onCustomize()
    {
        ColorPicker.instance.canvas.SetActive(true);
    }
}

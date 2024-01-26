using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    [SerializeField] public GameObject MainMenu;
    public void Awake()
    {
        instance = this;
    }

    public void onPlayButton()
    {
        SceneManager.LoadScene("Easy");
    }

    public void onQuitButton()
    {
        Application.Quit();
    }
}

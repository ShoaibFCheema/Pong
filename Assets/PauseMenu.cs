using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    [SerializeField] public GameObject pauseMenu;

    private void Awake()
    {
        instance = this;
    }

    public void onResume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void onPauseQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

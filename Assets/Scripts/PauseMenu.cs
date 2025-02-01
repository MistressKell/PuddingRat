using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if(isPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true) ;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false) ;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Main()
    {
        SceneManager.LoadScene(0);
    }
}

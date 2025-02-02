using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject credits;
    public GameObject controls;
    void Start()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        credits.SetActive(true);
        main.SetActive(false);
    }

    public void Controls()
    {
        main.SetActive(false);
        controls.SetActive(true);
    }

    public void Back()
    {
        credits.SetActive(false );
        controls.SetActive(false);
        main.SetActive(true);
    }
}

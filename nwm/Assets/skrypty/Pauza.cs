using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauza : MonoBehaviour
{
    public static bool pauza = false;

    public GameObject MenuPauzy;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauza) wznow();
            else pauzuj();
        }
    }

    public void wznow()
    {
        MenuPauzy.SetActive(false);
        Time.timeScale = 1f;
        pauza = false;
    }

    void pauzuj()
    {
        MenuPauzy.SetActive(true);
        Time.timeScale = 0f;
        pauza = true;
    }

    public void menu() 
    { 
        SceneManager.LoadScene("scene");
        Time.timeScale = 1f;
        FindObjectOfType<score>().resetScore();
    }

    public void end() { Application.Quit(); }
}

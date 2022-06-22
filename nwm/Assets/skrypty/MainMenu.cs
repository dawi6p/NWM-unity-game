using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void playgame() { SceneManager.LoadScene("scene1"); }
    public void end() { Application.Quit(); }
    private void Start()
    {
        GetComponentInChildren<Text>().text = "Highscore: " + FindObjectOfType<score>().Gethighscore().ToString();
    }

}

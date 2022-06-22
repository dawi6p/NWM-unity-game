using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pusty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(czek());
    }
    IEnumerator czek()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("scene");
    }
}

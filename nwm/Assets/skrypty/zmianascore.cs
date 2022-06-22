using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zmianascore : MonoBehaviour
{

    void Update()
    {
        GetComponent<Text>().text = "Score: " + FindObjectOfType<score>().Score.ToString();
    }
}

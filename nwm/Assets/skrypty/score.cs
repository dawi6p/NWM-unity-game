using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    [HideInInspector]
    public long Score = 0;
    private long HighScore = 0;
    public static score instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void zmienScore(int cos)
    {
        Score += cos;
        if (Score > HighScore) HighScore = Score;
        if (Score < 0) Score = 0;
        if (Score > 999999999) Score = 999999999;
    }

    public void resetScore() { Score = 0; }

    public long Gethighscore() { return HighScore; }
}

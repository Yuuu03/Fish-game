using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //retrieve score from playerprefs
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        //display final score text
        finalScoreText.text = "Score: " + finalScore.ToString();
    }
}

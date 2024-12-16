using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;


public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public Image loseImage;
    public Image winImage;
    // Start is called before the first frame update
    void Start()
    {
        int winStatus = PlayerPrefs.GetInt("WinStatus", 0);

        loseImage.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);

        if (winStatus == 0)
        {
            loseImage.gameObject.SetActive(true);
        }
        else
        {
            winImage.gameObject.SetActive(true);
        }

        //retrieve score from playerprefs
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        //display final score text
        finalScoreText.text = "Score: " + finalScore.ToString();
    }
}

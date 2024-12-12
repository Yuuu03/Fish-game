using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using Image = UnityEngine.UI.Image;


public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    private GameManager gameManager;
    public Image loseImage;
    public Image winImage;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        loseImage = GetComponent<Image>();
        winImage = GetComponent<Image>();
        loseImage.gameObject.SetActive(false);
        winImage.gameObject.SetActive(false);
        if (gameManager.winStatus == false)
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

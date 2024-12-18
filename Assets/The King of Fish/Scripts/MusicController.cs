using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Image musicOnIcon;
    [SerializeField] private Image musicOffIcon;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateMusicIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        Debug.Log("Button clicked!");
        muted =! muted;
        AudioListener.pause = muted;

        Save();
        UpdateMusicIcon();
    }

    private void UpdateMusicIcon()
    {
        if (muted == false)
        {
            musicOnIcon.enabled = true;
            musicOffIcon.enabled = false;
            Debug.Log("Music On Icon Enabled, Music Off Icon Disabled");
        }
        else
        {
            musicOnIcon.enabled = false;
            musicOffIcon.enabled = true;
            Debug.Log("Music Off Icon Enabled, Music On Icon Disabled");
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }

}

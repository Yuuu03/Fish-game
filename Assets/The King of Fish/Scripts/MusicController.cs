using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class MusicController : MonoBehaviour
{
    public static MusicController Instance {  get; private set; } 
    private AudioSource audioSource;
    public Image musicIcon;
    private bool musicOn = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void PlayMusic()
    {
        if (musicOn)
        {
            audioSource.Pause();
            musicIcon.gameObject.SetActive(false);
        }
        else
        {
            audioSource.Play();
            musicIcon.gameObject.SetActive(true);
        }
        musicOn =! musicOn;
    }
   
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") 
        {
            PlayMusic("menuMusic");
        }
        else if (SceneManager.GetActiveScene().name == "Level 1")
        {
            PlayMusic("gameMusic");
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            PlayMusic("gameMusic");
        }

    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
}

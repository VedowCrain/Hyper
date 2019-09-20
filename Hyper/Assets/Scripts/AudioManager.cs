using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogWarning("There is already another AudioManager in the scene. I die.");
            Destroy(this);
        }
    }

    private void Start()
    {
        PickNewMusicClip();
    }

    protected bool mute = false;

    public bool Mute
    {
        get { return mute; }
        set { mute = value; }
    }

    public AudioMixer Mixer;

    public AudioClip[] Music;
    public AudioSource MusicAudioSource;

    public string masterParam = "Master";
    public string ambienceParam = "Ambience";
    public string musicParam = "Music";
    public string sfxParam = "SFX";

    protected float timer = 0f;

    protected int musicIndex = 0;

    private void SetVolume(string parameter, float volume)
    {
        float audioVolume = Mathf.Log(volume) * 20;
        Mixer.SetFloat(parameter, audioVolume);
    }

    public void SetMasterVolume(float volume)
    {
        SetVolume(masterParam, volume);
    }

    public void SetSFXVolume(float volume)
    {
        SetVolume(sfxParam, volume);
    }

    public void SetAmbientVolume(float volume)
    {
        SetVolume(ambienceParam, volume);
    }

    public void SetMusicVolume(float volume)
    {
        SetVolume(musicParam, volume);
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = PlayNextClip();
        }
    }

    public void ToggleMute()
    {
        mute = !mute;
        SetMasterVolume(mute ? 0.001f : 1f);
    }

    public void PickNewMusicClip()
    {
        musicIndex = Random.Range(0, Music.Length);
        PlayNextClip();
    }

    public float PlayNextClip()
    {
        musicIndex++;
        if (musicIndex > Music.Length - 1)
        {
            musicIndex = 0;
        }

        MusicAudioSource.clip = Music[musicIndex];

        MusicAudioSource.Play();
        return MusicAudioSource.clip.length;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour {

    public AudioSource audio;
    public Object[] myMusic;

    void Awake()
    {
        myMusic = Resources.LoadAll("BackgroundMusic", typeof(AudioClip));
        audio.clip = myMusic[0] as AudioClip;
    }
    void Start()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio.Play();
    }
    void Update()
    {
        if (!audio.isPlaying)
            playRandomMusic();
    }
    void playRandomMusic()
    {
        audio.clip = myMusic[Random.Range(0, myMusic.Length)] as AudioClip;
        audio.Play();
    }
}

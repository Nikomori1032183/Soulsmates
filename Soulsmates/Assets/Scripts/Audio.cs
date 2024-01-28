using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class Audio : MonoBehaviour
{
    AudioSource musicSource, sfxSource;

    [Tab("Music")]
    public AudioClip mainMenuShort, // during main menu
        player1Theme, // when player 1 turn
        player1TimeRunningOut,
        player2Theme,
        player2TimeRunningOut,
        player3Theme,
        player3TimeRunningOut,
        player4Theme,
        player4TimeRunningOut;

    [Tab("SFX")]
    public AudioClip affectionDown,
        affectionUp,
        crowd,
        dog,
        doorOpen,
        itemGet,
        lockerFall,
        footstep,
        slip,
        soulChange,
        unlock,
        splash;

    //[Tab("Scroll")]
    //public AudioClip anime, guy, goose, monster;

    [Tab("UI")]
    [SerializeField]
    public AudioClip menuSwitch, menuConfirm;


    private void Start()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        musicSource = sources[0];
        sfxSource = sources[1];
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.loop = true;
        musicSource.clip = clip;
        musicSource.Play();
    }

    [Button]
    public void StopMusic()
    {
        musicSource.loop = false;
    }

    [Button]
    public void BreakMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}

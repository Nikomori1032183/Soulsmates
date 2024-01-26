using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

#region Class Information

// Author: Frank Manford
// Description: Class for handling the playing of audio for the text box
// Last Updated: 12/01/2024

#endregion

public class TextBoxAudio : MonoBehaviour
{
    [Tab("References")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip open, scroll, confirm, skip, exit;

    [Tab("Properties")]
    [SerializeField] ScrollAudioType scrollAudioType;
    [SerializeField][Range(0, 3)] float pitch;
    [SerializeField][Range(0, 1)] float pitchDeviation;

    private void Start()
    {
        // Events
        TextBox.OnOpen += PlayOpenSound;
        TextBox.OnStartTextScroll += StartScrollSound;
        TextBox.OnStopTextScroll += StopScrollSound;
        TextBox.OnTextScroll += PlayScrollSound;
        TextBox.OnConfirm += PlayConfirmSound;
        TextBox.OnExit += PlayExitSound;

        audioSource.pitch = pitch;
    }
    private void PlaySound(AudioClip clip, bool loop, float pitch)
    {
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.pitch = pitch;
        audioSource.Play();
    }

    [Button]
    private void PlayOpenSound()
    {
        Debug.Log("PlayOpenSound");
        PlaySound(open, false, pitch);
    }

    [Button]
    private void StartScrollSound()
    {
        if (GetScrollAudioType() == TextBoxAudio.ScrollAudioType.Loop)
        {
            Debug.Log("StartScrollSound");
            PlaySound(scroll, true, pitch);
        }
    }

    [Button]
    private void StopScrollSound()
    {
        if (GetScrollAudioType() == TextBoxAudio.ScrollAudioType.Loop)
        {
            Debug.Log("StopScrollSound");
            audioSource.Stop();
        }
    }

    [Button]
    private void PlayScrollSound()
    {
        if (GetScrollAudioType() == TextBoxAudio.ScrollAudioType.Character)
        {
            Debug.Log("PlayScrollSound");
            PlaySound(scroll, false, Random.Range(pitch - pitchDeviation, pitch + pitchDeviation));
        }
    }

    [Button]
    private void PlayConfirmSound()
    {
        Debug.Log("PlayConfirmSound");
        PlaySound(confirm, false, pitch);
    }

    [Button]
    private void PlaySkipSound()
    {
        Debug.Log("PlaySkipSound");
        PlaySound(skip, false, pitch);
    }

    [Button]
    private void PlayExitSound()
    {
        Debug.Log("PlayExitSound");
        PlaySound(exit, false, pitch);
    }

    public ScrollAudioType GetScrollAudioType()
    {
        return scrollAudioType;
    }

    public enum ScrollAudioType
    {
        Loop, Character
    }
}

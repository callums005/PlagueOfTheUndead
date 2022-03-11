using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioInterface : MonoBehaviour
{
    [Header("Audio Interface")]
    public AudioSource Source; 

    public void PlayAudio(bool playOnce = false, ulong timeDelay = 0)
    {
        if (!Source) return;
        if (!Source.clip) return;

        if (playOnce)
            Source.PlayOneShot(Source.clip);
        else
            Source.Play(timeDelay);
    }

    public void PauseAudio()
    {
        if (!Source) return;
        if (!Source.clip) return;

        Source.Pause();
    }

    public void StopAudio()
    {
        if (!Source) return;
        if (!Source.clip) return;

        Source.Stop();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        Instance = this;
    }

    public void PlayAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }

    public void PlayOneShotAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }

}

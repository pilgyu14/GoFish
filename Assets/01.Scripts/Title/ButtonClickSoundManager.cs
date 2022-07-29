using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioCilp;

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(audioCilp);
    }
}

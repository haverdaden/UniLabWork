using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{
    public static soundEffects Instance;
    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;
    void Awake()
    {
        // Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffects!");
            Destroy(Instance.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }
    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }
    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    // Play a given sound
    private void MakeSound(AudioClip originalClip)
    {
        // As it is not 3D audio clip, position doesn't matter.
        var AudioSource = GetComponent<AudioSource>();
        AudioSource.volume = 1;
        AudioSource.clip = originalClip;
        AudioSource.Play();
    }
}



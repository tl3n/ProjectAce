using System.Collections;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Music Settings")]
    public AudioSource musicSource;
    public AudioClip[] musicClips;

    [Header("Sound Effect Settings")]
    public AudioSource sfxSource;
    public AudioClip[] playerSfxClips;
    public AudioClip[] enemySfxClips;
    public AudioClip[] uiSfxClips;

    // Ensure to call base.Awake() to remove duplicates
    public override void Awake()
    {
        base.Awake();
        SetupAudioSources();
    }

    private void SetupAudioSources()
    {
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true;
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
            sfxSource.loop = false;
        }
    }

    // Play a music clip by index
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music index out of range.");
        }
    }

    // Play a player sound effect by index
    public void PlayPlayerSFX(int index)
    {
        PlaySFX(playerSfxClips, index);
    }

    // Play an enemy sound effect by index
    public void PlayEnemySFX(int index)
    {
        PlaySFX(enemySfxClips, index);
    }

    // Play a UI sound effect by index
    public void PlayUISFX(int index)
    {
        PlaySFX(uiSfxClips, index);
    }

    // Generic method to play any sound effect
    private void PlaySFX(AudioClip[] clips, int index)
    {
        if (index >= 0 && index < clips.Length)
        {
            sfxSource.PlayOneShot(clips[index]);
        }
        else
        {
            Debug.LogWarning("SFX index out of range.");
        }
    }

    // Stop the currently playing music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Stop the currently playing sound effect
    public void StopSFX()
    {
        sfxSource.Stop();
    }
}

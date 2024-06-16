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
    
    /// <summary>
    /// Ensure to call base.Awake() to remove duplicates
    /// </summary>
    public override void Awake()
    {
        base.Awake();
        SetupAudioSources();
    }

    /// <summary>
    /// 
    /// </summary>
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
    
    /// <summary>
    /// Play a music clip by index
    /// </summary>
    /// <param name="index"></param>
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < musicClips.Length)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else Debug.LogWarning("Music index out of range.");
    }
    
    /// <summary>
    /// Play a player sound effect by index
    /// </summary>
    /// <param name="index"></param>
    public void PlayPlayerSFX(int index)
    {
        PlaySFX(playerSfxClips, index);
    }
    
    /// <summary>
    /// Play an enemy sound effect by index
    /// </summary>
    /// <param name="index"></param>
    public void PlayEnemySFX(int index)
    {
        PlaySFX(enemySfxClips, index);
    }
    
    /// <summary>
    /// Play a UI sound effect by index
    /// </summary>
    /// <param name="index"></param>
    public void PlayUISFX(int index)
    {
        PlaySFX(uiSfxClips, index);
    }
    
    /// <summary>
    /// Generic method to play any sound effect
    /// </summary>
    /// <param name="clips"></param>
    /// <param name="index"></param>
    private void PlaySFX(AudioClip[] clips, int index)
    {
        if (index >= 0 && index < clips.Length) sfxSource.PlayOneShot(clips[index]);
        else Debug.LogWarning("SFX index out of range.");
    }

    
    /// <summary>
    /// Stop the currently playing music
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }
    
    /// <summary>
    /// Stop the currently playing sound effect
    /// </summary>
    public void StopSFX()
    {
        sfxSource.Stop();
    }
}

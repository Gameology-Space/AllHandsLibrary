using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundFX : MonoBehaviour
{
    public static SoundFX Instance { get; private set; }

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] woosh;

    [SerializeField]
    private AudioClip[] spellSounds;

    [SerializeField]
    private AudioClip UIClick;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep this instance between scene changes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayUIClick()
    {
        audioSource.clip = UIClick;
        audioSource.Play();
    }

    public void PlayWoosh()
    {
        if (woosh.Length > 0)
        {
            int randomIndex = Random.Range(0, woosh.Length);
            audioSource.clip = woosh[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No woosh clips assigned!");
        }
    }

    public void PauseClip()
    {
        audioSource.Pause();
    }

    public void StopClip()
    {
        audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);
    }

    public void PlayFireSound()
    {
        audioSource.clip = spellSounds[0];
        audioSource.Play();
    }

    public void PlayIceSound()
    {
        audioSource.clip = spellSounds[1];
        audioSource.Play();
    }

    public void PlayEarthSound()
    {
        audioSource.clip = spellSounds[2];
        audioSource.Play();
    }
}

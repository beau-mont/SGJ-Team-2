using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip test;
    public AudioClip test2;
    public AudioClip Back;
    public AudioClip MenuSelect;
    public AudioClip LevelSelect;


    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        musicSource.clip = test;
        musicSource.Play();
    }

    public void SFX(AudioClip Clip)
    {
        sfxSource.PlayOneShot(Clip);
    }
}
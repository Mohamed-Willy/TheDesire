using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("--------------------AudioSource----------------")]
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------------------AudioClip------------------")]
    public AudioClip laserSound;
    public AudioClip heavyBreathing;
    public AudioClip buttonClickMainMenu;
    public AudioClip buttonClickInGame;
    public AudioClip closingSceneSound;
    public AudioClip backgroundSound;
    public AudioClip actionBackgroundSound;
    public AudioClip openingSound;
    public AudioClip disintegrationSound;
    public AudioClip ionizerSound;
    public AudioClip metroidSound;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); 

        if (currentScene.name == "IntroScene" || currentScene.name == "MainMenu")
        {
            soundSource.clip = openingSound;
        }
        else
        {
            soundSource.clip = backgroundSound;
        }

        soundSource.Play();
    }
   public void playSFX(AudioClip clip)
    {
        if(clip == laserSound)SFXSource.PlayOneShot(ReverseAudioClip(clip));
        else SFXSource.PlayOneShot(clip);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "IntroScene" || scene.name == "MainMenu")
        {
            soundSource.clip = openingSound;
        }
        else
        {
            soundSource.clip = backgroundSound;
        }

        soundSource.Play();
    }

    private AudioClip ReverseAudioClip(AudioClip clip)
    {
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);

        float[] reversedSamples = new float[samples.Length];
        int reverseIndex = samples.Length - 1;

        for (int i = 0; i < samples.Length; i++)
        {
            reversedSamples[i] = samples[reverseIndex];
            reverseIndex--;
        }

        AudioClip reversedClip = AudioClip.Create(clip.name + "_Reversed", clip.samples, clip.channels, clip.frequency, false);
        reversedClip.SetData(reversedSamples, 0);

        return reversedClip;
    }
}

using UnityEngine;

public class TriggerRuneNote : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;

    public AudioClip audioClipClickA;
    public AudioClip audioClipClickB;
    public AudioClip audioClipClickC;
    public AudioClip audioClipClickD;
    public AudioClip audioClipClickE;
    public AudioClip audioClipClickF;
    public AudioClip audioClipClickG;

    public AudioClip audioClipHoverA;
    public AudioClip audioClipHoverB;
    public AudioClip audioClipHoverC;
    public AudioClip audioClipHoverD;
    public AudioClip audioClipHoverE;
    public AudioClip audioClipHoverF;
    public AudioClip audioClipHoverG;

    private AudioSource audioSource;

    private void Awake()
    {
        runeInterfaceController.OnSliceEntered += HandleSliceEntered;
        runeInterfaceController.OnSliceClicked += HandleSliceClicked;

        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void HandleSliceEntered(int slice)
    {
        Debug.Log("TriggerMusic -> Slice entered: " + slice);
        if(slice < 0)
        {
            audioSource.Stop();
            return;
        }

        if (slice == 0)
        {
            audioSource.clip = audioClipHoverA;
        }
        if (slice == 1)
        {
            audioSource.clip = audioClipHoverB;
        }
        if (slice == 2)
        {
            audioSource.clip = audioClipHoverC;
        }
        if (slice == 3)
        {
            audioSource.clip = audioClipHoverD;
        }
        if (slice == 4)
        {
            audioSource.clip = audioClipHoverE;
        }
        if (slice == 5)
        {
            audioSource.clip = audioClipHoverF;
        }
        if (slice == 6)
        {
            audioSource.clip = audioClipHoverG;
        }

        audioSource.Play();
    }

    void HandleSliceClicked(int slice)
    {
        Debug.Log("TriggerMusic -> Slice clicked: " + slice);

        if (slice == 0)
        {
            audioSource.clip = audioClipClickA;
        }
        if (slice == 1)
        {
            audioSource.clip = audioClipClickB;
        }
        if (slice == 2)
        {
            audioSource.clip = audioClipClickC;
        }
        if (slice == 3)
        {
            audioSource.clip = audioClipClickD;
        }
        if (slice == 4)
        {
            audioSource.clip = audioClipClickE;
        }
        if (slice == 5)
        {
            audioSource.clip = audioClipClickF;
        }
        if (slice == 6)
        {
            audioSource.clip = audioClipClickG;
        }

        audioSource.Play();

    }
}

using UnityEngine;

public class TriggerRuneNote : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;
    public AudioSource ambientNotesSource;
    public AudioSource playedNotesSource;

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

    //private AudioSource audioSource;

    private void Awake()
    {
        runeInterfaceController.OnSliceEntered += HandleSliceEntered;
        runeInterfaceController.OnSliceClicked += HandleSliceClicked;

        //audioSource = GetComponent<AudioSource>();
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
            ambientNotesSource.Stop();
            return;
        }

        if (slice == 0)
        {
            ambientNotesSource.clip = audioClipHoverA;
        }
        if (slice == 1)
        {
            ambientNotesSource.clip = audioClipHoverB;
        }
        if (slice == 2)
        {
            ambientNotesSource.clip = audioClipHoverC;
        }
        if (slice == 3)
        {
            ambientNotesSource.clip = audioClipHoverD;
        }
        if (slice == 4)
        {
            ambientNotesSource.clip = audioClipHoverE;
        }
        if (slice == 5)
        {
            ambientNotesSource.clip = audioClipHoverF;
        }
        if (slice == 6)
        {
            ambientNotesSource.clip = audioClipHoverG;
        }

        ambientNotesSource.Play();
    }

    void HandleSliceClicked(int slice)
    {
        Debug.Log("TriggerMusic -> Slice clicked: " + slice);

        if (slice == 0)
        {
            playedNotesSource.clip = audioClipClickA;
        }
        if (slice == 1)
        {
            playedNotesSource.clip = audioClipClickB;
        }
        if (slice == 2)
        {
            playedNotesSource.clip = audioClipClickC;
        }
        if (slice == 3)
        {
            playedNotesSource.clip = audioClipClickD;
        }
        if (slice == 4)
        {
            playedNotesSource.clip = audioClipClickE;
        }
        if (slice == 5)
        {
            playedNotesSource.clip = audioClipClickF;
        }
        if (slice == 6)
        {
            playedNotesSource.clip = audioClipClickG;
        }

        playedNotesSource.Play();

    }
}

using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections;

public class FModNotePlayer : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;

    [SerializeField]
    public EventReference noteEvent; // 🎯 Drag your event:/NotePlayer here

    [SerializeField]
    public EventReference noteHintsEvent; // 🎯 Drag your event:/NoteHints here

    [SerializeField]
    [Range(0f, 5f)]
    public float fadeOutDuration; // Seconds

    private readonly System.Collections.Generic.List<EventInstance> activeHintInstances = new();

    private void Awake()
    {
        runeInterfaceController.OnSliceClicked += PlayNote;
        runeInterfaceController.OnSliceEntered += PlayNoteHint;
        
        RuntimeManager.LoadBank("AJ", true); // trying to reduce latency in audio calls
    }

    private void OnDestroy()
    {
        runeInterfaceController.OnSliceClicked -= PlayNote;
        runeInterfaceController.OnSliceEntered -= PlayNoteHint;

        StopAllCoroutines();
  
    }

    public void PlayNote(int slice)
    {
        if (slice < 0 || slice > 6)
            return;

        PlayNoteByIndex(slice);
    }

    public void PlayNoteHint(int slice)
    {
        if (slice < 0 || slice > 6) {
            FadeOutAndReleaseAllNoteHints();
            return;
        }

        PlayNoteHintByIndex(slice);
    }

    private void PlayNoteByIndex(int index)
    {
        // Start new instance
        EventInstance noteInstance = RuntimeManager.CreateInstance(noteEvent);
        noteInstance.setParameterByName("NoteIndex", index);
        noteInstance.setVolume(1f);
        noteInstance.start();

        activeHintInstances.Add(noteInstance);
    }

    private void PlayNoteHintByIndex(int index)
    {
        // Start new instance
        EventInstance hintInstance = RuntimeManager.CreateInstance(noteHintsEvent);
        hintInstance.setParameterByName("NoteIndex", index);
        hintInstance.setVolume(1f); // Start at full volume
        hintInstance.start();

        // Fade out previous hint (if any)
        FadeOutAndReleaseAllNoteHints();

        // Track this new one
        activeHintInstances.Add(hintInstance);
    }

    private IEnumerator FadeOutAndRelease(EventInstance instance, float duration)
    {
        float time = 0f;
        float startVolume = 1f;

        while (time < duration)
        {
            float t = 1f - (time / duration);
            instance.setVolume(t * startVolume);
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        instance.release();
    }

    public void FadeOutAndReleaseAllNoteHints()
    {
        Debug.Log("fade out and release");
        foreach (var instance in activeHintInstances)
        {
            StartCoroutine(FadeOutAndRelease(instance, fadeOutDuration));
        }

        activeHintInstances.Clear(); // We hand off responsibility to the coroutine now
    }
}
using System.IO;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class FModNotePlayerProgrammerInstrument : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;

    public string filePath;

    public string eventPath = "event:/NotePlayer";

    private Dictionary<string, EventInstance> activeNoteHints = new Dictionary<string, EventInstance>();
    private Dictionary<string, EventInstance> activeNotes = new Dictionary<string, EventInstance>();

    Dictionary<string, Sound> sampleCache = new Dictionary<string, Sound>();

    private void Awake()
    {
        runeInterfaceController.OnSliceEntered += PlayNoteHint;
        runeInterfaceController.OnSliceClicked += PlayNote;
    }

    private void Start()
    {
        //PreloadSample("AJ_NoteA.wav");
        //PreloadSample("AJ_NoteB.wav");
        //PreloadSample("AJ_NoteC.wav");
        //PreloadSample("AJ_NoteD.wav");
        //PreloadSample("AJ_NoteE.wav");
        //PreloadSample("AJ_NoteF.wav");
        //PreloadSample("AJ_NoteG.wav");
        //PreloadSample("AJ_NoteHintA.wav");
        //PreloadSample("AJ_NoteHintB.wav");
        //PreloadSample("AJ_NoteHintC.wav");
        //PreloadSample("AJ_NoteHintD.wav");
        //PreloadSample("AJ_NoteHintE.wav");
        //PreloadSample("AJ_NoteHintF.wav");
        //PreloadSample("AJ_NoteHintG.wav");
    }

    //void PreloadSample(string filename)
    //{
    //    string fullPath = Path.Combine(Application.streamingAssetsPath, filePath, filename);

    //    FMOD.Studio.System studioSystem = RuntimeManager.StudioSystem;
    //    FMOD.System lowLevelSystem;
    //    studioSystem.getCoreSystem(out lowLevelSystem);

    //    Sound sound;
    //    RESULT result = lowLevelSystem.createSound(fullPath, MODE.DEFAULT | MODE.NONBLOCKING | MODE.CREATECOMPRESSEDSAMPLE, out sound);
    //    if (result == RESULT.OK)
    //    {
    //        sound.setMode(MODE.LOOP_OFF);
    //        sampleCache[filename] = sound;
    //    }
    //    else
    //    {
    //        UnityEngine.Debug.LogError("Failed to preload sound: " + result);
    //    }
    //}

    public void PlayNote(int slice)
    {
        //UnityEngine.Debug.Log("play note " + slice);

        //string sampleFileName = "";
        //if (slice < 0)
        //{
        //    StopAllNotes();
        //    return;
        //}

        //if (slice == 0)
        //{
        //    sampleFileName = "AJ_NoteC.wav";
        //}
        //if (slice == 1)
        //{
        //    sampleFileName = "AJ_NoteD.wav";
        //}
        //if (slice == 2)
        //{
        //    sampleFileName = "AJ_NoteE.wav";
        //}
        //if (slice == 3)
        //{
        //    sampleFileName = "AJ_NoteF.wav";
        //}
        //if (slice == 4)
        //{
        //    sampleFileName = "AJ_NoteG.wav";
        //}
        //if (slice == 5)
        //{
        //    sampleFileName = "AJ_NoteA.wav";
        //}
        //if (slice == 6)
        //{
        //    sampleFileName = "AJ_NoteB.wav";
        //}


        //if (activeNotes.ContainsKey(sampleFileName))
        //{
        //    // Already playing — stop it first to avoid overlap
        //    StopNote(sampleFileName);
        //}

        //EventInstance noteInstance = RuntimeManager.CreateInstance(eventPath);

        //string sampleNameCopy = sampleFileName; // copy to local scope

        //// Set callback to load the sample file
        //noteInstance.setCallback((eventType, instance, parameterPtr) =>
        //{
        //    if (!Application.isPlaying)
        //        return RESULT.OK;

        //    if (eventType == EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND)
        //    {
        //        var props = System.Runtime.InteropServices.Marshal.PtrToStructure<PROGRAMMER_SOUND_PROPERTIES>(parameterPtr);

        //        if (sampleCache.TryGetValue(sampleNameCopy, out var sound))
        //        {
        //            props.sound = sound.handle;
        //            Marshal.StructureToPtr(props, parameterPtr, false);
        //        }
        //        else
        //        {
        //            UnityEngine.Debug.LogWarning("Sample not preloaded: " + sampleNameCopy);
        //            return RESULT.ERR_FILE_NOTFOUND;
        //        }

        //        //string fullPath = Path.Combine(Application.streamingAssetsPath, filePath, sampleNameCopy);

        //        //FMOD.Studio.System studioSystem = RuntimeManager.StudioSystem;
        //        //FMOD.System lowLevelSystem;
        //        //studioSystem.getCoreSystem(out lowLevelSystem);

        //        //Sound sound;
        //        //RESULT result = lowLevelSystem.createSound(fullPath, MODE.DEFAULT | MODE.NONBLOCKING, out sound);
        //        //if (result != RESULT.OK)
        //        //{
        //        //    UnityEngine.Debug.LogError("FMOD failed to create sound: " + result);
        //        //    return RESULT.ERR_FILE_NOTFOUND;
        //        //}

        //        //props.sound = sound.handle;
        //        //System.Runtime.InteropServices.Marshal.StructureToPtr(props, parameterPtr, false);
        //    }

        //    return RESULT.OK;
        //});

        ////noteInstance.start();
        //activeNotes[sampleFileName] = noteInstance;
    }

    public void PlayNoteHint(int slice)
    {
        UnityEngine.Debug.Log("play note hint " + slice);

        string sampleFileName = "";
        if (slice < 0)
        {
            //StopAllNoteHints();
            return;
        }

        if (slice == 0)
        {
            sampleFileName = "AJ_NoteHintC.wav";
        }
        if (slice == 1)
        {
            sampleFileName = "AJ_NoteHintD.wav";
        }
        if (slice == 2)
        {
            sampleFileName = "AJ_NoteHintE.wav";
        }
        if (slice == 3)
        {
            sampleFileName = "AJ_NoteHintF.wav";
        }
        if (slice == 4)
        {
            sampleFileName = "AJ_NoteHintG.wav";
        }
        if (slice == 5)
        {
            sampleFileName = "AJ_NoteHintA.wav";
        }
        if (slice == 6)
        {
            sampleFileName = "AJ_NoteHintB.wav";
        }

        //StopAllNoteHints();

        EventInstance noteInstance = RuntimeManager.CreateInstance(eventPath);

        string sampleNameCopy = sampleFileName; // copy to local scope

        // Set callback to load the sample file
        noteInstance.setCallback((eventType, instance, parameterPtr) =>
        {
            //if (!Application.isPlaying)
            //    return RESULT.OK;

            if (eventType == EVENT_CALLBACK_TYPE.CREATE_PROGRAMMER_SOUND)
            {
                var props = System.Runtime.InteropServices.Marshal.PtrToStructure<PROGRAMMER_SOUND_PROPERTIES>(parameterPtr);

                string fullPath = Path.Combine(Application.streamingAssetsPath, filePath, sampleNameCopy);

                FMOD.Studio.System studioSystem = RuntimeManager.StudioSystem;
                FMOD.System lowLevelSystem;
                studioSystem.getCoreSystem(out lowLevelSystem);

                Sound sound;
                RESULT result = lowLevelSystem.createSound(fullPath, MODE.DEFAULT | MODE.NONBLOCKING, out sound);
                if (result != RESULT.OK)
                {
                    UnityEngine.Debug.LogError("FMOD failed to create sound: " + result);
                    return RESULT.ERR_FILE_NOTFOUND;
                }

                //    props.sound = sound.handle;
                //    System.Runtime.InteropServices.Marshal.StructureToPtr(props, parameterPtr, false);
            }

            return RESULT.OK;
        });

        //noteInstance.start();
        //activeNoteHints[sampleFileName] = noteInstance;
    }



    public void StopAll()
    {
        StopAllNoteHints();
        StopAllNotes();
    }

    public void StopAllNoteHints()
    {
        foreach (var kvp in activeNoteHints)
        {
            var instance = kvp.Value;

            // Use ALLOWFADEOUT if you want smoother stops, or IMMEDIATE if you're shutting down
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }

        activeNotes.Clear();
    }

    public void StopAllNotes()
    {
        foreach (var kvp in activeNotes)
        {
            var instance = kvp.Value;

            // Use ALLOWFADEOUT if you want smoother stops, or IMMEDIATE if you're shutting down
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
        }

        activeNotes.Clear();
    }


    public void StopNote(string sampleFileName)
    {
        if (activeNotes.TryGetValue(sampleFileName, out var noteInstance))
        {
            noteInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            noteInstance.release();
            activeNotes.Remove(sampleFileName);
        }
    }

    void OnDisable()
    {
        CleanupAudioInstances();
    }

    private void OnDestroy()
    {
        CleanupAudioInstances();
    }

    private void CleanupAudioInstances()
    {
        foreach (var kvp in activeNotes)
        {
            var instance = kvp.Value;
            instance.getPlaybackState(out var state);
            if (state != PLAYBACK_STATE.STOPPED)
            {
                instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            instance.release();
        }

        activeNotes.Clear();

        foreach (var kvp in activeNoteHints)
        {
            var instance = kvp.Value;
            instance.getPlaybackState(out var state);
            if (state != PLAYBACK_STATE.STOPPED)
            {
                instance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
            instance.release();
        }

        activeNoteHints.Clear();
    }
}
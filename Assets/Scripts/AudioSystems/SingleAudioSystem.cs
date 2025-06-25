using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAudioSystem : AudioSystemBase
{
    [Header("One source")]
    [SerializeField] protected AudioSource audioSource;

    public override void SetAndPlay(AudioClipAsset clipAsset)
    {
        if (CanPlay(clipAsset) && CheckAudioType(clipAsset.Type))
        {
            SetAudio(clipAsset);
        }
    }


    protected void SetAudio(AudioClipAsset clipAsset)
    {
        audioSource.Stop();
        audioSource.clip = clipAsset.Clip;
        audioSource.Play();
    }

    public override void Pause(AudioType aType)
    {
        if(CanHandlePausing())
            audioSource.Pause();
    }
    public override void Unpause(AudioType aType)
    {
        if(CanHandlePausing())
            audioSource.UnPause();
    }


    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        audioSource != null && clipAsset?.Clip != null;

    protected override bool CanHandlePausing() => audioSource != null;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAudioSystem : AudioSystemBase
{
    [Header("One source")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioTransition transition;

    public override void SetAndPlay(AudioClipAsset clipAsset)
    {
        if (!CanPlay(clipAsset) || !CanHandleAudioSources() || !CheckAudioType(clipAsset.Type))
            return;

        if(transition != null)
        {
            var sourceTransited = transition.Transite(audioSource, clipAsset.Clip);

            if (sourceTransited != null)
            {
                audioSource = sourceTransited;
                return;
            }
        }
            
        SetAudio(clipAsset); // If transition or sourceTransited == null we use different way
    }


    protected void SetAudio(AudioClipAsset clipAsset)
    {
        audioSource.Stop();
        audioSource.clip = clipAsset.Clip;
        audioSource.Play();
    }

    public override void Pause(AudioType aType)
    {
        if(CanHandleAudioSources())
            audioSource.Pause();
    }
    public override void Unpause(AudioType aType)
    {
        if(CanHandleAudioSources())
            audioSource.UnPause();
    }


    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        audioSource != null && clipAsset?.Clip != null;

    protected override bool CanHandleAudioSources() => audioSource != null;
}

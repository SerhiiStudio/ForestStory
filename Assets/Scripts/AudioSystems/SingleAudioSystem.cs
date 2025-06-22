using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAudioSystem : AudioSystemBase
{
    [Header("One source")]
    [SerializeField] protected AudioSource audioSource;

    public override void Play(AudioClipAsset clipAsset)
    {
        Debug.Log(audioSource != null);
        Debug.Log(clipAsset != null);
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


    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        audioSource != null && clipAsset != null;
}

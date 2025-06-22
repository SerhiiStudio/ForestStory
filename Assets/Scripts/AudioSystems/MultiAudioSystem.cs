using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiAudioSystem : AudioSystemBase
{
   // [SerializeField] protected AudioType audioType;
    [SerializeField] protected AudioSource[] audioSource;

    protected EventSystem events => EventSystem.Instance;

    public override void Play(AudioClipAsset clipAsset)
    {

    }

    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        audioSource.All(a => a != null) && clipAsset != null;
}

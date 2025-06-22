using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioSystemBase : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] protected AudioType audioType;

    public abstract void Play(AudioClipAsset clipAsset);

    protected abstract bool CanPlay(AudioClipAsset clipAsset);

    protected bool CheckAudioType(AudioType type) =>
        audioType == type;
}

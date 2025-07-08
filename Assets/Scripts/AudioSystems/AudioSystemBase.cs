using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioSystemBase : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] protected AudioType audioType;

    public abstract void SetAndPlay(AudioClipAsset clipAsset);

    public abstract void Pause(AudioType aType);
    public abstract void Unpause(AudioType aType);

    protected abstract bool CanPlay(AudioClipAsset clipAsset);
    protected abstract bool CanHandleAudioSources();

    protected bool CheckAudioType(AudioType type) =>
        audioType == type;
}

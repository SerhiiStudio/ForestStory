using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiAudioSystem : AudioSystemBase
{
    [SerializeField] protected GameObject audioSourceContainer;  
    [SerializeField] protected List<AudioSource> audioSources;

    protected EventSystem events => EventSystem.Instance;

    public override void SetAndPlay(AudioClipAsset clipAsset)
    {
         if (!CanPlay(clipAsset) || !CanHandleAudioSources() || !CheckAudioType(clipAsset.Type))
            return;
         
         var source = DetermineFreeSource(clipAsset);
         SetSourcePlay(source, clipAsset.Clip);
    }

    public override void Pause(AudioType aType)
    {
        if(!CanHandleAudioSources())
            return;

        foreach(var srs in audioSources)
            srs.Pause();
    }
    public override void Unpause(AudioType aType)
    {
        if(!CanHandleAudioSources())
            return;

        foreach(var srs in audioSources)
            srs.UnPause();
    }

    protected AudioSource DetermineFreeSource(AudioClipAsset clipAsset)
    {
         AudioSource source = null;

         foreach(var src in audioSources) 
         {
            if (src.isPlaying)
               continue;

            source = src;
            break;
         }

         if (source == null)
         {
            source = audioSourceContainer.AddComponent<AudioSource>();
            SetOutput(source);
            audioSources.Add(source);
         }

         return source;
    }

    protected void SetOutput(AudioSource source)
    {
        if(!CanHandleAudioSources() || audioSources.Count == 0)
            return;

        source.outputAudioMixerGroup = audioSources[0].outputAudioMixerGroup; // Get the first source
    }

    protected void SetSourcePlay(AudioSource source, AudioClip clip)
    {
      source.clip = clip;
      source.Play();
    }

    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        clipAsset?.Clip != null;

    protected override bool CanHandleAudioSources() =>
        audioSources != null && audioSources.All(a => a != null);
}

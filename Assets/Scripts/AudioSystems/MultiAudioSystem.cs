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
         if (CanPlay(clipAsset) && CheckAudioType(clipAsset.Type))
         {
            var source = DetermiteFreeSource(clipAsset);
            SetSourcePlay(source, clipAsset.Clip);
         }
    }

    public override void Pause(AudioType aType)
    {
        if(CanHandlePausing())
        {
            foreach(var srs in audioSources)
            {
                srs.Pause();
            }
        }
    }
    public override void Unpause(AudioType aType)
    {
        if(CanHandlePausing())
        {
            foreach(var srs in audioSources)
            {
                srs.UnPause();
            }
        }
    }

    protected AudioSource DetermiteFreeSource(AudioClipAsset clipAsset)
    {
         AudioSource source = null;

         foreach(var aSource in audioSources)
         {
            if (aSource.isPlaying)
               continue;

            source = aSource;
            break;
         }

         if (source == null)
         {
            source = audioSourceContainer.AddComponent<AudioSource>();
            audioSources.Add(source);
         }

         return source;
    }

    protected void SetSourcePlay(AudioSource source, AudioClip clip)
    {
      source.clip = clip;
      source.Play();
    }

    protected override bool CanPlay(AudioClipAsset clipAsset) =>
        audioSources.All(a => a != null) && clipAsset?.Clip != null;

    protected override bool CanHandlePausing()
    {
        if(audioSources != null)
        {
            foreach(var srs in audioSources)
            {
                if (srs == null)
                    return false;
            }
            return true;
        }
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MultiAudioSystem : AudioSystemBase
{
    [SerializeField] protected GameObject audioSourceContainer;  
    [SerializeField] protected List<AudioSource> audioSources;

    protected EventSystem events => EventSystem.Instance;

    public override void Play(AudioClipAsset clipAsset)
    {
         if (CanPlay(clipAsset))
         {
            var source = DetermiteFreeSource(clipAsset);
            SetSourcePlay(source, clipAsset.Clip);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTransition : MonoBehaviour
{
    [SerializeField] private AnimationCurve fadeOutCurve;
    [SerializeField] private AnimationCurve fadeInCurve;
    [SerializeField][Range(0f, 5f)] private float transitionDuration = 1f;

    private AudioSource activeSource;
    private AudioSource targetSource;

    private int defaultVolume = 1;



    public AudioSource Transite(AudioSource source, AudioClip clip)
    {
        if(source == null || clip == null)
            return null;

        activeSource = source;

        CreateAudioSource();
        targetSource.clip = clip;
        targetSource.volume = 0f;
        targetSource.Play();

        StartCoroutine(TransitionCoroutine());

        return targetSource;
    }

    private void CreateAudioSource()
    {
        targetSource = gameObject.AddComponent<AudioSource>();
        targetSource.outputAudioMixerGroup = activeSource.outputAudioMixerGroup;
        targetSource.loop = activeSource.loop;
    }

    private IEnumerator TransitionCoroutine()
    {
        if(activeSource == null || targetSource == null)
            yield break;

        var fadingOutSource = activeSource;
        var fadingInSource = targetSource;

        var timer = 0f;

        var fromStartVol = fadingOutSource.volume;
        var toStartVol = fadingInSource.volume;

        while(timer < transitionDuration)
        {
            float t = timer / transitionDuration;

            if(fadingOutSource != null)
                fadingOutSource.volume = fadeOutCurve.Evaluate(t) * fromStartVol;
            if(fadingInSource != null)
                fadingInSource.volume = fadeInCurve.Evaluate(t);

            timer += Time.deltaTime;
            yield return null;
        }

        if(fadingOutSource != null)
        {
            fadingOutSource.Stop();
            Destroy(fadingOutSource);
        }
        if(fadingInSource != null)
            fadingInSource.volume = defaultVolume;
    }
}

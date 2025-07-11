using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventHandler : MonoBehaviour
{
    [SerializeField] private AudioSystemBase[] audioSystems;
    private EventSystem events => EventSystem.Instance;

    private void OnEnable()
    {
        foreach(var system in audioSystems)
        {
            if (events != null && system != null)
            {
                events.SetAndPlayAudioEvent += system.SetAndPlay;
            }
        }
    }
    private void OnDisable()
    {
        foreach(var system in audioSystems)
        {
            if (events != null && system != null)
            {
                events.SetAndPlayAudioEvent -= system.SetAndPlay;
            }
       }
    }
}


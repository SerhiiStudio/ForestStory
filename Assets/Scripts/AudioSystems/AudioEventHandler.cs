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
            events.PlayAudioEvent += system.Play;
        }
    }
    private void OnDisable()
    {
        foreach(var system in audioSystems)
        {
            events.PlayAudioEvent -= system.Play;
        }
    }
}

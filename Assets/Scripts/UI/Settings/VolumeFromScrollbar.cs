using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeFromScrollbar : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private AudioMixer[] mixers;

    private Coroutine coroutine;

    private const string VOLUME_PAR = "Volume";
    private const string VOLUME_FILENAME = "Volume Data";

    private const float VOLUME_DB_MIN = -24f;
    private const float VOLUME_DB_MAX = 10f;
    private const float VOLUME_DB_MUTE = -80f;
    private const float DEFAULT_SCROLLBAR_VALUE = 0.5f;

    private const float STEP_SIZE = 0.01f;
    private const float TOLERANCE = 0.0008f;




    private void OnEnable()
    {
        StopCurrentCoroutine();

        coroutine = StartCoroutine(Initialize());

        scrollbar?.onValueChanged.AddListener(ChangeVolume);
    }
    private void OnDisable()
    {
        scrollbar?.onValueChanged.RemoveListener(ChangeVolume);
    }




    public void ChangeVolume(float value)
    {
        float dbVolume = GetDBVolume(value);

        UpdateVolume(dbVolume);

        if(!PermissionToSerializeBySteps(value))
            return;

        VolumeData volumeData = new VolumeData() { ScrollbarValue = value };
        Serializator.SaveToFolder<VolumeData>(volumeData, VOLUME_FILENAME);
    }

    private IEnumerator Initialize()
    {
        yield return null; // Wait for mixers initialize

        (VolumeData data, bool result) = Serializator.LoadFromFolder<VolumeData>(VOLUME_FILENAME);
        
        if(result == false)   // If the data is missing
            data.ScrollbarValue = DEFAULT_SCROLLBAR_VALUE; // In case of missing scrollbar we have base volume setting

        if (scrollbar != null)
                scrollbar.value = data.ScrollbarValue;
            
        ChangeVolume(data.ScrollbarValue); // To refresh value of audio mixers

        coroutine = null;
    }


    // To awoid frequent serialization
    private bool PermissionToSerializeBySteps(float value)
    {
        int step = Mathf.RoundToInt(value / STEP_SIZE);
        float center = step * STEP_SIZE;

        bool permission = Mathf.Abs(value - center) <= TOLERANCE;

        if(permission) Debug.Log(Mathf.Abs(value - center)); // While testing
        
        return permission;
    }


    private float GetDBVolume(float value)
    {
        float volume = Mathf.Lerp(VOLUME_DB_MIN, VOLUME_DB_MAX, value);

        if (volume == VOLUME_DB_MIN)
            volume = VOLUME_DB_MUTE; // If the volume is minimum - turn it off

        return volume;
    }

    private void UpdateVolume(float volume)
    {
        int nullMixerCount = 0;
        foreach(var mixer in mixers)
        {
            if(mixer != null)
                mixer.SetFloat(VOLUME_PAR, volume);
            else
                nullMixerCount++;
        }

        if(nullMixerCount > 0)
            Debug.LogWarning($"There are {nullMixerCount} null audio mixers in array");
    }



    private void StopCurrentCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}

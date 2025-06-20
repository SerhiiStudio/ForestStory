using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class TextOwnerEvents : MonoBehaviour
{
    private EventSystem events => EventSystem.Instance;

    public bool OnChangeText;
    public bool OnHideText;
    public bool OnShowText;
    public bool OnEndText;

    private void OnEnable()
    {
        events.ChangeTextEvent += ChangeText;
        events.HideTextEvent += HideText;
        events.ShowTextEvent += ShowText;
        events.EndTextEvent += EndText;
    }
    private void OnDisable()
    {
        events.ChangeTextEvent -= ChangeText;
        events.HideTextEvent -= HideText;
        events.ShowTextEvent -= ShowText;
        events.EndTextEvent -= EndText;
    }

    public void ChangeText(LocalizedString localizedText) 
    {
        if (OnChangeText) Debug.Log("Text changed: " + localizedText);
    }
    public void HideText()
    {
        if (OnHideText) Debug.Log("Text hid");
    }
    public void ShowText(LocalizedString localizedText)
    {
        if (OnShowText)
        { 
            Debug.Log("Text showed: " + localizedText);
/*
            Debug.Log("Table: " + localizedText.TableReference);
            Debug.Log("Entry: " + localizedText.TableEntryReference);
            Debug.Log("Text showed: " + localizedText);
            Debug.Log("Text hash: " + localizedText.GetHashCode());*/
        }

    }
    public void EndText() 
    {
        if (OnEndText) Debug.Log("Text ended");
    }
}

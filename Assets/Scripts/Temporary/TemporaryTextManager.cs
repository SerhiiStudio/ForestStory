using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class TemporaryTextManager : MonoBehaviour
{
    [SerializeField] private Text currentText;
    [SerializeField] private LocalizeStringEvent currentLocalizationEvent;

    private void OnEnable()
    {
        EventSystem.Instance.ChangeTextEvent += ChangeText;
        EventSystem.Instance.HideTextEvent += HideText;
        EventSystem.Instance.ShowTextEvent += ShowText;
        EventSystem.Instance.EndTextEvent += HideText;
    }
    private void OnDisable()
    {
        EventSystem.Instance.ChangeTextEvent -= ChangeText;
        EventSystem.Instance.HideTextEvent -= HideText;
        EventSystem.Instance.ShowTextEvent -= ShowText;
        EventSystem.Instance.EndTextEvent -= HideText;
    }

    private bool CheckWorkability() => 
    currentText != null &&
    currentLocalizationEvent != null;


    private void ChangeText(LocalizedString localizedText)
    {
        currentLocalizationEvent.StringReference = localizedText;
    }

    private void HideText()
    {
        currentText.enabled = false;
    }

    private void ShowText(LocalizedString localizedText)
    {
        currentLocalizationEvent.StringReference = localizedText;
        currentText.enabled = true;
    }
}

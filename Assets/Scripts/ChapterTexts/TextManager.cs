using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class TextManager : MonoBehaviour
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
        if (!CheckWorkability())
            return;

        localizedText.GetLocalizedStringAsync().Completed += context => 
        {
            string localizedStr = context.Result;
            currentText.text = localizedStr;
        };

        if (currentText.enabled == false)
            currentText.enabled = true;

    }

    private void HideText()
    {
        if (!CheckWorkability())
            return;
        currentText.text = "";

        currentText.enabled = false;
    }

    private void ShowText(LocalizedString localizedText)
    {
        if (CheckWorkability())
        {
            localizedText.GetLocalizedStringAsync().Completed += context =>
            {
                string localizedStr = context.Result;
                currentText.text = localizedStr;
            };
            currentText.enabled = true;
        }
    }
}

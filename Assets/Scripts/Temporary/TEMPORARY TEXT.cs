using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class TEMPORARYTEXT : MonoBehaviour
{
    [SerializeField] protected GameObject trigger;
    [SerializeField] protected LocalizeStringEvent localizeStrEvent;
    [SerializeField] protected TextsData txtData;
    [SerializeField] protected int clickCount = 2;
    [SerializeField] protected int id;

    protected LocalizedString hiddenText;

    protected int clicked;

    protected bool isHidden = false;


    protected void OnEnable()
    {
        if (txtData == null || txtData.LocalizedTexts.Length == 0)
        {
            string msg = $"List of text is : {(txtData == null ? "null" : "empty")} \n\n Gameobject's name: {gameObject.name}";

            Debug.LogWarning(msg);
        }

        EventSystem.Instance.Buttons += Clicked;
        EventSystem.Instance.LeaveIteractionTriggers += HideText;
        EventSystem.Instance.IteractionTriggers += ShowText;
    }

    protected void OnDisable()
    {
        EventSystem.Instance.Buttons -= Clicked;
        EventSystem.Instance.LeaveIteractionTriggers -= HideText;
        EventSystem.Instance.IteractionTriggers -= ShowText;
    }

    protected void Clicked(int id)
    {
        if (this.id == id)
        {
            clicked++;
            int textIndex = clicked - 1;
            int previousTextIndex = clicked - 2;

            if (previousTextIndex < txtData.LocalizedTexts.Length && previousTextIndex >= 0)
            {
            }
            if (textIndex < txtData.LocalizedTexts.Length)
            {
                localizeStrEvent.StringReference = txtData[textIndex];
            }

            if (textIndex == txtData.LocalizedTexts.Length)
            {
                localizeStrEvent.gameObject.SetActive(false);
                Debug.LogError("");
            }

            if (clicked == clickCount)
            {
                if (trigger != null)
                trigger.SetActive(false);
            }
        }
    }


    protected void HideText(int id)
    {
        if (this.id == id && !isHidden && TextEnabled(txtData))
        {
            localizeStrEvent.gameObject.SetActive(false);
            isHidden = true;
        }
    }

    protected void ShowText(int id)
    {
        if (this.id == id && isHidden)
        {
            localizeStrEvent.gameObject.SetActive(true);
            
            isHidden = false;
        }
    }

    protected bool TextEnabled(TextsData texts) =>
        texts != null && texts.LocalizedTexts.Any(t => t != null /*&& t.activeText*/);


    protected void ShowOrHideText(bool show)
    {

    }
}

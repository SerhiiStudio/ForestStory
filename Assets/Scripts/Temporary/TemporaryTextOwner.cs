using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class TemporaryTextOwner : MonoBehaviour // All debug.logerrors are while testing
{
    [SerializeField] protected int id;
    [SerializeField] protected TextsData txtData;
   

    [Header("Deleteself")]
    [SerializeField] protected GameObject trigger;


    protected int clickCount;
    protected LocalizedString currentText;

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

    protected void Start()
    {
        clickCount = txtData.LocalizedTexts.Length + 1; // Lenght plus one to hide the last element
    }

    protected void Clicked(int id)
    {
        if (this.id == id)
        {
            clicked++;

            int textIndex = clicked - 1;
            
            if (textIndex < txtData.LocalizedTexts.Length)
            {
                currentText = txtData.LocalizedTexts[textIndex];
                Debug.LogError("text changed");

                // Call the manager to change the text
                EventSystem.Instance.ChangeText(currentText);
            }

            if (clicked == clickCount)
            {
                // Tell the manager that this text is done
                EventSystem.Instance.EndText();
                Debug.LogError("this text is done");
                if (trigger != null)
                    trigger.SetActive(false);
            }
        }
    }


    protected void HideText(int id)
    {
        if (CanToggleText(id, false))
        {
            // Call the manager to hide the text
            EventSystem.Instance.HideText();
            Debug.LogError("text hid");
            isHidden = true;
        }
    }

    protected void ShowText(int id)
    {
        if (CanToggleText(id, true))
        {
            // Call the managere to show the text
            EventSystem.Instance.ShowText(currentText);
            Debug.LogError("text showed");
            isHidden = false;
        }
    }


    protected bool CanToggleText(int id, bool targetHiddenState) =>
    
        this.id == id && targetHiddenState == isHidden && TextEnabled(txtData);
    

    protected bool TextEnabled(TextsData texts) =>
        texts != null && texts.LocalizedTexts.Any(t => t != null);

}

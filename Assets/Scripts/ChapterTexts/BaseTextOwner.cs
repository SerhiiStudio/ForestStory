using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class BaseTextOwner : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected TextsData txtData;
   

    [Header("Deleteself")]
    [SerializeField] protected GameObject trigger;


    protected int clickCount;
    protected LocalizedString currentText;

    protected int clicked;

    protected bool isHidden = false;

    protected EventSystem events => EventSystem.Instance;


    protected void OnEnable()
    {
        events.Buttons += Clicked;
        events.LeaveIteractionTriggers += HideText;
        events.IteractionTriggers += ShowText;
    }

    protected void OnDisable()
    {
        events.Buttons -= Clicked;
        events.LeaveIteractionTriggers -= HideText;
        events.IteractionTriggers -= ShowText;
    }

    protected void Start()
    {
        int length = txtData?.LocalizedTexts?.Length ?? 0; // Define clickCount based on lenght of localized strings
        clickCount = length;
    }

    /// <summary>
    /// Activates on Buttons event
    /// </summary>
    /// <remarks>
    /// Calls: <see cref="CheckId(int)"\> - if true calls <see cref="IncreaseClicked"/> and determines <see cref="F:textIndex"/>, 
    /// calls <see cref="ChangeText(int)"/>
    /// and <see cref="CheckReachClickCount"/> - if true calls <see cref="EndText"/>
    /// </remarks>
    /// <param name="id">Id of the button that called the event</param>
    protected void Clicked(int id)
    {
        if (!CheckId(id))
            return;
        
        
            
        ChangeText(ExtractIndex());

        if (CheckReachClickCount())
            EndText();   

        IncreaseClicked();
    }


    protected virtual void ChangeText(int textIndex)
    {
        if (!TextEnabled())
        {
                Debug.LogError("An error occured");
                return;
        }
        if (CheckLengthLimit(textIndex))
        {
            currentText = txtData.LocalizedTexts[textIndex];
            // Call the manager to change the text
            CallChangeText();
        }
    }

    protected virtual bool CheckLengthLimit(int textIndex) =>
        textIndex < txtData.LocalizedTexts.Length;

    protected virtual void CallChangeText() =>
        events.ChangeText(currentText);

    protected virtual void EndText()
    {
        // Tell the manager that this text is done
        events.EndText();
        if (trigger != null)
            trigger.SetActive(false);
    }

    protected virtual void HideText(int id)
    {
        if (CheckId(id) && CanToggleText(false))
        {
            // Call the manager to hide the text
            events.HideText();
            isHidden = true;
        }
    }

    protected virtual void ShowText(int id)
    {
        if (CheckId(id) && CanToggleText(true) && currentText != null)
        {
            // Call the managere to show the text
            events.ShowText(currentText);
            isHidden = false;
        }
    }

    protected virtual int ExtractIndex() =>
        clicked;

    protected void IncreaseClicked() =>
        clicked++;

    protected bool CanToggleText(bool targetHiddenState) =>
    
        targetHiddenState == isHidden && TextEnabled();

    protected bool TextEnabled() =>
        txtData?.LocalizedTexts != null && txtData.LocalizedTexts.Length != 0 && txtData.LocalizedTexts.Any(t => t != null);

    protected bool CheckId(int id) =>
        id == this.id;

    protected bool CheckReachClickCount() =>
        clicked >= clickCount;
}

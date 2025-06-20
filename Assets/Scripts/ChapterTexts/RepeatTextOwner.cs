using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTextOwner : BaseTextOwner
{
    protected override int ExtractIndex()
    {
        int currentSequenceIndex = (clicked - 1) / 2;
        int count = txtData?.LocalizedTexts?.Length ?? 1;
        return currentSequenceIndex % count;
    }

    protected override void ChangeText(int textIndex)
    {
        if (clicked % 2 != 0)
        {
            base.ChangeText(textIndex);
            isHidden = false;
        }
        else
        {
            events.HideText();
            isHidden = true;
        }
    }

    protected override void EndText() { }
}

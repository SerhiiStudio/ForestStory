using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsed_Count_Listener : ItemUsedListener
{
    [SerializeField] protected int clickCount;
    protected int clicked;

    protected override bool CanHandle(int id)
    {
        IncreaseClicked();
        bool flag = base.CanHandle(id);
        flag &= CheckClicked();
        return flag;
    }

    protected void IncreaseClicked() => clicked++;
    protected bool CheckClicked() => clicked == clickCount;
}

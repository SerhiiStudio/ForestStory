using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TakeItemCountListener : TakeItemListener
{
    [SerializeField] private int clickCount;
    private int clicked;


    protected override void OnButtonClicked(int id)
    {
        if (id == this.id){
            clicked++;
            if (clicked == clickCount)
                base.OnButtonClicked(id);
        }
    }
}

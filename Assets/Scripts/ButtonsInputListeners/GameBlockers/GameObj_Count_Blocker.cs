using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObj_Count_Blocker : GameObjBlocker
{
    [Header("")] // Add a little space

    [SerializeField] private int clickCount;
    private int clicked;

    protected override void CallMethods()
    {
        if (CanExecute())
         {
             base.CallMethods();
         }
    }

    protected override bool CanExecute() 
    {
        clicked ++;

        if (clicked >= clickCount)
             return true;

         return false;
    }
}

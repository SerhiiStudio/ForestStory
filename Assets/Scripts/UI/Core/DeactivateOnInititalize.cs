using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnInititalize : AbsUiInitializable
{
    public override void Initialize()
    {
        gameObject.SetActive(false);
    }
}

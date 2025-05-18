using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListWLimits", menuName = "Data/World/Limits", order = 1)]
public class ListWorldLimits : ScriptableObject
{
    public List<WLimits> list;
}

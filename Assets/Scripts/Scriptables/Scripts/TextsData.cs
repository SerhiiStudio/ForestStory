using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TextsDataAsset", menuName = "Data/TextData")]
public class TextsData : ScriptableObject
{
    [SerializeField] private LocalizedString[] localizedStr;

    public LocalizedString[] LocalizedStr => localizedStr;
}

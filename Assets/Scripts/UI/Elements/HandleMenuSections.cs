using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMenuSections : MonoBehaviour
{
    [SerializeField] private GameObject menuSection;

    public void Open() 
    {
        if (menuSection != null)
            menuSection.SetActive(true);
    }
    public void Close() 
    {
        if (menuSection != null)
            menuSection.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandleTheMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    private bool IsPaused => menuObj.activeSelf;

    private void InputHandler(InputAction.CallbackContext ctx)
    {
        HandleMenu();
    }   
    
    private void OnEnable()
    {
        InputSistema.Instance.Input.Background.Esc.performed += InputHandler;
    } 

    public void HandleMenu()
    {
        menuObj.SetActive(!IsPaused);
    }
}

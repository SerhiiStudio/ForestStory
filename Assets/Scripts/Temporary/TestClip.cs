using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestClip : MonoBehaviour
{
    [SerializeField] private AudioClipAsset clipasset;
    private PlayerInput input_;

    private void Awake()
    {
        input_ = new PlayerInput();
    }

    private void OnEnable()
    {
        input_.Enable();

        input_.Test.Test.performed += ActivateAudioEvent;
    }
    private void OnDisable()
    {
        input_.Disable();

        input_.Test.Test.performed -= ActivateAudioEvent;
    }

    private void ActivateAudioEvent(InputAction.CallbackContext ctx)
    {
        EventSystem.Instance.SetAndPlayAudio(clipasset);
        Debug.Log("played");
    }
}

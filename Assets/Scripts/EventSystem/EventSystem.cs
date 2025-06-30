using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class EventSystem : MonoBehaviour
{
	public static EventSystem Instance;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	


// Triggers
//--------------------
	public event Action<int> IteractionTriggers;
	public event Action<int> LeaveIteractionTriggers;
//--------------------
	public void GetOnTrigger(int id) =>
		IteractionTriggers?.Invoke(id);
	
	public void GetOffTrigger(int id) =>
		LeaveIteractionTriggers?.Invoke(id);
//--------------------


// Buttons & clicks
//--------------------
	public event Action<int> Buttons;
//--------------------
	public void ClickedButton(int id) =>
		Buttons?.Invoke(id);
//--------------------

	
// Day transitioning
//--------------------
	public event Action<Locations> LocationTransitionStarted;
	public event Action<Locations> LocationTransitionFinished;
//--------------------
	public void StartLocationTransition(Locations locationToTransitTo) =>
		LocationTransitionStarted?.Invoke(locationToTransitTo);

	public void NotifyLocationTransitionEnded(Locations locationSwitchedTo) =>
		LocationTransitionFinished?.Invoke(locationSwitchedTo);
//--------------------


// Affect camera
//--------------------
	public event Action<Transform> TurnCameraEvent;
//--------------------
	public void TurnCamera(Transform transform)=>
		TurnCameraEvent?.Invoke(transform);
//--------------------


// Affect player
//--------------------
	public event Action<Transform> DisplacePlayerEvent;
	public event Action<bool> EnablePlayerMovement;
//--------------------
	public void DisplacePlayer(Transform transform) =>
		DisplacePlayerEvent?.Invoke(transform);
	public void EnableOrDisablePlayerMovement(bool enable) =>
		EnablePlayerMovement?.Invoke(enable);
//--------------------


// Work with items and inventory
//--------------------
	public event Action<int> TakeItemEvent;

	public event Action<ItemData> TakeItemToInventoryEvent;
	public event Func<ItemData, bool> UseItemInInventoryEvent;

	public event Action<int, bool> ItemUsedEvent;
	public event Action<int> ItemSuccessfullyUsedRemovedEvent;

	public event Func<ItemData, bool> TakeItemOffInventoryEvent;

	public event Action InventoryFullEvent;
//--------------------
	public void TakeItem(int id) =>
		TakeItemEvent?.Invoke(id);

	public void TakeItemToInventory(ItemData data) =>
		TakeItemToInventoryEvent?.Invoke(data);

	public bool UseItemInInventory(ItemData data) =>
		UseItemInInventoryEvent?.Invoke(data) ?? false;

	public void ItemSuccessfullyUsed(int id, bool result) =>
		ItemUsedEvent?.Invoke(id, result);

	public void ItemSuccessfullyRemoved(int id) =>
		ItemSuccessfullyUsedRemovedEvent?.Invoke(id);

	public bool TakeItemOffInventory(ItemData data) =>
		TakeItemOffInventoryEvent?.Invoke(data) ?? false;

	public void NotifyInventoryFull() =>
		InventoryFullEvent?.Invoke();
//--------------------


// Work with audio
//--------------------
	public event Action<AudioClipAsset> SetAndPlayAudioEvent;
	public event Action<AudioType> PauseAudioSystemEvent;
	public event Action<AudioType> UnpauseAudioSystemEvent;
//--------------------
	public void SetAndPlayAudio(AudioClipAsset audioClip) => 
		SetAndPlayAudioEvent?.Invoke(audioClip);
	public void PauseAudioSystem(AudioType aType) =>
		PauseAudioSystemEvent?.Invoke(aType);
	public void UnpauseAudioSystem(AudioType aType) =>
		UnpauseAudioSystemEvent?.Invoke(aType);
//--------------------


// Work with text	
//--------------------
	public event Action<LocalizedString> ChangeTextEvent;
	public event Action HideTextEvent;
	public event Action<LocalizedString> ShowTextEvent;
	public event Action EndTextEvent;
//--------------------
	public void ChangeText(LocalizedString localizedText) =>
		ChangeTextEvent?.Invoke(localizedText);

	public void HideText() =>
		HideTextEvent?.Invoke();

	public void ShowText(LocalizedString localizedText) =>
		ShowTextEvent?.Invoke(localizedText);

	public void EndText() =>
		EndTextEvent?.Invoke();
//--------------------
}

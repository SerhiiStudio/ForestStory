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
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public event Action<int> IteractionTriggers;
	public event Action<int> LeaveIteractionTriggers;
	public event Action<int> Buttons;

	public event Action<bool> EnablePlayerMovement;

	public event Action<Days> DayTransitionStarted;
	public event Action<Days> DayTransitionFinished;

	public event Action<Transform> TurnCameraEvent;
	public event Action<Transform> DisplacePlayerEvent;

	public event Action<int> TakeItemEvent;

	public event Action<ItemData> TakeItemToInventoryEvent;
	public event Func<ItemData, bool> UseItemInInventoryEvent;

	public event Action<int> ItemSuccessfullyUsedEvent;
	public event Action<int> ItemSuccessfullyUsedRemovedEvent;

	public event Func<ItemData, bool> TakeItemOffInventoryEvent;

	public event Action InventoryFullEvent;

	public event Action<AudioClipAsset> PlayAudioEvent;

	public event Action<LocalizedString> ChangeTextEvent;
	public event Action HideTextEvent;
	public event Action<LocalizedString> ShowTextEvent;
	public event Action EndTextEvent;


	public void GetOnTrigger(int id)
	{
		IteractionTriggers?.Invoke(id);
	}
	public void GetOffTrigger(int id)
	{
		LeaveIteractionTriggers?.Invoke(id);
	}
	public void ClickedButton(int id)
	{
		Buttons?.Invoke(id);
	}

	public void EnableOrDisablePlayerMovement(bool enable)
	{
		EnablePlayerMovement?.Invoke(enable);
	}

	public void StartDayTransition(Days dayToTransitTo)
	{
		DayTransitionStarted?.Invoke(dayToTransitTo);
	}
	public void NotifyDayTransitionEnded(Days daySwitchedTo)
	{
		DayTransitionFinished?.Invoke(daySwitchedTo);
	}

	public void TurnCamera(Transform transform)
	{
		TurnCameraEvent?.Invoke(transform);
	}
	public void DisplacePlayer(Transform transform)
	{
		DisplacePlayerEvent?.Invoke(transform);
	}

	public void TakeItem(int id)
	{
		TakeItemEvent?.Invoke(id);
	}
	public void TakeItemToInventory(ItemData data)
	{
		TakeItemToInventoryEvent?.Invoke(data);
	}
	public bool UseItemInInventory(ItemData data)
	{
		return UseItemInInventoryEvent?.Invoke(data) ?? false;
	}

	public void ItemSuccessfullyUsed(int id)
	{
		ItemSuccessfullyUsedEvent?.Invoke(id);
	}
	public void ItemSuccessfullyRemoved(int id)
	{
		ItemSuccessfullyUsedRemovedEvent?.Invoke(id);
	}

	public bool TakeItemOffInventory(ItemData data)
	{
		return TakeItemOffInventoryEvent?.Invoke(data) ?? false;
	}


	public void NotifyInventoryFull()
	{
		InventoryFullEvent?.Invoke();
	}


	public void PlayAudio(AudioClipAsset audioClip)
	{

		PlayAudioEvent?.Invoke(audioClip);
	}

	public void ChangeText(LocalizedString localizedText)
	{
		ChangeTextEvent?.Invoke(localizedText);
	}

	public void HideText()
	{
		HideTextEvent?.Invoke();
	}

	public void ShowText(LocalizedString localizedText)
	{
		ShowTextEvent?.Invoke(localizedText);
	}

	public void EndText()
	{
		EndTextEvent?.Invoke();
	}
}

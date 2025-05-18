using System;
using UnityEngine;

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
	public event Action<Days> DayTransitionStarted;
	public event Action<Days> DayTransitionFinished;


	public void GetOnTrigger(int id)
	{
		IteractionTriggers?.Invoke(id);
		Debug.Log("Trigger ID: " + id + " activated");
	}
	public void GetOffTrigger(int id)
	{
		LeaveIteractionTriggers?.Invoke(id);
	}
	public void ClickedButton(int id)
	{
		Buttons?.Invoke(id);
	}
	public void StartDayTransition(Days dayToTransitTo)
	{
		DayTransitionStarted?.Invoke(dayToTransitTo);
	}
	public void NotifyDayTransitionEnded(Days daySwitchedTo)
	{
		DayTransitionFinished?.Invoke(daySwitchedTo);
	}
}

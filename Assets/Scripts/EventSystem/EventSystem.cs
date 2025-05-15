using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
	public static EventSystem Instance;

	private void Awake()
	{
		Instance = this;
	}

	public event Action<int> IteractionTriggers;
	public event Action<int> LeaveIteractionTriggers;
	public event Action<int> Buttons;


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
}

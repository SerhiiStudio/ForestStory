using System;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
	public static EventSystem instance;

	public void Awake()
	{
		instance = this;
	}

	public event Action PlayerCameToHouseDoorEvent;
	public void PlayerCameToHouseDoor() 
	{
		PlayerCameToHouseDoorEvent?.Invoke();
	}
}

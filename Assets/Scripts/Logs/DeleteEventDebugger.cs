using UnityEngine;

public class DeleteEventDebugger : MonoBehaviour
{
	private void Start()
	{
		EventSystem.instance.PlayerCameToHouseDoorEvent += debugteh;
	}

	private void debugteh()
	{
		Debug.Log("entererd");
	}
}

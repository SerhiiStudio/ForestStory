using UnityEngine;

public class Itemtaken : MonoBehaviour
{
	private void OnEnable()
	{
		EventSystem.Instance.TakeItemEvent += LogItemHasBeenTaken;
	}
	private void OnDisable()
	{
		EventSystem.Instance.TakeItemEvent -= LogItemHasBeenTaken;
	}

	private void LogItemHasBeenTaken(int id)
	{
		Debug.Log("Item has been taken");
	}
}

using UnityEngine;

public class GameObjectBlocker : MonoBehaviour
{
	[SerializeField] private bool block;
	[SerializeField] private int id;
	[SerializeField] private int clickCount;
	[SerializeField] private GameObject[] gameObjectsToBlock;

	private int clicked;
	private void Blocker(int id)
	{
		if (id == this.id)
		{
			clicked++;
			if (clicked == clickCount)
				foreach (GameObject go in gameObjectsToBlock)
					go.SetActive(!block);
		}
	}

	private void OnEnable()
	{
		EventSystem.Instance.Buttons += Blocker;
	}
	private void OnDisable()
	{
		EventSystem.Instance.Buttons -= Blocker;
	}
}

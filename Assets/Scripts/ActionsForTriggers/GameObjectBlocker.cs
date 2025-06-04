using UnityEngine;

public class GameObjectBlocker : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private int clickCount;
	[SerializeField] private GameObject[] gameObjectsToBlock;
	[SerializeField] private GameObject[] gameObjectsToUnblock;

	private int clicked;
	private void Blocker(int id)
	{
		if (id == this.id)
		{
			clicked++;
			if (clicked == clickCount)
			{
				foreach (GameObject go in gameObjectsToBlock)
					go.SetActive(false);
				foreach (GameObject go in gameObjectsToUnblock)
					go.SetActive(true);
			}
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

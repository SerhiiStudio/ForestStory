using UnityEngine;

public class TakeItemListener : MonoBehaviour
{

	[SerializeField] private int id;

	private void TakeItem(int id)
	{
		if (id == this.id)
		{
			EventSystem.Instance.TakeItem(id);
		}
	}

	private void OnEnable()
	{
		EventSystem.Instance.Buttons += TakeItem;
	}
	private void OnDisable()
	{
		EventSystem.Instance.Buttons -= TakeItem;
	}
}

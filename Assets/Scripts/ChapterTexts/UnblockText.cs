using UnityEngine;

public class UnblockText : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private GameObject targetTrigger;
	private int clicked;
	[SerializeField] private int clickCount = 2;

	private void Start()
	{
		EventSystem.Instance.Buttons += Clicked;
	}

	private void Clicked(int id)
	{
		Debug.Log("Entered text event: " + id);

		if (this.id == id)
		{
			clicked++;

			if (clicked == clickCount)
			{
				targetTrigger.SetActive(true);
			}
		}
	}
}
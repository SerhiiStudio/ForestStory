using UnityEngine;
using UnityEngine.UI;

public class SimpleText : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private GameObject trigger;
	[SerializeField] private Text text1;
	[SerializeField] private Text text2;
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
			Debug.LogWarning(clicked);
			switch (clicked)
			{
				case 1:
					text1.enabled = true;
					break;
				case 2:
					text1.enabled = false;

					if (text2 != null)
						text2.enabled = true;
					break;
				case 3:
					text2.enabled = false;
					break;
			}
			if (clicked == clickCount)
				trigger.SetActive(false);
		}
	}
}

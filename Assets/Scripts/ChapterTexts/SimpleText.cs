using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SimpleText : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private GameObject trigger;
	[SerializeField] private List<Text> text;
	[SerializeField] private Text text1;
	[SerializeField] private Text text2;
	[SerializeField] private Text text3;
	[SerializeField] private Text text4;
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

					if (text3 != null)
						text3.enabled = true;
					break;
				case 4:
					text3.enabled = false;

				if (text4 != null)
						text4.enabled = true;
					break;
				case 5:
					text4.enabled = false;
					break;
			}
			if (clicked == clickCount)
				trigger.SetActive(false);
		}
	}

	private void HideText(int id)
	{
		if (this.id == id) 
		{

		}
	}
}

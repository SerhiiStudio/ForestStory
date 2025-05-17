using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
			int textIndex = clicked - 1;
			int previousTextIndex = clicked - 2;

			if (previousTextIndex < text.Count && previousTextIndex >= 0)
				text[previousTextIndex].enabled = false;
			if (textIndex < text.Count)
				text[textIndex].enabled = true;

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

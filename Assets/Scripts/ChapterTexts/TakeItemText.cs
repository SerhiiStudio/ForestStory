using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItemText : BaseText
{
	protected override void Clicked(int id)
	{
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
			{
				trigger.SetActive(false);
				EventSystem.Instance.TakeItem(id);
			}
		}
	}
}

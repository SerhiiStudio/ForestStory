using UnityEngine;

public sealed class SimpleText : BaseText
{
	protected override void Clicked(int id)
	{
		//Debug.Log("Entered text event: " + id);

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
}

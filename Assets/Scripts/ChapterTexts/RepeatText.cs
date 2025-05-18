using UnityEngine;

public sealed class RepeatText : BaseText
{
	protected override void Clicked(int id)
	{
		Debug.Log("Entered text event: " + id);

		if (this.id == id)
		{
			clicked++;

			int currentSequenceIndex = (clicked - 1) / 2;


			int listIndex = currentSequenceIndex % text.Count;


			foreach (var txt in text)
			{
				txt.enabled = false;
			}


			if (clicked % 2 != 0)
			{
				text[listIndex].enabled = true;
			}

		}
	}
}

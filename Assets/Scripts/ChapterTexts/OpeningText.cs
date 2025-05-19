public class OpeningText : BaseText
{
	protected override void Clicked(int id)
	{
		if (this.id == id)
		{
			clicked++;
			if (clicked == 1)
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

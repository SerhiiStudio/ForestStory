using UnityEngine;

public sealed class Use_Count_ItemListener : UseItemListener
{
	[SerializeField] private int clickCount;
	private int clicked;
	protected override void OnButtonClicked(int id)
	{
		clicked++;
		if (clicked == clickCount)
			base.OnButtonClicked(id);
	}
}

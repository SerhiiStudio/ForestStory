using UnityEngine;

public sealed class Remove_Count_ItemListener : RemoveItemListener
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

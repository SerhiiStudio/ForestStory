using UnityEngine;

public class TakeAble : BaseItem
{
	[SerializeField] private int id;
	[SerializeField] private int clickCount;
	private int clicked;

	[Header("If ")]
	[SerializeField] private GameObject thisGo;
	[SerializeField] private GameObject inventorySlotGo;

	private void Clicked(int id)
	{
		if (id == this.id) 
		{
			clicked++;
			if (clicked == clickCount)
			{
				//action
			}
		}
	}
}

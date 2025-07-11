using UnityEngine;

public class RemoveItemListener : AbsItemListener
{
	[SerializeField] protected ItemData data;
	protected override void OnButtonClicked(int id)
	{
		if (id == this.id)
		{
			if ((EventSystem.Instance?.TakeItemOffInventory(data) ?? false) && data != null)
			{
				EventSystem.Instance.ItemSuccessfullyRemoved(id);
			}
		}
	}
}

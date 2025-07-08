using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] protected Image image;

	[SerializeField] protected ItemData itemData;

	public ItemData ItemData => itemData;
	public bool Empty => itemData == null;


	public void AddItem(ItemData data)
	{
		itemData = data;

		image.sprite = itemData.Image;
		image.enabled = true;
	}

	public void UseItem(ItemData data)
	{
		if (data.PlaySoundOnUsing)
			EventSystem.Instance.SetAndPlayAudio(itemData.UseItemSound);
	}

	public void RemoveItem(ItemData data)
	{
		if (data == this.itemData)
		{
			if (data.PlaySoundOnRemoving)
				EventSystem.Instance.SetAndPlayAudio(itemData.RemoveItemSound);

			image.enabled = false;
			itemData = null;
		}
	}
}

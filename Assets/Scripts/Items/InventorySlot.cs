using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	[SerializeField] protected Image image;

	[Header("Should be audio effect")]
	[SerializeField] protected bool playSoundEffect;

	[SerializeField] protected ItemData itemData;

	public ItemData ItemData => itemData;
	public bool Empty => itemData == null;


	public void AddItem(ItemData data)
	{
		itemData = data;

		image.sprite = itemData.image;
		image.enabled = true;
		Debug.LogError(image.enabled);
	}

	public void UseItem(ItemData data)
	{
		if (data.playSoundOnUsing)
			EventSystem.Instance.PlayAudio(itemData.useItemSound);
	}

	public void RemoveItem(ItemData data)
	{
		if (data == this.itemData)
		{
			image.enabled = false;
			itemData = null;

			if (data.playSoundOnRemoving)
				EventSystem.Instance.PlayAudio(itemData.removeItemSound);
		}
	}
}

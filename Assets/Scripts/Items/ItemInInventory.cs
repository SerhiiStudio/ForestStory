using UnityEngine;
using UnityEngine.UI;

public class ItemInInventory : MonoBehaviour
{
	[SerializeField] protected Image image;

	[Header("Should be audio effect")]
	[SerializeField] protected bool playSoundEffect;

	[SerializeField] protected ItemData itemData;

	public ItemData ItemData => itemData;
	public bool Active => image.sprite != null;

	protected void OnEnable()
	{/*
		EventSystem.Instance.TakeItemToInventoryEvent += ShowItem;
		EventSystem.Instance.UseItemInInventoryEvent += UseItem;
		EventSystem.Instance.TakeItemOffInventoryEvent += HideItem;*/
	}

	protected void OnDisable()
	{
		//EventSystem.Instance.TakeItemToInventoryEvent -= ShowItem;
		//EventSystem.Instance.UseItemInInventoryEvent -= UseItem;
		//EventSystem.Instance.TakeItemOffInventoryEvent -= HideItem;
	}


	public void AddItem(ItemData data)
	{
		if (image == null)
		{
			image.sprite = itemData.image;
			image.enabled = true;
		}
	}

	public bool UseItem(ItemData data)
	{
		if (data == this.itemData && image.enabled)
		{
			if (data.playSoundOnUsing)
				EventSystem.Instance.PlayAudio(itemData.useItemSound);
			return true;
		}
		return false;
	}

	protected void HideItem(ItemData data)
	{
		if (data == this.image)
		{
			image.enabled = false;

			if (data.playSoundOnRemoving)
				EventSystem.Instance.PlayAudio(itemData.removeItemSound);
		}
	}
}

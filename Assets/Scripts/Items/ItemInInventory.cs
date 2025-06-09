using Unity.VisualScripting;
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
	{
		EventSystem.Instance.TakeItemToInventoryEvent += ShowItem;
		EventSystem.Instance.UseItemInInventoryEvent += UseItem;
		EventSystem.Instance.TakeItemOffInventoryEvent += HideItem;
	}

	protected void OnDisable()
	{
		EventSystem.Instance.TakeItemToInventoryEvent -= ShowItem;
		EventSystem.Instance.UseItemInInventoryEvent -= UseItem;
		EventSystem.Instance.TakeItemOffInventoryEvent -= HideItem;
	}


	protected void ShowItem(ItemData data)
	{
		if (image == null)
		{
			image.sprite =  itemData.image;
			image.enabled = true;
		}
	}

	protected void UseItem(ItemData data)
	{
		if (data == this.image && image.enabled)
		{
			EventSystem.Instance.PlayAudio(itemData.useItemSound);
		}
	}

	protected void HideItem(ItemData data)
	{
		if (data == this.image)
		{
			image.enabled = false;

			EventSystem.Instance.PlayAudio(itemData.removeItemSound);
		}
	}
}

using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private InventorySlot[] itemSlots;



	private void AddItem(ItemData itemData)
	{
		if(itemData == null)
			return;
			
		foreach (InventorySlot slot in itemSlots)
		{
			if (slot == null || !slot.Empty)
				continue;

			slot.AddItem(itemData);
			EventSystem.Instance.ItemAddedToInventory(itemData, true);
			return;
		}

		EventSystem.Instance.NotifyInventoryFull(itemData);
	}

	private bool UseItem(ItemData itemData)
	{
		foreach (InventorySlot slot in itemSlots)
		{
			if (slot == null || slot.Empty)
				continue;
			if (slot.ItemData == itemData)
			{
				slot.UseItem(itemData);
				return true;
			}
		}
		return false;
	}

	private bool RemoveItem(ItemData itemData)
	{
		foreach (InventorySlot slot in itemSlots)
		{
			if (slot == null || slot.Empty)
				continue;
			if (slot.ItemData == itemData)
			{
				slot.RemoveItem(itemData);
				return true;
			}
		}
		return false;
	}

	private void OnEnable()
	{
		EventSystem.Instance.TakeItemToInventoryEvent += AddItem;
		EventSystem.Instance.UseItemInInventoryEvent += UseItem;
		EventSystem.Instance.TakeItemOffInventoryEvent += RemoveItem;
	}
	private void OnDisable()
	{
		EventSystem.Instance.TakeItemToInventoryEvent -= AddItem;
		EventSystem.Instance.UseItemInInventoryEvent -= UseItem;
		EventSystem.Instance.TakeItemOffInventoryEvent -= RemoveItem;
	}
}

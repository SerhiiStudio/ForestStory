using UnityEngine;

public class Inventory : MonoBehaviour
{
	[SerializeField] private ItemInInventory[] itemSlots;

	private void AddItem(ItemData itemData)
	{
		foreach (ItemInInventory slot in itemSlots) 
		{
			if (slot.Active)
			{

			}
		}
	}
}

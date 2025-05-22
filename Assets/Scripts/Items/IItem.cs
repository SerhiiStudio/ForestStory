using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
	[SerializeField] protected int itemId;
	[SerializeField] protected int collectToInventory;
	[Tooltip("If item is supposed to be in inventory")]
	[SerializeField] protected Sprite inInventory;
	protected virtual void Take()
	{

	}

	public virtual void TakeToInventory()
	{

	}
}

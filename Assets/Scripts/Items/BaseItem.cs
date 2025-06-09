using System.Collections;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
	//[SerializeField] protected int itemId;
	[SerializeField] protected bool collectToInventory;
	[SerializeField] protected Animator animator;
	[Header("If item is supposed to be in inventory")]
	[SerializeField] protected ItemData itemData;
	[Header("\n\n-----------------------------------\n" +
		"Must be identical to text/trigger id")] // Not necessary but recommended
	[SerializeField] protected int id;

	protected virtual void Take(int id)
	{
		if (id == this.id)
		{
			// If item is supposed to be in inventory
			if (collectToInventory)
			{
				//itemData.id = id;

				TakeToInventory();

				

				return;
			}
			EventSystem.Instance.PlayAudio(itemData.takeItemSound);
			StartAnimationCoroutine();
		}
	}

	protected virtual void TakeToInventory()
	{
		EventSystem.Instance.TakeItemToInventory(itemData);
	}

	protected void OnEnable()
	{
		EventSystem.Instance.TakeItemEvent += Take;
	}
	protected void OnDisable()
	{
		EventSystem.Instance.TakeItemEvent -= Take;
	}

	protected void StartAnimationCoroutine()
	{
		StartCoroutine(AnimationCoroutine());
	}
	protected IEnumerator AnimationCoroutine()
	{
		animator.Play(ItemAnimationConstants.Disappear);
		yield return null;
	}

	protected void Destroy()
	{
		Destroy(gameObject);
	}
}

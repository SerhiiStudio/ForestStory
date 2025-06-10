using System.Collections;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
	[Header("\n\n-----------------------------------\n" +
		"Must be identical to text/trigger id")]
	[SerializeField] protected int id;

	[SerializeField] protected Animator animator;

	[Header("If item is supposed to be in inventory")]
	[SerializeField] protected bool collectToInventory;
	[SerializeField] protected ItemData itemData;

	public int Id => id;
	public ItemData ItemData => itemData;


	protected virtual void Take(int id)
	{
		if (id == this.id)
		{

			if (itemData.playSoundOnPickup)
				EventSystem.Instance.PlayAudio(itemData.takeItemSound);

			StartAnimationCoroutine();


			// If item is supposed to be in inventory
			if (collectToInventory)
			{
				if (itemData != null)
					TakeToInventory();
				else
					Debug.LogWarning("The item should be picked to inventory but the data is null");

				return;
			}
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

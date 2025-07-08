using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
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


	protected virtual void TryTake(int externalId)
	{
		if (CheckId(externalId))
			HandleTake();
	}

	protected virtual void HandleTake()
	{
		TryPlayAudio(itemData.PlaySoundOnPickup);
		StartAnimationCoroutine();
		if (collectToInventory)
			TakeToInventory();
	}

	protected bool CheckId(int id) =>
		id == this.id;

	protected void TryPlayAudio(bool play)
	{
		if (play)
			EventSystem.Instance.SetAndPlayAudio(itemData.TakeItemSound);
	}

	protected virtual void TakeToInventory()
	{
		if (itemData != null)
			EventSystem.Instance.TakeItemToInventory(itemData);
		else
			Debug.LogWarning("The item should be picked to inventory but the data is null");
	}

	protected void OnEnable()
	{
		EventSystem.Instance.TakeItemEvent += TryTake;
	}
	protected void OnDisable()
	{
		EventSystem.Instance.TakeItemEvent -= TryTake;
	}

	protected void StartAnimationCoroutine()
	{
		StartCoroutine(AnimationCoroutine());
	}
	protected virtual IEnumerator AnimationCoroutine()
	{
		animator.Play(ItemAnimationConstants.Disappear);
		yield return null; // Place for extencions
	}

	protected void DestroySelf()
	{
		Destroy(gameObject);
	}
}

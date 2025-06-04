using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class SpecialTrigger : MonoBehaviour//, IEnviromentEvent
{
	[Header("Methods to activate on trigger")]
	[SerializeField] private UnityEvent uEvent;

	[Header("Audio clip")]
	[SerializeField] private AudioClipAsset clip;
	[SerializeField] private float clipDelay;

	[Header("Animator")]
	[SerializeField] private Animator animator;
	[SerializeField] private float animatorDelay;
	[SerializeField] private float turnAnimatorOff;

	[Header("Disable or enable player movement")]
	[SerializeField] private float disablePlayerAfter;
	[SerializeField] private float enablePlayerAfter;

	private Coroutine audioCoroutine;
	private Coroutine animatorCoroutine;
	private Coroutine disablingPlayerCoroutine;

	private List<Coroutine> coroutines = new List<Coroutine>();


	private void Start()
	{
		AddCoroutines();
	}

	private void AddCoroutines()
	{
		coroutines.Add(audioCoroutine);
		coroutines.Add(animatorCoroutine);
		coroutines.Add(disablingPlayerCoroutine);
	}

	private void TryDestroyTrigger()
	{
		foreach (var coroutine in coroutines)
		{
			if (coroutine != null)
				return;
		}

		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Activate();
	}
	private void Activate()
	{
		uEvent?.Invoke();
	}


	public void PlayMusic()
	{
		if (audioCoroutine == null)
			audioCoroutine = StartCoroutine(MusicCoroutine());
	}
	private IEnumerator MusicCoroutine()
	{
		WaitForSeconds wait = new WaitForSeconds(clipDelay);
		yield return wait;
		EventSystem.Instance.PlayAudio(clip);

		audioCoroutine = null; // When coroutine ended our system to know if all coroutines are null

		TryDestroyTrigger(); // If all coroutines have been ended
	}

	public void PlayAnimator()
	{
		if (animatorCoroutine == null)
		animatorCoroutine = StartCoroutine(AnimatorCoroutine());
	}
	private IEnumerator AnimatorCoroutine()
	{
		WaitForSeconds wait = new WaitForSeconds(animatorDelay);
		yield return wait;

		animator.enabled = true;

		if (turnAnimatorOff > 0.1f)
		{
			yield return new WaitForSeconds(turnAnimatorOff);
			animator.enabled = false;
		}

		audioCoroutine = null;

		TryDestroyTrigger();
	}

	public void DisableEnablePlayerMovement()
	{
		if (disablingPlayerCoroutine == null)
			disablingPlayerCoroutine = StartCoroutine(DisablePlayerCoroutine());
	}
	private IEnumerator DisablePlayerCoroutine()
	{
		WaitForSeconds waitDisable = new WaitForSeconds(disablePlayerAfter);
		yield return waitDisable;
		EventSystem.Instance.EnableOrDisablePlayerMovenemt(false);

		if (enablePlayerAfter > 0.1f)
		{
			WaitForSeconds waitEnable = new WaitForSeconds(enablePlayerAfter);
			yield return waitEnable;
			EventSystem.Instance.EnableOrDisablePlayerMovenemt(true);
		}

		disablingPlayerCoroutine = null;

		TryDestroyTrigger();
	}
}

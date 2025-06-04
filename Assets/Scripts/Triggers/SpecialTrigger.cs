using System.Collections;
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

	


	private void TryDestroyTrigger()
	{
		if (audioCoroutine == null && animatorCoroutine == null && disablingPlayerCoroutine == null)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		uEvent?.Invoke(); // Activate the delegate
		Debug.Log("something happened");
	}


	public void PlayMusic()
	{
		if (audioCoroutine != null)
			return;

		if (clip == null)
		{
			Debug.LogWarning("The PlayMusic method was chosen but the audio clip wasn't assigned or null");
			return;
		}

		audioCoroutine = StartCoroutine(MusicCoroutine());

	}
	private IEnumerator MusicCoroutine()
	{
		WaitForSeconds clipWait = new WaitForSeconds(clipDelay);
		yield return clipWait;

		EventSystem.Instance.PlayAudio(clip);

		audioCoroutine = null; // When coroutine ended our system to know if all coroutines are null

		TryDestroyTrigger(); // If all coroutines have been ended
	}

	public void PlayAnimator()
	{
		if (animatorCoroutine != null) return;
		if (animator == null)
		{
			Debug.LogWarning("The PlayAnimator method was chosen but the animator wasn't assigned or null");
			return;
		}
		animatorCoroutine = StartCoroutine(AnimatorCoroutine());
				

	}
	private IEnumerator AnimatorCoroutine()
	{
		WaitForSeconds animatorWait = new WaitForSeconds(animatorDelay);
		yield return animatorWait;

		animator.enabled = true;

		if (turnAnimatorOff > 0.1f)
		{
			yield return new WaitForSeconds(turnAnimatorOff);
			animator.enabled = false;
		}

		animatorCoroutine = null;

		TryDestroyTrigger();
	}

	public void DisableEnablePlayerMovement()
	{
		if (disablingPlayerCoroutine == null)
			disablingPlayerCoroutine = StartCoroutine(DisablePlayerCoroutine());
	}
	private IEnumerator DisablePlayerCoroutine()
	{
		WaitForSeconds disableWait = new WaitForSeconds(disablePlayerAfter);
		yield return disableWait;
		EventSystem.Instance.EnableOrDisablePlayerMovement(false);

		if (enablePlayerAfter > 0.1f)
		{
			WaitForSeconds enableWait = new WaitForSeconds(enablePlayerAfter);
			yield return enableWait;

			EventSystem.Instance.EnableOrDisablePlayerMovement(true);
		}

		disablingPlayerCoroutine = null;

		TryDestroyTrigger();
	}
}

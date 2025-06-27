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

	[Header("Start day transition")]
	[SerializeField] private Locations location;
	[SerializeField] private float startLocationTransitionAfter;
	[SerializeField] private bool disablePlayerMovenent;

	[Header("Activate GameObjects")]
	[SerializeField] private GameObject[] gameObjectsToActivate;
	[SerializeField] private float timeToActivateGameObjects;

	[Header("Deactivate GameObjects")]
	[SerializeField] private GameObject[] gameObjectsToDeactivate;
	[SerializeField] private float timeToDeactivateGameObjects;

	private Coroutine audioCoroutine;
	private Coroutine animatorCoroutine;
	private Coroutine disablingPlayerCoroutine;
	private Coroutine dayTransitionCoroutine;
	private Coroutine activateGameObjectsCoroutine;
	private Coroutine deactivateGameObjectsCoroutine;




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

		EventSystem.Instance.SetAndPlayAudio(clip);

		audioCoroutine = null;
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
	}

	public void TransiteDay()
	{
		dayTransitionCoroutine = StartCoroutine(LocationTransitionCoroutine());
	}

	private IEnumerator LocationTransitionCoroutine()
	{
		WaitForSeconds locationTransitionWait = new WaitForSeconds(startLocationTransitionAfter);
		yield return locationTransitionWait;

		EventSystem.Instance.StartLocationTransition(location);

		if (disablePlayerMovenent)
			EventSystem.Instance.EnableOrDisablePlayerMovement(false);

		dayTransitionCoroutine = null;
	}

	public void ActivateGameObject()
	{
		if (activateGameObjectsCoroutine == null)
			activateGameObjectsCoroutine = StartCoroutine(ActivateGOsCoroutine());
	}
	private IEnumerator ActivateGOsCoroutine()
	{
		if (timeToActivateGameObjects > 0.01f)
		{
			WaitForSeconds waitToActivateGOs = new WaitForSeconds(timeToActivateGameObjects);
			yield return waitToActivateGOs;
		}

		foreach (GameObject go in gameObjectsToActivate)
		{
			go.SetActive(true);
		}

		activateGameObjectsCoroutine = null;
	}

	public void DeactivateGameObjects()
	{
		if (deactivateGameObjectsCoroutine == null)
			deactivateGameObjectsCoroutine = StartCoroutine(DeactivateGOsCoroutine());
	}

	private IEnumerator DeactivateGOsCoroutine()
	{
		if (timeToDeactivateGameObjects > 0.01f)
		{
			WaitForSeconds waitToDeactivateGOs = new WaitForSeconds(timeToDeactivateGameObjects);
			yield return waitToDeactivateGOs;
		}

		foreach (GameObject go in gameObjectsToDeactivate)
		{
			go.SetActive(false);
		}

		deactivateGameObjectsCoroutine = null;
	}
}

using System.Collections;
using UnityEngine;

public class DayOpening : MonoBehaviour
{
	[SerializeField] private Transform lookAt;
	[SerializeField] private Transform displacePlayerAt;
	private Coroutine coroutine;
	[SerializeField] private float timeVIdeoIsGoing = 2f; // while testing (change for some video player or animation)


	private void OnEnable()
	{
		EventSystem.Instance.DayTransitionStarted += StartOpening;
	}

	private void OnDisable()
	{
		EventSystem.Instance.DayTransitionStarted -= StartOpening;
	}

	private void StartOpening(Days day)
	{
		if (coroutine == null)
			coroutine = StartCoroutine(OpeningVid());
	}

	private IEnumerator OpeningVid()
	{
		Debug.Log("SOmething");
		WaitForSeconds wait = new WaitForSeconds(timeVIdeoIsGoing);

		yield return wait;

		EventSystem.Instance.TurnCamera(lookAt);
		EventSystem.Instance.DisplacePlayer(displacePlayerAt);

		coroutine = null;

	}
}

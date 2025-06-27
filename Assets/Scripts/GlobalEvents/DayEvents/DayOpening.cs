using System.Collections;
using UnityEngine;

public class DayOpening : MonoBehaviour
{
	[Header("Day")]
	[SerializeField] private Days day;
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
		if (coroutine == null && day == this.day)
			coroutine = StartCoroutine(OpeningVid());
	}

	private IEnumerator OpeningVid()
	{
		WaitForSeconds wait = new WaitForSeconds(timeVIdeoIsGoing);

		yield return wait;

		if(lookAt != null)
			EventSystem.Instance.TurnCamera(lookAt);

		if (displacePlayerAt != null)
			EventSystem.Instance.DisplacePlayer(displacePlayerAt);

		coroutine = null;

	}
}

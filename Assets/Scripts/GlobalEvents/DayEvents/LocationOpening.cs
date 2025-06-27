using System.Collections;
using UnityEngine;

public class LocationOpening : MonoBehaviour
{
	[Header("location")]
	[SerializeField] private Locations location;
	[SerializeField] private Transform lookAt;
	[SerializeField] private Transform displacePlayerAt;
	private Coroutine coroutine;
	[SerializeField] private float timeVIdeoIsGoing = 2f; // while testing (change for some video player or animation)


	private void OnEnable()
	{
		EventSystem.Instance.LocationTransitionStarted += StartOpening;
	}

	private void OnDisable()
	{
		EventSystem.Instance.LocationTransitionStarted -= StartOpening;
	}
	private void StartOpening(Locations location)
	{
		if (coroutine == null && location == this.location)
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

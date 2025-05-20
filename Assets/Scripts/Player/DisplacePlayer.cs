using UnityEngine;

public class DisplacePlayer : MonoBehaviour
{
	[SerializeField] private Transform player;
	[SerializeField] private Transform displaceTo;

	private void OnEnable()
	{
		EventSystem.Instance.DayTransitionStarted += Displace;
	}
	private void OnDisable()
	{
		EventSystem.Instance.DayTransitionStarted -= Displace;
	}

	private void Displace(Days day)
	{
		player.transform.position = displaceTo.position;
	}
}

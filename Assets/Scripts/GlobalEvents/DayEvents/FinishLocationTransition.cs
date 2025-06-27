using UnityEngine;

public class FinishlocationTransition : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private Locations location;

	[SerializeField] private int clickCount;
	private int clicks;

	private void OnEnable()
	{
		EventSystem.Instance.Buttons += ClickHandler;
	}
	private void OnDisable()
	{
		EventSystem.Instance.Buttons -= ClickHandler;
	}

	private void ClickHandler(int id)
	{
		if (id == this.id)
		{
			clicks++;
			if (clickCount == clicks)

				EventSystem.Instance.NotifyLocationTransitionEnded(location);
		}
	}
}
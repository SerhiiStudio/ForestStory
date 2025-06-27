using UnityEngine;

public class FinishlocationTransition : MonoBehaviour
{
	[SerializeField] private int id;
<<<<<<< HEAD:Assets/Scripts/GlobalEvents/DayEvents/FinishLocationTransition.cs
	[SerializeField] private Locations location;
=======
	[SerializeField] private Locations day;
>>>>>>> origin/master:Assets/Scripts/GlobalEvents/DayEvents/FinishDayTransition.cs
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
<<<<<<< HEAD:Assets/Scripts/GlobalEvents/DayEvents/FinishLocationTransition.cs
				EventSystem.Instance.NotifyLocationTransitionEnded(location);
=======
				EventSystem.Instance.NotifyLocationTransitionEnded(day);
>>>>>>> origin/master:Assets/Scripts/GlobalEvents/DayEvents/FinishDayTransition.cs
		}
	}
}
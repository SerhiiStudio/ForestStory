using UnityEngine;

public class StartLocationTransition : MonoBehaviour
{
	[SerializeField] private int id;
<<<<<<< HEAD:Assets/Scripts/GlobalEvents/DayEvents/StartLocationTransition.cs
	[SerializeField] private Locations location;
=======
	[SerializeField] private Locations day;
>>>>>>> origin/master:Assets/Scripts/GlobalEvents/DayEvents/StartDayTransition.cs
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
<<<<<<< HEAD:Assets/Scripts/GlobalEvents/DayEvents/StartLocationTransition.cs
			EventSystem.Instance.StartLocationTransition(location);
=======
			EventSystem.Instance.StartLocationTransition(day);
>>>>>>> origin/master:Assets/Scripts/GlobalEvents/DayEvents/StartDayTransition.cs
		}
	}
}

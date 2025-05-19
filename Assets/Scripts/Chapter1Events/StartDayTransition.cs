using UnityEngine;

public class StartDayTransition : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private Days day;
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
			EventSystem.Instance.StartDayTransition(day);
		}
	}
}

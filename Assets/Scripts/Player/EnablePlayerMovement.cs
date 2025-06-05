using UnityEngine;

public class EnablePlayerMovement : MonoBehaviour
{
	[SerializeField] private int id;
	[SerializeField] private int clickCount;
	[SerializeField] private bool enable;
	private int clicks;


	private void OnEnable()
	{
		EventSystem.Instance.Buttons += Clicked;
	}
	private void OnDisable()
	{
		EventSystem.Instance.Buttons -= Clicked;
	}

	private void Clicked(int id) 
	{
		if (id == this.id) 
		{
			clicks++;
			if (clicks == clickCount)
				EventSystem.Instance.EnableOrDisablePlayerMovement(enable);
		}
	}

	//  We don't need this method so far
	private void EnableOnDayTransition(Days day) // Choose the way to use enabling frequently
	{
	}
}

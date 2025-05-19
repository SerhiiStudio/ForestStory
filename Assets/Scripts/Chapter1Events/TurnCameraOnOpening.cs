using System.Collections.Generic;
using UnityEngine;

public class TurnCameraOnOpening : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private List<Transform> days;
	private const float CAMERA_OFF_SET = -10f;

	private void OnEnable()
	{
		EventSystem.Instance.DayTransitionStarted += TurnCamera;
	}
	private void OnDisable()
	{
		EventSystem.Instance.DayTransitionStarted -= TurnCamera;
	}
	private void TurnCamera(Days day)
	{
		int dayId = (int)day;
		var currentDayOpening = days[dayId];
		Vector3 position = new Vector3(currentDayOpening.position.x, currentDayOpening.position.y, CAMERA_OFF_SET);
		_camera.transform.position = position;
	}
}

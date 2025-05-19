using System.Collections.Generic;
using UnityEngine;

public class TurnCamera : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private List<Transform> daysOpening;
	[SerializeField] private List<Transform> daysActing;
	private const float CAMERA_OFF_SET = -10f;

	public TurnCamera Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	private void OnEnable()
	{
		EventSystem.Instance.DayTransitionStarted += TurnCamera_;
		EventSystem.Instance.TurnCameraEvent += TurnCamera_;
	}
	private void OnDisable()
	{
		EventSystem.Instance.DayTransitionStarted -= TurnCamera_;
		EventSystem.Instance.TurnCameraEvent -= TurnCamera_;
	}
	private void TurnCamera_(Days day)
	{
		int dayId = (int)day;
		var currentDayOpening = daysOpening[dayId];
		Vector3 position = new Vector3(currentDayOpening.position.x, currentDayOpening.position.y, CAMERA_OFF_SET);
		_camera.transform.position = position;
	}

	public void TurnCamera_ (Transform transform_)
	{
		Debug.Log("SOmething in turn camera");
		Vector3 position = new Vector3(transform_.position.x, transform_.position.y, CAMERA_OFF_SET);
		_camera.transform.position = position;
	}
}

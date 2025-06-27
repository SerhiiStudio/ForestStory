using System.Collections.Generic;
using UnityEngine;

public class TurnCamera : MonoBehaviour
{
	[SerializeField] private Camera _camera;
	[SerializeField] private List<Transform> locationsOpening;
	[SerializeField] private List<Transform> locationsActing;
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
		EventSystem.Instance.LocationTransitionStarted += TurnCamera_;
		EventSystem.Instance.TurnCameraEvent += TurnCamera_;
	}
	private void OnDisable()
	{
		EventSystem.Instance.LocationTransitionStarted -= TurnCamera_;
		EventSystem.Instance.TurnCameraEvent -= TurnCamera_;
	}
	private void TurnCamera_(Locations location)
	{
		int locationId = (int)location;
		var currentlocationOpening = locationsOpening[locationId];
		Vector3 position = new Vector3(currentlocationOpening.position.x, currentlocationOpening.position.y, CAMERA_OFF_SET);
		_camera.transform.position = position;
	}

	public void TurnCamera_ (Transform transform_)
	{
		Vector3 position = new Vector3(transform_.position.x, transform_.position.y, CAMERA_OFF_SET);
		_camera.transform.position = position;
	}
}

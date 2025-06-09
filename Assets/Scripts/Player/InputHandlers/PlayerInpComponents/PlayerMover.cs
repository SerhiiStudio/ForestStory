using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	public bool IsWalking { get; private set; }
	private PlayerInput playerInput;

	private const float walkTreshold = 0.1f;

	private void Awake() => playerInput = InputSistema.Instance.Input;

	private void Update()
	{
		if (PlayerMain.Instance.CanMove)
		{

			float walkInput = playerInput.Movement.Walk.ReadValue<float>();

			IsWalking = Mathf.Abs(walkInput) >= walkTreshold;

			if (IsWalking)
			{
				Vector3 direction = new Vector3(walkInput, 0, 0) * Time.deltaTime;
				transform.Translate(direction * PlayerMain.Instance.Speed);
			}
		}
	}
}

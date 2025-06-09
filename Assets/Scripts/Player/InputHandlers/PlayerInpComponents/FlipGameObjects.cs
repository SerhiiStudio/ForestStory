using UnityEngine;
using UnityEngine.InputSystem;

public class FlipPlayerGameObjects : MonoBehaviour
{
	[SerializeField] private Transform[] gameObjects;

	private const int flipMultiplier = -1;

	private bool isFlipped;

	private void OnEnable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed += FlipObjects;
	}
	private void OnDisable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed -= FlipObjects;
	}

	public void FlipObjects(InputAction.CallbackContext context)
	{
		float movementForce = context.ReadValue<float>();

		bool flipLeft = movementForce < 0 && !isFlipped;
		bool flipRight = movementForce > 0 && isFlipped;

		
		if (flipLeft || flipRight)
		{
			foreach (Transform sh in gameObjects)
			{
				sh.localScale = new Vector3(sh.localScale.x * flipMultiplier, sh.localScale.y);
			}
			isFlipped = !isFlipped;
		}
	}
}

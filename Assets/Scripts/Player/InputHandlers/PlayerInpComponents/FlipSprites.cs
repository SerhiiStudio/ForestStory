using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpriteFlipper : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;

	private void OnEnable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed += FlipSprites;
	}
	private void OnDisable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed -= FlipSprites;
	}

	private void FlipSprites(InputAction.CallbackContext context)
	{
		spriteRenderer.flipX = context.ReadValue<float>() < 0 ? true : false;
	}
}

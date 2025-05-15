using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputClick : MonoBehaviour
{
	private int triggerZoneId = -1;

	private PlayerInput input;


	private void Awake()
	{
		input = InputSistema.instance.input;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<CameOnTrigger>(out CameOnTrigger cot))
		{
			triggerZoneId = cot.GetId();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		triggerZoneId = -1;
	}

	private void OnEnable()
	{
		input.Clicks.Up.performed += ClickUp;
	}

	private void ClickUp(InputAction.CallbackContext context)
	{
		EventSystem.Instance.ClickedButton(triggerZoneId);
	}
}

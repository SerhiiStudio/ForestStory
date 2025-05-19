using UnityEngine;

public class InputSistema : MonoBehaviour
{
	public static InputSistema instance;
	public PlayerInput input;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(instance.gameObject);
		input = new PlayerInput();
	}

	private void OnEnable()
	{
		input.Enable();
	}
	private void OnDisable()
	{
		input.Disable();
	}
}

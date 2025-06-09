using UnityEngine;

public class InputSistema : MonoBehaviour
{
	public static InputSistema Instance { get; private set; }
	public PlayerInput Input => input;


	private PlayerInput input;

	

	private void Awake()
	{
		if (Instance != null && Instance != this) 
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
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

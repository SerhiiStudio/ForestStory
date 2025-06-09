using UnityEngine;

public class PlayerMain : MonoBehaviour // In progress to refactor
{

	public static PlayerMain Instance { get; private set; }

	private PlayerInput playerInput;


	
	[SerializeField] private Animator animator;
	[SerializeField] private float speed = 1;


	// If we need to stop transform movement to use rigidbody
	private bool isMovementStopped = false;
	private bool isWalking = false;
	private bool isCloserToLeft = false;
	private bool isGoingLeft;

	// Properties
	public float Speed => speed;

	public bool IsWalking => isWalking;
	public bool CanMove => !isMovementStopped;
	public bool GoingLeft => isGoingLeft && !isMovementStopped;
	public bool TurnedLeft => isGoingLeft;

	public bool IsInBounds {  get; private set; }


	void OnValidate()
	{
		if (animator != null)
			animator.speed = speed;
	}

	private void Awake()
	{
		playerInput = InputSistema.Instance.Input;

		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		if (animator == null)
			animator = GetComponent<Animator>();
	}

	private void OnEnable()
	{
		EventSystem.Instance.EnablePlayerMovement += EnableMovement;
	}
	private void OnDisable()
	{
		EventSystem.Instance.EnablePlayerMovement -= EnableMovement;
	}

	private void EnableMovement(bool enable)
	{
		isMovementStopped = !enable;
	}

	public void SetIfRestrictedByBoundary(bool state)
	{
		IsInBounds = state;
	}
}

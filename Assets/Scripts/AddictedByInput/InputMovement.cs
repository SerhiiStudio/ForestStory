using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{

	private PlayerInput input;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private SpriteRenderer sprite;
	[SerializeField] private Animator animator;
	[SerializeField] private float speed = 1;


	// If we need to stop transform movement to use rigidbody
	private bool isStoppedActiningTransform = false;
	private bool isWalking = false;
	private bool isCloserToLeft = false;

	private void Start()
	{
		if (playerGO == null)
			playerGO = gameObject;
	}

	private void Update()
	{
		float walkInp = input.Movement.Walk.ReadValue<float>();
		float upInt = input.Movement.Up.ReadValue<float>();

		if (!isStoppedActiningTransform)
		{
			isWalking = walkInp >= 0.1f || walkInp <= -0.1f;
			Debug.Log(isWalking);
			Vector3 direction = new Vector3(walkInp, 0, 0) * Time.deltaTime;
			transform.Translate(direction * speed);
		}

		float difference1 = Mathf.Abs(transform.position.x - WorldLimits.Instance.left);
		float difference2 = Mathf.Abs(transform.position.x - WorldLimits.Instance.right);
		isCloserToLeft = difference1 < difference2;
		if (isCloserToLeft && transform.position.x < WorldLimits.Instance.left)
		{
			transform.position = new Vector3(WorldLimits.Instance.left, transform.position.y);
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
		else if (!isCloserToLeft && transform.position.x > WorldLimits.Instance.right)
		{
			transform.position = new Vector3(WorldLimits.Instance.right, transform.position.y);
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}


		


		//Debug.Log(walkInp);
		//Debug.Log(upInt);
	}

	void OnValidate()
	{
		animator.speed = speed;
	}

	private void Awake()
	{
		input = new PlayerInput();
	}

	private void OnEnable()
	{
		input.Enable();

		input.Movement.Walk.started += SpriteFlipper;
		input.Movement.Walk.started += WalkAnim;
		input.Movement.Walk.canceled += IdleAnim;
	}
	private void OnDisable()
	{
		input.Disable();
	}

	private void SpriteFlipper(InputAction.CallbackContext context)
	{
		if (!isStoppedActiningTransform)
			sprite.flipX = context.ReadValue<float>() < 0 ? true : false;
	}
	private void WalkAnim(InputAction.CallbackContext context)
	{
		if (!isStoppedActiningTransform && !isWalking)
		{
			animator.Play(PeopleAnimationConstants.WalkAnimation);
		}
	}
	private void IdleAnim(InputAction.CallbackContext context)
	{
		Debug.Log("If walking :" + isWalking);
		if (!isStoppedActiningTransform && isWalking)
		{
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
	}
}

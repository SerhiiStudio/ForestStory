using UnityEngine;
using UnityEngine.InputSystem;

public class InputMovement : MonoBehaviour
{

	public static InputMovement Instance { get; private set; }

	private PlayerInput input;
	[SerializeField] private GameObject playerGO;
	[SerializeField] private SpriteRenderer sprite;
	[SerializeField] private Transform[] shadows;
	[SerializeField] private Animator animator;
	[SerializeField] private float speed = 1;


	// If we need to stop transform movement to use rigidbody
	private bool isStoppedActiningTransform = false;
	private bool isWalking = false;
	private bool isCloserToLeft = false;
	private bool shadowsFlipped;

	private void Start()
	{
		if (playerGO == null)
			playerGO = gameObject;
	}

	private void Update()
	{
		float walkInp = input.Movement.Walk.ReadValue<float>();
		float upInt = input.Movement.Up.ReadValue<float>();

		var limit = WorldLimits.Instance.CurrentLimit;


		if (!isStoppedActiningTransform)
		{
			isWalking = walkInp >= 0.1f || walkInp <= -0.1f;
			//Debug.Log(isWalking);
			Vector3 direction = new Vector3(walkInp, 0, 0) * Time.deltaTime;
			transform.Translate(direction * speed);
		}

		float difference1 = Mathf.Abs(transform.position.x - limit.left);
		float difference2 = Mathf.Abs(transform.position.x - limit.right);
		isCloserToLeft = difference1 < difference2;
		if (isCloserToLeft && transform.position.x < limit.left)
		{
			transform.position = new Vector3(limit.left, transform.position.y);
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
		else if (!isCloserToLeft && transform.position.x > limit.right)
		{
			transform.position = new Vector3(limit.right, transform.position.y);
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
		input = InputSistema.instance.input;

		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	private void OnEnable()
	{
		input.Movement.Walk.started += SpriteFlipper;
		input.Movement.Walk.started += ShadowFlipper;
		input.Movement.Walk.started += WalkAnim;
		input.Movement.Walk.canceled += IdleAnim;

		EventSystem.Instance.EnablePlayerMovement += EnableMovement;
	}
	private void OnDisable()
	{
		input.Movement.Walk.started -= SpriteFlipper;
		input.Movement.Walk.started -= ShadowFlipper;
		input.Movement.Walk.started -= WalkAnim;
		input.Movement.Walk.canceled -= IdleAnim;

		EventSystem.Instance.EnablePlayerMovement -= EnableMovement;
	}

	private void SpriteFlipper(InputAction.CallbackContext context)
	{
		if (!isStoppedActiningTransform)
			sprite.flipX = context.ReadValue<float>() < 0 ? true : false;
	}
	private void ShadowFlipper(InputAction.CallbackContext context)
	{

		foreach (Transform sh in shadows)
		{
			if (context.ReadValue<float>() > 0 && sh.localScale.x < 0 && !shadowsFlipped)
			{
				sh.localScale = new Vector3(sh.localScale.x * -1, sh.localScale.y);
				shadowsFlipped = true;
			}
			else
			{
				sh.localScale = new Vector3(sh.localScale.x * -1, sh.localScale.y);
				shadowsFlipped = false;
			}
		}

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
		//Debug.Log("If walking :" + isWalking);
		if (!isStoppedActiningTransform && isWalking)
		{
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
	}

	private void EnableMovement(bool enable)
	{
		if (!enable)
		{
			isStoppedActiningTransform = true;
		}
		else
		{
			isStoppedActiningTransform = false;
		}
	}
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimatorController : MonoBehaviour
{
	[SerializeField] private Animator animator;

	private const float walkTreshold = 0.1f;


	private void Awake()
	{
		if (animator == null)
			animator = GetComponent<Animator>();
	}
	private void Start()
	{
		if (animator != null)
			animator.speed = PlayerMain.Instance.Speed;
	}
	private void OnEnable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed += WalkAnim;
		InputSistema.Instance.Input.Movement.Walk.canceled += IdleAnim;
	}
	private void OnDisable()
	{
		InputSistema.Instance.Input.Movement.Walk.performed -= WalkAnim;
		InputSistema.Instance.Input.Movement.Walk.canceled -= IdleAnim;
	}

	private void WalkAnim(InputAction.CallbackContext context)
	{
		if (PlayerMain.Instance.CanMove && Mathf.Abs(context.ReadValue<float>()) >= walkTreshold && !PlayerMain.Instance.IsInBounds)
		{
			animator.Play(PeopleAnimationConstants.WalkAnimation);
		}
	}
	private void IdleAnim(InputAction.CallbackContext context)
	{
		if (PlayerMain.Instance.CanMove && Mathf.Abs(context.ReadValue<float>()) <= walkTreshold || !PlayerMain.Instance.IsInBounds)
		{
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
	}

	private void Update()
	{
		AnimateIdle();
	}

	private void AnimateIdle()
	{
		if (PlayerMain.Instance.IsInBounds && PlayerMain.Instance.CanMove)
		{
			animator.Play(PeopleAnimationConstants.IdleAnimation);
		}
	}
}

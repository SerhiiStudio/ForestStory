using UnityEngine;

public class WorldBoundaryLimiter : MonoBehaviour
{
	private bool isCloserToLeft;

	private const float boundTreshold = 0.07f;


	private void Update()
	{
		DetermineClosestBoundary();
		CorrectPositionIfOutOfBounds();
	}

	private void DetermineClosestBoundary()
	{
		var limits = WorldLimits.Instance.CurrentLimit;

		float distanceToLeft = Mathf.Abs(transform.position.x - limits.left);
		float distanceToRight = Mathf.Abs(transform.position.x - limits.right);

		if ((transform.position.x - limits.left) < boundTreshold && (InputSistema.Instance.Input.Movement.Walk.ReadValue<float>() < 0) || (transform.position.x - limits.right) > -boundTreshold && (InputSistema.Instance.Input.Movement.Walk.ReadValue<float>() > 0))
		
			PlayerMain.Instance.SetIfRestrictedByBoundary(true);
		else 
			PlayerMain.Instance.SetIfRestrictedByBoundary(false);
		
		isCloserToLeft = distanceToLeft < distanceToRight;
	}

	private void CorrectPositionIfOutOfBounds()
	{
		var limits = WorldLimits.Instance.CurrentLimit;

		if (isCloserToLeft && transform.position.x < limits.left)
		{
			transform.position = new Vector3(limits.left, transform.position.y);
		}
		else if (!isCloserToLeft && transform.position.x > limits.right)
		{
			transform.position = new Vector3(limits.right, transform.position.y);
		}
	}
}

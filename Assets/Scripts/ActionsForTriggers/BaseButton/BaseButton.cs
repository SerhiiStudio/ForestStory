using UnityEngine;

public class BaseButton : MonoBehaviour
{
	[SerializeField] protected int id;
	[SerializeField] protected SpriteRenderer spriteRenderer;
	[SerializeField] protected bool isActiveButton = true;

	private void Awake()
	{
		Debug.Log(EventSystem.Instance.gameObject.activeSelf);
		EventSystem.Instance.IteractionTriggers += ShowButton;
		EventSystem.Instance.LeaveIteractionTriggers += HideButton;
		EventSystem.Instance.Buttons += ActivateButton;
	}

	private void OnDisable()
	{
		EventSystem.Instance.IteractionTriggers -= ShowButton;
		EventSystem.Instance.LeaveIteractionTriggers -= HideButton;
		EventSystem.Instance.Buttons -= ActivateButton;
	}

	protected void ShowButton(int id)
	{
		if (id == this.id && isActiveButton)
		{
			spriteRenderer.enabled = true;
		}
	}
	protected void HideButton(int id)
	{
		if (id == this.id && isActiveButton)
		{
			spriteRenderer.enabled = false;
		}
	}

	protected void ActivateButton(int id)
	{
		if (id == this.id && isActiveButton)
		spriteRenderer.enabled = isActiveButton = false;
	}
}

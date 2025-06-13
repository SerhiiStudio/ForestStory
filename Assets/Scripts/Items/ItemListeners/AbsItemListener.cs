using UnityEngine;

public abstract class AbsItemListener : MonoBehaviour
{
	[SerializeField] protected int id;

	protected abstract void OnButtonClicked(int id);

	protected void OnEnable()
	{
		EventSystem.Instance.Buttons += OnButtonClicked;
	}
	protected void OnDisable()
	{
		EventSystem.Instance.Buttons -= OnButtonClicked;
	}
}

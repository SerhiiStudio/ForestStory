using UnityEngine;

public class CameOnTrigger : MonoBehaviour
{
	[SerializeField] protected int id;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		EventSystem.Instance.GetOnTrigger(id);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		EventSystem.Instance.GetOffTrigger(id);
	}
	public int GetId()
	{
		return id;
	}
}

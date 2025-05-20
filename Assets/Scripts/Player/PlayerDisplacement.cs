using UnityEngine;

public class PlayerDisplacement : MonoBehaviour
{
	private void OnEnable()
	{
		EventSystem.Instance.DisplacePlayerEvent += DisplacePlayer;
	}
	private void OnDisable()
	{
		EventSystem.Instance.DisplacePlayerEvent -= DisplacePlayer;
	}

	void DisplacePlayer(Transform pos)
	{
		transform.position = pos.position;
	}
}

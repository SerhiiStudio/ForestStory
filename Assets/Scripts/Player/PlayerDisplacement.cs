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
		if (pos.position.z != 0)
			pos.position = new Vector3(pos.position.x, pos.position.y, 0);

		transform.position = pos.position;
	}
}

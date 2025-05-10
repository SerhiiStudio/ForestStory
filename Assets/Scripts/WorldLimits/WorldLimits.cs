using UnityEngine;

public class WorldLimits : MonoBehaviour
{
	public float left;
	public float right;



	public static WorldLimits Instance;

	private void Awake()
	{
		Instance = this;
	}
}

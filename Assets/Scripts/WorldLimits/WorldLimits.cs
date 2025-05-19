using UnityEngine;

public class WorldLimits : MonoBehaviour
{ 
	[SerializeField] private ListWorldLimits listWorldLimits;
	private int currentLimitIndx;

	public static WorldLimits Instance { get; private set; }

	public WLimits CurrentLimit => listWorldLimits[currentLimitIndx];

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}


	public void ChangeLimits(Days day)
	{
		currentLimitIndx = (int)day;

		// while testing
		Debug.Log(currentLimitIndx);
		Debug.Log(listWorldLimits.Lenght);
		Debug.Log("Day changed: " + day);
		Debug.Log(listWorldLimits[currentLimitIndx].left);
		Debug.Log(listWorldLimits[currentLimitIndx].right);
	}


	private void OnEnable()
	{
		EventSystem.Instance.DayTransitionStarted += ChangeLimits;
	}

	private void OnDisable()
	{
		EventSystem.Instance.DayTransitionStarted -= ChangeLimits;
	}
}

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListWLimits", menuName = "Data/World/Limits", order = 1)]
public class ListWorldLimits : ScriptableObject
{
	[SerializeField] private List<WLimits> limitList;

	public WLimits this[int index]
	{
		get { return limitList[index]; }
	}
	public int Lenght => limitList.Count;
}

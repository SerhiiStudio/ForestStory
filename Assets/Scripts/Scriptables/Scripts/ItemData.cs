using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Data/Item", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
	public int id;
	public Sprite image;

	[Header("Audio effects")]
	public AudioClipAsset takeItemSound;
	public AudioClipAsset useItemSound;
	public AudioClipAsset removeItemSound;
}

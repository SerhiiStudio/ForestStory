using UnityEngine;


[CreateAssetMenu(menuName = "Data/Item", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
	public Sprite image;


	[Header("\nAudio effects")]
	public bool playSoundOnPickup;
	public AudioClipAsset takeItemSound;

	[Header("\n")]
	public bool playSoundOnUsing;
	public AudioClipAsset useItemSound;

	[Header("\n")]
	public bool playSoundOnRemoving;
	public AudioClipAsset removeItemSound;
}

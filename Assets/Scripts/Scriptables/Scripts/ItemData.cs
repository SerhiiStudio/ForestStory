using UnityEngine;


[CreateAssetMenu(menuName = "Data/Item", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
	[field: SerializeField] public Sprite Image { get; private set; }


	[field: SerializeField] public bool PlaySoundOnPickup { get; private set; }
	[field: SerializeField] public AudioClipAsset TakeItemSound { get; private set; }


	[field: SerializeField] public bool PlaySoundOnUsing { get; private set; }
	[field: SerializeField] public AudioClipAsset UseItemSound { get; private set; }


	[field: SerializeField] public bool PlaySoundOnRemoving { get; private set; }
	[field: SerializeField] public AudioClipAsset RemoveItemSound { get; private set; }
}

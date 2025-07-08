using UnityEngine;

[CreateAssetMenu(menuName = "Data/Audio/AudioClipAsset")]
public class AudioClipAsset : ScriptableObject
{
	[field: SerializeField] public AudioType Type { get; private set; }
	[field: SerializeField] public AudioClip Clip { get; private set; }
	public override string ToString()
	{
		return 
			$"Music activated\n" +
			$"Audio type: {Type}\n" +
			$"Clip: {Clip.name}";
	}
}

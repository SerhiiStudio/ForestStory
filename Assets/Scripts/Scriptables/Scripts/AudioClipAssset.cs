using UnityEngine;

[CreateAssetMenu(menuName = "Data/Audio/AudioClipAsset")]
public class AudioClipAsset : ScriptableObject
{
	public AudioType Type;
	public AudioClip Clip;

	public override string ToString()
	{
		return 
			$"Music activated\n" +
			$"Audio type: {Type}\n" +
			$"Clip: {Clip.name}";
	}
}

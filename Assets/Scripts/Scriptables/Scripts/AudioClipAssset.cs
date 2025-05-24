using UnityEngine;

[CreateAssetMenu(menuName = "Data/Audio/AudioClipAsset")]
public class AudioClipAsset : ScriptableObject
{
	public AudioType type;
	public AudioClip clip;

	public override string ToString()
	{
		return 
			$"Music activated\n" +
			$"Audio type: {type}\n" +
			$"Clip: {clip.name}";
	}
}

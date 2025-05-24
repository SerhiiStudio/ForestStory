using UnityEngine;

public class MusicActivatedLog : MonoBehaviour
{
	private void OnEnable()
	{
		EventSystem.Instance.PlayAudioEvent += Log;
	}
	private void OnDisable()
	{
		EventSystem.Instance.PlayAudioEvent -= Log;
	}

	private void Log(AudioClipAsset audioClip)
	{
		Debug.Log(audioClip.ToString());
	}
}

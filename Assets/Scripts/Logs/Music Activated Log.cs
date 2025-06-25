using UnityEngine;

public class MusicActivatedLog : MonoBehaviour
{
	private void OnEnable()
	{
		EventSystem.Instance.SetAndPlayAudioEvent += Log;
	}
	private void OnDisable()
	{
		EventSystem.Instance.SetAndPlayAudioEvent -= Log;
	}

	private void Log(AudioClipAsset audioClip)
	{
		Debug.Log(audioClip.ToString());
	}
}

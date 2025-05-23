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

	private void Log(AudioType type, int id)
	{
		Debug.Log(
			$"Music activated" +
			$"Audio type: {type}" +
			$"Index: {id}"
			);
	}
}

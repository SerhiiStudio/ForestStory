using System.Collections.Generic;
using UnityEngine;

public class BaseAudioSystem : MonoBehaviour
{
	[Header("Type")]
	[SerializeField] AudioType audioType;
	[Header("One source")]
	[SerializeField] protected AudioSource audioSource;



	private void OnEnable()
	{
		EventSystem.Instance.PlayAudioEvent += Activate;
	}

	private void OnDisable()
	{
		EventSystem.Instance.PlayAudioEvent -= Activate;
	}

	private void Activate(AudioClipAsset audioClip)
	{
		if (audioClip.type == this.audioType)
		{
			SetClip(audioClip.clip);
			PlayClip();
		}
	}
	private void PlayClip()
	{
		audioSource.Play();
	}
	private void SetClip(AudioClip clip)
	{
		audioSource.clip = clip;
	}
}

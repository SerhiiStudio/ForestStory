using System.Collections.Generic;
using UnityEngine;

public class BaseAudioSystem : MonoBehaviour
{
	[Header("Type")]
	[SerializeField] AudioType audioType;
	[Header("One source")]
	[SerializeField] protected AudioSource audioSource;
	[Header("Audio system clips")]
	[SerializeField] protected List<AudioClip> clips;

	private void OnEnable()
	{
		EventSystem.Instance.PlayAudioEvent += Activate;
	}

	private void OnDisable()
	{
		EventSystem.Instance.PlayAudioEvent -= Activate;
	}

	private void Activate(AudioType audioType, int id)
	{
		if (audioType == this.audioType)
		{
			SwapClip(id);
			PlayClip();
		}
	}

	private void SwapClip(int id)
	{
		audioSource.clip = clips[id];
	}
	private void PlayClip()
	{
		audioSource.Play();
	}
}

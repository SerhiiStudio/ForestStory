using System.Collections.Generic;
using UnityEngine;

public class BaseAudioSystem : MonoBehaviour
{
	[Header("One source")]
	[SerializeField] private AudioSource audioSource;
	[Header("Audio system clips")]
	[SerializeField] private List<AudioClip> clips;

	private void OnEnable()
	{
		// subscribe for play
	}

	private void OnDisable()
	{
		// unsubscribe
	}

	private void Activate(int id)
	{
		SwapClip(id);
		PlayClip();
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

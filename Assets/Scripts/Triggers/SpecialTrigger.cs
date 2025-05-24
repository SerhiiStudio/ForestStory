using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class SpecialTrigger : MonoBehaviour, IEnviromentEvent
{
	[Header("Audio clip")]
	[SerializeField] private AudioClipAsset clip;

	[Header("Methods to activate on trigger")]
	[SerializeField] private UnityEvent uEvent;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Activate();
	}
	public void Activate()
	{
		uEvent?.Invoke();
	}

	public void PlayMusic()
	{
		EventSystem.Instance.PlayAudio(clip);
	}
}

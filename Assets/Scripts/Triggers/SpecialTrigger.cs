using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpecialTrigger : MonoBehaviour, IEnviromentEvent
{

	[SerializeField] private AudioType audioType;
	[SerializeField] private int clipId;

	private void OnTriggerEnter2D(Collider2D other)
	{
		Activate();
	}
	public void Activate()
	{
		EventSystem.Instance.PlayAudio(audioType, clipId);
	}
}

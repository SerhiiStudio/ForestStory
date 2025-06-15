using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class BaseText : MonoBehaviour
{

	[SerializeField] protected GameObject trigger;
	[SerializeField] protected List<Text> text;
	[SerializeField] protected int clickCount = 2;
	[SerializeField] protected int id;


	protected Text hiddenText;

	protected int clicked;

	protected bool isHidden = false;


	protected void OnEnable()
	{
		if (text == null || text.Count == 0)
		{
			string msg = $"List of text is : {(text == null ? "null" : "empty")} \n\n Gameobject's name: {gameObject.name}";

			Debug.LogWarning(msg);
		}

		EventSystem.Instance.Buttons += Clicked;
		EventSystem.Instance.LeaveIteractionTriggers += HideText;
		EventSystem.Instance.IteractionTriggers += ShowText;
	}

	protected void OnDisable()
	{
		EventSystem.Instance.Buttons -= Clicked;
		EventSystem.Instance.LeaveIteractionTriggers -= HideText;
		EventSystem.Instance.IteractionTriggers -= ShowText;
	}

	protected abstract void Clicked(int id);


	protected void HideText(int id)
	{
		if (this.id == id && !isHidden && TextEnabled(text))
		{
			hiddenText = text.FirstOrDefault(t => t != null && t.enabled);
			if (hiddenText != null)
			{
				hiddenText.enabled = false;
				isHidden = true;
			}
		}
	}

	protected void ShowText(int id)
	{
		if (this.id == id && isHidden)
		{
			if (hiddenText != null && hiddenText.gameObject != null)
			{
				hiddenText.enabled = true;
			}
			
			isHidden = false;
			hiddenText = null;
		}
	}

	protected bool TextEnabled(IEnumerable<Text> texts) =>
		texts != null && texts.Any(t => t != null && t.enabled);
}

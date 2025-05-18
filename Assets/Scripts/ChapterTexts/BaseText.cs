using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : MonoBehaviour
{

	[SerializeField] protected GameObject trigger;
	[SerializeField] protected List<Text> text;
	[SerializeField] protected int clickCount = 2;
	[SerializeField] protected int id;
	protected int hiddenTextId;
	protected int clicked;

	protected bool isHidden = false;


	protected void OnEnable()
	{
		if (text.Count == 0 || text == null)
		{
			Debug.LogWarning(
	$"List of text is null or empty\n" +
	$"Is empty: {text.Count == 0}\n" +
	$"Is null: {text == null}\n\n" +
	$"Gameobject's name: {gameObject.name}"
);
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
			for (int i = 0; i < text.Count; i++)
			{
				var textItem = this.text[i];

				if (!textItem.enabled)
					continue;

				textItem.enabled = false;
				hiddenTextId = i;
				isHidden = true;
				break;
			}
		}
	}

	protected void ShowText(int id)
	{
		if (this.id == id && isHidden)
		{
			text[hiddenTextId].enabled = true;
			isHidden = false;
		}
	}

	protected bool TextEnabled(IEnumerable<Text> text)
	{
		bool isEnabled = false;
		foreach (var t in text)
		{
			if (t.enabled == true)
				isEnabled = true;
		}
		return isEnabled;
	}
}

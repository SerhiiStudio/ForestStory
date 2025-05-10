using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
	private bool active;

	public void ChangeLocale(int locale)
	{
		if (active)
			return;
		StartCoroutine(SetLocale(locale));
	}

	private IEnumerator SetLocale(int id)
	{
		active = true;
		yield return LocalizationSettings.InitializationOperation;
		LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[id];
		active = false;
	}
}

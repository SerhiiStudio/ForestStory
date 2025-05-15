using UnityEngine;

public class AspectRatioFix : MonoBehaviour
{
	void Start()
	{
		// Розрахунок співвідношення сторін
		float targetAspect = 16.0f / 9.0f;
		float windowAspect = (float)Screen.width / Screen.height;
		float scaleHeight = windowAspect / targetAspect;

		Camera camera = GetComponent<Camera>();

		if (scaleHeight < 1.0f)
		{
			// Додаємо чорні смуги з боків
			Rect rect = camera.rect;
			rect.width = scaleHeight;
			rect.x = (1.0f - scaleHeight) / 2.0f;
			camera.rect = rect;
		}
		else
		{
			// Додаємо чорні смуги зверху та знизу
			float scaleWidth = 1.0f / scaleHeight;
			Rect rect = camera.rect;
			rect.height = scaleWidth;
			rect.y = (1.0f - scaleWidth) / 2.0f;
			camera.rect = rect;
		}
	}
}

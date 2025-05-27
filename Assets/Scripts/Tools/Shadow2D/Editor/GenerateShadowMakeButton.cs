#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(SanctumCorp.DynamicShadowCaster2DMaker))]
public class GenerateShadowMakerButton : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if (GUILayout.Button("Generate ShadowCaster"))
		{
			var targetScript = (SanctumCorp.DynamicShadowCaster2DMaker)target;
			targetScript.GenerateShadows();
		}
	}
}
#endif

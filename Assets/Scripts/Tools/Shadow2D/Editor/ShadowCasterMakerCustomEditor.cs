#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace SanctumCorp
{
	[CustomEditor(typeof(ShadowCaster2DMaker))]
	public class GenerateShadowMakerButton : Editor
	{
		private bool showAdvanced = false;

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			base.OnInspectorGUI();

			if (GUILayout.Button("Generate ShadowCaster"))
			{
				var targetScript = (ShadowCaster2DMaker)target;
				targetScript.GenerateShadows();
			}

			Advanced();

			serializedObject.ApplyModifiedProperties();
		}

		private void Advanced()
		{
			showAdvanced = EditorGUILayout.Foldout(showAdvanced, "Advanced");

			if (showAdvanced)
			{
				EditorGUI.indentLevel++;
				EditorGUILayout.PropertyField(serializedObject.FindProperty("saveToFolder"));
				// TODO: Add other advanced options here if needed.
				EditorGUI.indentLevel--;
			}
		}
	}
}
#endif

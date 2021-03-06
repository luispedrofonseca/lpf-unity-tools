// Originally developed by Hugo Ruivo - https://twitter.com/HRuivo89

using UnityEditor;
using UnityEngine;

public class SlowmotionEditor : EditorWindow
{
	[MenuItem("Window/Slowmotion Editor")]
	private static void Init()
    {
	    var window = GetWindow<SlowmotionEditor>();
		window.Show();
		window.minSize = new Vector2 (10, 30);
    }

    private void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();

		EditorGUI.BeginChangeCheck();
		var newTimeScale = EditorGUILayout.Slider(Time.timeScale, 0, 3);
		if (EditorGUI.EndChangeCheck())
		{
			Time.timeScale = newTimeScale;
		}

		if (Time.timeScale == 0)
		{
			if (GUILayout.Button("Resume", GUILayout.Height(20), GUILayout.Width(64)))
			{
				Time.timeScale = 1.0f;
			}
		}
		else
		{
			if (GUILayout.Button("Pause", GUILayout.Height(20), GUILayout.Width(64)))
			{
				Time.timeScale = 0.0f;
			}
		}

		EditorGUILayout.EndHorizontal();
	}
}

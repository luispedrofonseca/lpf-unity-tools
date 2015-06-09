// Originally developed by Hugo Ruivo - https://twitter.com/HRuivo89

using UnityEditor;
using UnityEngine;

public class SlowmotionEditor : EditorWindow
{
	[MenuItem("Window/Slowmotion Editor")]
    static void Init()
    {
        SlowmotionEditor window = (SlowmotionEditor)EditorWindow.GetWindow(typeof(SlowmotionEditor));
        window.titleContent = new GUIContent("Slowmotion");
		window.Show();
		window.minSize = new Vector2 (10, 30);
    }
	
	void OnGUI()
	{
		EditorGUILayout.BeginHorizontal();

		Time.timeScale = EditorGUILayout.Slider(Time.timeScale, 0, 3);

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

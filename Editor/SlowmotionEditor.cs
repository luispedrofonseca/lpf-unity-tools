// Originally developed by Hugo Ruivo - https://twitter.com/HRuivo89

using UnityEditor;
using UnityEngine;

public class SlowmotionEditor : EditorWindow
{
	private float _previousTimeScale = 1;
	
	[MenuItem("Window/Slowmotion Editor")]
	private static void Init()
    {
	    var window = GetWindow<SlowmotionEditor>();
		window.Show();
		window.minSize = new Vector2 (10, 50);
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
				Time.timeScale = _previousTimeScale;
			}
		}
		else
		{
			if (GUILayout.Button("Pause", GUILayout.Height(20), GUILayout.Width(64)))
			{
				_previousTimeScale = Time.timeScale;
				Time.timeScale = 0.0f;
			}
		}

		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();

		EditorGUI.BeginChangeCheck();
		if (GUILayout.Button("0.001f", GUILayout.Height(20)))
		{
			Time.timeScale = 0.001f;
		}
		if (GUILayout.Button("0.01f", GUILayout.Height(20)))
		{
			Time.timeScale = 0.01f;
		}
		if (GUILayout.Button("0.03f", GUILayout.Height(20)))
		{
			Time.timeScale = 0.03f;
		}
		if (GUILayout.Button("0.1f", GUILayout.Height(20)))
		{
			Time.timeScale = 0.1f;
		}
		if (GUILayout.Button("0.5f", GUILayout.Height(20)))
		{
			Time.timeScale = 0.5f;
		}
		if (GUILayout.Button("1f", GUILayout.Height(20)))
		{
			Time.timeScale = 1f;
		}
		if (GUILayout.Button("2f", GUILayout.Height(20)))
		{
			Time.timeScale = 2f;
		}
		EditorGUILayout.EndHorizontal();
	}
}

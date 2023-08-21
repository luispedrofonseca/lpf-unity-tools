#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Reflection;

// Slightly modified version of the script by:
// Peter Schraut - http://www.console-dev.de

[CanEditMultipleObjects]
[CustomEditor(typeof(Transform))]
class TransformEditor : Editor
{
    SerializedProperty m_LocalPosition;
    SerializedProperty m_LocalRotation;
    SerializedProperty m_LocalScale;
    object m_TransformRotationGUI;

    void OnEnable()
    {
        m_LocalPosition = serializedObject.FindProperty("m_LocalPosition");
        m_LocalRotation = serializedObject.FindProperty("m_LocalRotation");
        m_LocalScale = serializedObject.FindProperty("m_LocalScale");

        if (m_TransformRotationGUI == null)
            m_TransformRotationGUI = System.Activator.CreateInstance(typeof(SerializedProperty).Assembly.GetType("UnityEditor.TransformRotationGUI", false, false));
        m_TransformRotationGUI.GetType().GetMethod("OnEnable").Invoke(m_TransformRotationGUI, new object[] { m_LocalRotation, GUIContent.none });
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawLocalPosition();
        DrawLocalRotation();
        DrawLocalScale();

        DrawPropertiesExcluding(serializedObject, new string[] { "m_LocalPosition", "m_LocalRotation", "m_LocalScale" });

        Verify();

        serializedObject.ApplyModifiedProperties();
    }

    void DrawLocalPosition()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button(new GUIContent("P", "Reset Position"), GUILayout.Width(20)))
                m_LocalPosition.vector3Value = Vector3.zero;

            EditorGUILayout.PropertyField(m_LocalPosition, GUIContent.none);
        }
    }

    void DrawLocalRotation()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button(new GUIContent("R", "Reset Rotation"), GUILayout.Width(20)))
                m_LocalRotation.quaternionValue = Quaternion.identity;

            m_TransformRotationGUI.GetType().GetMethod("RotationField", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(bool) }, null).Invoke(m_TransformRotationGUI, new object[] { false });
        }
    }

    void DrawLocalScale()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            if (GUILayout.Button(new GUIContent("S", "Reset Scale"), GUILayout.Width(20)))
                m_LocalScale.vector3Value = Vector3.one;

            EditorGUILayout.PropertyField(m_LocalScale, GUIContent.none);
        }
    }

    void Verify()
    {
        var transform = target as Transform;
        var position = transform.position;
        if (Mathf.Abs(position.x) > 100000f || Mathf.Abs(position.y) > 100000f || Mathf.Abs(position.z) > 100000f)
            EditorGUILayout.HelpBox("Due to floating-point precision limitations, it is recommended to bring the world coordinates of the GameObject within a smaller range.", MessageType.Warning);
    }
}
#endif
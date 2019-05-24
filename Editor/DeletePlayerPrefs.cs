using UnityEngine;
using UnityEditor;

public class DeletePlayerPrefs : Editor
{
    [MenuItem("Edit/Delete PlayerPrefs")]
    static void DeletePrefs()
    {
        if (EditorUtility.DisplayDialog("Delete all PlayerPrefs?", "Are you sure you want to delete all PlayerPrefs?", "Yes", "No"))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
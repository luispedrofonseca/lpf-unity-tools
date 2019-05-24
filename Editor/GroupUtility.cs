using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

///
/// Simple Group Utility for Unity3D - made by Ryan Miller ryan@reptoidgames.com
///
[ExecuteInEditMode]
public class GroupUtility : Editor
{
	[MenuItem("Edit/Group %g", false)]
	public static void Group()
	{
		if (Selection.transforms.Length > 0)
		{
			GameObject group = new GameObject("Group");
			group.transform.SetParent(Selection.gameObjects[0].transform.parent);

			// register undo as we parent objects into the group
			Undo.RegisterCreatedObjectUndo(group, "Group");
			foreach (GameObject s in Selection.gameObjects)
			{
				Undo.SetTransformParent(s.transform, group.transform, "Group");
			}

			Selection.activeGameObject = group;
		}
		else
		{
			Debug.LogWarning("You must select one or more objects.");
		}
	}
}
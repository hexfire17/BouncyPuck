using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(LevelGenerator))]
public class LevelEditor : Editor
{
	public override void OnInspectorGUI()
	{
		if (DrawDefaultInspector () || GUILayout.Button("Generate Level"))
		{
			base.OnInspectorGUI ();
			Debug.Log("GUI inspected, regenerating level");
			LevelGenerator generator = target as LevelGenerator;
			generator.GenerateLevel ();
		}
	}
}

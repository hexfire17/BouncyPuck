using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour 
{
	public void Awake()
	{
		Debug.Log ("Level Generator Started");
	}

	public void GenerateLevel()
	{
		Debug.Log ("Generating level " + _levelIndex);
		_currentLevel = _levels [_levelIndex];
	}
		
	void OnNextLevel(int levelIndex)
	{
		_levelIndex = levelIndex;
		GenerateLevel ();
	}

	[System.Serializable]
	public class Level
	{

	}

	public Level[] _levels;
	public int _levelIndex;
	Level _currentLevel;

	public Transform _obsticlePrefab;
}

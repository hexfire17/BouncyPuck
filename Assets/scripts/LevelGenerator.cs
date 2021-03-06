﻿using UnityEngine;
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

		if (transform.FindChild (_holderName))
		{
			DestroyImmediate(transform.FindChild(_holderName).gameObject);
		}

		_currentLevel = _levels [_levelIndex];
		foreach (LevelObject o in _currentLevel._levelObjects)
		{
			
			Transform target = Object.Instantiate (_softTargetPrefab, o._position, o._rotation) as Transform;
			target.transform.localScale = o._scale;
			target.parent = GetLevelHolder ();
		}
	}

	public void NewSoftObject ()
	{
		Debug.Log ("New Soft Object");
		_currentLevel = _levels [_levelIndex];
		Transform softTarget = Instantiate (_softTargetPrefab, Vector3.zero, _softTargetPrefab.transform.rotation) as Transform;
		softTarget.transform.parent = GetLevelHolder ();
	}

	public void SaveLevel ()
	{
		Debug.Log ("Saving level " + _levelIndex);
		_currentLevel = _levels [_levelIndex];

		_currentLevel._levelObjects = new List<LevelObject> ();
		foreach(Transform child in GetLevelHolder ())
		{
			LevelObject levelObject = new LevelObject ();
			levelObject._position = child.position;
			levelObject._scale = child.localScale;
			levelObject._rotation = child.transform.rotation;
			levelObject._transform = _softTargetPrefab;
			Debug.Log ("Type: " + child.GetType ());
			_currentLevel._levelObjects.Add (levelObject);
		}
	}
		
	void OnNextLevel(int levelIndex)
	{
		_levelIndex = levelIndex;
		GenerateLevel ();
	}

	Transform GetLevelHolder ()
	{
		if (_levelHolder == null) 
		{
			_levelHolder = new GameObject(_holderName).transform;
			_levelHolder.parent = transform;
		}
		return _levelHolder;
	}
		
	[System.Serializable]
	public class Level
	{
		public List<LevelObject> _levelObjects;
	}

	[System.Serializable]
	public class LevelObject
	{
		public Object _transform;
		public Vector3 _position;
		public Vector3 _scale;
		public Quaternion _rotation;
	}

	public Level[] _levels;
	public int _levelIndex;
	Level _currentLevel;

	Transform _levelHolder;
	const string _holderName = "LevelHolder";

	public Transform _softTargetPrefab;
}

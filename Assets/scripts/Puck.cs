using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		transform.localScale = Vector3.one * _size;
		_isLaunched = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (_isLaunched) 
		{
			transform.Translate (Time.deltaTime * _speed * _launchDirection);
		}
	}

	public void launch (Vector2 direction)
	{
		Debug.Log ("Launching puck in direction: " + direction);
		_launchDirection = direction;
		_isLaunched = true;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Collide: " + col.contacts [0].point);
//		float angle = Vector2.Angle(_launchDirection, );
	//	Debug.Log ("Angle: " + angle);
	}

	public Transform _puckPrefab;
	public float _size;
	public float _speed;

	bool _isLaunched;
	Vector2 _launchDirection;
}

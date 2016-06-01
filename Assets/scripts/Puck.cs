using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		transform.localScale = Vector3.one * _size;
		_rigidBody = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void launch (Vector2 direction)
	{
		Debug.Log ("Launching puck in direction: " + direction);
		_launchDirection = direction;
		_rigidBody.AddForce (_launchDirection.normalized * _speed);
	}

	public Transform _puckPrefab;
	public float _size;
	public float _speed;

	Vector2 _launchDirection;
	Rigidbody2D _rigidBody;
}

using UnityEngine;
using System.Collections;

public class Puck : MonoBehaviour 
{
	void Start ()
	{
		transform.localScale = Vector3.one * _size;
		_rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void launch (Vector2 direction)
	{
		Debug.Log ("Launching puck in direction: " + direction);
		_rigidBody.AddForce (direction.normalized * _speed);
	}

	public Transform _puckPrefab;
	public float _size;
	public float _speed;

	Rigidbody2D _rigidBody;
}

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

	void OnCollisionEnter2D (Collision2D c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnPuckEnter ();
		}
	}

	void OnCollisionExit2D (Collision2D c)
	{
		IHitable hitableObject = c.gameObject.GetComponent<IHitable> ();
		if (hitableObject != null)
		{ 
			hitableObject.OnPuckExit ();
		}
	}

	public Transform _puckPrefab;
	public float _size;
	public float _speed;

	Rigidbody2D _rigidBody;
}

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		_camera = FindObjectOfType<Camera> ();
		_isAiming = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			Vector3 spawnPosition = _camera.ScreenToWorldPoint (Input.mousePosition);
			spawnPosition.z = 0;
			_puck = Instantiate (_puckPrefab, spawnPosition, _puckPrefab.transform.rotation) as Puck; 
			Debug.Log ("click");
			_isAiming = true;
		} 
		else if (Input.GetMouseButtonUp (0))
		{
			Debug.Log ("click release");
			_aimDirection = _puck.transform.position - _camera.ScreenToWorldPoint (Input.mousePosition);
			_isAiming = false;
			_puck.launch (_aimDirection);
		}
		else if (_isAiming) 
		{
			_aimDirection = _puck.transform.position - _camera.ScreenToWorldPoint (Input.mousePosition);
		}
	}

	public Puck _puckPrefab;

	Puck _puck;
	Camera _camera;

	bool _isAiming;
	Vector2 _aimDirection;
}

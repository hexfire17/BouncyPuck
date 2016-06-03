using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	void Start () 
	{
		_camera = FindObjectOfType<Camera> ();
		_isAiming = false;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if (_puck != null) { Destroy (_puck.gameObject); }

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
			Destroy (_aimParticles.gameObject);
		}
		else if (_isAiming) {
			if (_aimParticles == null) {
				_aimParticles = Instantiate (_aimParticlePrefab, _puck.transform.position, _aimParticlePrefab.transform.rotation) as ParticleSystem;
			}

			Vector3 pointerPosition = _camera.ScreenToWorldPoint (Input.mousePosition);
			_aimParticles.transform.LookAt (2 * _aimParticles.transform.position - pointerPosition);
			_aimDirection = _puck.transform.position - pointerPosition;
		}
	}

	public Puck _puckPrefab;
	public ParticleSystem _aimParticlePrefab;

	Puck _puck;
	Camera _camera;
	ParticleSystem _aimParticles;

	bool _isAiming;
	Vector2 _aimDirection;
}

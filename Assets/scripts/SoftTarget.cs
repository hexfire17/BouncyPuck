using UnityEngine;
using System.Collections;

public class SoftTarget : MonoBehaviour, IHitable
{
	public void OnPuckEnter ()
	{
		Debug.Log ("Hit soft");
	}

	public void OnPuckExit ()
	{
		Debug.Log ("Destroy soft");
		Destroy (gameObject);
		Instantiate (_deathEffect, transform.position, transform.rotation);
	}

	public ParticleSystem _deathEffect;
}

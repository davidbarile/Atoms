using UnityEngine;
using System.Collections;

public class RotateParticle : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		_particle = gameObject.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_particle.startRotation = ( transform.parent.rotation.eulerAngles.z + 90 ) * Mathf.PI / 180;
		//Debug.Log ( transform.parent.rotation.eulerAngles.ToString() );
	}
	
	private ParticleSystem _particle = null;
}

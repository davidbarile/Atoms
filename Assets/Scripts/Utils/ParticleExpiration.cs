using UnityEngine;
using System.Collections;

public class ParticleExpiration : MonoBehaviour
{
	void Start()
	{
		_ParticleSystems = gameObject.GetComponentsInChildren< ParticleSystem >();
	}
	
	void LateUpdate ()
	{
		bool isActive = false;
		foreach( ParticleSystem ps in _ParticleSystems )
		{
			if ( ps != null && ps.isPlaying /* ps.particleCount != 0 */ )
			{
				isActive = true;
			}			
		}
		
		if( !isActive )
		{
			Destroy( gameObject );
		}
	}
	
	private ParticleSystem[] _ParticleSystems;
}

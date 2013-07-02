using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour 
{
	public int Value;
	public float Radius;
	public float Mass;
	
	public void Spawn( int inValue )
	{
		Value = inValue;
		Mass = Mathf.PI * Radius * Radius * Value * 5;//tweak this if desired
	}
	
	[SerializeField]
	private GameObject _PelletPlane1 = null;
	
	[SerializeField]
	private GameObject _PelletPlane2 = null;
	
	[SerializeField]
	private GameObject _PelletPlane3 = null;
	
	[SerializeField]
	private GameObject _PelletPlane4 = null;
	
	[SerializeField]
	private GameObject _PelletPlane5 = null;
}

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
}

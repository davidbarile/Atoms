using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour //extends Atom
{
	//public var mControls : *;
	public int mScore = 0;
	
	private Shell shell1;
	private Shell shell2;
	private Shell shell3;
	private Shell shell4;
	private Shell shell5;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void init()
	{
		//mName = inName;
			
		//create atom core & shells
		//var core : Object = { value : inCoreValue, radius : 25, color : 0x220000 };
		
		//create shells
		//shell1 = { brickValue : 5, numBricks : 16, radius : 35, color : 0x440000 };
		//shell2 = { brickValue : 4, numBricks : 24, radius : 45, color : 0x660000 };
		//shell3 = { brickValue : 3, numBricks : 32, radius : 55, color : 0x880000 };
		//shell4 = { brickValue : 2, numBricks : 48, radius : 65, color : 0xAA0000 };
		//shell5 = { brickValue : 1, numBricks : 64, radius : 75, color : 0xCC0000 };
		
		/*List < Shell > shells = new List< Shell >();
		for( int i = 1; i <= inNumShells; ++i )
		{
			//Debug.Log( i + " = shell" + i + "    brickValue = " + this["shell" + i].brickValue );
			//shells.push( this[ "shell" + i ] );
		}*/
		
		//super constructor with these values
		//super( mName, core, shells );
	}
}

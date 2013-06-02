using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public string Name;
	public int Score = 0;
	
	public Atom Atom = null;
	public KeyboardInput KeyboardInput;
	
	private object[] _core = null;
	private List <object[]> _shells = new List<object[]>();
	
	//Constructor
	void Start () 
	{
		Name = "David";
		
		//create atom core data
		_core = new object[3];
		_core[0] = 100;
		_core[1] = 25;//unused
		_core[2] = Util.HexToColor( "220000" );
		
		//create shells data
		object[] shell1 = new object[4];//innermost shell
		shell1[0] = 1;//Shell Layer Num
		shell1[1] = 16;//Num Bricks
		shell1[2] = 1;//Brick Value
		shell1[3] = Util.HexToColor( "440000" );//ShellColor
		
		object[] shell2 = new object[4];
		shell2[0] = 2;
		shell2[1] = 24;
		shell2[2] = 2;
		shell2[3] = Util.HexToColor( "660000" );
		
		object[] shell3 = new object[4];
		shell3[0] = 3;
		shell3[1] = 32;
		shell3[2] = 3;
		shell3[3] = Util.HexToColor( "880000" );
		
		object[] shell4 = new object[4];
		shell4[0] = 4;
		shell4[1] = 48;
		shell4[2] = 4;
		shell4[3] = Util.HexToColor( "AA0000" );
		
		object[] shell5 = new object[4];//outermost shell
		shell5[0] = 5;
		shell5[1] = 64;
		shell5[2] = 5;
		shell5[3] = Util.HexToColor( "CC0000" );
		
		_shells.Add ( shell1 );
		_shells.Add ( shell2 );
		_shells.Add ( shell3 );
		_shells.Add ( shell4 );
		_shells.Add ( shell5 );
		
		//Debug.Log( "Start()  NEW PLAYER   Name = " + Name );
		
		//Instantiate Atom with these values
		Atom = ( GameObject.Instantiate( Resources.Load( "Atom" ) ) as GameObject ).GetComponent<Atom>();
		Atom.transform.parent = transform;
		Atom.Init( Name, "Player", _core, _shells );//pseudo constructor
		
		//if using touch, add touch component instead
		KeyboardInput = gameObject.AddComponent<KeyboardInput>() as KeyboardInput;
		
		Debug.Log ( "Create Atom = " + Atom );
	}
	
	void Update()
	{
		
	}
	
	public void CycleLeft()
	{
		Debug.Log( "CycleLeft()      this = " + this );
		Atom.CycleLeft();
	}
	
	public void CycleRight()
	{
		Debug.Log( "CycleRight()      this = " + this );
		Atom.CycleRight();
	}
	
	public void RotateLeft()
	{
		Debug.Log( "RotateLeft()      this = " + this );
		Atom.RotateLeft();
	}
	
	public void RotateRight()
	{
		Debug.Log( "RotateRight()      this = " + this );
		Atom.RotateRight();
	}
	
	public void Thrust()
	{
		Debug.Log( "Thrust()      this = " + this );
		Atom.Thrust();
	}
	
	public void StopThrust()
	{
		Debug.Log( "StopThrust()      this = " + this );
		Atom.StopThrust();
	}
	
	public void Shoot( string inDirection )
	{
		Debug.Log( "Player.Shoot( " + inDirection + " )      this = " + this );
		Atom.Shoot( inDirection );
	}
}

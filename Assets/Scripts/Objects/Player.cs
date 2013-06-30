using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
	public string Name;
	public int Score = 0;
	
	public KeyboardInput KeyboardInput;
	
	[HideInInspector]
	public Atom ActiveAtom;
	
	//Constructor
	void Start () 
	{
		var coreObj = GameObject.Instantiate( CorePrefab.gameObject ) as GameObject;
		Core core = coreObj.GetComponent< Core >();
		core.Init( 100 );
		
		//create shells data
		List< Shell > shells = new List< Shell >();
		for( int i = 0; i < 5; ++i )
		{
			var shellInstance = GameObject.Instantiate( ShellPrefab.gameObject ) as GameObject;
			shellInstance.name = "Shell" + i;
			shells.Add( shellInstance.GetComponent< Shell >() );
		}
		shells[ 0 ].Init( 16, 1, _BrickPrefabs[ 0 ] );
		shells[ 1 ].Init( 24, 2, _BrickPrefabs[ 1 ] );
		shells[ 2 ].Init( 32, 3, _BrickPrefabs[ 2 ] );
		shells[ 3 ].Init( 48, 4, _BrickPrefabs[ 3 ] );
		shells[ 4 ].Init( 64, 5, _BrickPrefabs[ 4 ] );
		
		//Instantiate Atom with these values
		var atomInstance = GameObject.Instantiate( AtomPrefab.gameObject ) as GameObject; 
		atomInstance.GetComponent< Atom >().Init( "David", Atom.Role.Player, core, shells );
		atomInstance.transform.parent = transform;
		
		//if using touch, add touch component instead
		KeyboardInput = gameObject.AddComponent<KeyboardInput>() as KeyboardInput;
	}
	
	void Update()
	{
		
	}
	
	public void CycleLeft()
	{
		Debug.Log( "CycleLeft()      this = " + this );
		ActiveAtom.CycleLeft();
	}
	
	public void CycleRight()
	{
		Debug.Log( "CycleRight()      this = " + this );
		ActiveAtom.CycleRight();
	}
	
	public void RotateLeft()
	{
		Debug.Log( "RotateLeft()      this = " + this );
		ActiveAtom.RotateLeft();
	}
	
	public void RotateRight()
	{
		Debug.Log( "RotateRight()      this = " + this );
		ActiveAtom.RotateRight();
	}
	
	public void Thrust()
	{
		Debug.Log( "Thrust()      this = " + this );
		ActiveAtom.Thrust();
	}
	
	public void StopThrust()
	{
		Debug.Log( "StopThrust()      this = " + this );
		ActiveAtom.StopThrust();
	}
	
	public void Shoot( string inDirection )
	{
		Debug.Log( "Player.Shoot( " + inDirection + " )      this = " + this );
		ActiveAtom.Shoot( inDirection );
	}
	
	[SerializeField]
	private Brick[] _BrickPrefabs = new Brick[ 5 ];
	[SerializeField]
	private Atom AtomPrefab = null;
	[SerializeField]
	private Core CorePrefab = null;
	[SerializeField]
	private Shell ShellPrefab = null;
}

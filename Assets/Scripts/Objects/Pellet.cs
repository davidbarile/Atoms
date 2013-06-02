using UnityEngine;
using System.Collections;

public class Pellet : MonoBehaviour 
{
	public int Index;
	[HideInInspector]
	public Brick Brick = null ;//brick from which this pellet was shot
	public int PelletValue;
	public float PelletAngle;
	public int ShellLayer;
	public int BrickValue;
	//public int Color;
	public float Radius;
	public float Mass;
	
	//public float Speed = 10;
	//private Vector3 SpawnPosition;
	
	//private struct StoredCollisionData;
	
	// Use this for initialization
	void Start ()
	{
		//gameObject.SetActive( true );
		//rigidbody.AddRelativeForce( Vector3.forward * 20 );//ForceMode.Acceleration
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Spawn( Brick inBrick )
	{
		//attach parent brick data to pellet
		//Brick = Brick( inBrick );
		Index = Brick.Index;
		PelletValue = Brick.BrickValue;
		ShellLayer = Brick.ShellLayerNum;
		//PelletAngle = Brick.mAtom.mThrustDirection;
		//Color = Brick.Color;
		//Radius = Mathf.Round( width / 2 );
		Mass = Mathf.PI * Radius * Radius * PelletValue * 5;//tweak this if desired
		
		//add to Projectiles movie clip
		//Projectiles.sInstance.addChild( this );
		
		//position relative to atom and brick
		positionPellet();
		
		//create vars for quick calculation
		
		//add to dictionary
		/*if( !GameCycle.MovingObjectsDict[ this ] )
		{
			GameCycle.MovingObjectsDict[ this ] = this;
		}*/
		
		//begin movement
		//move();
	}
	
	private void positionPellet()
	{			
		//Global.outputPath( Brick.mShell );//do global to local on this, then calculate brick position by angle and radius
		
		//SpawnPosition = calculateBrickPosition();
		
		/*this.x = Brick.Atom.x + SpawnPosition.x;
		this.y = Brick.Atom.y + SpawnPosition.y;*/
	}
}

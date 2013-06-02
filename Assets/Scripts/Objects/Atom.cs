using UnityEngine;
using System.Collections.Generic;

public class Atom : MonoBehaviour 
{
	//public int Index = 0;
	public string Name;
	public string Type;
	public int Health;
	public bool IsAlive = true;
	public Core Core = null;
	public int NumShells;
	public int NumShellsRemaining;
	public List< Shell > Shells = new List< Shell >();
	public int NumBricks;
	public int NumBricksRemaining;
	
	//public float mXpos;
	//public float mYpos;
	public float SelectedBrickAngle;
	//public float ThrustDirection = 0;//is not .rotation
	public bool IsThrusting = false;
	public float Speed = 200;
	public float MaxSpeed = 20;
	//public float mAccellerationRate = .5;
	//public float mFriction = .98;
	//public float mRadius;
	//public float mMass;
	//public float mElasticity = .05;
	
	[HideInInspector]
	public Shell OuterMostShell = null;
	
	[HideInInspector]
	public Shell SelectedShell = null;
	
	[HideInInspector]
	public Brick SelectedBrick = null;
		
	// Use this for initialization
	void Start () 
	{
		Debug.Log ( "ATOM.Start()   this = " + this );
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void Init( string inName, string inType, object[] inCore, List<object[]> inShells )
	{
		Debug.Log ( "ATOM.Init()" );
		Name = inName;
		Type = inType;
		
		//instantate Core dynamically
		GameObject go = GameObject.Instantiate( Resources.Load( "Core" ) ) as GameObject;
		Core Core = go.GetComponent<Core>() as Core;
		
		go.transform.parent = transform;//make Atom its parent
		Core.Health = (int) inCore[ 0 ];
		//Core.Radius = (int) inCore[ 1 ];
		Core.CoreColor = (Color) inCore[ 2 ];
		
		NumShells = inShells.Count;
		
		Shell sh;
		
		//extract data from shells objects and pass into shell prefabs
		for( int i = 0; i < NumShells; ++i )
		{
			sh = transform.Find( "Shell" + ( i + 1 ) ).gameObject.GetComponent<Shell>() as Shell;
			//sh.gameObject.SetActive( true );
			
			//object[] shellData = inShells[ i ] as Object[];//doesn't work
			sh.LayerNum = (int) inShells[ i ][ 0 ];
			sh.NumBricks = (int) inShells[ i ][ 1 ];
			sh.BrickValue = (int) inShells[ i ][ 2 ];
			sh.ShellColor = (Color) inShells[ i ][ 3 ];
			sh.Init();
			
			//Debug.Log ( "ATOM.sh = " + sh );
			Shells.Add ( sh );//add to array
		}
		
		SelectedShell = Shells[ NumShells - 1 ];
		SelectedBrick = SelectedShell.Bricks[ 0 ];
		SelectedBrick.Select();
			
		Debug.Log ( "SelectedBrick = " + SelectedBrick );
		//Debug.Log ( "ATOM.init()   NumShells = " + NumShells );
	}
	
	public void CycleLeft()
	{
		//rotation -= SelectedBrick.BrickAngle;
		transform.Rotate( 0, -1, 0, Space.Self );
		
		if( NumBricksRemaining > 0 )
		{
			SelectedBrick.Deselect();
			
			//SelectedBrick = selectNextBrick( -1 );
			
			SelectedBrick.Select();
			
			SelectedBrickAngle = SelectedBrick.BrickAngle;
			
			//trace( "ATOM.AimAngle = " + AimAngle );
			
			//trace( "ATOM.cycleLeft()    this = " + this.rotation );
			//ThrustDirection = reduceAngleValue( rotation + SelectedBrickAngle );
			//Core.mRayImage.rotation = SelectedBrickAngle;
			//Core.mPointerImage.rotation = SelectedBrickAngle;
		}
		else
		{
			//SelectedBrickAngle -= Const.NINE_RAD;
			//reduceAngleValue( SelectedBrickAngle );
			//RotateLeft();
		}
		
	}
	
	public void CycleRight()
	{
		if( NumBricksRemaining > 0 )
		{
			//rotation += SelectedBrick.BrickAngle;
			transform.Rotate( 0, 1, 0, Space.Self );
			
			SelectedBrick.Deselect();
			
			SelectedBrick = selectNextBrick( 1 );
			
			SelectedBrick.Select();
			
			SelectedBrickAngle = SelectedBrick.BrickAngle;
			
			//trace( "ATOM.AimAngle = " + AimAngle );
			
			//trace( "ATOM.cycleRight()    this = " + this.rotation );
			//ThrustDirection = reduceAngleValue( rotation + SelectedBrickAngle );
			//Core.mRayImage.rotation = SelectedBrickAngle;
			//Core.mPointerImage.rotation = SelectedBrickAngle;
		}
		else
		{
			//SelectedBrickAngle += Const.NINE_RAD;
			//reduceAngleValue( SelectedBrickAngle );
			//RotateRight();
		}
	}
	
	public void RotateLeft()
	{	
		rigidbody.AddTorque ( Vector3.up * -1f );
	}
	
	public void RotateRight()
	{	
		rigidbody.AddTorque ( Vector3.up * 1f );
	}
	
	public void Thrust()
	{
		//trace( "ATOM.Thrust()    this = " + this );
		/*
		if( IsThrusting && ExplosionParticle )
		{
			ExplosionParticle.start();
		}
		else
		{
			IsThrusting = true;
			
			if(  !GameCycle.MovingObjectsDict[ this ] ) //not yet moving
			{
				//add to moving objects dictionary
				GameCycle.MovingObjectsDict[ this ] = this;
				
				//start thrust particle animation
				
			}
		}
		*/
		//add force speed
		rigidbody.AddRelativeForce( Vector3.forward * Speed );//ForceMode.Acceleration
	}
	
	public void StopThrust()
	{
		if( IsThrusting )
		{
			IsThrusting = false;
			
			//Particles.destroyParticle( ExplosionParticle );
			//Particles.stopParticle( ExplosionParticle );
			//ExplosionParticle.stop();
		}
	}
	
	public void Shoot( string inDirection )
	{
		Debug.Log( "Atom.Shoot( " + inDirection + " )      this = " + this );
		
		if( NumBricksRemaining > 0 )
		{
			Brick oldSelectedBrick = SelectedBrick;//store in local var to remove after next brick calculated
			SelectedBrick.Shoot();
			
			//var oldAngle : Number = SelectedBrickAngle;
			
			if( inDirection == "right" )
			{
				CycleRight();
			}
			else
			{
				CycleLeft();
			}
			
			//now remove old brick
			oldSelectedBrick.RemoveBrick();
			
			//rotation += oldAngle - SelectedBrickAngle;
			//rotation = reduceAngleValue( rotation );
			//ThrustDirection = reduceAngleValue( rotation + SelectedBrickAngle );
		}
	}
	
	public void Die()
	{
		Debug.Log( "DIE " + this.Name );
		
		IsAlive = false;
		//play death animation
		
		//then
		Destroy();
	}
	
	public void Destroy()
	{
		//remove from dictionary of moving objects
		//delete GameCycle.MovingObjectsDict[ this ];
		
		//remove from dictionary of atoms on GameScreen
		//delete GameScreen.sAtoms[ this ];
		
		//parent.removeChild( this );
		//delete this;
	}
	
	private Brick selectNextBrick( int inDirection )
	{
		int nextBrickNum = SelectedBrick.Index + inDirection;
		Brick nextBrick = SelectedShell.Bricks[ nextBrickNum ];
		Debug.Log ( "selectNextBrick( direction = " + inDirection + " )    nextBrickNum = " + nextBrickNum + "   nextBrick = " + nextBrick );
		return nextBrick;
	}
}

using UnityEngine;
using System.Collections.Generic;

enum Direction
{
	Clockwise = 1,
	Counterclockwise = -1
}

public class Atom : MonoBehaviour
{
	public enum Role
	{
		Player,
		Enemy
	}
	
	public string Name;
	public Role Owner;
	public bool IsAlive = true;
	public Core Core = null;
	public List< Shell > Shells = new List< Shell >();
	
	public float SelectedBrickAngle;
	public bool IsThrusting = false;
	public float Speed = 200;
	public float MaxSpeed = 20;
	
	[HideInInspector]
	public Shell OuterMostShell = null;
	
	[HideInInspector]
	public Shell SelectedShell = null;
	
	[HideInInspector]
	public Brick SelectedBrick = null;
	
	public void Init( string inName, Role inOwner, Core inCore, List< Shell > inShells )
	{
		Debug.Log ( "ATOM.Init()" );
		Name = inName;
		Owner = inOwner;
		Shells = inShells;
		for( int i = 0; i < inShells.Count; ++i )
		{
			inShells[ i ].transform.parent = this.transform;
		}
		Core = inCore;
		inCore.transform.parent = transform;
		
		SelectedShell = Shells[ Shells.Count - 1 ];
		SelectedBrick = SelectedShell.Bricks[ 0 ];
		SelectedBrick.Select();
			
		Debug.Log ( "SelectedBrick = " + SelectedBrick );
	}
	
	public void CycleLeft()
	{
		//rotation -= SelectedBrick.BrickAngle;
		transform.Rotate( 0, -1, 0, Space.Self );
		
		//if( NumBricksRemaining > 0 )
		{
			SelectedBrick.Deselect();
			
			//SelectedBrick = selectNextBrick( -1 );
			
			SelectedBrick.Select();
			
			//SelectedBrickAngle = SelectedBrick.BrickAngle;
			
			//trace( "ATOM.AimAngle = " + AimAngle );
			
			//trace( "ATOM.cycleLeft()    this = " + this.rotation );
			//ThrustDirection = reduceAngleValue( rotation + SelectedBrickAngle );
			//Core.mRayImage.rotation = SelectedBrickAngle;
			//Core.mPointerImage.rotation = SelectedBrickAngle;
		}
		
	}
	
	public void CycleRight()
	{
		//if( NumBricksRemaining > 0 )
		{
			//rotation += SelectedBrick.BrickAngle;
			transform.Rotate( 0, 1, 0, Space.Self );
			
			SelectedBrick.Deselect();
			
			SelectedBrick = selectNextBrick( Direction.Clockwise );
			
			SelectedBrick.Select();
			
		//	SelectedBrickAngle = SelectedBrick.BrickAngle;
			
			//trace( "ATOM.AimAngle = " + AimAngle );
			
			//trace( "ATOM.cycleRight()    this = " + this.rotation );
			//ThrustDirection = reduceAngleValue( rotation + SelectedBrickAngle );
			//Core.mRayImage.rotation = SelectedBrickAngle;
			//Core.mPointerImage.rotation = SelectedBrickAngle;
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
		
		//if( NumBricksRemaining > 0 )
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
	
	private Brick selectNextBrick( Direction inDirection )
	{
		int newIndex = SelectedShell.SelectedBrickIndex + ( int ) inDirection;
		if( newIndex < 0 )
		{
			newIndex = SelectedShell.Bricks.Count - 1;
		}
		else if( newIndex > SelectedShell.Bricks.Count )
		{
			newIndex = 0;	
		}
		
		if( !SelectedShell.Bricks[ newIndex ].IsActive )
		{
			// try to go outer shell first, then inner shell
		}
		
		Debug.LogError( "Fix me" );
		return null;
	}
}

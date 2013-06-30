using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public float WedgeWidth;
	public float WedgeLeft;
	public float WedgeRight;
	public int ShellLayerNum;
	public int Value;
	public int BrickPointsRemaining;
	public Color BrickColor;
	
	public void Init( int inValue )
	{
		Value = inValue;
	}
	
	public bool IsActive
	{
		get
		{
			return _IsActive;
		}
		set
		{
			_IsActive = value;
			gameObject.SetActive( value );
		}
	}
	
	public void PositionBrick( int inIndex, int inCount )
	{
		//rotate brick prefab
		float brickAngle =  (float) inIndex / inCount * 360;
		TransformExtensionMethods.SetLocalRotationY( gameObject.transform, brickAngle );
	}
	
	public void Select()
	{
		Renderer renderer = GetComponentInChildren< Renderer >();
		BrickColor = renderer.material.color;
		renderer.material.color = Color.blue;
	}
	
	public void Deselect()
	{
		Renderer renderer = GetComponentInChildren< Renderer >();
		renderer.material.color = BrickColor;
	}
	
	public void Shoot()
	{
		Debug.Log ( "Brick.Shoot()   this = " + this );
		
		//SFX.playSound( SFX.ShotSound );
		
		//Pellet = new Pellet( this );
		/*var pool : PelletPool = Game.sInstance["PelletPool" + uint( ShellLayer + 1 ) ];
		var pellet : Pellet = pool.getPellet();
		pellet.spawn( this );*/
		
		//instantate new brick
		GameObject go = GameObject.Instantiate( Resources.Load( "Pellet" ) ) as GameObject;
		Pellet pellet = go.GetComponent<Pellet>();
		pellet.Spawn( Value );
		go.SetActive( true );
		
		//make it so pellet does not hit its own atom
		//Physics.IgnoreCollision( go.collider, Atom.Core.transform.collider );
		//do this by 
		//Physics.IgnoreLayerCollision;
		
		//add data to pellet
		
		pellet.transform.position = transform.position;
		pellet.transform.rotation = transform.rotation;
		pellet.rigidbody.AddRelativeForce( Vector3.forward * 50 );//ForceMode.Acceleration
		
		MeshRenderer loc = gameObject.GetComponent<MeshRenderer>() as MeshRenderer;
		Debug.Log ( "LOC = " + loc );//WHAT TYPE IS THIS REALLY?  HOW DO I GET ITS POSITION?
		
		//TransformExtensionMethods.SetLocalPositionX( pel.transform, loc.transform.localPosition.x );
		
		//_pellet.transform.position = loc.transform.position;
	}
	
	public void RemoveBrick()
	{
		IsActive = false;
	}
	
	public void TakeDamage( Pellet inPellet )
	{
		//optimize by just sending pelletValue instead of entire object
		int brickValue = BrickPointsRemaining;
		
		//Debug.Log( "takeDamage()  pellet = " + pelletValue + "   brick = " + brickValue );
		
		BrickPointsRemaining -= inPellet.Value;;
		inPellet.Value -= brickValue;
		
		//Debug.Log( "    HIT   pellet  = " + inPellet.PelletValue + "    brick = " + BrickValue );
		
		if( BrickPointsRemaining <= 0 )
		{
			//play sound
			//SFX.playSound( SFX.ByeewDown );
			
			//play particle anim
			RemoveBrick();
		}
		else
		{
			//SFX.playSound( SFX.Pyoo );
			
			//maybe later show this with mini level bar or something
			//alpha = BrickPointsRemaining / BrickValue;
		}
	}
	
	private bool _IsActive;
}

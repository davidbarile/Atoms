using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	[HideInInspector]
	public Atom Atom = null;
	[HideInInspector]
	public Shell Shell = null;
	public int Index;
	public float BrickAngle;
	public float WedgeWidth;
	public float WedgeLeft;
	public float WedgeRight;
	public int NumBricks;
	public int ShellLayerNum;
	public int BrickValue;
	public int BrickPointsRemaining;
	public float ShellRadius;
	public Color BrickColor;
	
	public bool IsSelected = false;
	private Pellet _pellet = null;
	
	// Use this for initialization
	void Awake () 
	{
		gameObject.SetActive( false );
		//Debug.Log ( ">>>>>>> BRICK   this = " + this );
	}
	
	void Start () 
	{
		//gameObject.SetActive( false );
		//Debug.Log ( ">>>>>>> BRICK   this = " + this );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void PositionBrick()
	{
		//rotate brick prefab
		BrickAngle =  (float) Index / (float) NumBricks * 360;
		TransformExtensionMethods.SetLocalRotationY( gameObject.transform, BrickAngle );
	}
	
	public void Select()
	{
		Debug.Log ( "Select()   Brick#" + Index );
		IsSelected = true;
		
		Renderer renderer = GetComponentInChildren< Renderer >();
		renderer.material.color = Color.blue;
	}
	
	public void Deselect()
	{
		IsSelected = false;
		
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
		_pellet = go.GetComponent<Pellet>();
		go.SetActive( true );
		
		//make it so pellet does not hit its own atom
		//Physics.IgnoreCollision( go.collider, Atom.Core.transform.collider );
		//do this by 
		//Physics.IgnoreLayerCollision;
		
		//add data to pellet
		_pellet.Index = Index;
		
		_pellet.transform.position = transform.position;
		_pellet.transform.rotation = transform.rotation;
		_pellet.rigidbody.AddRelativeForce( Vector3.forward * 50 );//ForceMode.Acceleration
		
		MeshRenderer loc = gameObject.GetComponent<MeshRenderer>() as MeshRenderer;
		Debug.Log ( "LOC = " + loc );//WHAT TYPE IS THIS REALLY?  HOW DO I GET ITS POSITION?
		
		//TransformExtensionMethods.SetLocalPositionX( pel.transform, loc.transform.localPosition.x );
		
		//_pellet.transform.position = loc.transform.position;
	}
	
	public void RemoveBrick()
	{
		//Debug.Log( "removeBrick()   remaining = " + mAtom.NumBricksRemaining );
		IsSelected = false;
		
		gameObject.SetActive( false );
		
		--Shell.NumBricksRemaining;
		--Atom.NumBricksRemaining;
		
		if( Shell.NumBricksRemaining == 0 )
		{
			Debug.Log( "--- removeShell() # " + Shell.LayerNum );
			Shell.RemoveShell();
		}
	}
	
	public void TakeDamage( Pellet inPellet )
	{
		Debug.Log( "Brick.TakeDamage()  id = " + inPellet.Brick.Index );
		//optimize by just sending pelletValue instead of entire object
		int pelletValue = inPellet.PelletValue;
		int brickValue = BrickPointsRemaining;
		
		//Debug.Log( "takeDamage()  pellet = " + pelletValue + "   brick = " + brickValue );
		
		BrickPointsRemaining -= pelletValue;
		inPellet.PelletValue -= brickValue;
		
		//Debug.Log( "    HIT   pellet  = " + inPellet.PelletValue + "    brick = " + BrickValue );
		
		if( BrickPointsRemaining <= 0 )
		{
			if( IsSelected )
			{
				//select brick to right or left
				
			}
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
}

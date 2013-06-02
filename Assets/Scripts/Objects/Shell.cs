using UnityEngine;
using System.Collections.Generic;

public class Shell : MonoBehaviour 
{
	[HideInInspector]
	public Atom Atom = null;
	
	public float BrickAngle;
	public int LayerNum;
	public int NumBricks;
	public int NumBricksRemaining;
	public int BrickValue;
	public float Radius;
	public Color ShellColor;
	public List< Brick > Bricks = new List< Brick >();
	public bool IsSelected = false;
	[HideInInspector]
	public Brick SearchBrick = null;
	
	// Use this for initialization
	void Start () 
	{
		//gameObject.SetActive( false );
		//Debug.Log ( "SHELL   this = " + this );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Init()
	{
		//Debug.Log ( "BRICK  init()    NuBricks = " + NuBricks + "   Shell# = " + LayerNum );
		
		Atom = transform.parent.GetComponent<Atom>() as Atom;
			
		Bricks = new List< Brick >();
		
		for( int i = 0; i < NumBricks; ++i )
		{
			//instantate new brick
			GameObject go = GameObject.Instantiate( Resources.Load( "Brick" + LayerNum ) ) as GameObject;
			Brick br = go.GetComponent<Brick>() as Brick;
			
			go.transform.parent = transform;//make Shell its parent
			
			//pass in relevant data
			br.Index = i;
			br.NumBricks = NumBricks;
			br.Atom = Atom;
			br.Shell = this;
			br.ShellLayerNum = LayerNum;
			br.BrickValue = 5;
			br.BrickColor = ShellColor;
			br.PositionBrick();
			
			go.SetActive( true );
			
			++Atom.NumBricksRemaining;
			
			Bricks.Add( br );
		}
		
		//BrickAngle = Bricks[ 1 ].BrickAngle;//get first bricks rotation angle
	}
	
	public void RemoveShell()
	{
		//Debug.Log( "removeShell()    LayerNum = " + LayerNum );
		
		//visible = false;//hide shell
		--Atom.NumShellsRemaining;
		
		tweenOutShell();
		
		/*
		if( Atom.NumShellsRemaining > 0 )
		{
			//decrement layer
			for( int i = Atom.NumShells - 1; i >= 0; --i )
			{
				if( Atom.Shells[ i ].NumBricksRemaining )
				{
					Atom.SelectedShell = Atom.Shells[ i ];
					Atom.OuterMostShell = Atom.SelectedShell;
					Atom.Radius = Atom.OuterMostShell.Radius;
					break;
				}
			}
			
			Atom.SearchShell = Atom.SelectedShell;
			Atom.SearchShellIndex = Atom.SearchShell.mLayer;
			
			//calculate brick index on new shell layer
			int newIndex = Atom.getBrickIndexFromAngle( Atom.SelectedBrick.BrickAngle, Atom.SearchShell );
			Atom.SearchShell.mSearchBrick = Atom.SearchShell.Bricks[ newIndex ];
			
			//use selection algorithm to find brick
			Atom.SelectedBrick = Atom.selectNextBrick( Atom.SearchDirection );
			
			Atom.SelectedBrick.Select();
			
			//Debug.Log( "done with shell remove" );
		}
		else
		{
			Atom.Radius = Atom.Core.Radius;
			
			//only core is left
			//Atom.Core.mPointerImage.visible = true;
			//TweenLite.to( Atom.Core.mPointerImage, .2, { alpha : .6, ease : Cubic.easeIn } );
		}*/
	}
	
	private void tweenOutShell()
	{
		//Debug.Log( "tweenOutShell()" );
		
		//TweenLite.to( mShellRingImage, .8, { x : -Radius * 1.5, y : -Radius * 1.5, width : Radius * 3, height : Radius * 3, alpha : 0, ease : Cubic.easeOut } );
		//hide when fade out complete
		//setTimeout( function( inTarget : Shell ) { inTarget.visible = false }, 800, this );
	}
}

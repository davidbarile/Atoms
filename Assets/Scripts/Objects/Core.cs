using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour 
{
	[HideInInspector]
	public Atom Atom = null;
	public int MaxHealth;
	public string Index = "core";
	public int Health = 0;
	//public float Radius;
	public Color CoreColor;
	
	// Use this for initialization
	void Awake () 
	{
		//gameObject.SetActive( false );
		Debug.Log ( "Core.awake()" );
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void TakeDamage( Pellet inPellet )
	{	/*
		//optimize by just sending pelletValue instead of entire object
		int pelletValue = inPellet.mPelletValue;
		int coreValue = mHealth;
		
		mHealth -= pelletValue;
		Debug.Log( "mHealth = " + mHealth );
		inPellet.mPelletValue -= coreValue;
		
		//shrink core radius
		float healthRatio = mHealth / mMaxHealth / 2 + .5;
		scaleX = healthRatio;
		scaleY = healthRatio;
		mRadius = healthRatio;
		
		//if just core, shrink total atom radius
		if( mAtom.mNumBricksRemaining == 0 )
		{
			mAtom.mRadius = healthRatio;
		}
		
		//core killed
		if( mHealth <= 0 )
		{
			if( mAtom.mIsAlive )
			{
				Debug.Log( "mAtom = " + mAtom + " die" );
				mAtom.die();
			}
		}*/
	}
}

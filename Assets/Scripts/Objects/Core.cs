using UnityEngine;
using System.Collections;

public class Core : MonoBehaviour 
{
	[HideInInspector]
	public Atom Atom = null;
	public int MaxHealth;
	public int Health = 0;
	
	public void Init( int inHealth )
	{
		MaxHealth = inHealth;
		Health = inHealth;
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

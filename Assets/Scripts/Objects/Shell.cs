using UnityEngine;
using System.Collections.Generic;

public class Shell : MonoBehaviour
{
	[HideInInspector]
	public Atom Atom = null;
	
	public int BrickCount;
	public List< Brick > Bricks = new List< Brick >();
	[HideInInspector]
	public Brick SearchBrick = null;
	public int SelectedBrickIndex;
	
	public void Init( int inBrickCount, int inBrickValue, Brick inBrickPrefab )
	{
		BrickCount = inBrickCount;
		for( int i = 0; i < BrickCount; ++i )
		{
			GameObject brickInstance = GameObject.Instantiate( inBrickPrefab.gameObject ) as GameObject;
			Brick br = brickInstance.GetComponent< Brick >();
			br.Init( inBrickValue );
			float brickAngle =  (float) i / BrickCount * 360;
			br.PositionBrick( brickAngle );
			br.transform.parent = this.transform;
			br.name = "Brick" + i;
			Bricks.Add( br );
		}	
	}
	
	public ArcLengthIndex GetNearestBrickIndex( Direction inDirection, float inAngle )
	{
		int startIndex = Mathf.RoundToInt( inAngle * BrickCount );
		if( inDirection == Direction.Clockwise )
		{
			int endIndex = startIndex - 1;
			if( endIndex < 0 )
			{
				endIndex = BrickCount - 1;
			}
			
			for( int i = startIndex; i != endIndex; ++i )
			{
				int nextIndex = i % BrickCount;
				if( Bricks[ nextIndex ].IsActive )
				{
					return new ArcLengthIndex{ angle = Mathf.Abs( nextIndex - startIndex ) / BrickCount - 1 / ( 2 * BrickCount ), index = nextIndex };
				}
			}
		}
		else
		{
			int endIndex = startIndex + 1;
			if( endIndex > BrickCount - 1 )
			{
				endIndex = 0;
			}
			
			for( int i = startIndex; i != endIndex; --i )
			{
				int nextIndex = i % BrickCount;
				if( Bricks[ nextIndex ].IsActive )
				{
					return new ArcLengthIndex{ angle = Mathf.Abs( nextIndex - startIndex ) / BrickCount + 1 / ( 2 * BrickCount ), index = nextIndex };
				}
			}	
		}
		
		return new ArcLengthIndex{ angle = -1, index = -1 };
	}
	
	public float GetSelectedAngle( Brick inSelectedBrick, Direction inFromDirection )
	{
		for( int i = 0; i < Bricks.Count; ++i )
		{
			if( inSelectedBrick == Bricks[ i ] )
			{
				if( inFromDirection == Direction.Clockwise )
				{
					return i / BrickCount - 1 / ( 2 * BrickCount );
				}
				else
				{
					return i / BrickCount + 1 / ( 2 * BrickCount );
				}
			}
		}
		
		return -1;
	}
}

public struct ArcLengthIndex
{
	public float angle;
	public int index;
}

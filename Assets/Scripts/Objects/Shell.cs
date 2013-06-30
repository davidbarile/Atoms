using UnityEngine;
using System.Collections.Generic;

public class Shell : MonoBehaviour
{
	[HideInInspector]
	public Atom Atom = null;
	
	public float BrickAngle;
	public List< Brick > Bricks = new List< Brick >();
	[HideInInspector]
	public Brick SearchBrick = null;
	public int SelectedBrickIndex;
	
	public void Init( int inBrickCount, int inBrickValue, Brick inBrickPrefab )
	{
		for( int i = 0; i < inBrickCount; ++i )
		{
			GameObject brickInstance = GameObject.Instantiate( inBrickPrefab.gameObject ) as GameObject;
			Brick br = brickInstance.GetComponent< Brick >();
			br.Init( inBrickValue );
			br.PositionBrick( i, inBrickCount );
			br.transform.parent = this.transform;
			br.name = "Brick" + i;
			Bricks.Add( br );
		}	
	}
}

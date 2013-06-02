using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour 
{
	public Player Player = null;//which player's atom the controls are associated with
	
	void Start()
	{
		Player = gameObject.GetComponent<Player>() as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetKey( KeyCode.UpArrow ) )
		{
			Player.Thrust();
		}
		
		if( Input.GetKey( KeyCode.LeftArrow ) )
		{
			Player.RotateLeft();
		}
		
		if( Input.GetKey( KeyCode.RightArrow ) )
		{
			Player.RotateRight();
		}
		
		if( Input.GetKeyDown( KeyCode.Space ) )
		{
			Player.Shoot( "right" );
		}
		
		if( Input.GetKey( KeyCode.Z ) )
		{
			Player.CycleLeft();
		}
		
		if( Input.GetKey( KeyCode.X ) )
		{
			Player.CycleRight();
		}
	}
}

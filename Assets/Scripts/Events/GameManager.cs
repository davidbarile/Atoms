using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Player Player = null;
	
	void Awake()
	{
		Debug.Log( "GAME MANAGER Awake()  this = " + this );
	}
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log( "GAME MANAGER Start()  this = " + this );
		
		//spawn player
		Player = GameObject.Instantiate( Player ) as Player;
		Player.gameObject.SetActive( true );
	}
}

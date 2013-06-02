using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public Player Player = null;
	
	[SerializeField]
	private Atom _atomTemplate = null;
	
	void Awake()
	{
		Debug.Log( "GAME MANAGER Awake()  this = " + this );
		_atomTemplate.gameObject.SetActive( false );
	}
	
	// Use this for initialization
	void Start () 
	{
		Debug.Log( "GAME MANAGER Start()  this = " + this );
		
		//spawn player
		Player = GameObject.Instantiate( Resources.Load( "Player" ) ) as Player;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

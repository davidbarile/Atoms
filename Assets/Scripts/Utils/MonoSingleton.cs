using UnityEngine;

// Modified, originally from http://wiki.unity3d.com/index.php/Singleton#Generic_Based_Singleton_for_MonoBehaviours

public abstract class MonoSingleton< T > : MonoBehaviour where T : MonoSingleton< T >
{
	public MonoSingleton()
	{
	}
	
	public MonoSingleton( bool inShouldAddToDynamicObjects )
	{
		_ShouldAddToDynamicObjects = inShouldAddToDynamicObjects;	
	}
	
    public static T Instance
    {
        get
        {
            // Instance requiered for the first time, we look for it
            if( _Instance == null )
            {
                _Instance = GameObject.FindObjectOfType( typeof( T ) ) as T;

                // Object not found, we create a temporary one
                if( _Instance == null )
                {
					// first try to make it from a prefab 
					// HACK: not sure how to pass this in, havent thought about it much though
					
                    _Instance = new GameObject( typeof( T ).ToString(), typeof( T ) ).GetComponent< T >();
					DontDestroyOnLoad( _Instance );
					
					if ( _Instance._ShouldAddToDynamicObjects )
					{
						//GameInstance.AddDynamicObject( _Instance.gameObject );
					}
					
                    // Problem during the creation, this should not happen
                    if( _Instance == null )
                    {
                        Debug.LogError( "Problem during the creation of " + typeof( T ).ToString() );
                    }
                }
                _Instance.Init();
            }
            return _Instance;
        }
    }


    // This function is called when the instance is used the first time
    // Put all the initializations you need here, as you would do in Awake
    public virtual void Init(){}

    // Make sure the instance isn't referenced anymore when the user quit, just in case.
    private void OnApplicationQuit()
    {
        _Instance = null;
    }

    private static T _Instance = null;
	private bool _ShouldAddToDynamicObjects = true;
} 

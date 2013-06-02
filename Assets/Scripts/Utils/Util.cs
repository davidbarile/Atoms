using UnityEngine;
using System.Collections.Generic;

class Util
{
	public static void Swap<T>(ref T lhs, ref T rhs)
	{
	    T temp;
	    temp = lhs;
	    lhs = rhs;
	    rhs = temp;
	}
	

	public static void Shuffle<T>( ref List<T> inList )
	{
	    for (int i = inList.Count - 1; i >= 0; i--)
	    {
	        // Swap element "i" with a random earlier element it (or itself)
	        int swapIndex = Random.Range( 0, i + 1);
			
			// can't use swap, so sad
			T swapElement = inList[swapIndex];
			inList[ swapIndex ] = inList[i];;
			inList[ i ] = swapElement;
			
	    }
	}
	
	public static void DestroyChildren( GameObject inParent )
	{
		List< GameObject > exceptions = new List<GameObject>();
		DestroyChildren ( inParent, exceptions );
	}
	
	public static void DestroyChildren( GameObject inParent, List< GameObject > inExceptions )
	{	
		List< GameObject > childrenToAbandon = new List<GameObject>();
		for ( int i = inParent.transform.childCount - 1; i >= 0; i-- )
		{
			GameObject childObj = inParent.transform.GetChild( i ).gameObject;
			
			if ( !inExceptions.Contains( childObj ) )
			{
				childrenToAbandon.Add( childObj );
				GameObject.Destroy( childObj );
			}
		}
		
		foreach ( GameObject child in childrenToAbandon )
		{
			child.transform.parent = null;
		}
				
	}
	
	
	public static T GetComponentInChildren< T >( GameObject inParent ) where T : Component
	{	
		for ( int i = 0; i < inParent.transform.childCount; ++i )
		{
			var childObj = inParent.transform.GetChild( i );
			
			var comp = childObj.GetComponent< T >();
			
			if ( comp != null )
			{
				return comp;
			}
		}
		
		return null;
	}
	
	public static T[] GetComponentsInChildren< T >( GameObject inParent ) where T : Component
	{
		List< T > components = new List<T>();
		
		for ( int i = 0; i < inParent.transform.childCount; ++i )
		{
			var childObj = inParent.transform.GetChild( i );
			
			var comp = childObj.GetComponent< T >();
			
			if ( comp != null )
			{
				components.Add( comp );
			}
		}
		
		return components.ToArray();
	}
	
	public static Color HexToColor( string hex )
	{
		byte r = byte.Parse( hex.Substring( 0,2 ), System.Globalization.NumberStyles.HexNumber );
		byte g = byte.Parse( hex.Substring( 2,2 ), System.Globalization.NumberStyles.HexNumber );
		byte b = byte.Parse( hex.Substring( 4,2 ), System.Globalization.NumberStyles.HexNumber );
		return new Color32( r, g, b, 255 );
	}
}


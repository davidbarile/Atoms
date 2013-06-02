using System;
using UnityEngine;

public static class TransformExtensionMethods
{
	//position
    public static void SetPositionX( this Transform inTransform, float inX )
    {
		inTransform.position = new Vector3( inX, inTransform.position.y, inTransform.position.z );
	}
	
	public static void SetPositionY( this Transform inTransform, float inY )
    {
		inTransform.position = new Vector3( inTransform.position.x, inY, inTransform.position.z );
	}
	
	public static void SetPositionZ( this Transform inTransform, float inZ )
    {
		inTransform.position = new Vector3( inTransform.position.x, inTransform.position.y, inZ );
	}
	
	//local position
	public static void SetLocalPositionX( this Transform inTransform, float inX )
    {
		inTransform.localPosition = new Vector3( inX, inTransform.localPosition.y, inTransform.localPosition.z );
	}
	
	public static void SetLocalPositionY( this Transform inTransform, float inY )
    {
		inTransform.localPosition = new Vector3( inTransform.localPosition.x, inY, inTransform.localPosition.z );
	}
	
	public static void SetLocalPositionZ( this Transform inTransform, float inZ )
    {
		inTransform.localPosition = new Vector3( inTransform.localPosition.x, inTransform.localPosition.y, inZ );
	}
	
	//local scale
	public static void SetLocalScaleX( this Transform inTransform, float inX )
    {
		inTransform.localScale = new Vector3( inX, inTransform.localScale.y, inTransform.localScale.z );
	}
	
	public static void SetLocalScaleY( this Transform inTransform, float inY )
    {
		inTransform.localScale = new Vector3( inTransform.localScale.x, inY, inTransform.localScale.z );
	}
	
	public static void SetLocalScaleZ( this Transform inTransform, float inZ )
    {
		inTransform.localScale = new Vector3( inTransform.localScale.x, inTransform.localScale.y, inZ );
	}
	
	//rotation
	public static void SetRotationX( this Transform inTransform, float inX )
    {
		inTransform.rotation = Quaternion.Euler( new Vector3( inX, inTransform.rotation.eulerAngles.y, inTransform.rotation.eulerAngles.z ) );
	}
	
	public static void SetRotationY( this Transform inTransform, float inY )
    {
		inTransform.rotation = Quaternion.Euler( new Vector3( inTransform.rotation.eulerAngles.x, inY, inTransform.rotation.eulerAngles.z ) );	
	}
	
	public static void SetRotationZ( this Transform inTransform, float inZ )
	{
		inTransform.rotation = Quaternion.Euler( new Vector3( inTransform.rotation.eulerAngles.x, inTransform.rotation.eulerAngles.y, inZ ) );	
	}
	
	//local rotation
	public static void SetLocalRotationX( this Transform inTransform, float inX )
    {
		inTransform.localRotation = Quaternion.Euler( new Vector3( inX, inTransform.localRotation.eulerAngles.y, inTransform.localRotation.eulerAngles.z ) );
	}
	
	public static void SetLocalRotationY( this Transform inTransform, float inY )
    {
		inTransform.localRotation = Quaternion.Euler( new Vector3( inTransform.localRotation.eulerAngles.x, inY, inTransform.localRotation.eulerAngles.z ) );
	}
	
	public static void SetLocalRotationZ( this Transform inTransform, float inZ )
    {
		inTransform.localRotation = Quaternion.Euler( new Vector3( inTransform.localRotation.eulerAngles.x, inTransform.localRotation.eulerAngles.y, inZ ) );
	}
}


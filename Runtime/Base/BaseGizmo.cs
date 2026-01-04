/*
	Copyright © Carl Emil Carlsen 2020-2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public abstract class BaseGizmo : MonoBehaviour
	{
		[SerializeField] protected bool _destroyInPlayer = true;
		[SerializeField] protected bool _displayAlways = true;



		protected abstract void Draw();


		protected virtual void Awake()
		{
			if( !Application.isEditor && _destroyInPlayer ) Destroy( this );
		}


		void OnDrawGizmosSelected()
		{
			if( enabled && !_displayAlways ) Draw();
		}


		void OnDrawGizmos()
		{
			if( enabled && _displayAlways ) Draw();
		}


		protected static void DrawLabel( Vector3 position, string text, Color color, int size = 12 )
		{
#if UNITY_EDITOR
			GUIStyle style = new GUIStyle();
			style.normal.textColor = color;
			style.fontSize = size;
			UnityEditor.Handles.Label( position, text, style );
#endif
		}


		protected static void DrawLabel( Vector3 position, string text )
		{
#if UNITY_EDITOR
			UnityEditor.Handles.Label( position, text );
#endif
		}
	}
}
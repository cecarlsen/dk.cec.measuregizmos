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


		protected static void DrawLabel( Vector3 position, string text )
		{
#if UNITY_EDITOR
			UnityEditor.Handles.Label( position, text );
#endif
		}
	}
}
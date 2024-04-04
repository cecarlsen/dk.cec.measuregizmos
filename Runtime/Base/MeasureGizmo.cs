/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public abstract class MeasureGizmo : MonoBehaviour
	{
		[SerializeField] protected bool _destroyInPlayer = true;
		[SerializeField] protected bool _displayAlways = true;
		[SerializeField] protected MetricUnit _metricUnit = MetricUnit.Meters;
		[SerializeField] protected Color _color = Color.yellow;


		protected abstract void Draw();


		protected virtual void Awake()
		{
			if( !Application.isEditor && _destroyInPlayer ) Destroy( this );
		}


		void OnDrawGizmosSelected()
		{
			if( !_displayAlways ) Draw();
		}


		void OnDrawGizmos()
		{
			if( _displayAlways ) Draw();
		}


		protected string MeasureToString( float value )
		{
			switch( _metricUnit )
			{
				case MetricUnit.Meters:
					return value.ToString( "F2" ) + "m";
				case MetricUnit.Millimeters:
					return Mathf.RoundToInt( value * 1000 ).ToString() + "mm";
			}
			return string.Empty;
		}


		protected static void DrawLabel( Vector3 position, string text )
		{
#if UNITY_EDITOR
			UnityEditor.Handles.Label( position, text );
#endif
		}
	}
}
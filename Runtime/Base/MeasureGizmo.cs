/*
	Copyright © Carl Emil Carlsen 2020-2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public abstract class MeasureGizmo : BaseGizmo
	{
		[SerializeField] protected MetricUnit _metricUnit = MetricUnit.Meters;
		[SerializeField] protected Color _color = Color.yellow;


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
	}
}
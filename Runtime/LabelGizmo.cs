/*
	Copyright © Carl Emil Carlsen 2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class LabelGizmo : BaseGizmo
	{
		[SerializeField] string _text = string.Empty;
		[SerializeField] Vector3 _offsetLocal = Vector3.zero;
		[SerializeField] Vector3 _offsetWorld = Vector3.zero;
		[SerializeField] Color _lineColor = Color.clear;
		

		protected override void Draw()
		{
			var text = string.IsNullOrEmpty( _text ) ? name : _text;
			var labelPosition = transform.position + transform.rotation * _offsetLocal + _offsetWorld;
			DrawLabel( labelPosition, text );

			if( _lineColor.a > 0f ){
				Gizmos.color = _lineColor;
				Gizmos.DrawLine( transform.position, labelPosition );
			}
		}
	}
}
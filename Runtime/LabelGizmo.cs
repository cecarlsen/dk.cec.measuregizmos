/*
	Copyright © Carl Emil Carlsen 2025-2026
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
		[SerializeField] int _textSize = 12;
		[SerializeField] Color _textColor = Color.white;
		[SerializeField] Color _lineColor = Color.clear;
		

		protected override void Draw()
		{
			var text = string.IsNullOrEmpty( _text ) ? name : _text;
			var labelPosition = transform.position + transform.rotation * _offsetLocal + _offsetWorld;
			DrawLabel( labelPosition, text, _textColor, _textSize );

			if( _lineColor.a > 0f ){
				Gizmos.color = _lineColor;
				Gizmos.DrawLine( transform.position, labelPosition );
			}
		}
	}
}
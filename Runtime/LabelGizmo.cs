/*
	Copyright © Carl Emil Carlsen 2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class LabelGizmo : MeasureGizmo
	{
		[SerializeField] string _text = string.Empty;
		[SerializeField] Vector3 _offsetLocal = Vector3.zero;
		[SerializeField] Vector3 _offsetWorld = Vector3.zero;



		protected override void Draw()
		{
			var text = string.IsNullOrEmpty( _text ) ? name : _text;
			var position = transform.position + transform.rotation * _offsetLocal + _offsetWorld;
			DrawLabel( position, text );
		}
	}
}
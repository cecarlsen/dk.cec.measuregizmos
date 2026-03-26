/*
	Copyright © Carl Emil Carlsen 2025-2026
	http://cec.dk
*/

using System;
using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class TransformGizmo : BaseGizmo
	{
		[SerializeField] Color _color = Color.yellow;
		[SerializeField] bool _drawAxis = false;


		protected override void Draw()
		{
			Gizmos.matrix = transform.localToWorldMatrix;

			if( _color.a > 0f ){
				Gizmos.color = _color;
				Gizmos.DrawWireCube( Vector3.zero, Vector3.one );
			}
			if( _drawAxis ){
				Gizmos.color = Color.red;
				Gizmos.DrawLine( Vector3.zero, Vector3.right );
				Gizmos.color = Color.green;
				Gizmos.DrawLine( Vector3.zero, Vector3.up );
				Gizmos.color = Color.blue;
				Gizmos.DrawLine( Vector3.zero, Vector3.forward );
			}
		}
	}
}
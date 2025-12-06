/*
	Copyright © Carl Emil Carlsen 2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class TransformGizmo : BaseGizmo
	{
		[SerializeField] Color _color = Color.yellow;


		protected override void Draw()
		{
			Gizmos.color = _color;
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawWireCube( Vector3.zero, Vector3.one );
		}
	}
}
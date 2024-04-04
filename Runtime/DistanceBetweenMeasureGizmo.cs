/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public class DistanceBetweenMeasureGizmo : MeasureGizmo
	{
		[SerializeField] Transform _targetTransformA = null;
		[SerializeField] Transform _targetTransformB = null;


		protected override void Draw()
		{
			if( !_targetTransformA && !_targetTransformB ) return;

			var transA = _targetTransformA ? _targetTransformA : transform;
			var transB = _targetTransformB ? _targetTransformB : transform;

			Gizmos.color = _color;
			Gizmos.DrawLine( transA.position, transB.position );

			Vector3 towardsB = transB.position - transA.position;
			DrawLabel( transA.position + towardsB * 0.5f, MeasureToString( towardsB.magnitude ) );
		}
	}
}
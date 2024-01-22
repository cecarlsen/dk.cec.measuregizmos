/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MeasureGizmos
{
	public class DistanceToMeasureGizmo : MeasureGizmo
	{
		[SerializeField] Transform _targetTransform = null;


		protected override void Draw()
		{
			if( !_targetTransform ) return;

			Gizmos.color = _color;
			Gizmos.DrawLine( transform.position, _targetTransform.position );

#if UNITY_EDITOR
			Vector3 towardsB = _targetTransform.position - transform.position;
			Handles.Label( transform.position + towardsB * 0.5f, MeasureToString( towardsB.magnitude ) );
#endif
		}
	}
}
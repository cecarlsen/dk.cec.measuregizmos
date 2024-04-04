/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public class DistanceRaycastMeasureGizmo : MeasureGizmo
	{

		protected override void Draw()
		{
			var ray = new Ray( transform.position, transform.forward );
			var hit = new RaycastHit();
			if( Physics.Raycast( ray, out hit ) ) {

				Gizmos.color = _color;
				Gizmos.DrawLine( ray.origin, ray.origin + ray.direction * hit.distance );
				DrawLabel( ray.origin + ray.direction * hit.distance * 0.5f, MeasureToString( hit.distance ) );
			}
		}
	}
}
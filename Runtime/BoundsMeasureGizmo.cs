/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class BoundsMeasureGizmo : MeasureGizmo
	{


		protected override void Draw()
		{
			Bounds bounds = ComputeBounds();
			if( bounds.size == Vector3.zero ) return;

			Gizmos.color = _color;
			Gizmos.DrawWireCube( bounds.center, bounds.size );

			DrawLabel( bounds.min + ( Vector3.right * bounds.extents.x ), "w: " + MeasureToString( bounds.size.x ) );
			DrawLabel( bounds.min + ( Vector3.up * bounds.extents.y ), "h: " + MeasureToString( bounds.size.y ) );
			DrawLabel( bounds.min + ( Vector3.forward * bounds.extents.z ), "d: " + MeasureToString( bounds.size.z ) );
		}


		Bounds ComputeBounds()
		{
			Renderer[] renderers = GetComponentsInChildren<Renderer>();
			if( renderers.Length == 0 ) return new Bounds();
			Bounds bounds = new Bounds( renderers[ 0 ].bounds.center, Vector3.zero );
			foreach( Renderer render in renderers ) bounds.Encapsulate( render.bounds );
			return bounds;
		}
	}
}
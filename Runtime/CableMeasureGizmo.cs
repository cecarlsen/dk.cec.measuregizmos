/*
	Copyright © Carl Emil Carlsen 2025
	http://cec.dk
*/

using UnityEngine;

namespace MeasureGizmos
{
	public class CableMeasureGizmo : MeasureGizmo
	{
		[SerializeField] CornerAnchor[] _cornerAnchors = new CornerAnchor[0];


		[System.Serializable]
		public class CornerAnchor {
			public Transform transform;
			//public float radius = 1f;
		}


		protected override void Draw()
		{
			if( _cornerAnchors?.Length < 2 ) return;

			float length = 0;
			var last = _cornerAnchors[0].transform;
			Gizmos.color = _color;
			for( int i = 1; i < _cornerAnchors.Length; i++ ) {
				var current = _cornerAnchors[i].transform;
				Gizmos.DrawLine( last.position, current.position );
				length += Vector3.Distance( last.position, current.position );
				last = current;
			}

			DrawLabel( last.position, MeasureToString( length ) );
		}
	}
}
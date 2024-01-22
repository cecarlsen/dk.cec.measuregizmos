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
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	public class CameraOntoPlaneMeasureGizmo : MeasureGizmo
	{
		[SerializeField] Transform _planeTransform = null;
		[SerializeField] bool _showCenter = false;
		[SerializeField] bool _showPixels = false;

		Camera _camera;
		Vector3[] _hitPoints = new Vector3[ 4 ];

		static readonly Vector3[] viewportCorners = new Vector3[] { Vector3.zero, Vector3.up, Vector3.one, Vector3.right };

		public Vector3 bottomLeftHitPoint { get { return _hitPoints[ 0 ]; } }
		public Vector3 topLeftHitPoint { get { return _hitPoints[ 1 ]; } }
		public Vector3 topRightHitPoint { get { return _hitPoints[ 2 ]; } }
		public Vector3 bottomRightHitPoint { get { return _hitPoints[ 3 ]; } }
		public Vector3 centerLeftHitPoint { get { return Vector3.Lerp( bottomLeftHitPoint, topLeftHitPoint, 0.5f ); } }
		public Vector3 centerTopHitPoint { get { return Vector3.Lerp( topLeftHitPoint, topRightHitPoint, 0.5f ); } }
		public Vector3 centerRightHitPoint { get { return Vector3.Lerp( topRightHitPoint, bottomRightHitPoint, 0.5f ); } }
		public Vector3 centerBottomHitPoint { get { return Vector3.Lerp( bottomRightHitPoint, bottomLeftHitPoint, 0.5f ); } }

		public Vector3 centerHitPoint { get { return Vector3.Lerp( centerLeftHitPoint, centerRightHitPoint, 0.5f ); } }

		public float rightHeight { get { return Vector3.Distance( bottomRightHitPoint, topRightHitPoint ); } }
		public float leftHeight { get { return Vector3.Distance( bottomLeftHitPoint, topLeftHitPoint ); } }
		public float centerHeight { get { return Vector3.Distance( centerBottomHitPoint, centerTopHitPoint ); } }

		public float topWidth { get { return Vector3.Distance( topLeftHitPoint, topRightHitPoint ); } }
		public float bottomWidth { get { return Vector3.Distance( bottomLeftHitPoint, bottomRightHitPoint ); } }
		public float centerWidth { get { return Vector3.Distance( centerLeftHitPoint, centerRightHitPoint ); } }


		protected override void Awake()
		{
			_camera = GetComponent<Camera>();
			base.Awake();
		}


		void Update()
		{
			Plane plane = new Plane( _planeTransform.forward, _planeTransform.position );

			for( int i = 0; i < _hitPoints.Length; i++ ) {
				Ray ray = _camera.ViewportPointToRay( viewportCorners[ i ] );
				float hitDist;
				if( !plane.Raycast( ray, out hitDist ) ) return;
				Vector3 hitPoint = ray.origin + ray.direction * hitDist;
				_hitPoints[ i ] = hitPoint;
			}
		}


		protected override void Draw()
		{
			if( !_camera || !_planeTransform ) return;

			Gizmos.color = _color;
			for( int i0 = 0; i0 < _hitPoints.Length; i0++ ) {
				int i1 = i0 < _hitPoints.Length-1 ? i0+1 : 0;
				Gizmos.DrawLine( _hitPoints[ i0 ], _hitPoints[ i1 ] );
			}

			if( _showCenter ) {
				Gizmos.DrawLine( centerLeftHitPoint , centerRightHitPoint );
				Gizmos.DrawLine( centerTopHitPoint, centerBottomHitPoint );
			}

			if( _showPixels )
			{
				Gizmos.color = new Color( _color.r, _color.g, _color.b, _color.a * 0.1f );
				for( int i = 1; i < _camera.pixelHeight-1; i++ ) {
					float t = i / (_camera.pixelHeight-1f);
					Vector3 p0 = Vector3.Lerp( bottomLeftHitPoint, topLeftHitPoint , t );
					Vector3 p1 = Vector3.Lerp( bottomRightHitPoint, topRightHitPoint, t );
					Gizmos.DrawLine( p0, p1 ); 
				}
				for( int i = 1; i < _camera.pixelWidth - 1; i++ ) {
					float t = i / ( _camera.pixelWidth - 1f );
					Vector3 p0 = Vector3.Lerp( bottomLeftHitPoint, bottomRightHitPoint, t );
					Vector3 p1 = Vector3.Lerp( topLeftHitPoint, topRightHitPoint, t );
					Gizmos.DrawLine( p0, p1 );
				}
			}


#if UNITY_EDITOR
			Handles.Label( centerLeftHitPoint, "h: " + MeasureToString( leftHeight ) );
			Handles.Label( centerRightHitPoint, "h: " + MeasureToString( rightHeight ) );
			Handles.Label( centerTopHitPoint, "w: " + MeasureToString( topWidth ) );
			Handles.Label( centerBottomHitPoint, "w: " + MeasureToString( bottomWidth ) );

			if( _showCenter ) {
				Handles.Label( centerHitPoint, "w: " + MeasureToString( centerWidth ) + ", h: " + MeasureToString( centerHeight ) );
			}
#endif
		}
	}
}
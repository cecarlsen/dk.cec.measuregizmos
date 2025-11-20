/*
	Copyright © Carl Emil Carlsen 2020-2025
	http://cec.dk
*/

using System.Collections.Generic;
using UnityEngine;

namespace MeasureGizmos
{
	[ExecuteInEditMode]
	public class BoundsMeasureGizmo : MeasureGizmo
	{
		[SerializeField] Transform _parentTransform;
		[SerializeField] bool _drawChildBounds = true;
		[SerializeField] bool _drawX = true;
		[SerializeField] bool _drawY = true;
		[SerializeField] bool _drawZ = true;
		[SerializeField,Range(0f,1f)] float _labelXOffset = 0.5f;
		[SerializeField,Range(0f,1f)] float _labelYOffset = 0.5f;
		[SerializeField,Range(0f,1f)] float _labelZOffset = 0.5f;

		List<MeshFilter> _meshFilters = new List<MeshFilter>();
		Vector3[] _corners = new Vector3[8];


		protected override void Draw()
		{
			Bounds bounds = ComputeBounds();
			if( bounds.size == Vector3.zero ) return;

			Gizmos.matrix = _parentTransform ? _parentTransform.localToWorldMatrix : transform.localToWorldMatrix;
			Gizmos.color = _color;
			Gizmos.DrawWireCube( bounds.center, bounds.size );

			Vector3 size = bounds.size;
			size.Scale( _parentTransform.lossyScale );

			if( _drawX ) DrawLabel( Gizmos.matrix.MultiplyPoint3x4( bounds.min + ( Vector3.right * bounds.size.x * _labelXOffset ) ), "w: " + MeasureToString( size.x ) );
			if( _drawY ) DrawLabel( Gizmos.matrix.MultiplyPoint3x4( bounds.min + ( Vector3.up * bounds.size.y * _labelXOffset ) ), "h: " + MeasureToString( size.y ) );
			if( _drawZ ) DrawLabel( Gizmos.matrix.MultiplyPoint3x4( bounds.min + ( Vector3.forward * bounds.size.z * _labelXOffset ) ), "d: " + MeasureToString( size.z ) );
		}


		Bounds ComputeBounds()
		{
			var trans = _parentTransform ? _parentTransform : transform;
			trans.GetComponentsInChildren( _meshFilters);
			for( int i = _meshFilters.Count - 1; i >= 0; i-- ){
				if( !_meshFilters[i].gameObject.activeInHierarchy || !_meshFilters[i].sharedMesh ) _meshFilters.RemoveAt( i );
			}
			if( _meshFilters.Count == 0 ) return new Bounds();

			if( _drawChildBounds ) Gizmos.color = new Color( _color.r, _color.g, _color.b, _color.a * 0.25f );
			bool first = true;
			Bounds bounds = new Bounds();
			foreach( var filter in _meshFilters )
			{
				var modelToWorldMatrix = filter.transform.localToWorldMatrix;
				var modelBounds = filter.sharedMesh.bounds;
				var transformedBounds =GetTransformedBounds( modelBounds, modelToWorldMatrix, trans.worldToLocalMatrix, _corners );
				if( first ){
					first = false;
					bounds = transformedBounds;
				} else{
					bounds.Encapsulate( transformedBounds );
				}
				
				if( _drawChildBounds ){
					Gizmos.matrix = modelToWorldMatrix;
					Gizmos.DrawWireCube( modelBounds.center, modelBounds.size );
				}
			}
			return bounds;
		}


		static Bounds GetTransformedBounds( Bounds modelBounds, Matrix4x4 modelToWorldMatrix, Matrix4x4 worldToParentMatrix, Vector3[] corners )
		{
			GetCorners( modelBounds, corners );
			TransformCorners( modelToWorldMatrix, corners );
			return GeometryUtility.CalculateBounds( corners, worldToParentMatrix );
		}


		static void GetCorners( Bounds bounds, Vector3[] corners )
		{
			Vector3 min = bounds.min;
			Vector3 max = bounds.max;

			corners[0] = new Vector3(min.x, min.y, min.z);
			corners[1] = new Vector3(max.x, min.y, min.z);
			corners[2] = new Vector3(min.x, max.y, min.z);
			corners[3] = new Vector3(max.x, max.y, min.z);
			corners[4] = new Vector3(min.x, min.y, max.z);
			corners[5] = new Vector3(max.x, min.y, max.z);
			corners[6] = new Vector3(min.x, max.y, max.z);
			corners[7] = new Vector3(max.x, max.y, max.z);
		}


		static void TransformCorners( Matrix4x4 matrix, Vector3[] corners )
		{
			for( int i = 0; i < corners.Length; i++ ){
				corners[i] = matrix.MultiplyPoint3x4( corners[i] );
			}
		}
	}
}
/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( CameraOntoPlaneMeasureGizmo ) )]
	public class CameraOntoPlaneMeasureGizmoInspector : MeasureGizmoInspector
	{
		CameraOntoPlaneMeasureGizmo _gizmo;

		SerializedProperty _planeTransform;
		SerializedProperty _showCenter;
		SerializedProperty _showPixels;


		protected override void OnEnable()
		{
			base.OnEnable();

			_gizmo = target as CameraOntoPlaneMeasureGizmo;

			_planeTransform = serializedObject.FindProperty( "_planeTransform" );
			_showCenter = serializedObject.FindProperty( "_showCenter" );
			_showPixels = serializedObject.FindProperty( "_showPixels" );
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			BasePropertyFields();
			EditorGUILayout.PropertyField( _planeTransform );
			EditorGUILayout.PropertyField( _showCenter );
			EditorGUILayout.PropertyField( _showPixels );

			serializedObject.ApplyModifiedProperties();
		}
	}
}
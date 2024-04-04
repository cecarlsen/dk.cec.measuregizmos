/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( DistanceBetweenMeasureGizmo ) )]
	public class DistanceBetweenMeasureGizmoInspector : MeasureGizmoInspector
	{
		SerializedProperty _targetTransformA;
		SerializedProperty _targetTransformB;


		protected override void OnEnable()
		{
			base.OnEnable();

			_targetTransformA = serializedObject.FindProperty( nameof( _targetTransformA ) );
			_targetTransformB = serializedObject.FindProperty( nameof( _targetTransformB ) );
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			BasePropertyFields();
			EditorGUILayout.PropertyField( _targetTransformA );
			EditorGUILayout.PropertyField( _targetTransformB );

			serializedObject.ApplyModifiedProperties();
		}
	}
}
/*
	Copyright © Carl Emil Carlsen 2020-2024
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( DistanceToMeasureGizmo ) )]
	public class DistanceToMeasureGizmoInspector : MeasureGizmoInspector
	{
		SerializedProperty _targetTransformAProp;
		SerializedProperty _targetTransformBProp;


		protected override void OnEnable()
		{
			base.OnEnable();

			_targetTransformAProp = serializedObject.FindProperty( "_targetTransformA" );
			_targetTransformBProp = serializedObject.FindProperty( "_targetTransformB" );
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			BasePropertyFields();
			EditorGUILayout.PropertyField( _targetTransformAProp );
			EditorGUILayout.PropertyField( _targetTransformBProp );

			serializedObject.ApplyModifiedProperties();
		}
	}
}
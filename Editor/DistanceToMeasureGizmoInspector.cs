/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( DistanceToMeasureGizmo ) )]
	public class DistanceToMeasureGizmoInspector : MeasureGizmoInspector
	{
		SerializedProperty _targetTransform;


		protected override void OnEnable()
		{
			base.OnEnable();

			_targetTransform = serializedObject.FindProperty( "_targetTransform" );
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			BasePropertyFields();
			EditorGUILayout.PropertyField( _targetTransform );

			serializedObject.ApplyModifiedProperties();
		}
	}
}
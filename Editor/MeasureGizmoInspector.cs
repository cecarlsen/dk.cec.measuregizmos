/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( MeasureGizmo ) )]
	public abstract class MeasureGizmoInspector : Editor
	{
		protected SerializedProperty _destroyInPlayer;
		protected SerializedProperty _displayAlways;
		protected SerializedProperty _metricUnit;
		protected SerializedProperty _color;


		protected virtual void OnEnable()
		{
			_destroyInPlayer = serializedObject.FindProperty( "_destroyInPlayer" );
			_displayAlways = serializedObject.FindProperty( "_displayAlways" );
			_metricUnit = serializedObject.FindProperty( "_metricUnit" );
			_color = serializedObject.FindProperty( "_color" );
		}


		protected void BasePropertyFields()
		{
			EditorGUILayout.PropertyField( _destroyInPlayer );
			EditorGUILayout.PropertyField( _displayAlways );
			EditorGUILayout.PropertyField( _metricUnit );
			EditorGUILayout.PropertyField( _color );
		}
	}
}
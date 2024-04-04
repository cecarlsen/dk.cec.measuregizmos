/*
	Copyright © Carl Emil Carlsen 2020-2024
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
			_destroyInPlayer = serializedObject.FindProperty( nameof( _destroyInPlayer ) );
			_displayAlways = serializedObject.FindProperty( nameof( _displayAlways ) );
			_metricUnit = serializedObject.FindProperty( nameof( _metricUnit ) );
			_color = serializedObject.FindProperty( nameof( _color ) );
		}


		protected void BasePropertyFields()
		{
			EditorGUILayout.PropertyField( _destroyInPlayer );
			EditorGUILayout.PropertyField( _displayAlways );
			EditorGUILayout.PropertyField( _metricUnit );
			EditorGUILayout.PropertyField( _color );

			EditorGUILayout.Space();
		}
	}
}
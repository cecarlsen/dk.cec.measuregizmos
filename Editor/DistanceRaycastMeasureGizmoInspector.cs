/*
	Copyright © Carl Emil Carlsen 2024
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( DistanceRaycastMeasureGizmo ) )]
	public class DistanceRaycastMeasureGizmoInspector : MeasureGizmoInspector
	{

		protected override void OnEnable()
		{
			base.OnEnable();
	
		}


		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			BasePropertyFields();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
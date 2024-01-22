/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEditor;

namespace MeasureGizmos
{
	[CustomEditor( typeof( BoundsMeasureGizmo ) )]
	public class BoundsMeasureGizmoInspector : MeasureGizmoInspector
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
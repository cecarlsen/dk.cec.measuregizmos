/*
	Copyright © Carl Emil Carlsen 2020
	http://cec.dk
*/

using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace MeasureGizmos
{
	[CustomEditor( typeof( BoundsMeasureGizmo ) )]
	public class BoundsMeasureGizmoInspector : MeasureGizmoInspector
	{

		public override VisualElement CreateInspectorGUI()
		{
			VisualElement root = new VisualElement();
					
			InspectorElement.FillDefaultInspector( root, serializedObject, this);

			return root;
		}
	}
}
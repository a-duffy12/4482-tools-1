using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShapeRandomizer))]
[CanEditMultipleObjects]
public class ShapeConEditor : Editor
{
   private ShapeRandomizer shape;
   [SerializeField ]private bool showProperties;

   private void OnEnable()
   {
      shape = target as ShapeRandomizer;
   }

   public override void OnInspectorGUI()
   {
      if (!showProperties)
      {
         if (GUILayout.Button("Show Properties"))
         {
            showProperties = true;
         }
      }
      
      if (showProperties)
      {
         if (GUILayout.Button("Hide Properties"))
         {
            showProperties = false;
         }
      }

      if (showProperties)
      {
         base.OnInspectorGUI();
      }
      
      EditorGUILayout.Space();
      EditorGUILayout.Space();
      EditorGUILayout.LabelField("Randomization Fields", EditorStyles.boldLabel);

      GUILayout.Label("X Position");
      shape.minX = EditorGUILayout.Slider("Minimum X Position", shape.minX, -20f, 0f);
      shape.maxX = EditorGUILayout.Slider("Maximum X Position", shape.maxX, 0f, 20f);
      EditorGUILayout.Space();

      GUILayout.Label("Y Position");
      shape.minY = EditorGUILayout.Slider("Minimum", shape.minY, -20f, 0f);
      shape.maxY = EditorGUILayout.Slider("Maximum", shape.maxY, 0f, 20f);
      EditorGUILayout.Space();

      GUILayout.Label("Z Position");
      shape.minZ = EditorGUILayout.Slider("Minimum", shape.minZ, -20f, 0f);
      shape.maxZ = EditorGUILayout.Slider("Maximum", shape.maxZ, 0f, 20f);
      EditorGUILayout.Space();

      GUILayout.Label("Scale");
      shape.minScale = EditorGUILayout.Slider("Minimum", shape.minScale, 0, 1);
      shape.maxScale = EditorGUILayout.Slider("Maximum", shape.maxScale, 1, 100);
      EditorGUILayout.Space();

      EditorGUILayout.Space();
      EditorGUILayout.LabelField("Randomize Shape", EditorStyles.boldLabel);
      EditorGUILayout.Space();

      GUILayout.BeginHorizontal();

      if (GUILayout.Button("Position"))
      {
         shape.RandomizePosition(); 
      }

      if (GUILayout.Button("Scale"))
      {
         shape.RandomizeScale(); 
      }

      if (GUILayout.Button("Color"))
      {
         shape.RandomizeColor(); 
      }

      GUILayout.EndHorizontal();

      if (GUILayout.Button("All"))
      {
         shape.Randomize(); 
      }

      EditorGUILayout.Space();
      EditorGUILayout.LabelField("Reset", EditorStyles.boldLabel);
      EditorGUILayout.Space();

      GUILayout.BeginHorizontal();

      if (GUILayout.Button("Reset Shape"))
      {
         shape.ResetShape(); 
      }

      if (GUILayout.Button("Reset Sliders"))
      {
         shape.ResetSliders();
      }

      GUILayout.EndHorizontal();

      //ApplyModifiedProperties();
   }
}

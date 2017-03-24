using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;

[CustomEditor( typeof(ColorPatternHighlight))]
public class ColorPatternHighlight_editor : Editor {

    private List<bool> patternFoldouts;

  
    public void DrawPatternInspector(ColorPatternHighlight.PatternInfo pattern)
    {
        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("Color selection settings",MessageType.None);
        pattern.patternColor = EditorGUILayout.ColorField("Pattern color",pattern.patternColor);
        pattern.range = EditorGUILayout.Slider("RGB Range",pattern.range,0,2.83f);
        pattern.hueRange = EditorGUILayout.Slider("Hue Range",pattern.hueRange,0,5f);
        pattern.edgeSharpness = EditorGUILayout.Slider("Edge sharpness",pattern.edgeSharpness,1f,20f);
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.HelpBox("Highlight settings",MessageType.None);
        pattern.highlightType = (ColorPatternHighlight.HighlightTypes)EditorGUILayout.EnumPopup("Highlight type",pattern.highlightType);
        pattern.patternTexture = (Texture) EditorGUILayout.ObjectField("Texture", pattern.patternTexture, typeof (Texture), false);
        pattern.strength = EditorGUILayout.Slider("Strength",pattern.strength,0,2f);
        pattern.autoTiling = EditorGUILayout.ToggleLeft("Auto tiling",pattern.autoTiling);
        if (!pattern.autoTiling)
            pattern.tiling = EditorGUILayout.Vector2Field("Tiling",pattern.tiling);
        pattern.tilingShift = EditorGUILayout.Vector2Field("Tiling shift",pattern.tilingShift);
        EditorGUILayout.EndVertical();
    }


	public override void OnInspectorGUI()
	{
		ColorPatternHighlight cph = (ColorPatternHighlight)target;

        int toDelete = -1;

        if (cph.patterns == null)
        {
            cph.patterns = new ColorPatternHighlight.PatternInfo[1];
            cph.patterns[0] = new ColorPatternHighlight.PatternInfo();
            patternFoldouts = new List<bool>();
            patternFoldouts.Add(true);
        }

        if (patternFoldouts == null || cph.patterns.Length != patternFoldouts.Count)
        {
            patternFoldouts = new List<bool>();
            for (int i = 0; i < cph.patterns.Length; i++)
                patternFoldouts.Add (false);
        }

        Color defaultTextColor = GUI.contentColor;

        EditorGUILayout.BeginVertical();
        for (int i = 0; i < cph.patterns.Length; i++)
        {                       
            GUI.contentColor = new Color(cph.patterns[i].patternColor.r,
                cph.patterns[i].patternColor.g,
                cph.patterns[i].patternColor.b,
                1);
            GUILayout.BeginHorizontal();
            if (patternFoldouts[i] = EditorGUILayout.Foldout(patternFoldouts[i],"Pattern #" + i.ToString()))
            {
                if (i !=0 && GUILayout.Button("Remove")
                    && (EditorUtility.DisplayDialog("Are you sure?",
                        "Deleting pattern settings is irreversible.",
                        "Yes, delete this pattern setup.",
                        "No, I changed my mind")))
                    toDelete = i;
                GUILayout.EndHorizontal();
                EditorGUI.indentLevel++;
                GUI.contentColor = defaultTextColor;
                DrawPatternInspector(cph.patterns[i]);
                EditorGUI.indentLevel--;
            }
            else
            {
                if (i !=0 && GUILayout.Button("Remove")
                    && (EditorUtility.DisplayDialog("Are you sure?",
                        "Deleting pattern settings is irreversible.",
                        "Yes, delete this pattern setup.",
                        "No, I changed my mind")))
                    toDelete = i;
                GUILayout.EndHorizontal();
                GUI.contentColor = defaultTextColor;
            }
        }
            
        if (GUILayout.Button("Add pattern"))
        {
            if (cph.patterns == null)
                cph.patterns = new ColorPatternHighlight.PatternInfo[1];
            else
                Array.Resize(ref cph.patterns,cph.patterns.Length + 1);

            patternFoldouts.Add(true);

            cph.patterns[cph.patterns.Length - 1] = new ColorPatternHighlight.PatternInfo();
        }
        EditorGUILayout.EndVertical();

        if (toDelete != -1)
        {
            patternFoldouts.RemoveAt(toDelete);
            for (int i = toDelete; i < cph.patterns.Length-1; i++)
            {
                cph.patterns[i] = cph.patterns[i+1];
            }
            Array.Resize(ref cph.patterns,cph.patterns.Length-1);
        }

        if (GUI.changed)
            EditorUtility.SetDirty (target);
	}

  
}

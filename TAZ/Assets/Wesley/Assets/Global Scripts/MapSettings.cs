using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

///<summary>
///This script makes the MapLayer class a scriptable object
///To create a new MapLayer, right click in the project view and select Map Layer Settings
///You can then use this script with the LevelGenerator to generate your level

public enum Algorithm
{
    RandomWalkTop, RandomWalkTopSmoothed, RandomWalkCave
}

[System.Serializable]
[CreateAssetMenu(fileName ="NewMapSettings", menuName = "Map Settings", order = 0)]
public class MapSettings : ScriptableObject
{
    public Algorithm algorithm;    
    public bool randomSeed;	
    public float seed;	
    public int fillAmount;
	public int smoothAmount;
    public int clearAmount;
    public int interval;
    public int minPathWidth, maxPathWidth, maxPathChange, roughness, windyness;
    public bool edgesAreWalls;
    public float modifier;
}

//Custom UI for our class
[CustomEditor(typeof(MapSettings))]
public class MapSettings_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        MapSettings mapLayer = (MapSettings)target;
		GUI.changed = false;
		EditorGUILayout.LabelField(mapLayer.name, EditorStyles.boldLabel);

		mapLayer.algorithm = (Algorithm)EditorGUILayout.EnumPopup(new GUIContent("Generation Method", "The generation method we want to use to generate the map"), mapLayer.algorithm);
		mapLayer.randomSeed = EditorGUILayout.Toggle("Random Seed", mapLayer.randomSeed);

		//Only appear if we have the random seed set to false
        if (!mapLayer.randomSeed)
        {
            mapLayer.seed = EditorGUILayout.FloatField("Seed", mapLayer.seed);
        }

		//Shows different options depending on what algorithm is selected
        switch (mapLayer.algorithm)
        {
            case Algorithm.RandomWalkTop:
                //No additional Variables
                break;
            case Algorithm.RandomWalkTopSmoothed:
                mapLayer.interval = EditorGUILayout.IntSlider("Minimum Section Length", mapLayer.interval, 1, 10);
                break;
            case Algorithm.RandomWalkCave:
                mapLayer.clearAmount = EditorGUILayout.IntSlider("Amount To Clear", mapLayer.clearAmount, 0, 100);
                break;
        }

		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		AssetDatabase.SaveAssets();

		if(GUI.changed)
			EditorUtility.SetDirty(mapLayer);
    }
}

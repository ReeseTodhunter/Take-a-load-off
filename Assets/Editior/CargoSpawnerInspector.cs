using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CargoSpawner))]

public class CargoSpawnerInspector : Editor
{
    CargoSpawner spawner;

    private void OnEnable()
    {
        spawner = (CargoSpawner)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (Application.isPlaying)
        {
            if (GUILayout.Button("Spawn Crates"))
            {
                spawner.SpawnCargo(spawner.numToSpawn);
            }
        }
    }
}

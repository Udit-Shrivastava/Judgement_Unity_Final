using UnityEditor;
using UnityEngine;

public class MovementAreaEditor : EditorWindow
{
    Vector3 AreaTransform = Vector3.zero;
    GameObject prefab;
    
    [MenuItem("Tools/ZombieMovement/Movement Area Marker")]
    public static void ShowWindow()
    {
        GetWindow(typeof(MovementAreaEditor));
    }

    private void OnGUI()
    {
        AreaTransform = EditorGUILayout.Vector3Field("Staring Point Trandform", AreaTransform);
        prefab = EditorGUILayout.ObjectField("Column Prefab", prefab, typeof(GameObject), true) as GameObject;
        
        if(GUILayout.Button("Spawn Diagonal Sets"))
        {
            SpawnDiagonals();
        }
        
    }

    private void SpawnDiagonals()
    {
        GameObject diagonal1 = Instantiate(prefab, AreaTransform, Quaternion.identity);
        diagonal1.name = "Diagonal_1";
        AreaTransform.x = AreaTransform.x + 5f;
        GameObject diagonal2 = Instantiate(prefab, AreaTransform, Quaternion.identity);
        diagonal2.name = "Diagonal_2";
        AreaTransform.x = AreaTransform.x - 5f;

    }
}

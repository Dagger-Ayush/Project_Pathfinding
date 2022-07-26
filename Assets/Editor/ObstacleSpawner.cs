using UnityEngine;
using UnityEditor;

public class ObstacleSpawner : EditorWindow
{
    [SerializeField] public GameObject obstacle;
    [SerializeField] string obstacleBaseName;
    [SerializeField] int objectId;
    readonly bool[,] spawn = new bool[10, 10];
    [MenuItem("My Tools/ObstacleManager")]

    public static void ShowWindow()
    {
        GetWindow(typeof(ObstacleSpawner));
    }

    private void OnGUI()
    {

        GUILayout.Label("Choose obstacle to be spawned", EditorStyles.boldLabel);

        obstacle = EditorGUILayout.ObjectField("Obstacle", obstacle, typeof(GameObject), false) as GameObject;

        GUILayout.Label("Select the position (10x10) Grid Respectively", EditorStyles.boldLabel);

        for (int j = 9; j >= 0; j--)
        {
            GUILayout.BeginHorizontal();

            for (int i = 0; i <= 9; i++)
                spawn[i, j] = EditorGUILayout.Toggle(spawn[i, j]);
        
            GUILayout.EndHorizontal();
        }

        //------------------------------------------------------------//
        //'for' loop' for  functioning of toogle button isn't used as if any of the button is toggle on each toggle button will be toggle on automatically
        //------------------------------------------------------------//

        // Button to spawn the object 
        if (GUILayout.Button("Spawn"))
        {
            // 1st Column
            if (spawn[0, 0])
            {
                Vector3 spawnPos = new(1, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }


            if (spawn[1, 0])
            {
                Vector3 spawnPos = new(3, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 0])
            {
                Vector3 spawnPos = new(5, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 0])
            {
                Vector3 spawnPos = new(7, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 0])
            {
                Vector3 spawnPos = new(9, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 0])
            {
                Vector3 spawnPos = new(11, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 0])
            {
                Vector3 spawnPos = new(13, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 0])
            {
                Vector3 spawnPos = new(15, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 0])
            {
                Vector3 spawnPos = new(17, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 0])
            {
                Vector3 spawnPos = new(19, 2, 1);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 2nd Column
            if (spawn[0, 1])
            {
                Vector3 spawnPos = new(1, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 1])
            {
                Vector3 spawnPos = new(3, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 1])
            {
                Vector3 spawnPos = new(5, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 1])
            {
                Vector3 spawnPos = new(7, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 1])
            {
                Vector3 spawnPos = new(9, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 1])
            {
                Vector3 spawnPos = new(11, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 1])
            {
                Vector3 spawnPos = new(13, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 1])
            {
                Vector3 spawnPos = new(15, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 1])
            {
                Vector3 spawnPos = new(17, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 1])
            {
                Vector3 spawnPos = new(19, 2, 3);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 3rd Column
            if (spawn[0, 2])
            {
                Vector3 spawnPos = new(1, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 2])
            {
                Vector3 spawnPos = new(3, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 2])
            {
                Vector3 spawnPos = new(5, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 2])
            {
                Vector3 spawnPos = new(7, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 2])
            {
                Vector3 spawnPos = new(9, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 2])
            {
                Vector3 spawnPos = new(11, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 2])
            {
                Vector3 spawnPos = new(13, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 2])
            {
                Vector3 spawnPos = new(15, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 2])
            {
                Vector3 spawnPos = new(17, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 2])
            {
                Vector3 spawnPos = new(19, 2, 5);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 4th Column
            if (spawn[0, 3])
            {
                Vector3 spawnPos = new(1, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 3])
            {
                Vector3 spawnPos = new(3, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 3])
            {
                Vector3 spawnPos = new(5, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 3])
            {
                Vector3 spawnPos = new(7, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 3])
            {
                Vector3 spawnPos = new(9, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 3])
            {
                Vector3 spawnPos = new(11, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 3])
            {
                Vector3 spawnPos = new(13, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 3])
            {
                Vector3 spawnPos = new(15, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 3])
            {
                Vector3 spawnPos = new(17, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 3])
            {
                Vector3 spawnPos = new(19, 2, 7);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 5th column
            if (spawn[0, 4])
            {
                Vector3 spawnPos = new(1, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 4])
            {
                Vector3 spawnPos = new(3, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 4])
            {
                Vector3 spawnPos = new(5, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 4])
            {
                Vector3 spawnPos = new(7, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 4])
            {
                Vector3 spawnPos = new(9, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 4])
            {
                Vector3 spawnPos = new(11, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 4])
            {
                Vector3 spawnPos = new(13, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 4])
            {
                Vector3 spawnPos = new(15, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 4])
            {
                Vector3 spawnPos = new(17, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 4])
            {
                Vector3 spawnPos = new(19, 2, 9);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 6th Column
            if (spawn[0, 5])
            {
                Vector3 spawnPos = new(1, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 5])
            {
                Vector3 spawnPos = new(3, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 5])
            {
                Vector3 spawnPos = new(5, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 5])
            {
                Vector3 spawnPos = new(7, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 5])
            {
                Vector3 spawnPos = new(9, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 5])
            {
                Vector3 spawnPos = new(11, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 5])
            {
                Vector3 spawnPos = new(13, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 5])
            {
                Vector3 spawnPos = new(15, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 5])
            {
                Vector3 spawnPos = new(17, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 5])
            {
                Vector3 spawnPos = new(19, 2, 11);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 7th Column
            if (spawn[0, 6])
            {
                Vector3 spawnPos = new(1, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 6])
            {
                Vector3 spawnPos = new(3, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 6])
            {
                Vector3 spawnPos = new(5, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 6])
            {
                Vector3 spawnPos = new(7, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 6])
            {
                Vector3 spawnPos = new(9, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 6])
            {
                Vector3 spawnPos = new(11, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 6])
            {
                Vector3 spawnPos = new(13, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 6])
            {
                Vector3 spawnPos = new(15, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 6])
            {
                Vector3 spawnPos = new(17, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 6])
            {
                Vector3 spawnPos = new(19, 2, 13);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 8th Column
            if (spawn[0, 7])
            {
                Vector3 spawnPos = new(1, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 7])
            {
                Vector3 spawnPos = new(3, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 7])
            {
                Vector3 spawnPos = new(5, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 7])
            {
                Vector3 spawnPos = new(7, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 7])
            {
                Vector3 spawnPos = new(9, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 7])
            {
                Vector3 spawnPos = new(11, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 7])
            {
                Vector3 spawnPos = new(13, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 7])
            {
                Vector3 spawnPos = new(15, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 7])
            {
                Vector3 spawnPos = new(17, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 7])
            {
                Vector3 spawnPos = new(19, 2, 15);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 9th Column
            if (spawn[0, 8])
            {
                Vector3 spawnPos = new(1, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 8])
            {
                Vector3 spawnPos = new(3, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 8])
            {
                Vector3 spawnPos = new(5, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 8])
            {
                Vector3 spawnPos = new(7, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 8])
            {
                Vector3 spawnPos = new(9, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 8])
            {
                Vector3 spawnPos = new(11, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 8])
            {
                Vector3 spawnPos = new(13, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 8])
            {
                Vector3 spawnPos = new(15, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 8])
            {
                Vector3 spawnPos = new(17, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 8])
            {
                Vector3 spawnPos = new(19, 2, 17);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            // 10th Column
            if (spawn[0, 9])
            {
                Vector3 spawnPos = new(1, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[1, 9])
            {
                Vector3 spawnPos = new(3, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[2, 9])
            {
                Vector3 spawnPos = new(5, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[3, 9])
            {
                Vector3 spawnPos = new(7, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[4, 9])
            {
                Vector3 spawnPos = new(9, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[5, 9])
            {
                Vector3 spawnPos = new(11, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[6, 9])
            {
                Vector3 spawnPos = new(13, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[7, 9])
            {
                Vector3 spawnPos = new(15, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[8, 9])
            {
                Vector3 spawnPos = new(17, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);
            }

            if (spawn[9, 9])
            {
                Vector3 spawnPos = new(19, 2, 19);
                Instantiate(obstacle, spawnPos, Quaternion.identity);

            }
        }
    }
}

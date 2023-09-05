using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject lastCube;
    
    private GameObject newCube;
    private int cubeDirection;
    private Vector3 firstSpawnPos;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateCube();
        }
        InvokeRepeating(nameof(CreateCube),0,1f);
    }

    private void CreateCube()
    {
        cubeDirection = Random.Range(0, 2);
        if (cubeDirection == 0)
        {
            newCube = Instantiate(cubePrefab, new Vector3(lastCube.transform.position.x - 1, lastCube.transform.position.y, lastCube.transform.position.z),Quaternion.identity);
            lastCube = newCube;
        }
        else
        {
         newCube = Instantiate(cubePrefab, new Vector3(lastCube.transform.position.x, lastCube.transform.position.y, lastCube.transform.position.z + 1),
                quaternion.identity);
         lastCube = newCube;
        }
    }
}

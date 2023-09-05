using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject lastCube;
    [SerializeField] CubeDetector cubeDetector;
    
    private GameObject newCube;
    private int cubeDirection;
    private Vector3 firstSpawnPos;
    private void Start()
    {
        GenerateCube();
        InvokeRepeating(nameof(CreateNewCube),0,1f);
    }

    private void Update()
    {
        cubeDetector.transform.position = lastCube.transform.position;
    }

    private void GenerateCube()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateNewCube();
        }
    }

    private void CreateNewCube()
    {
        cubeDirection = Random.Range(0, 2);
        if (cubeDirection == 0 && !cubeDetector.XBounded)
        {
            SpawnCubeToX();
        }
        else
        {
            if(cubeDetector.ZBounded && !cubeDetector.ZBounded)
                SpawnCubeToX();
            SpawnCubeToZ();
        }
    }

    private void SpawnCubeToX()
    {
        newCube = Instantiate(cubePrefab, new Vector3(lastCube.transform.position.x - 1, lastCube.transform.position.y, lastCube.transform.position.z),Quaternion.identity);
        lastCube = newCube;
    }

    private void SpawnCubeToZ()
    {
        newCube = Instantiate(cubePrefab, new Vector3(lastCube.transform.position.x, lastCube.transform.position.y, lastCube.transform.position.z + 1),
            quaternion.identity);
        lastCube = newCube;
    }
}

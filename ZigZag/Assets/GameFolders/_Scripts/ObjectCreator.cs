using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject lastCube;
    [SerializeField] CubeDetector cubeDetector;

    [SerializeField] float cubeSpawnRate;
    
    private GameObject newCube;
    private int cubeDirection;
    private int cubeCount;
    private Vector3 firstSpawnPos;
    private void Start()
    {
        GenerateCube();
        InvokeRepeating(nameof(CreateNewCube),0,cubeSpawnRate);
    }

    private void Update()
    {
        cubeDetector.transform.position = newCube.transform.position;
    }

    private void GenerateCube()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateNewCube();
        }
    }

    private void CreateNewCube()
    {
        if(cubeCount >= 40f) return;
        
        cubeDirection = Random.Range(0, 2);
        if (!cubeDetector.XBounded && !cubeDetector.ZBounded)
        {
            if(cubeDirection == 0)
                SpawnCubeToX();
            else
                SpawnCubeToZ();
        }
        else if (cubeDetector.XBounded)
        {
            SpawnCubeToZ();
            cubeDetector.XBounded = false;
        }
        else if (cubeDetector.ZBounded)
        {
            SpawnCubeToX();
            cubeDetector.ZBounded = false;
        }
    }

    private void SpawnCubeToX()
    {
        newCube = Instantiate(cubePrefab,
            new Vector3(lastCube.transform.position.x - 1, lastCube.transform.position.y,
                lastCube.transform.position.z), Quaternion.identity);
        lastCube = newCube;
        cubeCount++;
    }

    private void SpawnCubeToZ()
    {

        newCube = Instantiate(cubePrefab,
            new Vector3(lastCube.transform.position.x, lastCube.transform.position.y,
                lastCube.transform.position.z + 1),
            quaternion.identity);
        lastCube = newCube;
        cubeCount++;
    }
}

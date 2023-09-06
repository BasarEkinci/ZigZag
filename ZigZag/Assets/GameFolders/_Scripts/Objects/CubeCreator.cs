using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeCreator : MonoBehaviour
{
    #region Variables

    #region SerializedFields

    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject lastCube;
    [SerializeField] GameObject diamond;
    [SerializeField] CubeDetector cubeDetector;
    [SerializeField] float cubeSpawnRate;

    #endregion

    #region Private Variables

    private GameObject newCube;
    private int cubeDirection;
    private Vector3 firstSpawnPos;

    #endregion

    #endregion
    
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
        for (int i = 0; i < 1; i++)
        {
            CreateNewCube();
        }
    }

    private void CreateNewCube()
    {
        if(GameManager.Instance.CubeCount >= 40f || GameManager.Instance.IsGameOver) return;
        
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
        SpawnDiamond();
        GameManager.Instance.CubeCount++;
    }

    private void SpawnCubeToZ()
    {

        newCube = Instantiate(cubePrefab,
            new Vector3(lastCube.transform.position.x, lastCube.transform.position.y,
                lastCube.transform.position.z + 1),
            Quaternion.identity);
        lastCube = newCube;
        SpawnDiamond();
        GameManager.Instance.CubeCount++;
    }

    private void SpawnDiamond()
    {
        Vector3 spanwPos = new Vector3(newCube.transform.position.x, newCube.transform.position.y + 0.8f,
            newCube.transform.position.z);
        int chance = Random.Range(0, 8);
        if (chance < 3)
        {
            Instantiate(diamond, spanwPos,Quaternion.identity);
        }
    }
}

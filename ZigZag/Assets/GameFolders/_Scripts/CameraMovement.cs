using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed;

    void LateUpdate()
    {
        if(GameManager.Instance.IsGameOver || !GameManager.Instance.IsGameStarted) return;
        
        transform.position += new Vector3(-speed, 0, speed) * Time.deltaTime;
    }
}

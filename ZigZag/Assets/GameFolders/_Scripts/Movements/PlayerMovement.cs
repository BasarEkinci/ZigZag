using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;
    Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        direction = Vector3.forward;
        speed = 5;
    }

    private void Update()
    {
        if (transform.position.y < 0.749f)
        {
            GameManager.Instance.IsGameOver = true;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        Debug.Log("\nx: " + rb.velocity.x.ToString("0") + " y: " + rb.velocity.y.ToString("0"));
        PlayerMover();
    }

    private void ChangeDirection()
    {
        if(GameManager.Instance.IsGameOver) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.PlayOneShot(1);
            if (direction == Vector3.forward)
                direction = Vector3.left;
            else
                direction = Vector3.forward;
            GameManager.Instance.Score++;
        }
    }

    private void PlayerMover()
    {
        if (!GameManager.Instance.IsGameStarted) return;
        ChangeDirection();
        transform.position += direction * (speed * Time.deltaTime);
    }
}

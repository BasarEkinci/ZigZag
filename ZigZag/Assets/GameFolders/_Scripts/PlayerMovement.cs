using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody rigidbody;
    Vector3 direction;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        direction = Vector3.forward;
    }

    private void Update()
    {
        if (transform.position.y < 0.75f)
            GameManager.Instance.IsGameOver = true;
        PlayerMover();
    }

    private void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (direction == Vector3.forward)
                direction = Vector3.left;
            else
                direction = Vector3.forward;
            GameManager.Instance.Score++;
        }
    }

    private void PlayerMover()
    {
        if (GameManager.Instance.IsGameOver) return;
        
        ChangeDirection();
        transform.position += direction * (speed * Time.deltaTime);
    }
}

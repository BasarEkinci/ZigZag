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
        }
    }

    private void PlayerMover()
    {
        ChangeDirection();
        transform.position += direction * (speed * Time.deltaTime);
    }
}

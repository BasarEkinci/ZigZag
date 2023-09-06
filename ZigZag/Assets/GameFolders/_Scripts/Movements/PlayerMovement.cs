using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;

    Vector3 direction;
    private void Start()
    {
        direction = Vector3.forward;
        speed = 5;
    }

    private void Update()
    {
        if (transform.position.y < 0.75f)
            GameManager.Instance.IsGameOver = true;
        PlayerMover();
        Debug.Log("Speed: " + speed);
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
        if (GameManager.Instance.Score / 60 == 1)
            speed += 0.1f * Time.deltaTime;
        transform.position += direction * (speed * Time.deltaTime);
    }
}

using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5.5f;
    private Vector3 direction;
    private void Start() 
    {
        direction = Vector3.forward;
    }
    private void Update()
    {
        if (transform.position.y <= 0.74f)
            GameManager.Instance.IsGameOver = true;

        PlayerMover();
    }
    private void ChangeDirection()
    {
        if(GameManager.Instance.IsGameOver) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.Score++;
            SoundManager.Instance.PlayOneShot(1);
            if (direction == Vector3.forward)
                direction = Vector3.left;
            else
                direction = Vector3.forward;
        }
    }
    private void PlayerMover()
    {
        if (!GameManager.Instance.IsGameStarted) return;
        ChangeDirection();
        transform.position += direction * (speed * Time.deltaTime);
    }
}
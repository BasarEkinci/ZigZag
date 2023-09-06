using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Rigidbody rb;

    private void Update()
    {
        if(transform.position.y <= -7f)
            Destroy(gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }
}

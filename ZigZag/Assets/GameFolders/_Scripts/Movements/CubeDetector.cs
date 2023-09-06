using System;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    public bool XBounded { get;  set; }
    public bool ZBounded { get;  set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("xBound"))
        {
            Debug.Log("xBounded");
            XBounded = true;
        }else if (other.gameObject.CompareTag("zBound"))
        {
            Debug.Log("zBounded");
            ZBounded = true;
        }
    }
}

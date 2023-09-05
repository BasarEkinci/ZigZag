using System;
using UnityEngine;

public class CubeDetector : MonoBehaviour
{
    public bool XBounded { get; private set; }
    public bool ZBounded { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("xBound"))
        {
            XBounded = true;
            ZBounded = false;
        }else if (other.CompareTag("zBound"))
        {
            ZBounded = true;
            XBounded = false;
        }
    }
}

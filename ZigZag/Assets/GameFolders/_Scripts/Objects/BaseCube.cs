using System;
using UnityEngine;
using DG.Tweening;


public class BaseCube : MonoBehaviour
{
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.DOMoveY(-4, 1f);
        }
    }

}

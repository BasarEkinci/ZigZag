using System;
using DG.Tweening;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] GameObject exposionEffext;
    private void Start()
    {
        transform.DOMoveY(transform.position.y + 0.2f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        transform.DORotate(Vector3.up * 10, 0.2f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Score++;
            SoundManager.Instance.PlayOneShot(0);
            Instantiate(exposionEffext, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
    }
}

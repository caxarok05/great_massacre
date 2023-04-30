using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    private Vector3 _bulletDirection;

    public void SetData(Vector3 bulletDirection)
    {
        _bulletDirection = bulletDirection;
    }

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        gameObject.transform.Translate(_bulletDirection * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}

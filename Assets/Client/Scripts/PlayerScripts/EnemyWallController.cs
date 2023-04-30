using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWallController : MonoBehaviour, IEnemyResist
{
    [SerializeField] private GameObject wallTrigger;
    [SerializeField] private GameObject _bulletPrefab;
    private GameObject bullet;
    private GameObject target;
    private GameObject looktarget;
    private bool IsResist = true;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player2");
        looktarget = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        transform.LookAt(looktarget.transform, Vector3.up);
    }

    private void OnMouseDown()
    {
        if (!IsResist)
        {
            bullet = Instantiate(_bulletPrefab, target.transform.position, Quaternion.identity);
            bullet.GetComponent<BulletScript>().SetData(gameObject.transform.position - target.transform.position);
        }

    }

    public void ChangeResistState()
    {
        IsResist = false;
    }
    private void OnDestroy()
    {
        wallTrigger.GetComponent<IEnemyDeadCounter>().CountDead();
    }
}

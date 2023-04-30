using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WallBehaviour : MonoBehaviour, IEnemyDeadCounter
{

    [SerializeField] private List<GameObject> _enemyList;
    private int _deadCounter = 0;

    [SerializeField] private GameObject _wallPlayerPos;
    [SerializeField] private GameObject _wallPlayerBackPos;

    private GameObject _player;

    private void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_deadCounter >= 3)
        {
            KillAllEnemies();
            _deadCounter = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _enemyList.Count; i++)
            {
                _enemyList[i].GetComponent<IEnemyResist>().ChangeResistState();
            }
            RoadMoveScript._speed = 0;
            other.gameObject.GetComponent<IWallHiden>().HideBehindWall(_wallPlayerPos.transform, true);
        }
    }


    private void KillAllEnemies()
    {
        
        _player.GetComponent<IWallGoBack>().GoBack(_wallPlayerBackPos.transform);
    }

    public void CountDead()
    {
        _deadCounter++;
    }
}

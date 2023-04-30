using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnerScript : MonoBehaviour, ISpawner
{
    [SerializeField] private List<GameObject> _roadList;
    [SerializeField] private GameObject _wallRoad;
    [SerializeField] private float _roadLength;
    private GameObject _road;
    private int _wallCounter = 0;

    private void Start()
    {
        _road = Instantiate(_roadList[Random.Range(0, _roadList.Count - 1)], transform.position, Quaternion.identity);
    }

    public void Spawn()
    {
        _wallCounter++;
        Vector3 position = new Vector3(0, 0, _road.transform.position.z + _roadLength);
        if (_wallCounter >= 2)
        {
            _road = Instantiate(_wallRoad, position, Quaternion.identity);
            _wallCounter = 0;
        }
        else
        {
            _road = Instantiate(_roadList[Random.Range(0, _roadList.Count - 1)], position, Quaternion.identity);
        }
        

    }
}

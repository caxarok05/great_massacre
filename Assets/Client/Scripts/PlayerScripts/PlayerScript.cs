using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IWallHiden, IWallGoBack
{
    [SerializeField] private GameObject _cinemachineCameraBased;
    [SerializeField] private GameObject _cinemachineCameraWall;
    [SerializeField] private GameObject spawner;

    private Transform _point;
    private Transform _backPoint;

    private bool IsHide = false;
    private bool IsGoBack = false;
    private void FixedUpdate()
    {   
        if (IsGoBack)
        {
            Debug.Log(IsGoBack);
            _cinemachineCameraWall.SetActive(false);
            _cinemachineCameraBased.SetActive(true);

            gameObject.transform.position = Vector3.MoveTowards(transform.position, _backPoint.position, Time.deltaTime * 10f);
            gameObject.transform.LookAt(_backPoint.position);

            if (gameObject.transform.position.x == _backPoint.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                RoadMoveScript._speed = 10;
                IsGoBack = false;
            }
            IsHide = false;
        }

        if (IsHide)
        {
            _cinemachineCameraWall.SetActive(true);
            _cinemachineCameraBased.SetActive(false);

            gameObject.transform.position = Vector3.MoveTowards(transform.position, _point.position, Time.deltaTime * 8f);
            gameObject.transform.LookAt(_point.position);
            if (gameObject.transform.position.x == _point.position.x)
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                IsHide = false;

            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerWall"))
        {
            spawner.GetComponent<ISpawner>().Spawn();
        }
    }
    public void HideBehindWall(Transform point, bool istrue)
    {
        _point = point;
        IsHide = istrue;
    }

    public void GoBack(Transform backPos)
    {

        _backPoint = backPos;
        IsGoBack = true;
    }
}

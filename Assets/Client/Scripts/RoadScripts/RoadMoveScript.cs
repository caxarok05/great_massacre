using UnityEngine;

public class RoadMoveScript : MonoBehaviour
{
    public static float _speed = 10;
    [SerializeField] private float _destroyPoint;
    private void Update()
    {
        gameObject.transform.Translate(Vector3.back * _speed * Time.deltaTime);
        if (gameObject.transform.position.z < _destroyPoint)
        {
            Destroy(gameObject);
        }
    }
}

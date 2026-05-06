using UnityEngine;
using Zenject;

public class UnitFactory : MonoBehaviour
{
    [Inject]
    public void Construct(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
    public class Factory : PlaceholderFactory<Vector3, Quaternion, UnitFactory>
    {
    }
}

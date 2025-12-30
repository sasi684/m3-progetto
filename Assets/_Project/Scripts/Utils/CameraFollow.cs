using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void LateUpdate()
    {
        if (target)
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}

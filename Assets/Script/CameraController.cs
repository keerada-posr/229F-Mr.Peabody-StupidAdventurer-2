using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform bot;
    public float smoothSpeed = 5f;

    private Transform target;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

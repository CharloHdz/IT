using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public GameObject playerObject;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 playerPos = playerObject.transform.position;
        Vector3 screenPos = cam.WorldToScreenPoint(playerPos);

        Vector3 targetPos = transform.position;
        if (screenPos.x < Screen.width / 2f)
        {
            targetPos.x = Mathf.SmoothDamp(transform.position.x, playerPos.x - offset.x, ref velocity.x, smoothTime);
        }
        else if (screenPos.x > Screen.width / 2f)
        {
            targetPos.x = Mathf.SmoothDamp(transform.position.x, playerPos.x + offset.x, ref velocity.x, smoothTime);
        }

        if (screenPos.y < Screen.height / 2f)
        {
            targetPos.y = Mathf.SmoothDamp(transform.position.y, playerPos.y - offset.y, ref velocity.y, smoothTime);
        }
        else if (screenPos.y > Screen.height / 2f)
        {
            targetPos.y = Mathf.SmoothDamp(transform.position.y, playerPos.y + offset.y, ref velocity.y, smoothTime);
        }

        if (screenPos.z < 0)
        {
            targetPos.z = Mathf.SmoothDamp(transform.position.z, playerPos.z - offset.z, ref velocity.z, smoothTime);
        }
        else if (screenPos.z > 0)
        {
            targetPos.z = Mathf.SmoothDamp(transform.position.z, playerPos.z + offset.z, ref velocity.z, smoothTime);
        }

        transform.position = targetPos;
    }
}



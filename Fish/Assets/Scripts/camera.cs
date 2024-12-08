using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform followTransform;
    public float followSpeed = 3f;
    public float offset = -1f;

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(followTransform.position.x, followTransform.position.y + offset, -10f);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

    }
}

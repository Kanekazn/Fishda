using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameMovement : MonoBehaviour
{
    private float vertical;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    [Header("Movement Range")]
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(0, vertical * speed);

        //float clampedY = Mathf.Clamp(rb.position.y, minY, maxY);
        //rb.position = new Vector2(rb.position.x, clampedY);
    }
}

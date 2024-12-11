using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObstacle : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if (transform.position.x < -15)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            
        }
    }
}

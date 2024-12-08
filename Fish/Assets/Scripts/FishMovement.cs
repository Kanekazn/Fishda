using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    private Transform endLocation;
    private float speed = 3f; // Set speed of fish movement
    private bool isMoving = true; // Flag to track if fish is moving

    // Set the destination for fish
    public void SetEndLocation(Transform targetLocation)
    {
        endLocation = targetLocation;
    }

    // Move the fish towards the destination
    public void MoveFishToTarget()
    {
        if (endLocation == null)
        {
            Debug.LogError("End location is not set for the fish.");
            return;
        }

        StartCoroutine(MoveToTargetCoroutine());
    }

    private IEnumerator MoveToTargetCoroutine()
    {
        // Check if we are still moving towards the target
        while (Vector3.Distance(transform.position, endLocation.position) > 0.1f)
        {
            if (isMoving) // Only move if isMoving is true
            {
                Vector3 direction = (endLocation.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;

                // Flip the fish direction based on its destination
                if (endLocation.position.x > transform.position.x)
                    FlipRight();
                else
                    FlipLeft();
            }

            yield return null; // Wait until the next frame
        }

        // Once the fish reaches the target, destroy it
        Destroy(gameObject);
    }

    // Method to stop the fish for a certain duration
    public void StopFish(float duration)
    {
        isMoving = false; // Stop the fish
        StartCoroutine(RestartMovement(duration)); // Restart movement after the delay
    }

    // Coroutine to resume movement after a delay
    private IEnumerator RestartMovement(float duration)
    {
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        isMoving = true; // Resume movement
    }

    // Flip fish to the left
    private void FlipLeft()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Flip fish to the right
    private void FlipRight()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Detect collision with the hook
    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook")) // Ensure the hook has the correct tag
        {
            StopFish(5f); // Stop fish for 5 seconds when it collides with the hook
        }
    }
}

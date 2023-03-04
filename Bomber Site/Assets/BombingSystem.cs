using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombingSystem : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] GameObject bomb;

    [SerializeField] float speed;

    public Vector3 targetPosition;
    private void Start()
    {

    }

    private void Update()
    {
        SpawnAtMouse();
    }

    private void SpawnAtMouse()
    {
        // Set bombing position then spawn bomber plane
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            Instantiate(plane, transform.position, Quaternion.identity);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            SpawnBomb(targetPosition);
        }
    }

    public void SpawnBomb(Vector3 spawnPosition)
    {
        float detectionRadius = 5f;
        // Spawn the game object at the calculated position
        GameObject newObject = Instantiate(bomb, spawnPosition, Quaternion.identity);

        // Check for other objects within the detection radius of the new object
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newObject.transform.position, detectionRadius);

        foreach (Collider2D collider in colliders)
        {
            // Do something with the colliding object(s)
            Debug.Log("Detected object: " + collider.gameObject.name);
            if (collider.gameObject.name.Equals("Enemy"))
            {
                Destroy(collider.gameObject);
            }
        }

        Destroy(newObject.gameObject, 5f);
    }

}

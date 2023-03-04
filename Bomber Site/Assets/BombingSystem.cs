using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombingSystem : MonoBehaviour
{
    [SerializeField] GameObject plane;

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
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            Debug.Log(targetPosition);
            Instantiate(plane, transform.position, Quaternion.identity);
        }
    }
}

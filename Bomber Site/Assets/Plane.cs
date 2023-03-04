using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField] Vector3 target;

    [SerializeField] BombingSystem mission;

    GameObject gameManager;

    float distance;

    bool isMissionSuccess = false;


    void Start()
    {
        // Get bombing position from gameManager & set up plane
        gameManager = GameObject.Find("GameManager");
        mission = gameManager.GetComponent<BombingSystem>();
        target = mission.targetPosition;
        transform.up = target - transform.position;
    }

    void Update()
    {
        // Move plane toward target
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        distance = Vector3.Distance(transform.position, target);

        if (distance <= 1 && !isMissionSuccess)
        {
            isMissionSuccess = true;
            mission.SpawnBomb(transform.position);
        }

    }
}

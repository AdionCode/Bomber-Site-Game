using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField] Vector3 target;

    [SerializeField] BombingSystem mission;

    GameObject gameManager;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        mission = gameManager.GetComponent<BombingSystem>();
        Debug.Log(mission.targetPosition);
        target = mission.targetPosition;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.up = target - transform.position;
    }
}

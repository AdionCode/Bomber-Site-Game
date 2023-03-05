using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    Vector2 wayPoint;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    bool isIdle = false;

    void Start()
    {
        setNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            if (Random.Range(0, 1) == 1 && !isIdle)
            {
                setNewDestination();
            }
            else
            {
                setIdleState();
            }
        }
    }

    private void setIdleState()
    {
        isIdle = true;

    }

    private void setNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-minDistance, minDistance));
    }
}

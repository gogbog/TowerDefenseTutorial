using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.points[wavepointIndex];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetTheNexTPoint();
        }
    }

    private void GetTheNexTPoint()
    {
        wavepointIndex++;

        if (wavepointIndex >= Waypoints.points.Length)
        {
            Destroy(gameObject);
            return;
        }

        target = Waypoints.points[wavepointIndex];
    }
}

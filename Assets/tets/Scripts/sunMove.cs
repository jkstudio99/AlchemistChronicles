using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunMove : MonoBehaviour
{
    public float speed;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("sunControll").GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        if (Vector2.Distance (transform.position, target.position) > 1)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
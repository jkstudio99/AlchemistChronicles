using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawControll : MonoBehaviour
{
    public Transform pointLeft, pointRight;
    public float speed;

    private void Start()
    {
        gameObject.transform.position = new Vector3(pointLeft.position.x, pointLeft.position.y, pointLeft.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointLeft.position, speed * Time.deltaTime);
        if (transform.position == pointLeft.position)
        {
            Transform t = pointLeft;
            pointLeft = pointRight;
            pointRight = t;
        }
    }
}

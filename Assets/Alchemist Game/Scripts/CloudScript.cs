using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float cloudSpeed = 1.6f;
    private float EngPositionX;

    public void StartFloating (float speed, float endPosX)
    {
        cloudSpeed = speed;
        EngPositionX = endPosX;
    }
    void Update()
    {
        //Cloud movement
        transform.Translate(Vector3.right * (Time.deltaTime * cloudSpeed));
        //Position check
        if (transform.position.x > EngPositionX)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRunFX : MonoBehaviour
{
    public float setback = 0f;

    //Removing an effect (Run and jump FX)
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + setback);
    }
}
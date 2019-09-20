using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRotation : MonoBehaviour
{
    public Transform platfromSpin;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        platfromSpin.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    protected Renderer meshRenderer; 
    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            meshRenderer.material.color = other.gameObject.GetComponent<Renderer>().material.color;
            print("World Color" + other.gameObject.GetComponent<Renderer>().material.color);
        }
    } 
}

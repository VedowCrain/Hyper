using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Material playerMat;
    public float thrust;
    public float jumpthrust;
    public float Timer = 1f;
    public KeyCode left;
    public KeyCode right;
    public KeyCode Jump;

    void Start()
    {
        playerMat.color = Color.white;
    }

    public void Update()
    {
        if (Timer !=0)
        {
            Timer -= 0.5f * Time.deltaTime;
        }
        else
        {
            Timer = 0f;
        }

        if (Input.GetKey(left))
        {
            print("Left");
            rb.AddForce(Vector3.left * thrust);
        }

        if (Input.GetKey(right))
        {
            print("Right");
            rb.AddForce(Vector3.right * thrust);
        }

        if (Input.GetKeyDown(Jump) && Timer <= 0)
        {
            rb.AddForce(Vector3.up * jumpthrust, ForceMode.Impulse);
            Timer = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerMat.color = other.gameObject.GetComponent<Renderer>().material.color;
        }
    }
}

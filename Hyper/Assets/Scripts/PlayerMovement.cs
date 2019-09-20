using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Es.InkPainter.Sample;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Material playerMat;
    public float thrust;
    public float jumpthrust;
    public float Timer = 1f;
    public KeyCode left;
    public KeyCode right;

    public Renderer meshRenderer;
    public CollisionPainter painter;

    void Start()
    {
        // meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.color = Color.white;
    }

    public void Update()
    {
        if (GameMannger.gameState != GameState.Playing) return;

        if (Timer != 0)
        {
            Timer -= 0.5f * Time.deltaTime;
        }
        else
        {
            Timer = 0f;
        }

        /* if (Input.GetKey(left))
         {
             print("Left");
             rb.AddForce(Vector3.left * thrust);
         }

         if (Input.GetKey(right))
         {
             print("Right");
             rb.AddForce(Vector3.right * thrust);
         }*/

        if (Input.GetButtonDown("Jump") && Timer <= 0)
        {
            rb.AddForce(Vector3.up * jumpthrust, ForceMode.Impulse);
            Timer = 0.5f;
        }

        var x = Input.GetAxisRaw("Horizontal") * thrust;
        rb.AddForce(new Vector3(x, 0, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Color c = other.gameObject.GetComponent<Renderer>().material.color;
            meshRenderer.material.color = c;
            meshRenderer.material.SetColor("_EmissionColor", c);

            painter.brush.Color = other.gameObject.GetComponent<Renderer>().material.color;
            print("Ball Color" + other.gameObject.GetComponent<Renderer>().material.color);
        }
    }
}

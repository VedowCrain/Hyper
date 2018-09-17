using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        print ("ping");

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.GetComponent<Rigidbody>());
            FinalScore.Instance.Show();
            Time.timeScale = 0;
        }
        else if(other.gameObject.CompareTag("World"))
        {
            Destroy(this.gameObject);
        }
            
    }
}

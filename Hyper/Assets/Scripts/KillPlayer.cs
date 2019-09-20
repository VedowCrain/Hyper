using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public TrailRenderer trail;
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
            FinalScore.Instance.Show();
            GameMannger.gameState = GameState.GameOver;
        }
        else if(other.gameObject.CompareTag("World"))
        {
            Destroy(this.gameObject);
        }
            
    }
}

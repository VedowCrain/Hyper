using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{

    public Color TriColor;
    public Material TriMat;
    public float Timer;
    public float CurrentTime;
    public Rigidbody Bullet;

    private void Start()
    {
        TriMat.color = TriColor;
        CurrentTime = Timer;

        Timer = Random.Range(0.1f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Color " + TriColor);
            ScoreManager.Instance.Addscore();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        CurrentTime -= 0.1f * Time.deltaTime;

        if (CurrentTime <= 0)
        {
            Rigidbody clone;
            clone = Instantiate(Bullet, transform.position, transform.rotation) as Rigidbody;
            CurrentTime = Timer;
        }
    }
}

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

    protected Gradient gradient;
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
            print("Color Tri" + TriColor);
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
            KillPlayer kill = clone.GetComponent<KillPlayer>();
            if (kill != null)
            {
                kill.trail.startColor = TriColor;
                kill.trail.endColor = new Color(TriColor.r, TriColor.g, TriColor.b, 0f);

            }
            CurrentTime = Timer;
        }
    }
}

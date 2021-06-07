using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float lifeTimer;
    public float maxLife;
    public float speed;
    public Dispenser dispenser;
    private void Start()
    {
        dispenser = GameObject.FindGameObjectWithTag("Dispenser").GetComponent<Dispenser>();
        this.transform.parent = null;
    }
    private void Update()
    {
        transform.position += Vector3.down * speed;

        lifeTimer += Time.deltaTime;

        if(lifeTimer > maxLife)
        {
            Destroy(gameObject);
        }
    }
}

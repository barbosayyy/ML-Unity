using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    public bool atPos1;
    public bool atPos2;

    public float speed;
    private float Timer;
    public float deployTime;

    public List<GameObject> projectilePool = new List<GameObject>();
    public GameObject projectile;
    public Transform deployPoint;

   

    private void Start()
    {
        transform.position = pos1.transform.position;
        atPos1 = true;
        atPos2 = false;
    }
    private void Update()
    {
        if (atPos1)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos2.position, speed * Time.deltaTime);
            if (transform.position == pos2.position)
            {
                StartCoroutine(Switch1());
            }
            
        }
        if (atPos2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos1.position, speed * Time.deltaTime);
            if (transform.position == pos1.position)
            {
                StartCoroutine(Switch2());
            }
        }

        Timer += Time.deltaTime;
        if (Timer > deployTime)
        {
            StartCoroutine(Deploy());
        }

        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (projectilePool[i] == null)
            {
                projectilePool.Clear();
            }
        }
    }

    IEnumerator Switch1()
    {
        atPos1 = false;
        atPos2 = true;
        yield return new WaitForSeconds(1);
        yield break;
    }
    IEnumerator Switch2()
    {
        atPos1 = true;
        atPos2 = false;
        yield return new WaitForSeconds(1);
        yield break;
    }
    IEnumerator Deploy()
    {
        if(projectilePool.Count > 5)
        {
            yield break;
        }
        GameObject projectileGo;
        projectileGo = Instantiate(projectile, deployPoint);
        projectilePool.Add(projectileGo);
        Timer = 0;
        yield break;
    }
}


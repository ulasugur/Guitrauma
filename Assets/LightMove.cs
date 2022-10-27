using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    public float Left= 10;
    public float Right= -10;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(RandomMove());
    }

    private IEnumerator RandomMove()
    {
        while (true)
        {
            rb.velocity = transform.right * Left;
            yield return new WaitForSeconds(3f);
            rb.velocity = transform.right * Right;
            yield return new WaitForSeconds(3f);
        }
    }
}

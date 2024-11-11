using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_to_B_Object : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float speed = 1;
    private float sinTime;
    private Vector3 a, b, storage;
    
    private void Start()
    {
        a = transform.position;
        b = target.position;
    }
    private void Update()
    {
        sinTime += Time.deltaTime * speed;
        sinTime = Mathf.Clamp(sinTime, 0, Mathf.PI);
        float t = evaluate(sinTime);
        transform.position = Vector3.Lerp(a, b, t);
        if (transform.position == b)
        {
            storage = a;
            a = b;
            b = storage;
            sinTime = 0;
        }
        
        
        
        Debug.DrawLine(a, b);
    }
    public float evaluate(float x)
    {
        return 0.5f * Mathf.Sin(x - Mathf.PI / 2f) + 0.5f;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public float speed; // Скорость перемещения объекта

    private bool _go;
    public bool go { get { return _go; } set { _go = value; } }

    private bool _on;
    public bool on{ get { return _on; } set { _on = value; } }

    private bool _off;
    public bool off{ get { return _off; } set { _off = value; } }

    public Transform[] _points;


    private void Start()
    {
        
    }
    // Метод для передвижения объекта
    private void Update()
    {

        if (_go)
        {
           // gameObject.SetActive(true);
            Move(_points, speed);
           
        }
       


    }



    public void Move(Transform[] points, float speed)
    {
        StartCoroutine(MoveToPoint(points, speed));
    }

    private IEnumerator MoveToPoint(Transform[] points, float speed)
    {

        int currentPointIndex = 0;

        while (currentPointIndex < points.Length)
        {
            Transform currentPoint = points[currentPointIndex];
            float distanceToCurrentPoint = Vector3.Distance(transform.position, currentPoint.position);

            if (distanceToCurrentPoint <= 0.1f)
            {
                currentPointIndex++;
                if (currentPointIndex >= points.Length)
                {
                    yield break; // reached the last point, stop the coroutine
                }
                currentPoint = points[currentPointIndex];
            }

            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

            yield return null;
        }
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            _on = true;
        }
    }*/
}

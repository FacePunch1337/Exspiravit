using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{



    private GameObject observedObject;
   
    private Quaternion targetRotation;
    private Quaternion _lastRot;
    public Quaternion lastRot { get { return _lastRot; } set { _lastRot = value; } }

    private bool _look;

    public bool look
    {
        get { return _look; }
        set
        {
            _look = value;
        }
    }
    private bool _end;

    public bool end
    {
        get { return _end; }
        set
        {
            _end = value;
        }
    }

    void Start()
    {
       


    }

    private void Update()
    {
        _lastRot = transform.rotation;

        
            
        
        
        if (_look)
        {
            if (!GameObject.Find("Door"))
            {
                observedObject = GameObject.Find("ObservedSoul");
                
            }
            else
            {
                observedObject = GameObject.Find("Door");

            }
            LookTo();
           

        }
        
    }

    private void LookTo()
    {
       
        float rotationSpeed = 2f;
        Vector3 direction = observedObject.transform.position - transform.position;
        direction.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        

    }
    public void PlayAnim()
    {
       
        gameObject.GetComponent<FPcam>().enabled = false;
        _look = true;
        


    }

    public void StopAnim()
    {
        gameObject.GetComponent<FPcam>().enabled = true;
      
        _look = false;
        _end = true;
    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Application.Quit();
            Debug.Log("QUIT");
        }
    }
}

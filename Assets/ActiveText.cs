using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveText : MonoBehaviour
{
    public FadeText fadeText;
    private bool isInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;
            fadeText.SetTextActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            fadeText.SetTextActive(false);
        }
    }

    private void Update()
    {
        if (isInTrigger)
        {
            fadeText.UpdateTextAlpha(transform.position);
        }
    }
}

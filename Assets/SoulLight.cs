using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SoulLight : MonoBehaviour
{
    public Light lightPoint;
    public float targetIntensity = 500f;
    public float duration = 5f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / duration;
        float currentIntensity = Mathf.Lerp(0f, targetIntensity, progress);
        lightPoint.intensity = currentIntensity;

        if (progress >= 1f)
        {
            // Достигнута целевая интенсивность, можно остановить обновление
            enabled = false;
        }
    }


}

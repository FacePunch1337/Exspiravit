using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Скорость вращения
    public bool rotateClockwise = true; // Флаг для выбора вращения по часовой или наоборот

    // Обновление каждый кадр
    private void Update()
    {
        // Определяем направление вращения
        float direction = rotateClockwise ? 1f : -1f;

        // Поворачиваем шестерню вокруг оси Y на заданную скорость и направление
        transform.Rotate(Vector3.forward, direction * rotationSpeed * Time.deltaTime);
    }
}

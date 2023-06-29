using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    /*private Transform player;

    private void Update()
    {
        if (player == null)
        {
            // Если игрок не определен, попытайтесь найти его по тегу "Player"
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                return; // Выйти из метода, если игрок не найден
            }
        }

        // Направление, в котором должна быть повернута лицевая часть объекта
        Vector3 targetDirection = player.position - transform.position;
        targetDirection.y = 0; // Задаем нулевую высоту, чтобы объект не наклонялся

        if (targetDirection != Vector3.zero)
        {
            // Получаем новый поворот в направлении игрока
            Quaternion targetRotation = Quaternion.LookRotation(transform.TransformDirection(Vector3.right));

            // Плавно поворачиваем объект в сторону игрока
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }*/
}

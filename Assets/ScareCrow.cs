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
            // ���� ����� �� ���������, ����������� ����� ��� �� ���� "Player"
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
            else
            {
                return; // ����� �� ������, ���� ����� �� ������
            }
        }

        // �����������, � ������� ������ ���� ��������� ������� ����� �������
        Vector3 targetDirection = player.position - transform.position;
        targetDirection.y = 0; // ������ ������� ������, ����� ������ �� ����������

        if (targetDirection != Vector3.zero)
        {
            // �������� ����� ������� � ����������� ������
            Quaternion targetRotation = Quaternion.LookRotation(transform.TransformDirection(Vector3.right));

            // ������ ������������ ������ � ������� ������
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }*/
}

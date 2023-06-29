using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // �������� ��������
    public bool rotateClockwise = true; // ���� ��� ������ �������� �� ������� ��� ��������

    // ���������� ������ ����
    private void Update()
    {
        // ���������� ����������� ��������
        float direction = rotateClockwise ? 1f : -1f;

        // ������������ �������� ������ ��� Y �� �������� �������� � �����������
        transform.Rotate(Vector3.forward, direction * rotationSpeed * Time.deltaTime);
    }
}

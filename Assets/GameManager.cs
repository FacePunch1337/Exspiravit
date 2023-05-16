using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    


    private void Start()
    {
        SpawnPlayer();
        playerPrefab.TryGetComponent(out FadeCamera fadeCamera);
        fadeCamera.gameStart = true;




    }

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        

        // �������� ��������� ������ ������
        Camera playerCamera = playerPrefab.GetComponentInChildren<Camera>();

        // �������� �������� ������
        playerCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // �������� � ������� ��� Z
    }
}


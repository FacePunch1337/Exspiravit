using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
 
   


    private void Start()
    {
       
       

        if (spawnPoint != null)
        {
            SpawnPlayer();
            playerPrefab.TryGetComponent(out FadeCamera fadeCamera);
            fadeCamera.gameStart = true;
        }
        else spawnPoint = null;

       







    }
    private void Update()
    {
       
    }

   

    public void SpawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        

        // Получить компонент камеры игрока
        Camera playerCamera = playerPrefab.GetComponentInChildren<Camera>();

        // Изменить вращение камеры
        playerCamera.transform.rotation = Quaternion.Euler(90f, 0f, 0f); // Смотреть в сторону оси Z
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoToTexture : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Ссылка на компонент VideoPlayer
    public Material skyboxMaterial; // Ссылка на материал видео-скайбокса

    private RenderTexture renderTexture; // Создаем RenderTexture для текстуры скайбокса
    private void Start()
    {
        // Создаем новый RenderTexture с желаемым разрешением и форматом
        renderTexture = new RenderTexture(1920, 1080, 0, RenderTextureFormat.Default);

        // Присваиваем созданную текстуру RenderTexture в материал видео-скайбокса
        skyboxMaterial.SetTexture("_Tex", renderTexture);

        // Назначаем RenderTexture для VideoPlayer
        videoPlayer.targetTexture = renderTexture;

        // Загружаем и воспроизводим видео
        videoPlayer.url = "Assets/skybox/bgm1.mp4";
        videoPlayer.Play();
    }
}

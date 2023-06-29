using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoToTexture : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ������ �� ��������� VideoPlayer
    public Material skyboxMaterial; // ������ �� �������� �����-���������

    private RenderTexture renderTexture; // ������� RenderTexture ��� �������� ���������
    private void Start()
    {
        // ������� ����� RenderTexture � �������� ����������� � ��������
        renderTexture = new RenderTexture(1920, 1080, 0, RenderTextureFormat.Default);

        // ����������� ��������� �������� RenderTexture � �������� �����-���������
        skyboxMaterial.SetTexture("_Tex", renderTexture);

        // ��������� RenderTexture ��� VideoPlayer
        videoPlayer.targetTexture = renderTexture;

        // ��������� � ������������� �����
        videoPlayer.url = "Assets/skybox/bgm1.mp4";
        videoPlayer.Play();
    }
}

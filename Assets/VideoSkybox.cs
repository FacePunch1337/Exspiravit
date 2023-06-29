using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;

public class VideoSkybox : MonoBehaviour
{
    public Material skyboxMaterial;
    public string videoPath;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.isLooping = true;
        videoPlayer.renderMode = VideoRenderMode.APIOnly;

        RenderPipelineManager.beginCameraRendering += UpdateSkybox;
    }

    private void Start()
    {
        videoPlayer.url = videoPath;
        videoPlayer.Play();
    }

    private void OnDestroy()
    {
        RenderPipelineManager.beginCameraRendering -= UpdateSkybox;
    }

    private void UpdateSkybox(ScriptableRenderContext context, Camera camera)
    {
        if (camera.cameraType != CameraType.Game || camera.cameraType != CameraType.SceneView)
            return;

        if (skyboxMaterial != null && videoPlayer != null)
            skyboxMaterial.SetTexture("_BaseMap", videoPlayer.texture);
    }
}

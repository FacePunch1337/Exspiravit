using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtracks;
    private AudioSource musicSource;

    private void Start()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();
        PlaySceneSoundtrack();
    }

    private void PlaySceneSoundtrack()
    {
        string name = SceneManager.GetActiveScene().name;
        foreach (AudioClip soundtrack in soundtracks)
        {
            if (soundtrack.name.Contains(name))
            {
                musicSource.clip = soundtrack;
                musicSource.loop = true;
                musicSource.Play();

                return;
            }
        }
        Debug.LogWarning((object)("No soundtrack found for scene: " + name));
    }



    public void PlaySoundtrack(string name)
    {
        foreach (AudioClip soundtrack in soundtracks)
        {
            if (soundtrack.name.Contains(name))
            {
                musicSource.clip = soundtrack;
                musicSource.loop = true;
                musicSource.Play();
                return;
            }
        }
        Debug.LogWarning((object)("No soundtrack found for scene: " + name));
    }

    public void StopSoundtrack()
    {
        StartCoroutine(FadeOutMusic());
    }

    private IEnumerator FadeOutMusic()
    {
        float duration = 1f; // �����, �� ������� ����� ��������� ����
        float time = 0f; // ������� �����
        float startVolume = musicSource.volume; // ��������� ���������

        while (time < duration)
        {
            time += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, time / duration); // ������ ��������� ���������
            yield return null;
        }

        musicSource.Stop(); // ���������� ���������������
    }

}

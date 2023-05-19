using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public AudioClip[] soundtracks;
    private AudioSource musicSource;
    public float soundVolume;
    public float musicVolume;
    
    public Options options;

    private void Start()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();
        PlaySceneSoundtrack();
      

    }
    private void Update()
    {

        AudioSettings();

    }

    private void AudioSettings()
    {
        musicSource.volume = options.musicSliderValue;
        
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
        float duration = 1f; // время, за которое нужно затухнуть звук
        float time = 0f; // текущее время
        float startVolume = musicSource.volume; // начальная громкость

        while (time < duration)
        {
            time += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(startVolume, 0f, time / duration); // плавно уменьшаем громкость
            yield return null;
        }

        musicSource.Stop(); // остановить воспроизведение
    }

    

   
}

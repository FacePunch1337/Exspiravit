using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogSceneScript : MonoBehaviour
{
    public TMP_Text textComponent;
    public float interval = 1.0f; // Интервал между выводом строк в секундах
    public float fadeDuration = 0.5f; // Продолжительность затухания текста при переходе в секундах

    public string[] dialogueStrings; // Массив строк для диалога
    private int currentIndex = 0; // Текущий индекс строки диалога

    private IEnumerator displayCoroutine; // Корутина для отображения диалога

    private void Update()
    {
        textComponent.ForceMeshUpdate(); // Принудительное обновление меша текста
    }
    private void Start()
    {
       

        displayCoroutine = DisplayDialogue();
        StartCoroutine(displayCoroutine);
    }

    private IEnumerator DisplayDialogue()
    {
        while (currentIndex < dialogueStrings.Length)
        {

            // Затухание текста
            textComponent.CrossFadeAlpha(0.0f, fadeDuration, false);
            yield return new WaitForSeconds(fadeDuration);

            textComponent.text = dialogueStrings[currentIndex];

            // Проявление текста
            textComponent.CrossFadeAlpha(1.0f, fadeDuration, false);


            currentIndex++;
            yield return new WaitForSeconds(interval);

        }
        if(currentIndex == dialogueStrings.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

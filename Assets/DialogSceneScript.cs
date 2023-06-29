using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogSceneScript : MonoBehaviour
{
    public TMP_Text textComponent;
    public float interval = 1.0f; // �������� ����� ������� ����� � ��������
    public float fadeDuration = 0.5f; // ����������������� ��������� ������ ��� �������� � ��������

    public string[] dialogueStrings; // ������ ����� ��� �������
    private int currentIndex = 0; // ������� ������ ������ �������

    private IEnumerator displayCoroutine; // �������� ��� ����������� �������

    private void Update()
    {
        textComponent.ForceMeshUpdate(); // �������������� ���������� ���� ������
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

            // ��������� ������
            textComponent.CrossFadeAlpha(0.0f, fadeDuration, false);
            yield return new WaitForSeconds(fadeDuration);

            textComponent.text = dialogueStrings[currentIndex];

            // ���������� ������
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

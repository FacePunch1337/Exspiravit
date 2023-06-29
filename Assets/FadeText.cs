using TMPro;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    public GameObject[] textObjects;
    public string[] textStrings;

    private TMP_Text[] textComponents;
    private float targetAlpha = 0f; // Целевое значение альфа-канала
    private float fadeSpeed = 1f;

    private void Start()
    {
        InitializeTextComponents();
        SetTextActive(false);
    }

    private void InitializeTextComponents()
    {
        textComponents = new TMP_Text[textObjects.Length];
        for (int i = 0; i < textObjects.Length; i++)
        {
            TMP_Text textComponent = textObjects[i].GetComponentInChildren<TMP_Text>();
            if (textComponent != null)
            {
                textComponents[i] = textComponent;
                textComponent.alpha = 0f; // Изначально устанавливаем прозрачность в 0
            }
            else
            {
                Debug.LogWarning($"TMP_Text component not found on text object {textObjects[i].name}");
            }
        }
    }

    public void SetTextActive(bool isActive)
    {
        for (int i = 0; i < textComponents.Length; i++)
        {
            textComponents[i].gameObject.SetActive(isActive);
        }
    }

    public void UpdateTextAlpha(Vector3 playerPosition)
    {
        for (int i = 0; i < textComponents.Length; i++)
        {
            if (i < textStrings.Length)
            {
                float distance = Vector3.Distance(playerPosition, textComponents[i].transform.position);
                float alpha = 1f - (distance / 10f); // Масштабируйте значение 10f в соответствии с вашими требованиями
                alpha = Mathf.Clamp01(alpha);

                textComponents[i].text = textStrings[i]; // Присваиваем текст из массива textStrings
                textComponents[i].alpha = alpha; // Устанавливаем прозрачность
            }
        }
    }
}

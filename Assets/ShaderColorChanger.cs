using UnityEngine;

public class ShaderColorChanger : MonoBehaviour
{
    public Material material;
    public float changeSpeed = 1f;

    private float hue;

    private void Start()
    {
        // Получение изначального значения цвета из шейдера
        Color startColor = material.GetColor("_TintColor");
        hue = RGBtoHSV(startColor).x;
    }

    private void Update()
    {
        // Изменение значения цвета в цветовом круге
        hue += Time.deltaTime * changeSpeed;
        if (hue > 1f)
            hue -= 1f;

        // Преобразование значения цвета обратно в RGB и установка нового цвета в шейдер
        Color newColor = HSVtoRGB(new Vector3(hue, 1f, 1f));
        material.SetColor("_TintColor", newColor);
    }

    // Преобразование цвета из RGB в HSV
    private Vector3 RGBtoHSV(Color color)
    {
        float min = Mathf.Min(Mathf.Min(color.r, color.g), color.b);
        float max = Mathf.Max(Mathf.Max(color.r, color.g), color.b);
        float delta = max - min;

        float h = 0f;
        float s = max != 0f ? delta / max : 0f;
        float v = max;

        if (delta != 0f)
        {
            if (max == color.r)
                h = (color.g - color.b) / delta;
            else if (max == color.g)
                h = 2f + (color.b - color.r) / delta;
            else
                h = 4f + (color.r - color.g) / delta;

            h /= 6f;

            if (h < 0f)
                h += 1f;
        }

        return new Vector3(h, s, v);
    }

    // Преобразование цвета из HSV в RGB
    private Color HSVtoRGB(Vector3 hsv)
    {
        float h = hsv.x;
        float s = hsv.y;
        float v = hsv.z;

        float r = 0f;
        float g = 0f;
        float b = 0f;

        if (s == 0f)
        {
            r = g = b = v;
        }
        else
        {
            float varH = h * 6f;
            int varI = (int)varH;
            float var1 = v * (1f - s);
            float var2 = v * (1f - s * (varH - varI));
            float var3 = v * (1f - s * (1f - (varH - varI)));

            switch (varI)
            {
                case 0:
                    r = v;
                    g = var3;
                    b = var1;
                    break;
                case 1:
                    r = var2;
                    g = v;
                    b = var1;
                    break;
                case 2:
                    r = var1;
                    g = v;
                    b = var3;
                    break;
                case 3:
                    r = var1;
                    g = var2;
                    b = v;
                    break;
                case 4:
                    r = var3;
                    g = var1;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = var1;
                    b = var2;
                    break;
            }
        }

        return new Color(r, g, b);
    }
}
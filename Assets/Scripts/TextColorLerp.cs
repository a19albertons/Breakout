using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Clase para realizar una interpolación de color en un texto de la interfaz gráfica
/// </summary>
public class TextColorLerp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI msg;
    [SerializeField] float duration;

    /// <summary>
    /// Inicializa la interpolación de color del texto.
    /// </summary>
    void Start()
    {
        StartCoroutine("ChangeColor");
    }

    /// <summary>
    /// Realiza la interpolación de color del texto desde negro a blanco
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeColor()
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            msg.color = Color.Lerp(Color.black, Color.white, t / duration);
            yield return null;
        }

        StartCoroutine("ChangeColor");
    }
}

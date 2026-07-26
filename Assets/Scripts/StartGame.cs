using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase para iniciar el juego cuando se presiona la tecla Espacio, ocultando el cursor y gestionando la transición a la siguiente escena.
/// </summary>
public class StartGame : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] Transform pala;
    [SerializeField] GameObject pelota;
    [SerializeField] float duration;

    /// <summary>
    /// Inicializa el juego ocultando el cursor y gestionando la transición a la siguiente escena cuando se presiona la tecla Espacio.
    /// </summary>
    void Start()
    {
        Cursor.visible = false;
    }

    /// <summary>
    /// Actualiza el estado del juego cada frame y verifica si se ha presionado la tecla Espacio para iniciar la transición a la siguiente escena.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("StartNextLevel");
        }
    }

    /// <summary>
    /// Gestiona la transición a la siguiente escena del juego, animando la reducción de la pala y cargando la escena correspondiente después de un retraso especificado.
    /// </summary>
    /// <returns></returns>
    IEnumerator StartNextLevel()
    {
        // Obtenemos la escala inicial de la pala y definimos la escala final a la que queremos reducirla
        Vector3 scaleStart = pala.localScale;
        Vector3 scaleEnd = new Vector3(0, scaleStart.y, scaleStart.z);

        // Definimos un tiemop base 0 que va subiendo hasta la duracion determinada
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            pala.localScale = Vector3.Lerp(scaleStart, scaleEnd, t / duration);
            yield return null;
        }
        // Cargar la escena del juego (índice 1)
        SceneManager.LoadScene(1);
    }
}
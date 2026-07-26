using UnityEngine;

/// <summary>
/// Clase para salir del juego cuando se presiona la tecla Escape.
/// </summary>
public class ExitGame : MonoBehaviour
{
    /// <summary>
    /// Actualiza el estado del juego cada frame y verifica si se ha presionado la tecla Escape para salir del juego.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
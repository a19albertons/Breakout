using UnityEngine;
using TMPro;

/// <summary>
/// Clase para controlar la interfaz gráfica del juego, mostrando la puntuación y las vidas restantes del jugador.
/// </summary>
public class GUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtLives;

    /// <summary>
    /// Actualiza la interfaz gráfica del juego cada frame, mostrando la puntuación y las vidas restantes del jugador.
    /// </summary>
    private void OnGUI()
    {
        // Actualizar el texto 
        txtScore.text = string.Format("{0,3:D3}", GameManager.Score); // Queremos formatearlo a 3 dígitos 
                                                                      // Primer cero, el índice de los valores de la lista que se va a introducir, cuántos caracteres vamos a querer y el formato va a ser dígitos a 3. 

        // Actualizamos marcador
        txtLives.text = GameManager.Lives.ToString();
    }
}
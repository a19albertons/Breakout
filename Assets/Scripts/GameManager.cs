using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using TMPro;

[assembly: InternalsVisibleTo("Tests")] // Es el de edit mode

/// <summary>
/// Clase para gestionar el estado del juego, incluyendo puntuación, vidas y reinicio del juego.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static int Score { get; private set; } = 0;
    public static int Lives { get; private set; } = 3;
    // Se asocia el número de ladrillos destructibles al ID de la escena (Scene-0: 0 ladrillos, Scene-1: 32)
    public static List<int> totalBricks = new List<int> { 0, 28, 28 };

    /// <summary>
    /// Actualiza la puntuación del jugador sumando los puntos obtenidos.
    /// </summary>
    /// <param name="points"></param>
    public static void UpdateScore(int points) { Score += points; }

    /// <summary>
    /// Actualiza el número de vidas del jugador restando una vida.
    /// </summary>
    public static void UpdateLives() { Lives--; }

    /// <summary>
    /// Reinicia el juego estableciendo la puntuación y las vidas a sus valores iniciales y recargando la escena principal.
    /// </summary>
    public static void ResetGame()
    {
        Score = 0;

        Lives = 3;

        SceneManager.LoadScene(0);
    }

    // Para reiniciar las puntuaciones y vidas sin recargar la escena, útil para los tests de EditMode
    internal static void ResetState()
    {
        Score = 0;
        Lives = 3;
    }
}
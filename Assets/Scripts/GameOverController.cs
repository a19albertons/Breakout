using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// Clase para controlar el estado de "Game Over" en el juego, mostrando un mensaje y permitiendo reiniciar el juego.
/// </summary>
public class GameOverController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GameOver;
    //Variable que indica si el juego ya ha rematado
    bool gameOver = false;

    /// <summary>
    /// Comprueba cada frame si el juego ha terminado y gestiona la visualización del mensaje de "Game Over" y el reinicio del juego.
    /// </summary>
    void Update()
    {
        //En la función se comprueba que no estamos en game over y si las vidas han llegado ya 0
        if (!gameOver && GameManager.Lives <= 0)
        {
            //Si se cumple se activa el texto "Game Over"
            GameOver.gameObject.SetActive(true);
            gameOver = true;
        }

        //Si el juego ya ha terminado y el usuario presiona cualquier tecla se reinicia el juego
        if (gameOver && Input.anyKeyDown)
        {
            GameManager.ResetGame();
        }
    }
}
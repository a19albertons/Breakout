using UnityEngine;

/// <summary>
/// Clase para controlar el movimiento de la pala del jugador, permitiendo desplazarse horizontalmente dentro de los límites establecidos.
/// </summary>
public class PalaController : MonoBehaviour
{
    const float MAX_X = 3.1f;
    const float MIN_X = -3.1f;
    [SerializeField] float speed;

    /// <summary>
    /// Actualiza el estado del juego cada frame, permitiendo que la pala se desplace hacia la izquierda o derecha según la entrada del jugador y respetando los límites de movimiento.
    /// </summary>
    void Update()
    {
        float x = transform.position.x; // Obtener la posición actual de x de la pala
        if (x > MIN_X && Input.GetKey("left"))
        {
            // Desplazamiento hacia la izquierda con un valor negativo
            // Utilizamos deltaTime para obtener una referencia de la velocidad independiente del hardware
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (x < MAX_X && Input.GetKey("right"))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0); // Desplazamiento hacia la derecha
        }
    }
}

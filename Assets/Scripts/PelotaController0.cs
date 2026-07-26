using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Clase para controlar el comportamiento de la pelota en el juego, incluyendo su lanzamiento, sonidos, colisiones iteracción con los bloques...
/// Se limita a la escena inicial
/// </summary>
public class PelotaController0 : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float delay;
    [SerializeField] float force;
    [SerializeField] AudioClip sfxPaddel;  // Sonido al chocar con la pala
    [SerializeField] AudioClip sfxBrick;   // Sonido al chocar con un ladrillo
    [SerializeField] AudioClip sfxWall;    // Sonido al chocar con una pared
    [SerializeField] AudioClip sfxFail;    // Sonido al salir por la pared inferior
    AudioSource sfx;  // Componente AudioSource

    // Estructura donde almacenaremos las etiquetas y la puntuación de cada ladrillo
    Dictionary<string, int> ladrillos = new Dictionary<string, int>(){
    {"Ladrillo-Amarillo", 10},
    {"Ladrillo-Verde", 15},
    {"Ladrillo-Naranja", 20},
    {"Ladrillo-Rojo", 25},
    };

    /// <summary>
    /// Inicializa la pelota, obteniendo los componentes necesarios y lanzando la pelota después de un retraso especificado.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<AudioSource>();
        Invoke("LanzarPelota", delay);
    }

    /// <summary>
    /// Lanza la pelota al inicio del juego.
    /// </summary>
    private void LanzarPelota()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = Vector2.zero;
        float dirX, dirY = -1;
        dirX = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dir = new Vector2(dirX, dirY);
        dir.Normalize();

        rb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Gestiona las colisiones de la pelota con otros objetos para genera los sonidos exclusivamente de iteracciones
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Almacenamos la etiqueta del objeto con el que estamos colisionando
        string tag = other.gameObject.tag;

        if (tag == "Pala")
        {
            sfx.clip = sfxPaddel;
            sfx.Play();
        }
        else if (ladrillos.ContainsKey(tag))
        {
            sfx.clip = sfxBrick;
            sfx.Play();
        }
        else if (tag == "ParedDerecha" || tag == "ParedIzquierda" || tag == "ParedSuperior")
        {
            sfx.clip = sfxWall;
            sfx.Play();
        }
    }

}
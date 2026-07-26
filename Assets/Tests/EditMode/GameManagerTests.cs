using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

/// <summary>
/// Tests unitarios para GameManager en EditMode.
/// Verifica la lógica estática de puntuación y vidas sin necesidad del motor Unity runtime.
/// </summary>
public class GameManagerTests
{
    [SetUp]
    public void SetUp()
    {
        // Resetear valores antes de cada test
        GameManager.ResetState();
    }

    [TearDown]
    public void TearDown()
    {
        // Restaurar valores originales después de cada test
        GameManager.ResetState();
    }

    #region Tests de Score

    /// <summary>
    /// Verifica que Score inicia en 0 por defecto.
    /// </summary>
    [Test]
    public void Score_Deberia_IniciarEn_Cero()
    {
        // Arrange & Act
        int scoreInicial = GameManager.Score;

        // Assert
        Assert.That(scoreInicial, Is.EqualTo(0), "Score debería iniciar en 0");
    }

    /// <summary>
    /// Verifica que UpdateScore incrementa Score correctamente.
    /// </summary>
    [Test]
    public void UpdateScore_Deberia_Incrementar_Score()
    {
        // Act
        GameManager.UpdateScore(10);

        // Assert
        Assert.That(GameManager.Score, Is.EqualTo(10), "Score debería ser 10 después de UpdateScore(10)");
    }

    /// <summary>
    /// Verifica que múltiples llamadas a UpdateScore se acumulan.
    /// </summary>
    [Test]
    public void UpdateScore_Deberia_Acumular_MultipleVeces()
    {
        // Act
        GameManager.UpdateScore(10);
        GameManager.UpdateScore(5);
        GameManager.UpdateScore(25);

        // Assert
        Assert.That(GameManager.Score, Is.EqualTo(40), "Score debería ser 40 después de sumar 10+5+25");
    }

    /// <summary>
    /// Verifica que UpdateScore funciona con valores negativos (si se implementara).
    /// </summary>
    [Test]
    public void UpdateScore_Deberia_Manejar_Valores_Negativos()
    {
        // Arrange
        GameManager.UpdateScore(20);

        // Act
        GameManager.UpdateScore(-5);

        // Assert
        Assert.That(GameManager.Score, Is.EqualTo(15), "Score debería ser 15 después de UpdateScore(20) y UpdateScore(-5)");
    }

    /// <summary>
    /// Verifica que UpdateScore funciona con valores grandes.
    /// </summary>
    [Test]
    public void UpdateScore_Deberia_Manejar_Valores_Grandes()
    {
        // Act
        GameManager.UpdateScore(100);
        GameManager.UpdateScore(250);

        // Assert
        Assert.That(GameManager.Score, Is.EqualTo(350), "Score debería ser 350 después de sumar 100+250");
    }

    #endregion

    #region Tests de Lives

    /// <summary>
    /// Verifica que Lives inicia en 3 por defecto.
    /// </summary>
    [Test]
    public void Lives_Deberia_IniciarEn_Tres()
    {
        // Arrange & Act
        int livesInicial = GameManager.Lives;

        // Assert
        Assert.That(livesInicial, Is.EqualTo(3), "Lives debería iniciar en 3");
    }

    /// <summary>
    /// Verifica que UpdateLives decrementa Lives correctamente.
    /// </summary>
    [Test]
    public void UpdateLives_Deberia_Decrementar_Lives()
    {
        // Act
        GameManager.UpdateLives();

        // Assert
        Assert.That(GameManager.Lives, Is.EqualTo(2), "Lives debería ser 2 después de UpdateLives");
    }

    /// <summary>
    /// Verifica que múltiples llamadas a UpdateLives decrementan correctamente.
    /// </summary>
    [Test]
    public void UpdateLives_Deberia_Decrementar_MultipleVeces()
    {
        // Act
        GameManager.UpdateLives();
        GameManager.UpdateLives();
        GameManager.UpdateLives();

        // Assert
        Assert.That(GameManager.Lives, Is.EqualTo(0), "Lives debería ser 0 después de 3 llamadas a UpdateLives");
    }

    /// <summary>
    /// Verifica que Lives puede llegar a 0.
    /// </summary>
    [Test]
    public void Lives_Deberia_Poder_LlegarA_Cero()
    {
        // Act
        GameManager.UpdateLives();
        GameManager.UpdateLives();
        GameManager.UpdateLives();

        // Assert
        Assert.That(GameManager.Lives, Is.EqualTo(0), "Lives debería poder llegar a 0");
    }

    #endregion

    #region Tests de totalBricks

    /// <summary>
    /// Verifica que totalBricks contiene los valores esperados.
    /// </summary>
    [Test]
    public void totalBricks_Deberia_Contener_Valores_Esperados()
    {
        // Act & Assert
        Assert.That(GameManager.totalBricks, Is.Not.Null, "totalBricks no debería ser null");
        Assert.That(GameManager.totalBricks.Count, Is.EqualTo(3), "totalBricks debería tener 3 elementos");
        Assert.That(GameManager.totalBricks[0], Is.EqualTo(0), "totalBricks[0] debería ser 0 (escena 0: sin ladrillos)");
        Assert.That(GameManager.totalBricks[1], Is.EqualTo(28), "totalBricks[1] debería ser 28 (escena 1)");
        Assert.That(GameManager.totalBricks[2], Is.EqualTo(28), "totalBricks[2] debería ser 28 (escena 2)");
    }

    #endregion

    #region Tests de ResetGame (solo propiedades estáticas)

    /// <summary>
    /// Verifica que ResetGame restablece Score a 0.
    /// Nota: No se testea SceneManager.LoadScene() en EditMode.
    /// </summary>
    [Test]
    public void ResetGame_Deberia_Restablecer_ScoreA_Cero()
    {
        // Arrange
        GameManager.UpdateScore(100);
        Assert.That(GameManager.Score, Is.EqualTo(100), "Setup: Score debería ser 100 antes de resetear");

        // Act (solo las propiedades estáticas, no SceneManager)
        GameManager.ResetState();

        // Assert
        Assert.That(GameManager.Score, Is.EqualTo(0), "Score debería ser 0 después de ResetGame");
    }

    /// <summary>
    /// Verifica que ResetGame restablece Lives a 3.
    /// Nota: No se testea SceneManager.LoadScene() en EditMode.
    /// </summary>
    [Test]
    public void ResetGame_Deberia_Restablecer_LivesA_Tres()
    {
        // Arrange
        GameManager.UpdateLives();
        GameManager.UpdateLives();
        Assert.That(GameManager.Lives, Is.EqualTo(1), "Setup: Lives debería ser 1 antes de resetear");

        // Act (solo las propiedades estáticas, no SceneManager)
        GameManager.ResetState();

        // Assert
        Assert.That(GameManager.Lives, Is.EqualTo(3), "Lives debería ser 3 después de ResetState");
    }

    #endregion
}

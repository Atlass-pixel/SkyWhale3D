using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Para poder cargar la escena nuevamente

public class BadCollectible : MonoBehaviour
{
    public GameObject gameOverCanvas;  // El canvas de derrota, lo asignarás en el inspector
    public float restartDelay = 3f;    // Tiempo de espera para reiniciar el juego

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Si el jugador toca el collectible "malo"
        {
            // Detener el juego (puedes usar Time.timeScale para pausar todo el juego)
            Time.timeScale = 0f;  // Pausa el juego

            // Mostrar el canvas de derrota
            if (gameOverCanvas != null)
            {
                gameOverCanvas.SetActive(true);
            }

            // Reiniciar el juego después de 3 segundos
            Invoke(nameof(ReloadGame), restartDelay);
        }
    }

    // Método para reiniciar el juego
    private void ReloadGame()
    {
        // Reinicia la escena actual
        Time.timeScale = 1f;  // Asegurarse de que el tiempo vuelva a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarga la escena actual
    }
}

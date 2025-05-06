using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    [Header("UI de victoria")]
    public GameObject canvasVictoria; // Canvas que muestra la victoria

    // M�todo que se llama cuando el jugador atraviesa el trigger
    void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que ha activado el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Detenemos el juego
            Time.timeScale = 0f;

            // Mostramos el Canvas de victoria
            if (canvasVictoria != null)
                canvasVictoria.SetActive(true);
        }
    }

    // M�todo para reiniciar la escena despu�s de un tiempo o por acci�n del jugador
    public void RestartGame()
    {
        // Restablecemos el tiempo del juego
        Time.timeScale = 1f;

        // Reiniciamos la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

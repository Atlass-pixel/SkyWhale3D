using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Método para reiniciar la escena actual
    public void RestartScene()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para ir al menú y descargar la escena actual
    public void GoToMenu()
    {
        // Cargar la escena del menú
        SceneManager.LoadScene("Menu");

        // Descartar la escena actual para liberar memoria
        // Nota: Asegúrate de que el nombre de la escena "Menu" esté correctamente escrito
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

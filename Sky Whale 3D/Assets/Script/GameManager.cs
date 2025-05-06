using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // M�todo para reiniciar la escena actual
    public void RestartScene()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // M�todo para ir al men� y descargar la escena actual
    public void GoToMenu()
    {
        // Cargar la escena del men�
        SceneManager.LoadScene("Menu");

        // Descartar la escena actual para liberar memoria
        // Nota: Aseg�rate de que el nombre de la escena "Menu" est� correctamente escrito
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}

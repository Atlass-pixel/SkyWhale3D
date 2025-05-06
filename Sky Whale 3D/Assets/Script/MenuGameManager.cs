using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    [Header("Canvas de menú")]
    public GameObject canvasActual;
    public GameObject canvasNuevo;

    // Cierra la aplicación
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    // Cambia de un canvas a otro
    public void CambiarCanvas()
    {
        if (canvasActual != null)
            canvasActual.SetActive(false);

        if (canvasNuevo != null)
            canvasNuevo.SetActive(true);
    }

    // Carga la escena TouchLevel y descarga la actual
    public void CargarTouchLevel()
    {
        Time.timeScale = 1f;
        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("TouchLevel", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(escenaActual);
    }

    // Carga la escena AutoTouchLevel y descarga la actual
    public void CargarAutoTouchLevel()
    {
        Time.timeScale = 1f;
        string escenaActual = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("AutoTouchLevel", LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(escenaActual);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxX = 4f;
    public float jumpForce = 7f;

    private Rigidbody rb;

    [Header("Consumibles")]
    public int consumibles = 0;
    public TextMeshProUGUI consumiblesText;

    [Header("Altura máxima")]
    public TextMeshProUGUI maxHeightText; // Texto para mostrar la altura máxima alcanzada
    private float maxHeight = 0f; // Variable para almacenar la altura máxima

    [Header("UI de derrota")]
    public GameObject canvasDerrota;

    private bool primerToque = false;
    private bool acelerometroActivo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateConsumiblesUI();

        if (canvasDerrota != null)
            canvasDerrota.SetActive(false);
    }

    void Update()
    {
        if (!primerToque && Input.touchCount > 0)
        {
            primerToque = true;
            acelerometroActivo = true;
            Jump(); // salto inicial
        }

        if (acelerometroActivo)
        {
            float inputX = Input.acceleration.x;
            float moveX = inputX * moveSpeed;

            Vector3 pos = transform.position;
            pos.x += moveX * Time.deltaTime;
            pos.x = Mathf.Clamp(pos.x, -maxX, maxX);
            transform.position = pos;
        }

        // Actualizamos la altura máxima
        if (transform.position.y > maxHeight)
        {
            maxHeight = transform.position.y; // Si el jugador sube, actualizamos la altura máxima
            UpdateMaxHeightUI(); // Actualizamos el UI con la nueva altura máxima
        }
    }

    void Jump()
    {
        if (consumibles > 0) // Solo salta si tiene consumibles
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            consumibles--; // Disminuye el contador de consumibles al saltar
            UpdateConsumiblesUI();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumible"))
        {
            consumibles++; // Aumenta el contador al recoger un consumible
            Destroy(other.gameObject);
            UpdateConsumiblesUI();
            Jump(); // Salta inmediatamente al recoger un consumible
        }
        else if (other.CompareTag("ConsumibleMalo"))
        {
            StartCoroutine(GameOver());
        }
    }

    void UpdateConsumiblesUI()
    {
        if (consumiblesText != null)
        {
            consumiblesText.text = "Puntos: " + consumibles;
        }
    }

    // Actualiza la UI con la altura máxima
    void UpdateMaxHeightUI()
    {
        if (maxHeightText != null)
        {
            maxHeightText.text = "Altura Máxima: " + Mathf.Floor(maxHeight) + "m"; // Mostramos la altura redondeada
        }
    }

    IEnumerator GameOver()
    {
        if (canvasDerrota != null)
            canvasDerrota.SetActive(true);

        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(3f); // usa tiempo real, time.timeScale no

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

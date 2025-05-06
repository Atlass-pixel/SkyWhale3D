using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; 

[RequireComponent(typeof(Rigidbody))]
public class PlayerController2 : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 7f;
    public float maxHorizontalSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 12f;
    private bool canJump = true;

    [Header("Consumibles")]
    public int consumibles = 3;
    public TextMeshProUGUI consumiblesTMPText;
    public GameObject canvasDerrota;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateConsumiblesUI();
        if (canvasDerrota != null)
            canvasDerrota.SetActive(false);
    }

    void Update()
    {
        float horizontalInput = Input.acceleration.x;
        float newVelocityX = Mathf.Clamp(horizontalInput * moveSpeed, -maxHorizontalSpeed, maxHorizontalSpeed);
        rb.velocity = new Vector3(newVelocityX, rb.velocity.y, rb.velocity.z);

        if (Input.touchCount > 0 && canJump && consumibles > 0)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        canJump = false;
        consumibles--;
        UpdateConsumiblesUI();
        Invoke(nameof(EnableJump), 0.2f);
    }

    void EnableJump()
    {
        canJump = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Consumible"))
        {
            consumibles++;
            Destroy(other.gameObject);
            UpdateConsumiblesUI();
        }
        else if (other.CompareTag("ConsumibleMalo"))
        {
            StartCoroutine(GameOver());
        }
    }

    void UpdateConsumiblesUI()
    {
        if (consumiblesTMPText != null)
        {
            consumiblesTMPText.text = "Saltos: " + consumibles;
        }
    }

    IEnumerator GameOver()
    {
        if (canvasDerrota != null)
            canvasDerrota.SetActive(true);

        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

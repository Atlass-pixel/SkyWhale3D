using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       // Referencia al transform del jugador
    public float smoothSpeed = 0.1f;  // Velocidad de suavizado del movimiento de la c�mara
    public Vector3 offset;        // Offset para posicionar la c�mara (ajustar para tener la distancia deseada)

    private void Start()
    {
        // Establecer el offset inicial
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        // Seguir solo el movimiento en el eje Y
        Vector3 desiredPosition = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);

        // Suavizar el movimiento de la c�mara (lerp)
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Actualizar la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}

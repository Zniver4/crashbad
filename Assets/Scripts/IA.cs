using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform ball;     // Referencia a la pelota
    public float speed = 5f;   // Velocidad de seguimiento
    public float zMinLimit = -5f;  // Límite mínimo en el eje Z
    public float zMaxLimit = 5f;   // Límite máximo en el eje Z

    private void Update()
    {
        // Obtener la posición actual de la IA y la pelota
        Vector3 currentPosition = transform.position;
        Vector3 ballPosition = ball.position;

        // Calcular la nueva posición en el eje Z
        float newZPosition = Mathf.Lerp(currentPosition.z, ballPosition.z, speed * Time.deltaTime);

        // Limitar el movimiento en el eje Z
        newZPosition = Mathf.Clamp(newZPosition, zMinLimit, zMaxLimit);

        // Actualizar la posición de la IA
        transform.position = new Vector3(currentPosition.x, currentPosition.y, newZPosition);
    }
}


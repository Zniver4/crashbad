using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Transform[] balls;  // Array de referencias a las pelotas
    public float speed = 5f;   // Velocidad de seguimiento
    public float zMinLimit = -5f;  // Límite mínimo en el eje Z
    public float zMaxLimit = 5f;   // Límite máximo en el eje Z

    private void Update()
    {
        if (balls.Length == 0) return; // Si no hay pelotas, no hacer nada

        // Encontrar la pelota más cercana
        Transform closestBall = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform ball in balls)
        {
            float distance = Vector3.Distance(transform.position, ball.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestBall = ball;
            }
        }

        if (closestBall == null) return; // Si no se encuentra ninguna pelota, no hacer nada

        // Obtener la posición actual de la IA y la pelota más cercana
        Vector3 currentPosition = transform.position;
        Vector3 ballPosition = closestBall.position;

        // Calcular la nueva posición en el eje Z
        float newZPosition = Mathf.Lerp(currentPosition.z, ballPosition.z, speed * Time.deltaTime);

        // Limitar el movimiento en el eje Z
        newZPosition = Mathf.Clamp(newZPosition, zMinLimit, zMaxLimit);

        // Actualizar la posición de la IA
        transform.position = new Vector3(currentPosition.x, currentPosition.y, newZPosition);
    }
}


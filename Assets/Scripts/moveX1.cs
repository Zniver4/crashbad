using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveX1 : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float limiteIzquierdo = -10f; // Límite izquierdo
    public float limiteDerecho = 10f; // Límite derecho

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal2") * velocidad * Time.deltaTime;

        // Nueva posición con el movimiento aplicado
        float nuevaPosicionX = transform.position.x + movimiento;

        // Asegúrate de que la nueva posición esté dentro de los límites
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

        // Aplica la nueva posición
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

    }
}

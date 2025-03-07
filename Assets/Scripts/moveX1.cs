using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveX1 : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float limiteIzquierdo = -10f; // L�mite izquierdo
    public float limiteDerecho = 10f; // L�mite derecho

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal2") * velocidad * Time.deltaTime;

        // Nueva posici�n con el movimiento aplicado
        float nuevaPosicionX = transform.position.x + movimiento;

        // Aseg�rate de que la nueva posici�n est� dentro de los l�mites
        nuevaPosicionX = Mathf.Clamp(nuevaPosicionX, limiteIzquierdo, limiteDerecho);

        // Aplica la nueva posici�n
        transform.position = new Vector3(nuevaPosicionX, transform.position.y, transform.position.z);

    }
}

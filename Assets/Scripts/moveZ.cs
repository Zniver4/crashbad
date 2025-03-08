using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveZ : MonoBehaviour
{
    public float speed = 10f;           // Velocidad de movimiento
    public float zMinLimit = -5f;       // L�mite m�nimo en el eje Z
    public float zMaxLimit = 5f;        // L�mite m�ximo en el eje Z

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical");

        // Calcular el movimiento en el eje Z
        float moveZ = moveInput * speed * Time.deltaTime;

        // Obtener la posici�n actual del objeto y aplicar el movimiento en el eje Z
        Vector3 newPosition = transform.position;
        newPosition.z += moveZ;

        // Limitar el movimiento en el eje Z
        newPosition.z = Mathf.Clamp(newPosition.z, zMinLimit, zMaxLimit);

        // Aplicar la nueva posici�n directamente
        transform.position = newPosition;

        // Depurar la nueva posici�n y el input
        Debug.Log("Posici�n nueva: " + transform.position + ", Input: " + moveInput);
    }
}

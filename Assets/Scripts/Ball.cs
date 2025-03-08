using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float forceMagnitude = 10f;
    public Vector3 originPosition;
    public float minYLimit = -10f;
    public float maxYLimit = 10f;
    public float minXLimit = -10f;
    public float maxXLimit = 10f;
    public float minZLimit = -10f;
    public float maxZLimit = 10f;
    public float initialSpeed = 5f; // Nueva variable para la velocidad inicial
    public float minSpeedThreshold = 0.1f; // Umbral m�nimo de velocidad

    private Rigidbody rb;
    private Collider ballCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballCollider = GetComponent<Collider>();
        originPosition = transform.position; // Guardamos la posici�n de origen

        // Ajusta las propiedades del Rigidbody
        rb.mass = 2f;
        rb.drag = 1f;
        rb.angularDrag = 1f;

        // Configura el material f�sico para no tener rebote
        PhysicMaterial noBounceMaterial = new PhysicMaterial();
        noBounceMaterial.bounciness = 0f;
        noBounceMaterial.bounceCombine = PhysicMaterialCombine.Minimum;
        ballCollider.material = noBounceMaterial;

        // Aplica una velocidad inicial
        rb.velocity = new Vector3(initialSpeed, 0, initialSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Aplica una fuerza aleatoria cuando la pelota colisione con algo
        Vector3 randomForce = new Vector3(
            Random.Range(-forceMagnitude, forceMagnitude),
            Random.Range(-forceMagnitude, forceMagnitude),
            Random.Range(-forceMagnitude, forceMagnitude)
        );
        rb.AddForce(randomForce, ForceMode.Impulse);
    }

    void Update()
    {
        // Verifica si la pelota est� fuera de los l�mites
        if (transform.position.y < minYLimit ||
            transform.position.y > maxYLimit ||
            transform.position.x < minXLimit ||
            transform.position.x > maxXLimit ||
            transform.position.z < minZLimit ||
            transform.position.z > maxZLimit)
        {
            // Resetea la pelota a su posici�n de origen
            transform.position = originPosition;
            rb.velocity = Vector3.zero; // Det�n cualquier movimiento actual
        }

        // Verifica si la velocidad de la pelota es muy baja
        if (rb.velocity.magnitude < minSpeedThreshold)
        {
            // Aplica una fuerza adicional para mantener la pelota en movimiento
            Vector3 additionalForce = new Vector3(
                Random.Range(-forceMagnitude, forceMagnitude),
                Random.Range(-forceMagnitude, forceMagnitude),
                Random.Range(-forceMagnitude, forceMagnitude)
            );
            rb.AddForce(additionalForce, ForceMode.Impulse);
        }
    }
}

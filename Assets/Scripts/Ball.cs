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

    private Rigidbody rb;
    private Collider ballCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballCollider = GetComponent<Collider>();
        originPosition = transform.position; // Guardamos la posición de origen

        // Ajusta las propiedades del Rigidbody
        rb.mass = 2f;
        rb.drag = 1f;
        rb.angularDrag = 1f;

        // Configura el material físico para no tener rebote
        PhysicMaterial noBounceMaterial = new PhysicMaterial();
        noBounceMaterial.bounciness = 0f;
        noBounceMaterial.bounceCombine = PhysicMaterialCombine.Minimum;
        ballCollider.material = noBounceMaterial;
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
        // Verifica si la pelota está fuera de los límites
        if (transform.position.y < minYLimit ||
            transform.position.y > maxYLimit ||
            transform.position.x < minXLimit ||
            transform.position.x > maxXLimit ||
            transform.position.z < minZLimit ||
            transform.position.z > maxZLimit)
        {
            // Resetea la pelota a su posición de origen
            transform.position = originPosition;
            rb.velocity = Vector3.zero; // Detén cualquier movimiento actual
        }
    }
}

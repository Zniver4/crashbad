using TMPro;
using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour
{
    public int playerLives = 3;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI messageText;
    public GameObject[] balls; // Array de pelotas
    public Canvas messageCanvas; // Canvas que contiene el mensaje

    private void Start()
    {
        UpdateLivesText();
        messageCanvas.gameObject.SetActive(false); // Desactivar el canvas al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject ball in balls)
        {
            if (other.gameObject == ball)
            {
                playerLives--;
                UpdateLivesText();
                ShowMessage();

                if (playerLives <= 0)
                {
                    // Manejar el fin del juego para este jugador
                    messageText.text = "¡Player 1 ha perdido todas sus vidas!";
                }
                break; // Salir del bucle una vez que se encuentra la pelota
            }
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Vidas: " + playerLives;
    }

    private void ShowMessage()
    {
        messageCanvas.gameObject.SetActive(true); // Activar el canvas
        messageText.text = "¡Player 1 ha perdido una vida!";
        // Opcional: puedes agregar un temporizador para ocultar el mensaje después de unos segundos
        StartCoroutine(HideMessageAfterDelay(2f)); // Ocultar el mensaje después de 2 segundos
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageCanvas.gameObject.SetActive(false); // Desactivar el canvas
    }
}

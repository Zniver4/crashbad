using TMPro;
using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour
{
    public int playerLives = 3;
    public TextMeshProUGUI livesText;
    public GameObject[] balls; // Array de pelotas
    public GameObject player; // Referencia al GameObject del jugador

    private void Start()
    {
        UpdateLivesText();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject ball in balls)
        {
            if (other.gameObject == ball)
            {
                if (playerLives > 0)
                {
                    playerLives--;
                    UpdateLivesText();

                    if (playerLives <= 0)
                    {
                        // Manejar el fin del juego para este jugador
                        playerLives = 0; // Asegurarse de que no baje de 0
                        HidePlayer();
                    }
                }
                break; // Salir del bucle una vez que se encuentra la pelota
            }
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "" + playerLives;
    }

    private void HidePlayer()
    {
        // Desactivar el GameObject del jugador
        player.SetActive(false);
    }
}

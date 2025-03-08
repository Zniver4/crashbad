using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public GameObject[] players; // Lista de jugadores
    public TextMeshProUGUI gameOverText; // Texto de Game Over en el Canvas
    public GameObject gameOverCanvas; // Canvas de Game Over

    private void Start()
    {
        gameOverCanvas.SetActive(false); // Asegúrate de que el Canvas esté desactivado al inicio
        Time.timeScale = 1; // Asegúrate de que el tiempo esté corriendo al inicio
    }

    private void Update()
    {
        CheckPlayers();
    }

    private void CheckPlayers()
    {
        int activePlayers = 0;
        string winner = "";

        foreach (GameObject player in players)
        {
            if (player.activeInHierarchy)
            {
                activePlayers++;
                winner = player.name;
            }
        }

        if (activePlayers == 1)
        {
            gameOverCanvas.SetActive(true);
            gameOverText.text = winner + " ha ganado!";
            Time.timeScale = 0; // Pausar el juego
            // Opcional: desactivar el juego o mostrar opciones adicionales
        }
    }
}

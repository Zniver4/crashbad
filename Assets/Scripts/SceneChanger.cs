using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Método para cambiar a la escena especificada por su nombre y despausar el juego
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1; // Restablecer el tiempo a la escala normal antes de cambiar de escena
        SceneManager.LoadScene(sceneName);
    }

    // Método opcional para cargar la escena siguiente en la lista de Build Settings
    public void LoadNextScene()
    {
        Time.timeScale = 1; // Restablecer el tiempo a la escala normal antes de cambiar de escena
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No hay más escenas en la lista de Build Settings.");
        }
    }
}

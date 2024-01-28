using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    // Метод для перезапуска сцены
    public void RestartScene()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameManager.Instance.work = false;

        // Перезапускаем текущую сцену
        SceneManager.LoadScene(currentSceneIndex);
    }
}
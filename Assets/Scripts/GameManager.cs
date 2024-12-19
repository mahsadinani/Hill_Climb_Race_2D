using UnityEngine;

public class GameManager : MonoBehaviour
{

public static GameManager instance;
[SerializeField] private GameObject _GameOverCanvas;

private void Awake()
{
    if (instance==null) 
    {
        instance = this;
    }

    Time.timeScale = 1f; 
}

public void GameOver()
{
    _GameOverCanvas.SetActive(true);
    Time.timeScale = 0f;
}

}

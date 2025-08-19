using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverMusic;
    private AudioSource musicSource;
    public bool isGameActive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverScreen.SetActive(true);
        musicSource.clip = gameOverMusic;
        musicSource.volume = 1f;
        musicSource.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
}

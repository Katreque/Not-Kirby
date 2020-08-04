using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{

    public static GameControl instancia;
    public GameObject gameOvertext;
    public Text scoreText;

    public bool gameOver = false;
    private int score = 0;
    public float scrollSpeed = -1.5f;

    void Awake()
    {
        if (instancia == null) {
            instancia = this;
        } else if(instancia != this) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void JogadorMorreu() {
        gameOvertext.SetActive(true);
        gameOver = true;
    }

    public void JogadorPontuou() {
        if (gameOver == true) {
            return;
        }  

        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}

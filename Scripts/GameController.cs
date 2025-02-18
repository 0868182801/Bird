using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;  // dùng để chạy scene
using UnityEngine.UI;
using System.Reflection.Emit;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    bool isStartFirstTime = true;
    int gamePoint = 0;
    public Text txtPoint;
    public GameObject panelEndGame;
    public Text txtEndPoint;
    public Button buttonRestart;
    // Khi di chuột vào button đổi màu tới sử dụng hình ảnh khác --> Sprite
     public Button buttonQuit;
    public Sprite buttonIdle;   // màu bthg
    public Sprite buttonHover;  // màu khi di chuột qua
    public Sprite buttonClick;  // màu khi click giữ button
    public Sprite buttonquitIdle;   // màu bthg
    public Sprite buttonquitHover;  // màu khi di chuột qua
    public Sprite buttonquitClick;  // màu khi click giữ button

    void Start(){
        Time.timeScale = 0; // bắt đầu thì game đứng yên
        isEndGame = false;
        isStartFirstTime = true;
        panelEndGame.SetActive(false);
    }

    void Update(){
        if (isEndGame) {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime){   // nhấp chuột trái game hoạt động
                StartGame();  
            }
        }
        else {
            if (Input.GetMouseButtonDown(0)){   // Nhấn 1 lần duy nhất  
                Time.timeScale = 1;
            }
        }
    }

    public void RestartButtonClick(){
        buttonRestart.GetComponent<Image>().sprite = buttonClick;
    }

    public void RestartButtonHover(){
        buttonRestart.GetComponent<Image>().sprite = buttonHover;
      
    }

    public void RestartButtonIdle(){
        buttonRestart.GetComponent<Image>().sprite = buttonIdle;

    }
    public void QuitButtonClick(){
        buttonQuit.GetComponent<Image>().sprite = buttonquitClick;
    }

    public void QuitButtonHover(){
        buttonQuit.GetComponent<Image>().sprite = buttonquitHover;
      
    }

    public void QuitButtonIdle(){
        buttonQuit.GetComponent<Image>().sprite = buttonquitIdle;

    }
    public void GetPoint(){
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

    public void StartGame(){
        SceneManager.LoadScene(0);   // load màn chơi
    }

    public void RestartGame(){
        StartGame();
    }
    public void QuitGame(){
        Application.Quit();
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; // Dừng chơi trong Unity Editor
#endif
    }
    public void EndGame() {
        isEndGame = true;
        isStartFirstTime = false;
        Time.timeScale = 0;     // tốc độ của game: mặc định là 1 khi giảm xuống 0 thì ngưng đọng time
        panelEndGame.SetActive(true);
        txtEndPoint.text = "Your point\n" + gamePoint.ToString();
    }
}
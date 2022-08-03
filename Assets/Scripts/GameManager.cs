using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton for Game Manage
    public static GameManager instance { get; private set; }
    
    [Header("In Game")]
    public bool gamePaused = false;

    [Header("In Editor")]
    [SerializeField] private GameObject gameMenuCanvas;
    [SerializeField] private GameObject gamePlayCanvas;
    [SerializeField] private Texture2D cursorTexture;
    
    private void Awake()
    {
        // Set singleton
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        // Mouse movement lock & Keep position at middle point of screen
        Cursor.lockState = CursorLockMode.Locked;
        
        Vector2 cursorOffset = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorOffset, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        // Game Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }

    void GamePause()
    {
        gamePaused = true;
        gameMenuCanvas.SetActive(true);

        // Mouse movement free
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void BackToGameBtn()
    {
        gamePaused = false;
        gameMenuCanvas.SetActive(false);

        // Mouse movement lock & Keep position at middle point of screen
        Cursor.lockState = CursorLockMode.Locked;
    }
}

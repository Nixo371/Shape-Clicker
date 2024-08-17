using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;  // Drag your Panel here in the Inspector
    public Button resumeButton;
    public Button quitButton;

    private bool isPaused = false;

    void Start()
    {
        // Make sure the menu is not active at the start
        pauseMenuPanel.SetActive(false);

        // Assign the button actions
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuPanel.SetActive(true);  // Show the pause menu
        Time.timeScale = 0f;  // Freeze the game
        isPaused = true;

        // Reset button states
        ResetButtonState(resumeButton);
        ResetButtonState(quitButton);
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);  // Hide the pause menu
        Time.timeScale = 1f;  // Unfreeze the game
        isPaused = false;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stop playing the game in the editor
        #else
        Application.Quit();  // Quit the game
        #endif
    }

    void ResetButtonState(Button button)
    {
        button.interactable = false;  // Temporarily disable the button
        button.interactable = true;   // Re-enable the button, resetting its state
    }
}

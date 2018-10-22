using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayGUI : MonoBehaviour {
    public GameObject PauseMenu;
    public GameObject PauseButton;

    private void Start()
    {
        TogglePause(false);
    }

    public void TogglePause()
    {
        PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
        PauseButton.SetActive(!PauseButton.activeInHierarchy);

        Time.timeScale = PauseMenu.activeInHierarchy ? 0 : 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause(bool isActive)
    {
        PauseMenu.SetActive(isActive);
        PauseButton.SetActive(!isActive);

        Time.timeScale = PauseMenu.activeInHierarchy ? 0 : 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public Transform main;
    public Transform worldOne;

    private void Start()
    {
        ReturnMain();
    }

    public void ReturnMain()
    {
        CameraController.instance.SetNewFocus(main);
    }

    public void Btn_Continue()
    {
        CameraController.instance.SetNewFocus(worldOne); 
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}

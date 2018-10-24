using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public static PlayerInput instance;

    public bool JumpInput;
    public bool ChangeInput;

    [SerializeField]
    public GameObject mobileController;

    [SerializeField]
    private float HSensitivity = 1;
    private float HInput = 0;

    private void Awake()
    {
        instance = this;


#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        mobileController.SetActive(false);
#endif
    }

    public void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        HInput = Input.GetAxisRaw("Horizontal");
#endif

#if UNITY_ANDROID
        HInput = LeftJoystick.instance.GetInputDirection().x;
#endif

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        //JumpInput = Input.GetKeyDown(KeyCode.Space) ? true : false;
        //JumpInput = Input.GetKeyUp(KeyCode.Space) ? false :true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpInput = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpInput = false;
        }

        ChangeInput = Input.GetKeyDown(KeyCode.LeftShift);
    #endif
    }

    public float GetHInput()
    {
        return HInput;
    }

    public void Btn_Jump()
    {
        JumpInput = true;
    }

    public void Btn_Change()
    {
        ChangeInput = true;
    }
}

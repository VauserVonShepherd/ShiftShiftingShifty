using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeShape : MonoBehaviour {
    public static PlayerChangeShape instance;

    [SerializeField]
    private GameObject[] ShapeList;
    private int shapeVal = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeShape();
    }

    private void Update()
    {
        if (PlayerInput.instance.ChangeInput)
        {
            ChangeShape();
        }
    }

    public void ChangeShape()
    {
        ShapeList[shapeVal].SetActive(false);
        ++shapeVal;
        if(shapeVal >= ShapeList.Length)
        {
            shapeVal = 0;
        }
        ShapeList[shapeVal].SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;

    public static GameManager Instance
    {
        get;
        private set;
    }

    public Sprite[] HeartImages;

    public GameObject ItemInfoPanel;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
}
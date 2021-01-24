using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectViewer : MonoBehaviour 
{

    [SerializeField] private Image viewer;
    public Action OnSelectViwerButton;

    private void Awake()
    {
        var button = GetComponentInChildren<Button>();
        button.onClick.AddListener( () => 
        {
            if(OnSelectViwerButton != null)
            {
                OnSelectViwerButton();
            }
        });

    }

    public void SetViewrImg(Sprite viewerImg)
    {
        viewer.sprite = viewerImg;
    }

	
}

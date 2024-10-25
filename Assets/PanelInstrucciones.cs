using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInstrucciones : MonoBehaviour
{
    private SFXController sFXController;
    public RectTransform optionsPanel;

    public Vector3 hiddenPosition = new Vector3(-1537f, 0f, 0f);
    public Vector3 visiblePosition = Vector3.zero;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private bool isOptionsVisible = false;

    private void Awake()
    {
        sFXController = FindObjectOfType<SFXController>();
    }

    void Start()
    {
        optionsPanel.localPosition = hiddenPosition; 
    }

    void Update()
    {
        Vector3 targetPosition;

        if (isOptionsVisible)
        {
            targetPosition = visiblePosition; 
        }
        else
        {
            targetPosition = hiddenPosition; 
        }
        optionsPanel.localPosition = Vector3.SmoothDamp(optionsPanel.localPosition, targetPosition, ref velocity, smoothTime);
    }

    public void ToggleOptions()
    {
        sFXController.PlayClickSound();
        isOptionsVisible = !isOptionsVisible; 
    }
}
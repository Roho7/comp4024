using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionRenderingLogic : MonoBehaviour
{
    private CanvasRenderer canvasRenderer;

    void Start()
    {
        // Get the CanvasRenderer component
        canvasRenderer = GetComponent<CanvasRenderer>();

        // Check if the CanvasRenderer component exists
        if (canvasRenderer != null)
        {
            // Set the CanvasRenderer component to be initially invisible
            canvasRenderer.SetAlpha(0f);
        }
        else
        {
            Debug.LogError("No CanvasRenderer component found on the UI element.");
        }
    }
}

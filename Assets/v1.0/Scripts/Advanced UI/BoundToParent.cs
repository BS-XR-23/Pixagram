using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bounds the rect transform to be within it's parent's bounds
[RequireComponent(typeof(RectTransform))]
public class BoundToParent : MonoBehaviour
{
    RectTransform currentRect;
    RectTransform anchorRect;
    Rect lastResolution;

    float currentHalfWidth;
    float currentHalfHeight;
    float anchorHalfWidth;
    float anchorHalfHeight;

    public float buffer = 10;
    
    private void Init()
    {
        anchorRect = transform.parent.GetComponent<RectTransform>();
        currentRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        lastResolution = new Rect();
        Init();
    }

    void UpdateRects()
    {
        Init();
        currentHalfWidth = currentRect.rect.width * transform.localScale.x / 2.0f;
        currentHalfHeight = currentRect.rect.height * transform.localScale.y / 2.0f;
        anchorHalfWidth = anchorRect.rect.width * anchorRect.localScale.x / 2.0f;
        anchorHalfHeight = anchorRect.rect.height * anchorRect.localScale.y / 2.0f;
    }

    bool ResolutionChanged()
    {
        return lastResolution != anchorRect.rect;
    }

    bool WithinBounds()
    {
        return (currentHalfWidth < anchorHalfWidth - buffer) && (currentHalfHeight < anchorHalfHeight - buffer);
    }

    bool BeyondBounds()
    {
        return (currentHalfWidth > anchorHalfWidth + buffer) && (currentHalfHeight > anchorHalfHeight + buffer);
    }

    public void ForceRescale()
    {
        Rescale();
        lastResolution = new Rect();
    }

    private void OnEnable()
    {
        ForceRescale();
    }

    void Update()
    {
        if (ResolutionChanged())
        {
            Rescale();
        }
    }

    void Rescale()
    {
        // Reset to very large
        transform.localScale = Vector3.one * 1.1f;
        UpdateRects();

        // Shrink to be within bounds
        if (!WithinBounds())
        {
            while (!WithinBounds() && (transform.localScale.x > 0.1f))
            {
                transform.localScale -= Vector3.one * 0.1f * Time.deltaTime;
                UpdateRects();
            }
        }

        lastResolution = anchorRect.rect;
    }
}

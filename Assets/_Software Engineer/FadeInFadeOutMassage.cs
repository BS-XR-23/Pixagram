using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeInFadeOutMassage : MonoBehaviour
{
    public float time;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeInFadeOut()
    {
        _canvasGroup.DOFade(1, time).SetLoops(2, LoopType.Yoyo);
    }
}

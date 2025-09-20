using Unity.VisualScripting;
using UnityEngine;

public class CanvasView : MonoBehaviour, ICanavas
{

    private Canvas baseCanvas;
    [SerializeField] private CanvasType canvasType;

    private void Awake()
    {
        baseCanvas = GetComponent<Canvas>();
    }

    public void Show() => baseCanvas.enabled = true;

    public void Hide() => baseCanvas.enabled = false;

    public CanvasType Type => canvasType;
}
using System.Collections.Generic;
using UnityEngine;

public class UIManagerComponent : MonoBehaviour
{


    [SerializeField] private List<CanvasView> canvasViews;
    private Dictionary<CanvasType, CanvasView> canvases = new();

    private void Awake()
    {
        foreach (var view in canvasViews)
        {
            canvases.Add(view.Type, view);
            view.Hide();
        }
        ShowCanvas(CanvasType.BaseCanvas);
    }
    public void ShowCanvas(CanvasType canvasType)
    {
        foreach (var kvp in canvases)
            kvp.Value.Hide();

        if (canvases.TryGetValue(canvasType, out var view))
            view.Show();
    }

}
public enum CanvasType
{
    BaseCanvas,
    AimCanvas

}

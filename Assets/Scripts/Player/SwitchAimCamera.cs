using Cinemachine;
using System;
using Unity.VisualScripting;
using UnityEngine;


public class SwitchAimCamera : MonoBehaviour, ICanavas
{
    [SerializeField] private int priorityAimCamera = 9;
    [SerializeField] private CanvasType type;

    [SerializeField] private Canvas canvasAim;
    private CinemachineVirtualCamera aimCamera;




    private void Awake()
    {
        aimCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void AimCameraEnabled()
    {
        aimCamera.Priority += priorityAimCamera;
    }
    public void AimCameraDisabled()
    {
        aimCamera.Priority -= priorityAimCamera;
    }

    public void Show() => canvasAim.enabled = true;
    public void Hide() => canvasAim.enabled = false;

    public CanvasType Type => type;
}

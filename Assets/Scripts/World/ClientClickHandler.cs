using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientClickHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Material material;
    public Material selectedMaterial;
    public MeshRenderer renderer;
    public ClientController client;

    public void OnPointerClick(PointerEventData eventData)
    {
        client.onHandlerClicked();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material = selectedMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        renderer.material = material;
    }
}

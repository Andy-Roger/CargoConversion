using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cargoSpotManager : MonoBehaviour, IHittable
{
    private Color cargoColor;

    private void Start()
    {
        cargoColor = transform.GetChild(0).GetComponent<Renderer>().material.color;
        cargoList.cargos.Add(transform.GetChild(0).GetComponent<Renderer>());
    }

    public void receiveHit(RaycastHit hit)
    {
        transform.GetChild(0).GetComponent<Renderer>().material.DOColor(new Color(cargoColor.r, cargoColor.g, cargoColor.b, 1), 1);
    }
}

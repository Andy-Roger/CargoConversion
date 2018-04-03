using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cargoList : MonoBehaviour 
{
    public static List<Renderer> cargos = new List<Renderer>();

    public void unloadCargo()
    {
        foreach(Renderer cargo in cargos)
        {
            cargo.material.DOColor(new Color(cargo.material.color.r, cargo.material.color.g, cargo.material.color.b, 0.1f), 1);
        }
    }
}

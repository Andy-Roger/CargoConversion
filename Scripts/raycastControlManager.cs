using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class raycastControlManager : MonoBehaviour
{
    private GameObject currentlyHitObject;
    public Material cargoSpotHighlighted;
    public Color initialColor;
    public GameObject reticle;

    private void Start()
    {
        DOTween.Init();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            select();
        }

        setCurrentlyActive(transform.position, transform.forward);


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            reticle.transform.position = hit.point;
            reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }

    void select()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<MonoBehaviour>() is IHittable)
            {
                hit.collider.gameObject.GetComponent<IHittable>().receiveHit(hit);
            }
        }
    }

    void setCurrentlyActive(Vector3 targetPosition, Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(targetPosition, direction);
        if (Physics.Raycast(ray, out hit))
        {
            //fires once when new object is hit with a raycast
            if (hit.collider.gameObject != currentlyHitObject && hit.collider.gameObject.GetComponent<MonoBehaviour>() is IHittable)
            {
                if(currentlyHitObject != null)
                {
                    //currently hit game obejct color = oldcolor
                    currentlyHitObject.GetComponent<Renderer>().material.DOColor(Color.white, 1);
                }

                currentlyHitObject = hit.collider.gameObject;
                currentlyHitObject.GetComponent<Renderer>().material.DOColor(Color.cyan, 1);
            }
        }
    }
}

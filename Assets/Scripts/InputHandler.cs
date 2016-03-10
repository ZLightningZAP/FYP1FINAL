﻿using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{

    public GameObject BulletHole;
    public ParticleSystem OnHitEffect;

    private float gap = 0.1f;

    Camera camera;

    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //If Left Click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(OnHitEffect, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));

                Instantiate(BulletHole, hit.point + (hit.normal * gap), Quaternion.LookRotation(hit.normal));
            }

        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

public class HealthBar : MonoBehaviour {
    private static Camera mainCamera;
    private Health health;
    private Slider healthBar;
    void Start()
    {
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
        health = GetComponentInParent<Health>();
        healthBar = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update() {
        healthBar.value = health.GetHealth() / health.GetMaxHealth();

        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);
    }
}

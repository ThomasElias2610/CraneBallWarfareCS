using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    [SerializeField]
    Material skyboxes;

    void Awake()
    {
        RenderSettings.skybox = skyboxes;
        RenderSettings.ambientIntensity = 0f;
    }
}

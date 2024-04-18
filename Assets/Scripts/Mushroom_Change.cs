using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom_Change : MonoBehaviour
{
    public Material firstMushroomMaterial;
    public Material secondMushroomMaterial;

    private Color firstMushroomEmissionStart = new Color(113, 0, 0, 1);
    private Color firstMushroomEmissionEnd = new Color(113, 0, 255, 1);

    private Color secondMushroomEmissionStart = new Color(113, 0, 255, 1);
    private Color secondMushroomEmissionEnd = new Color(113, 0, 0, 1);

    private float fadeDuration = 2.0f; // Duration of the fade in seconds
    private float timer = 0.0f;
    private bool fading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player is what's triggering the collision
        {
            fading = true;
            timer = 0.0f;
        }
    }

    private void Update()
    {
        if (fading)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;

            // Fade first mushroom's blue emission from 255 to 0
            Color currentFirstMushroomEmission = new Color(
                firstMushroomEmissionStart.r,
                firstMushroomEmissionStart.g,
                Mathf.Lerp(firstMushroomEmissionStart.b, firstMushroomEmissionEnd.b, t),
                firstMushroomEmissionStart.a
            );
            firstMushroomMaterial.SetColor("_EmissionColor", currentFirstMushroomEmission);

            // Fade second mushroom's blue emission from 0 to 255
            Color currentSecondMushroomEmission = new Color(
                secondMushroomEmissionStart.r,
                secondMushroomEmissionStart.g,
                Mathf.Lerp(secondMushroomEmissionStart.b, secondMushroomEmissionEnd.b, t),
                secondMushroomEmissionStart.a
            );
            secondMushroomMaterial.SetColor("_EmissionColor", currentSecondMushroomEmission);

            if (timer >= fadeDuration)
            {
                fading = false;
            }
        }
    }
}

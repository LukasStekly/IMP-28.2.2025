using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTub : MonoBehaviour
{
    public Transform waterSurface;
    public float fillSpeed = 0.1f;
    public float maxHeight = 1.0f;
    bool isFilling = false;
    public ParticleSystem steam;
    public GameObject steam_mirror, mirror, tap, water;

     bool tapRotated = false; // pro kontrolu, zda byl kohoutek otoèen
     bool steamStarted = false; // pro kontrolu, zda již byl efekt páry spuštìn

    void Start()
    {
        // Inicializace stavu
        steam.Stop(); // Zastaví efekt páry na zaèátku
        mirror.SetActive(true);
        steam_mirror.SetActive(false);
        water.SetActive(false);
    }

    void Update()
    {
        if (isFilling && waterSurface.position.y < maxHeight)
        {
            // Plnìní vany
            waterSurface.position += new Vector3(0, fillSpeed * Time.deltaTime, 0);

            if (steam.isPlaying)
            {
                steam.Stop(); // Zastaví páru bìhem plnìní
            }
        }
        else if (isFilling && waterSurface.position.y >= maxHeight)
        {
            // Konec plnìní
            isFilling = false;

            if (!steamStarted)
            {
                steam.Play(); // Spustí efekt páry
                steamStarted = true; // Zajistí, že pára se spustí pouze jednou
            }

            mirror.SetActive(false);
            water.SetActive(false);
            steam_mirror.SetActive(true); // Ukáže zrcadlo s párou
        }
    }

    private void RotateTap()
    {
        if (!tapRotated)
        {
            tap.transform.Rotate(0, 0, 90); // Otoèí kohoutek o 90 stupòù
            tap.transform.Translate(4, 0, 4, 0);
            tapRotated = true;
        }
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RotateTap();
                StartFilling();

                // Aktivace pøíslušných objektù
                mirror.SetActive(true);
                steam_mirror.SetActive(false);
                water.SetActive(true);

                steamStarted = false; // Reset efektu páry
            }
        }
    }

    public void StartFilling()
    {
        isFilling = true;
    }
}


using UnityEngine;
using Cinemachine;
using System.Diagnostics;

public class FreezeCameraOnCtrl : MonoBehaviour
{
    public CinemachineFreeLook thirdPersonCamera; // Reference na Cinemachine kameru

    private bool isCameraFrozen = false; // Stav, zda je kamera zamrzlá

    void Update()
    {
        // Detekce stisknutí a uvolnìní klávesy Ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            FreezeCamera(true); // Zamrzne kameru a zobrazí kurzor
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            FreezeCamera(false); // Uvolní kameru a skryje kurzor
        }
    }

    void FreezeCamera(bool freeze)
    {
        if (thirdPersonCamera != null)
        {
            isCameraFrozen = freeze;

            if (freeze)
            {
                // Zamrzne kameru
                thirdPersonCamera.m_XAxis.m_InputAxisName = ""; // Zastaví pohyb na ose X
                thirdPersonCamera.m_YAxis.m_InputAxisName = ""; // Zastaví pohyb na ose Y

                // Zobrazí kurzor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // Uvolní kameru
                thirdPersonCamera.m_XAxis.m_InputAxisName = "Mouse X"; // Obnoví pohyb na ose X
                thirdPersonCamera.m_YAxis.m_InputAxisName = "Mouse Y"; // Obnoví pohyb na ose Y

                // Skryje kurzor
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        else
        {
            
        }
    }
}

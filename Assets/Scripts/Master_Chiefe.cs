using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Chiefe : MonoBehaviour
{
    public Animator Chief_Anim;
    private bool point = false;

    // Tato metoda je vol�na, kdy� chce� spustit animaci.
    public void Animation()
    {
        if (!point) // Pokud animace je�t� neprob�h�
        {
            point = true;
            Chief_Anim.SetBool("Point", true);
            // Spust�me korutinu pro resetov�n� animace po 2 sekund�ch
            StartCoroutine(ResetAnimation());
        }
    }

    // Korutina, kter� po�k� 2 sekundy a resetuje animaci
    private IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(2f); // Po�k�me 2 sekundy
        Chief_Anim.SetBool("Point", false);
        point = false; // Resetov�n� stavu
    }
}

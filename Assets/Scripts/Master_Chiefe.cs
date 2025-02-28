using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_Chiefe : MonoBehaviour
{
    public Animator Chief_Anim;
    private bool point = false;

    // Tato metoda je volána, když chceš spustit animaci.
    public void Animation()
    {
        if (!point) // Pokud animace ještì neprobíhá
        {
            point = true;
            Chief_Anim.SetBool("Point", true);
            // Spustíme korutinu pro resetování animace po 2 sekundách
            StartCoroutine(ResetAnimation());
        }
    }

    // Korutina, která poèká 2 sekundy a resetuje animaci
    private IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(2f); // Poèkáme 2 sekundy
        Chief_Anim.SetBool("Point", false);
        point = false; // Resetování stavu
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstraktista luokasta ei voi luoda olioita. Sen sijaan luokasta pitää periyttää
// ei-abstrakti luokka, josta oliot luodaan.

// RequireComponent attribuutilla voidaan kertoa Unitylle, että Spaceship
// on riippuvainen Mover-komponentista
[RequireComponent(typeof(Mover))]
public abstract class Spaceship : MonoBehaviour
{
    // Jäsenmuuttuja, jonka tyyppi on Mover ja nimi mover.
    private Mover mover;

    // Taulukollinen ase-olioita. Tähän taulukkoon tallennataan viittaukset
    // kaikista aluksen aseista.
    private Weapon[] weapons;

    // Protected-määritteen vuoksi tämä property on luettavissa lapsiluokista.
    // Koska setteriä ei ole määritetty, Moverin arvoa ei voi muuttaa lapsiluokasta.
    protected Mover Mover
    {
        get { return mover; }
    }

    // Protected-määritteellä metodi näkyy lapsiluokille
    protected void Awake()
    {
        // Hakee Mover-tyyppista samasta GameObjectista, johon tämä
        // PlayerSpaceship-komponentti on kytketty.
        mover = GetComponent<Mover>();

        // Haetaan viittaukset kaikkiin ase-olioihin, jotka on liitetty tähän
        // GameObjectiin ja sen lapsiin.
        weapons = GetComponentsInChildren<Weapon>();
    }

    protected void Shoot()
    {
        // For-silmukka käy läpi kaikki weapons-taulukkoon tallennetut aseet.
        // Taulukon indeksointi alkaa nollasta. Ensimmäisen alkion indeksi on
        // siis nolla.
        for (int i = 0; i < weapons.Length; i++)
        {
            Weapon weapon = weapons[i];
            weapon.Shoot();
        }
    }
}

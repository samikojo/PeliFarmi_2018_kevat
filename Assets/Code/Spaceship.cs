using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstraktista luokasta ei voi luoda olioita. Sen sijaan luokasta pitää periyttää
// ei-abstrakti luokka, josta oliot luodaan.

// RequireComponent attribuutilla voidaan kertoa Unitylle, että Spaceship
// on riippuvainen Mover-komponentista
[RequireComponent(typeof(Mover), typeof(Health))]
public abstract class Spaceship : MonoBehaviour, IDestroyable
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
        //set { mover = value; }
    }

    // Autoproperty. Kääntäjä generoi muuttujan, johon propertyn arvo
    // tallennetaan, automaattisesti.
    public Health HitPoints
    {
        get;
        protected set;
    }

    // Protected-määritteellä metodi näkyy lapsiluokille
    protected void Awake()
    {
        // Hakee Mover-tyyppista samasta GameObjectista, johon tämä
        // PlayerSpaceship-komponentti on kytketty.
        mover = GetComponent<Mover>();

        // AddComponent lisää komponentin GameObjectille. 
        // mover = gameObject.AddComponent<Mover>();

        // Haetaan viittaukset kaikkiin ase-olioihin, jotka on liitetty tähän
        // GameObjectiin ja sen lapsiin.
        weapons = GetComponentsInChildren<Weapon>();

        // Haetaan viittaus Health-komponenttiin. Jos komponenttia ei 
        // löydy, lisätään se.
        HitPoints = GetComponent<Health>();
        if (HitPoints == null)
        {
            // Health-komponenttia ei löytynyt, lisätään se. Koska komponentti
            // ei ollut liitetty GameObjectiin, sille ei ole voitu asettaa
            // järkeviä arvoja. Asetetaan ne tässä.
            HitPoints = gameObject.AddComponent<Health>();
            HitPoints.MaxHealth = 150;
            HitPoints.StartingHealth = 100;
        }
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

    // Suoritetaan aluksen tuhoutuessa.
    public void Die()
    {
        // Aluksen tuhoutuessa asetetaan se inaktiiviseksi.
        gameObject.SetActive(false);
    }
}

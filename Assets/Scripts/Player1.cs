using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player1 : MonoBehaviour
{
    #region(Variables)

    #region(Public Variables)
    // Public
    public int m_Health = 100;
    public int m_Shield;
    public int m_Armor;
    public int m_Damage = 10;
    public int GroupedProjectiles = 25;
    public float m_MovementSpeed = 20f;
    public float m_FireDelay = 0.5f;
    public float m_ProjectileSpeed = 50f;
    public GameObject LaserProjectile;

    List<GameObject> m_LaserProjectiles;

    // Power-Up Bools
    public bool damagePlusActive = false;
    public bool movementSpeedPlusActive = false;
    public bool healthUpPlusActive = false;

    #region(Shop Variables)
    // Shop Items
    public bool ShieldPurchased = false;
    public bool ArmorPruchased = false;
    public bool SecondWeaponPurchased = false;
    public GameObject secondWeapon;
    public bool ThirdWeaponPurchased = false;
    public GameObject thirdWeapon;
    #endregion

    // Hazard Bools
    public bool hitGravityWell = false;

    #endregion

    #region(Private Variables)
    // Private
    private Rigidbody2D playerRB;

    #endregion
    #endregion

    #region(Unity Functions)
    // Use this for initialization
    void Start()
    {
        // Gets Rigidbody2D
        playerRB = GetComponent<Rigidbody2D>();

        // Initialise Projectile Pool when the game starts
        m_LaserProjectiles = new List<GameObject>();
        for (int i = 0; i < GroupedProjectiles; i++)
        {
            GameObject LaserProjectiles = (GameObject)Instantiate(LaserProjectile);
            LaserProjectile.SetActive(false);
            m_LaserProjectiles.Add(LaserProjectiles);
        }

        InvokeRepeating("MainShooting", m_FireDelay, m_FireDelay);
    }

    // Update is called once per frame
    void Update()
    {
        secondWeapon.gameObject.SetActive(false);
        thirdWeapon.gameObject.SetActive(false);

        // Activates the GravityRandomiser when Player has collided with a Gravity Well
        if (hitGravityWell == true)
        {
            GravityRandomiser();
        }

        PlayerMovement();
        ExtraWeapons();
    }
    #endregion

    #region(Movement Functions)
    public void PlayerMovement()
    {
        // Move Player Up/Forward
        if (Input.GetKey(KeyCode.W))
        {
            playerRB.AddForce(transform.up * m_MovementSpeed);
        }

        // Move Player Down/Backward
        if (Input.GetKey(KeyCode.S))
        {
            playerRB.AddForce(-transform.up * m_MovementSpeed);
        }

        // Move Player Left
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.AddForce(-transform.right * m_MovementSpeed);
        }

        // Move Player Right
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.AddForce(transform.right * m_MovementSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            MainShooting();
        }
    }
    #endregion

    #region(PowerUps)

    #endregion

    #region(Gravity Function)
    public void GravityRandomiser()
    {
        // Randomises player Gravity to make controls difficult
        playerRB.gravityScale = Random.Range(-6f, 6f);
    }
    #endregion

    #region(Shop Functions)
    public void ExtraWeapons()
    {
        // Activates the Second Weapon and Second Weapon functions when Purchased from the Shop
        if (SecondWeaponPurchased == true)
        {
            secondWeapon.gameObject.SetActive(true);
            SecondWeaponShooting();
        }

        // Activates the Third Weapon and Third Weapon functions when Purchased from the Shop
        if (ThirdWeaponPurchased == true)
        {
            {
                thirdWeapon.gameObject.SetActive(true);
                ThirdWeaponShooting();
            }
        }
    }
    #endregion

    #region(Shooting Functions)
    public void MainShooting()
    {
        for (int i = 0; i < m_LaserProjectiles.Count; i++)
        {
            if (!m_LaserProjectiles[i].activeInHierarchy)
            {
                    m_LaserProjectiles[i].transform.position = transform.up * m_ProjectileSpeed * Time.deltaTime;
                    m_LaserProjectiles[i].transform.rotation = transform.rotation;
                    m_LaserProjectiles[i].SetActive(true);
                    break;
            }
        }
    }

    public void SecondWeaponShooting()
    {

    }

    public void ThirdWeaponShooting()
    {

    }
    #endregion
}

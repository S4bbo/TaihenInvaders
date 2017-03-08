using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLaser : MonoBehaviour
{
    #region(Variables)
    // Public
    public float m_RotationSpeed = 100f;

    // Private

    #endregion

    #region(Unity Functions)
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeaponRotation();
    }
    #endregion

    #region(Rotation Function)
    void WeaponRotation()
    {
        transform.Rotate(Vector3.forward * m_RotationSpeed * Time.deltaTime);
    }
    #endregion
}

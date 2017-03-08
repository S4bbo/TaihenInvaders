using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTiles : MonoBehaviour
{
    #region(Variables)
    // Public
    public MeshRenderer meshRenderer;

    // Private

    #endregion

    #region(Unity Functions)
    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollSpeed = Time.time * 0.5f;
        meshRenderer.material.mainTextureOffset = new Vector3(0, -scrollSpeed, 0);
    }
    #endregion
}

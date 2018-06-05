using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public bool isSelected;
  //  public bool isActive;
    public Material originalMaterial;

	// Use this for initialization
	void Start () {
        if (gameObject.GetComponent<Renderer>())
        {
            originalMaterial = gameObject.GetComponent<Renderer>().material;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

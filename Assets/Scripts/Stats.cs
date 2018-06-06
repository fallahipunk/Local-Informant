using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public bool isSelected;
    public float scaleRate = 0.01f;

  //  public bool isActive;
    public Material originalMaterial;

	// Use this for initialization
	void Start () {
        isSelected = false;
        if (gameObject.GetComponent<Renderer>())
        {
            originalMaterial = gameObject.GetComponent<Renderer>().material;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelected){
            transform.localScale += new Vector3(Mathf.Sin(Time.time) *scaleRate , Mathf.Sin(Time.time)*scaleRate ,Mathf.Sin(Time.time)*scaleRate );
        }
            
		
	}
}

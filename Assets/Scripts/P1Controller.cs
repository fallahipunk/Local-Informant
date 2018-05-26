using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour {

    int childArrayValue = 0;
    int childArraySize;
    public int childCounter = 1;
    public Transform[] childs;
    public GameObject[] childObjects;

    public Material activeMaterial;

    void Start()
    {
            // create array containing all children, to be used on the Interactive Objects game object
        childs = gameObject.GetComponentsInChildren<Transform>();
        childArraySize = childs.Length;
        childObjects = new GameObject[childArraySize];

        foreach (Transform trans in childs)
        {
            childArrayValue++;
            childObjects.SetValue(trans.gameObject, childArrayValue - 1);
        }
    }
	
	// Update is called once per frame
	void Update () {
        // player one movement between Interactive Objects;
        if (Input.GetKeyDown(KeyCode.W)){
            childCounter++;

            //cap counter at array size and loop it
            if (childCounter >= childArraySize)
            {
                childCounter = 1;
            }

            if (childCounter < 1)
            {
                childCounter = childArraySize - 1;
            }
            activateObject(childCounter);
        }
        else  if (Input.GetKeyDown(KeyCode.S))
        {
            childCounter--;

            //cap counter at array size and loop it
            if (childCounter >= childArraySize)
            {
                childCounter = 1;
            }

            if (childCounter < 1)
            {
                childCounter = childArraySize - 1;
            }
            activateObject(childCounter);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            childCounter++;

            //cap counter at array size and loop it
            if (childCounter >= childArraySize)
            {
                childCounter = 1;
            }

            if (childCounter < 1)
            {
                childCounter = childArraySize - 1;
            }
            activateObject(childCounter);
      
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            childCounter--;

            //cap counter at array size and loop it
            if (childCounter >= childArraySize)
            {
                childCounter = 1;
            }

            if (childCounter < 1)
            {
                childCounter = childArraySize - 1;
            }
            activateObject(childCounter);

        }


 
     //   Debug.Log("P1 Counter = " + childCounter);
	}

    void activateObject(int index){
        //check of there is a game object in the array corrisponding to a index given
        if(childObjects[index]!= null){
           Material myMaterial = childObjects[index].GetComponent<Renderer>().material;
            if (myMaterial !=null){
                Debug.Log(childObjects[index] + " is now active");
                childObjects[index].GetComponent<Renderer>().material = activeMaterial;
            }
        }
    }

}



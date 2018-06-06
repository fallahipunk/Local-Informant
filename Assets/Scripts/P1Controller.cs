//Player 1 controller script, to be places on the Interactive objects 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{

    //Interactive Objects (children) Vars
    int childArrayValue = 0;
    int childArraySize;
    public int p1ChildCounter = 1;
    public Transform[] p1Childs;
    public GameObject[] p1ChildObjects;
    int p1LastObjectIndex = 1;

    //Matarial Vars

    public string playerNumberString;
    public string activeMaterialString;
    public string selectedMaterialString;


    public Material p1ActiveMaterial;
    public Material p1SelectedMaterial;

    void Start()
    {
        // initiate different parts of material names
        playerNumberString = "-p1";
        activeMaterialString = "-active";
        selectedMaterialString = "-selected";


        // create array containing all children
        p1Childs = gameObject.GetComponentsInChildren<Transform>();
        childArraySize = p1Childs.Length;
        p1ChildObjects = new GameObject[childArraySize];

        foreach (Transform trans in p1Childs)
        {
            childArrayValue++;
            p1ChildObjects.SetValue(trans.gameObject, childArrayValue - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // player one movement between Interactive Objects;

        if (Input.GetKeyDown(KeyCode.W))
        {
            p1LastObjectIndex = p1ChildCounter;


            moveUp();

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            p1LastObjectIndex = p1ChildCounter;


            moveDown();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            p1LastObjectIndex = p1ChildCounter;


            moveUp();
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            p1LastObjectIndex = p1ChildCounter;

            moveDown();
        }


        // -------- Selection Input ------- //

        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.V))
        {
            selectObject(p1ChildCounter);
        }

        //   Debug.Log("P1 Counter = " + childCounter);
    }



    void moveUp()
    {



        p1ChildCounter++;

        //cap counter at array size and loop it
        if (p1ChildCounter >= childArraySize)
        {
            p1ChildCounter = 1;
        }

        if (p1ChildCounter < 1)
        {
            p1ChildCounter = childArraySize - 1;
        }

        //Skip Selected Objects

        if (p1ChildObjects[p1ChildCounter].GetComponent<Stats>() != null)
        {
            if (p1ChildObjects[p1ChildCounter].GetComponent<Stats>().isSelected == true)
            {
                if (gameObject.GetComponent<SelectionManager>().allSelected != true)
                {
                    moveUp();
                }
            }
            else
            {
                //activate next unselected object
                activateObject(p1ChildCounter);
            }
        }



    }

    void moveDown()
    {

        p1ChildCounter--;

        //cap counter at array size and loop it
        if (p1ChildCounter >= childArraySize)
        {
            p1ChildCounter = 1;
        }

        if (p1ChildCounter < 1)
        {
            p1ChildCounter = childArraySize - 1;
        }

        if (p1ChildObjects[p1ChildCounter].GetComponent<Stats>() != null)
        {
            if (p1ChildObjects[p1ChildCounter].GetComponent<Stats>().isSelected == true)
            {
                if (gameObject.GetComponent<SelectionManager>().allSelected != true)
                {
                    moveDown();
                }
            }
            else
            {
                //activate previous unselected object
                activateObject(p1ChildCounter);
            }
        }

    }


    //-----Activate Function -----//

    void activateObject(int index)
    {
        //get the base material name
        string instanceName = p1ChildObjects[index].GetComponent<Stats>().originalMaterial.name;
        string originalMaterialName = instanceName.Remove(instanceName.Length - 11);


        // if last object was not selected retern it to its original material
        if (!p1ChildObjects[p1LastObjectIndex].GetComponent<Stats>().isSelected)
        {
            p1ChildObjects[p1LastObjectIndex].GetComponent<Renderer>().material = p1ChildObjects[p1LastObjectIndex].GetComponent<Stats>().originalMaterial;
        }

        //compose a the full active material name
        string activeMaterialName = originalMaterialName + playerNumberString + activeMaterialString;


        if (Resources.Load(activeMaterialName, typeof(Material)) as Material != null)
        {
            p1ActiveMaterial = Resources.Load(activeMaterialName, typeof(Material)) as Material;
        }

        if (p1ActiveMaterial == null)
        {
            p1ActiveMaterial = p1ChildObjects[index].GetComponent<Renderer>().material = Resources.Load("Red", typeof(Material)) as Material; ;
        }
        p1ChildObjects[index].GetComponent<Renderer>().material = p1ActiveMaterial;

        Debug.Log(activeMaterialName);

    }

    //------- Selection Function -------//

    void selectObject(int index)
    {

        // set the isSelected flag in the Stats component to true
        if (p1ChildObjects[p1ChildCounter].GetComponent<Stats>() != null)
        {
            p1ChildObjects[p1ChildCounter].GetComponent<Stats>().isSelected = true;
        }

        //get the base material name
        string instanceName = p1ChildObjects[index].GetComponent<Stats>().originalMaterial.name;
        string originalMaterialName = instanceName.Remove(instanceName.Length - 11);


        //compose a the full selected material name
        string selectedMaterialName = originalMaterialName + playerNumberString + selectedMaterialString;


        if (Resources.Load(selectedMaterialName, typeof(Material)) as Material != null)
        {
            p1SelectedMaterial = Resources.Load(selectedMaterialName, typeof(Material)) as Material;
        }

        if (p1SelectedMaterial == null || p1ChildObjects[index].GetComponent<Renderer>().material.name == selectedMaterialName + " (Instance)")
        {
            p1SelectedMaterial = p1ChildObjects[index].GetComponent<Renderer>().material = Resources.Load("Red", typeof(Material)) as Material; ;
        }

        p1ChildObjects[index].GetComponent<Renderer>().material = p1SelectedMaterial;


        Debug.Log(selectedMaterialName);

    }
}
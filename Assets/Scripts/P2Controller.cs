//Player 2 controller script, to be placed on the Interactive objects Game Object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Controller : MonoBehaviour
{

    //Interactive Objects (children) Vars
    int childArrayValue = 0;
    int childArraySize;
    public int p2ChildCounter = 1;
    public Transform[] p2Childs;
    public GameObject[] p2ChildObjects;
    int p2LastObjectIndex = 1;

    //Matarial Vars

    public string playerNumberString;
    public string activeMaterialString;
    public string selectedMaterialString;


    public Material p2ActiveMaterial;
    public Material p2SelectedMaterial;

    void Start()
    {
        // initiate different parts of material names
        playerNumberString = "-p2";
        activeMaterialString = "-active";
        selectedMaterialString = "-selected";


        // create array containing all children
        p2Childs = gameObject.GetComponentsInChildren<Transform>();
        childArraySize = p2Childs.Length;
        p2ChildObjects = new GameObject[childArraySize];

        //start child counter at end of array
        p2ChildCounter = childArraySize - 1;

        foreach (Transform trans in p2Childs)
        {
            childArrayValue++;
            p2ChildObjects.SetValue(trans.gameObject, childArrayValue - 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // player one movement between Interactive Objects;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            p2LastObjectIndex = p2ChildCounter;


            moveUp();

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            p2LastObjectIndex = p2ChildCounter;


            moveDown();
        }

        // -------- Selection Input ------- //

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectObject(p2ChildCounter);
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectObject2(p2ChildCounter);
        }


  
    }



    void moveUp()
    {



        p2ChildCounter++;

        //cap counter at array size and loop it
        if (p2ChildCounter >= childArraySize)
        {
            p2ChildCounter = 1;
        }

        if (p2ChildCounter < 1)
        {
            p2ChildCounter = childArraySize - 1;
        }

        //Skip Selected Objects

        if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>() != null)
        {
            //if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>().isSelected == true)
            //{
            //    if (gameObject.GetComponent<SelectionManager>().allSelected != true)
            //    {
            //        moveUp();
            //    }
            //}
            //else
            //{
                //activate next unselected object
                activateObject(p2ChildCounter);
           // }
        }



    }

    void moveDown()
    {

        p2ChildCounter--;

        //cap counter at array size and loop it
        if (p2ChildCounter >= childArraySize)
        {
            p2ChildCounter = 1;
        }

        if (p2ChildCounter < 1)
        {
            p2ChildCounter = childArraySize - 1;
        }

        //if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>() != null)
        //{
            ////if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>().isSelected == true)
            ////{
            //    //if (gameObject.GetComponent<SelectionManager>().allSelected != true)
            //    //{
            //        moveDown();
            //  //  }
            //}
            //else
            //{
                //activate previous unselected object
                activateObject(p2ChildCounter);
        //    }
        //}

    }


    //-----Activate Function -----//

    void activateObject(int index)
    {

        p2ChildObjects[p2LastObjectIndex].GetComponent<Outline>().enabled = false;


        p2ChildObjects[index].GetComponent<Outline>().enabled = true;



    }

    //------- Selection Function -------//

    void selectObject(int index)
    {

        // set the isSelected flag in the Stats component to true
        if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>() != null)
        {
            p2ChildObjects[p2ChildCounter].GetComponent<Stats>().isSelected = true;
        }

        //get the base material name
        string instanceName = p2ChildObjects[index].GetComponent<Stats>().originalMaterial.name;
        string originalMaterialName = instanceName.Remove(instanceName.Length - 11);


        //compose a the full selected material name
        string selectedMaterialName = originalMaterialName + playerNumberString + selectedMaterialString;


        if (Resources.Load(selectedMaterialName, typeof(Material)) as Material != null)
        {
            p2SelectedMaterial = Resources.Load(selectedMaterialName, typeof(Material)) as Material;
        }

        if (p2SelectedMaterial == null || p2ChildObjects[index].GetComponent<Renderer>().material.name == selectedMaterialName + " (Instance)")
        {
            p2SelectedMaterial = p2ChildObjects[index].GetComponent<Renderer>().material = Resources.Load("Red", typeof(Material)) as Material; ;
        }

        p2ChildObjects[index].GetComponent<Renderer>().material = p2SelectedMaterial;


        Debug.Log(selectedMaterialName);

    }

    void selectObject2(int index)
    {

        // set the isSelected flag in the Stats component to true
        if (p2ChildObjects[p2ChildCounter].GetComponent<Stats>() != null)
        {
            p2ChildObjects[p2ChildCounter].GetComponent<Stats>().isSelected = true;
        }

        //get the base material name
        string instanceName = p2ChildObjects[index].GetComponent<Stats>().originalMaterial.name;
        string originalMaterialName = instanceName.Remove(instanceName.Length - 11);


        //compose a the full selected material name
        string selectedMaterialName = originalMaterialName + playerNumberString + activeMaterialString;


        if (Resources.Load(selectedMaterialName, typeof(Material)) as Material != null)
        {
            p2SelectedMaterial = Resources.Load(selectedMaterialName, typeof(Material)) as Material;
        }

        if (p2SelectedMaterial == null || p2ChildObjects[index].GetComponent<Renderer>().material.name == selectedMaterialName + " (Instance)")
        {
            p2SelectedMaterial = p2ChildObjects[index].GetComponent<Renderer>().material = Resources.Load("Red", typeof(Material)) as Material; ;
        }

        p2ChildObjects[index].GetComponent<Renderer>().material = p2SelectedMaterial;


        Debug.Log(selectedMaterialName);

    }
}
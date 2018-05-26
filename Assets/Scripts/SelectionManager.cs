using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public bool allSelected;

    public int lvl;

    int childArrayValue2 = 0;
    int childArraySize2;
    public int childCounter2 = 1;
    public Transform[] childs2;
    public GameObject[] childObjects2;


    void Start()
    {
     

        // create array containing all children, to be used on the Interactive Objects game object
        childs2 = gameObject.GetComponentsInChildren<Transform>();
        childArraySize2 = childs2.Length;
        childObjects2 = new GameObject[childArraySize2];

        foreach (Transform trans in childs2)
        {
            childArrayValue2++;
            childObjects2.SetValue(trans.gameObject, childArrayValue2 - 1);
        }
    }

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            allSelected = IsAllSelected();
            Debug.Log(allSelected);
            if(allSelected == true){
                if (lvl !=null){
                    Application.LoadLevel(lvl);
                }
                else{
                    Application.LoadLevel(0);
                }
            }
        }

	}

    private bool IsAllSelected()
    {
        for (int i = 0; i < childObjects2.Length; ++i)
        {
            if (childObjects2[i].GetComponent<Stats>().isSelected == false){
                return false;
            }
     
        }

        return true;
    }

}

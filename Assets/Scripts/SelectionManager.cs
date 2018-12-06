using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour
{
    public Transform BgPrefab;
    private bool BgVisable;

    public int lvl;

    public bool allSelected;

   

    // children vars (children of Interactive Objects)
    int childArrayValue2 = 0;
    int childArraySize2;
    public int childCounter2 = 1;
    public Transform[] childs2;
    public GameObject[] childObjects2;


    void Start()
    {
        Cursor.visible = false;

        BgVisable = false;

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
    void Update()
    {
        

            allSelected = AreAllSelected();
            // Debug.Log(allSelected);
            if (allSelected)
            {
                ShowBG();
            }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.S))
            {

                if (allSelected)
                {

                    SceneManager.LoadScene(lvl);

                }
            }


    }

        private bool AreAllSelected()
        {
            for (int i = 0; i < childObjects2.Length; ++i)
            {
                if (childObjects2[i].GetComponent<Stats>())
                {
                    if (childObjects2[i].GetComponent<Stats>().isSelected == false)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        void ShowBG()
        {
        if (BgPrefab != null && BgVisable == false)
        {
            Instantiate(BgPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            BgVisable = true;
        }
        }

    }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSlice : MonoBehaviour
{

    public GameObject slicePrefab;
    public GameObject manager;
    public GameObject wheelPlaceholder;
    
    //Button methods for adding new slices.
    public void AddBlackButton()
    {
        GameObject black = Instantiate(slicePrefab,wheelPlaceholder.transform);
        black.name = "Black";
        black.GetComponent<Slice>().SliceSetup(Color.black, "Black", 1);
        manager.GetComponent<WheelManager>().AddSlice(black);
    }
    
    public void AddYellowButton()
    {
        GameObject yellow = Instantiate(slicePrefab, wheelPlaceholder.transform);
        yellow.name = "Yellow";
        yellow.GetComponent<Slice>().SliceSetup(Color.yellow, "Yellow", 1);
        manager.GetComponent<WheelManager>().AddSlice(yellow);
    }
}

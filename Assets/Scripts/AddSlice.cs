using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddSlice : MonoBehaviour
{

    public GameObject slicePrefab;
    public GameObject manager;
    public GameObject wheelPlaceholder, customPanel;
    public TMP_InputField valueInput;
    public TMP_Text colorInput;

    public void AddBlackButton()
    {
        GameObject black = Instantiate(slicePrefab,wheelPlaceholder.transform);
        black.name = "Black";
        black.GetComponent<Slice>().SliceSetup(Color.black, "Black", 1);
        manager.GetComponent<WheelManager>().AddSlice(black);
    }
    public void Back()
    {
        customPanel.SetActive(false);
    }
    public void CustomPanel()
    {
        customPanel.SetActive(true);
    }
    public void AddYellowButton()
    {
        GameObject yellow = Instantiate(slicePrefab, wheelPlaceholder.transform);
        yellow.name = "Yellow";
        yellow.GetComponent<Slice>().SliceSetup(Color.yellow, "Yellow", 1);
        manager.GetComponent<WheelManager>().AddSlice(yellow);
    }
    public void AddCustomButton()
    {
        string color = colorInput.text;
        string value = valueInput.text;
        switch (color)
        {
            case "Black":
                GameObject black = Instantiate(slicePrefab, wheelPlaceholder.transform);
                black.name = value;
                black.GetComponent<Slice>().SliceSetup(Color.black, value, 1);
                manager.GetComponent<WheelManager>().AddSlice(black);
                break;
            case "Blue":
                GameObject blue = Instantiate(slicePrefab, wheelPlaceholder.transform);
                blue.name = value;
                blue.GetComponent<Slice>().SliceSetup(Color.blue, value, 1);
                manager.GetComponent<WheelManager>().AddSlice(blue);
                break;
            case "Brown":
                GameObject brown = Instantiate(slicePrefab, wheelPlaceholder.transform);
                brown.name = value;
                brown.GetComponent<Slice>().SliceSetup(new Color32(150, 75, 0,255), value, 1);
                manager.GetComponent<WheelManager>().AddSlice(brown);
                break;
            case "Green":
                GameObject green = Instantiate(slicePrefab, wheelPlaceholder.transform);
                green.name = value;
                green.GetComponent<Slice>().SliceSetup(Color.green, value, 1);
                manager.GetComponent<WheelManager>().AddSlice(green);
                break;
            case "Orange":
                GameObject orange = Instantiate(slicePrefab, wheelPlaceholder.transform);
                orange.name = value;
                orange.GetComponent<Slice>().SliceSetup(new Color32(255, 165, 0,255), value, 1);
                manager.GetComponent<WheelManager>().AddSlice(orange);
                break;
            case "Pink":
                GameObject pink = Instantiate(slicePrefab, wheelPlaceholder.transform);
                pink.name = value;
                pink.GetComponent<Slice>().SliceSetup(new Color32(255, 192, 203,255), value, 1);
                manager.GetComponent<WheelManager>().AddSlice(pink);
                break;
            case "Purple":
                GameObject purple = Instantiate(slicePrefab, wheelPlaceholder.transform);
                purple.name = value;
                purple.GetComponent<Slice>().SliceSetup(new Color32(159, 43, 104, 255), value, 1);
                manager.GetComponent<WheelManager>().AddSlice(purple);
                break;
            case "Red":
                GameObject red = Instantiate(slicePrefab, wheelPlaceholder.transform);
                red.name = value;
                red.GetComponent<Slice>().SliceSetup(Color.red, value, 1);
                manager.GetComponent<WheelManager>().AddSlice(red);
                break;
            case "Yellow":
                GameObject yellow = Instantiate(slicePrefab, wheelPlaceholder.transform);
                yellow.name = value;
                yellow.GetComponent<Slice>().SliceSetup(Color.yellow, value, 1);
                manager.GetComponent<WheelManager>().AddSlice(yellow);
                break;
            default:
                break;
        }
    }
}

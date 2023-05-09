using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    //Obselete private Dictionary<int,GameObject> _slices = new Dictionary<int,GameObject>();
    private List<GameObject> _slicesProto = new List<GameObject>();
    private int _sliceCounter = 0;
    private float _sliceAngle;
    private float _fillAmount = 1f;
    public GameObject slicePrefab;
    public GameObject wheelPlaceholder;
    bool setupDelete = false;
    void Start()
    {
        Setup();
        ArrangeSlices();
        
    }

    //Inserts 2 slices for starting point.
    void Setup()
    {
        GameObject black = Instantiate(slicePrefab, wheelPlaceholder.transform);
        _slicesProto.Add(black);
        _sliceCounter++;
        GameObject yellow = Instantiate(slicePrefab,wheelPlaceholder.transform);
        _slicesProto.Add(yellow);
        _sliceCounter++;
        black.name = "Black";
        black.GetComponent<Slice>().SliceSetup(Color.black, "Black", 1);
        yellow.name = "Yellow";
        yellow.GetComponent<Slice>().SliceSetup(Color.yellow, "Yellow", 1);
    }

    //Arranges Slice properties.
    void ArrangeSlices()
    {
        Debug.Log("a**************************");
        _sliceAngle = 360 / (float)_slicesProto.Count;
        Debug.Log("Slice Angle: "+_sliceAngle);
        _fillAmount /= _slicesProto.Count();
        int sliceAmount = _slicesProto.Count;
        Debug.Log("slice Amount: " + sliceAmount);
        //_slices[0].GetComponent<Slice>().fillAmount = _fillAmount;

        foreach (var slice in _slicesProto.Select((slice,index) => (slice,index)))
        {
            if (slice.index != 0 && setupDelete == false){
                slice.slice.GetComponent<Slice>().fillAmount = _fillAmount;
                slice.slice.transform.eulerAngles = new Vector3(0, 0, (_slicesProto[slice.index - 1].transform.rotation.eulerAngles.z - _sliceAngle));
            }
            if(slice.index == 0)
            {
                slice.slice.GetComponent<Slice>().fillAmount = _fillAmount;
            }
            else if(setupDelete == true && slice.index !=0)
            {
                slice.slice.GetComponent<Slice>().fillAmount = _fillAmount;
                slice.slice.transform.eulerAngles = new Vector3(0, 0, (_slicesProto[slice.index - 1].transform.rotation.eulerAngles.z - _sliceAngle));
            }
        }
        if (sliceAmount == 4 && setupDelete == false)
        {
            _slicesProto.Remove(_slicesProto[0]);
            Destroy(GameObject.Find("Black"));
            _slicesProto.Remove(_slicesProto[0]);
            Destroy(GameObject.Find("Yellow"));
            _fillAmount = 1f;
            setupDelete = true;
            Debug.Log("List length: "+_slicesProto.Count);
            Debug.Log("b**************************");
            _slicesProto[0].transform.eulerAngles = new Vector3(0, 0, 0);
            ArrangeSlices();
            return;
        }
        Debug.Log("c**************************");
    }

    //Adds new Slices.
    public void AddSlice(GameObject slice)
    {

        _fillAmount = 1;
        //Obselete _slices.Add(_sliceCounter,slice);
        _slicesProto.Add(slice);
        _sliceCounter++;
        ArrangeSlices();
    }

}

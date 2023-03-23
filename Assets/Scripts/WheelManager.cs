using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    private Dictionary<int,GameObject> _slices = new Dictionary<int,GameObject>();
    private int _sliceCounter = 0;
    private float _sliceAngle;
    private float _fillAmount = 1f;
    public GameObject slicePrefab;
    public GameObject wheelPlaceholder;
    void Start()
    {
        Setup();
        ArrangeSlices();
        
    }

    //Inserts 2 slices for starting point.
    void Setup()
    {
        GameObject black = Instantiate(slicePrefab, wheelPlaceholder.transform);
        _slices.Add(_sliceCounter,black);
        _sliceCounter++;
        GameObject yellow = Instantiate(slicePrefab,wheelPlaceholder.transform);
        _slices.Add(_sliceCounter, yellow);
        _sliceCounter++;
        black.name = "Black";
        black.GetComponent<Slice>().SliceSetup(Color.black, "Black", 1);
        yellow.name = "Yellow";
        yellow.GetComponent<Slice>().SliceSetup(Color.yellow, "Yellow", 1);
    }

    //Arranges Slice properties.
    void ArrangeSlices()
    {
        _sliceAngle = 360 / (float)_slices.Count;
        _fillAmount /= _slices.Count;
        _slices[0].GetComponent<Slice>().fillAmount = _fillAmount;
        foreach (var slice in _slices)
        {
            if (slice.Key != 0){
                slice.Value.GetComponent<Slice>().fillAmount = _fillAmount;
                slice.Value.transform.eulerAngles = new Vector3(0, 0, (_slices[slice.Key - 1].transform.rotation.eulerAngles.z - _sliceAngle));
            }
        }
    }

    //Adds new Slices.
    public void AddSlice(GameObject slice)
    {
        _fillAmount = 1;
        _slices.Add(_sliceCounter,slice);
        _sliceCounter++;
        ArrangeSlices();
    }

}

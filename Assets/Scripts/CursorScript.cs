using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField]private string _resultValue;
    //For returning last value on the cursor.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.GetComponent<Slice>().sliceValue);
        _resultValue = collision.gameObject.GetComponent<Slice>().sliceValue;

    }
    public string GetResultValue()
    {
        return _resultValue;
    }
}

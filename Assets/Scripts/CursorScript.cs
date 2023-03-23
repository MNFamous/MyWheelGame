using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField]private string _resultValue;
    public AudioSource clickSound;
    private void Start()
    {
        clickSound = this.GetComponent<AudioSource>();
    }
    //For returning last value on the cursor.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.GetComponent<Slice>().sliceValue);
        _resultValue = collision.gameObject.GetComponent<Slice>().sliceValue;
        clickSound.Play();
    }
    public string GetResultValue()
    {
        return _resultValue;
    }
}

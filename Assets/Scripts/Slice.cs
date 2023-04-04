using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slice : MonoBehaviour
{
    private bool _setupCondition= false, _audioCondition= false;
    private GameObject _prefab;
    public string sliceValue;
    public float fillAmount;
    public Color fillColor;
    AudioSource clickSound;
    RaycastHit2D hit;

    public void SliceSetup(Color fillColor, string value, float fillAmount)
    {
        this.sliceValue = value;
        this.fillColor = fillColor;
        this.fillAmount = fillAmount;
        _setupCondition = true;
    }

    private void Start()
    {
        clickSound = this.GetComponent<AudioSource>();
        _prefab = this.gameObject;
        StartCoroutine(SliceSetupCheck());
    }

    //Checks if all values are not null
    IEnumerator SliceSetupCheck()
    {
        yield return new WaitUntil(() => _setupCondition == true);
        _prefab.GetComponent<Image>().fillAmount = fillAmount;
        _prefab.GetComponent<Image>().color = fillColor;
    }
    private void Update()
    {
        _prefab.GetComponent<Image>().fillAmount = fillAmount;
        _prefab.GetComponent<Image>().color = fillColor;
        if (Physics2D.Linecast(this.transform.position, transform.TransformDirection(Vector3.up)).collider != null && _audioCondition == false)
        {
            PlayAudio();
            hit = Physics2D.Linecast(this.transform.position, transform.TransformDirection(Vector3.up));
            Debug.Log(hit.collider.tag);
            _audioCondition = true;
        }
        else
        {
            _audioCondition = false;
        }
    }

    void PlayAudio()
    {

        clickSound.Play();

    }
}


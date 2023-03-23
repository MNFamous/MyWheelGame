using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class SpinScript : MonoBehaviour
{
    [SerializeField]private float _rotationSpeed;
    [SerializeField]private bool _isTurning = false;
    [SerializeField] private bool _spamIncrement;
    [SerializeField] private bool _cooldownStart = false;
    private CursorScript _resultValue;
    private TextMeshProUGUI _resultText;
    private Rigidbody2D _rb;
    private float _zRotation;
    public GameObject wheelPlaceholder, cursor, resultLabel;
    public float buttonCooldown,spamTorque; 
    private void Awake()
    {
        _rb = wheelPlaceholder.GetComponent<Rigidbody2D>();
        _resultValue = cursor.GetComponent<CursorScript>();
        _resultText = resultLabel.GetComponent<TextMeshProUGUI>();
    }

    //Start spinning.
    public void Spin()
    {
        _rotationSpeed = Random.Range(10, 30);
        StartCoroutine(SpinControl());
    }

    //When wheel stops gets last value on the cursor
    private void FixedUpdate()
    {
        if (_zRotation == wheelPlaceholder.transform.eulerAngles.z)
        {
            _isTurning = false;
            _resultText.text = _resultValue.GetResultValue();
        }
        _zRotation = wheelPlaceholder.transform.eulerAngles.z;
    }

    //Button spam cooldown
    IEnumerator CoolDown()
    {
        _spamIncrement = true;
        yield return new WaitForSeconds(buttonCooldown);
        _isTurning = true;
        _spamIncrement = false;
        _cooldownStart = false;
    }
    //Spinning the wheel.
    IEnumerator SpinControl()
    {
        if( _spamIncrement == true)
        {
            _rb.AddTorque(spamTorque, ForceMode2D.Impulse);
        }
        if (_isTurning == false && _spamIncrement == false)
        {
            _rb.AddTorque(_rotationSpeed, ForceMode2D.Impulse);
        }
        if ( _cooldownStart == false && _isTurning == false)
        {
            StartCoroutine(CoolDown());
            _cooldownStart = true;
        }
        yield return null;
    }
}

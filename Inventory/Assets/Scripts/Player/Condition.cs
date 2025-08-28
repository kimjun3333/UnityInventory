using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public event Action<float> OnValueChanged;

    [SerializeField] private float maxValue;
    [SerializeField] private float minValue;
    [SerializeField] private float curValue;

    public float MaxValue => maxValue;
    public float MinValue => minValue;
    public float CurValue
    {
        get => curValue;
        set
        {
            curValue = value;
            OnValueChanged?.Invoke(curValue);
        }
    }

    public void Add(float value)
    {
        CurValue = Mathf.Clamp(curValue + value, minValue , maxValue);
    }

    public void Subtract(float value)
    {
        CurValue = Mathf.Clamp(curValue - value, minValue, maxValue);
    }
}

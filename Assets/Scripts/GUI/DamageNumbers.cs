using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

public class DamageNumbers : MonoBehaviour
{
    public int Number;
    
    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    private List<GameObject> Numbers = new List<GameObject>();
    [SerializeField] private GameObject DamageNumberPrefab;
    [SerializeField] private Vector3 DamageNumberOffset;
    [SerializeField] private Vector3 MasterOffset;

    [SerializeField] private float ScaleSinTime;
    [SerializeField] private float ScaleSinPower;
    [SerializeField] private float DefaultScale;
    
    [SerializeField] private float RotationSinTime;
    [SerializeField] private float RotationSinPower;
    
    private Vector3 CurrentOffset;
    
    private Stack<int> digits = new Stack<int>();
    
    private void Start()
    {
        ShowNumbers(Number);
    }

    private IEnumerator FadeOut()
    {
        for(float a = 1f; a > 0f; a -= 0.1f) 
        {
            <SpriteRenderer>().color = new Color(1, 1, 1, a);

            yield return null;
        }
    }
    
    private void Update()
    {
        transform.localScale = Vector3.one * (Math.Abs(Mathf.Sin(Time.time * ScaleSinTime) * ScaleSinPower) + DefaultScale);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * RotationSinTime) * RotationSinPower);
    }
 
    public void ShowNumbers(int number)
    {
        DecypherNumber(number);
        
        Numbers.Clear();
        
        CurrentOffset = MasterOffset;

        foreach (int digit in digits)
        {
            GameObject damageNumber = Instantiate(DamageNumberPrefab, transform, false);
            damageNumber.GetComponent<SpriteRenderer>().sprite = Sprites[digit];

            CurrentOffset += DamageNumberOffset;

            damageNumber.transform.localPosition = CurrentOffset;
            
            Numbers.Add(damageNumber);
        }
        
        StartCoroutine(FadeOut());
    }

    private void DecypherNumber(int number)
    {
        while (number > 0)
        {
            int digit = number % 10;
            number /= 10;
            
            digits.Push(digit);
        }
        
        MasterOffset = Vector3.zero - ((float)digits.Count / 2 * DamageNumberOffset);
    }
}

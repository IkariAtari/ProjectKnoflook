using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class DamageNumbers : MonoBehaviour
{
    public int Number;
    
    [SerializeField] private List<Sprite> Sprites = new List<Sprite>();
    private List<GameObject> Numbers = new List<GameObject>();
    [SerializeField] private GameObject DamageNumberPrefab;
    [SerializeField] private Vector3 DamageNumberOffset;
    [SerializeField] private Vector3 MasterOffset;
    
    [SerializeField] [Range(0f, 5f)] private float RotationSinTime;
    [SerializeField] [Range(0f, 5f)] private float RotationSinPower;

    [SerializeField] private AnimationCurve MovementSpeed;

    [SerializeField] [Range(10f, 100f)] private float TimeScale;
    
    [SerializeField] [Range(0f, 1f)] private float ScaleNoiseConstant;
    [SerializeField] [Range(0f, 20f)] private float MovementNoiseConstant;
    
    [SerializeField] [ReadOnly] private float CurrentTime;
    
    private Vector3 CurrentOffset;
    private bool Active;
    private Stack<int> digits = new Stack<int>();
    
    private float MovementNoise;
    private float ScaleNoise;
    
    private IEnumerator FadeOut()
    {
        for(float a = 1f; a > 0f; a -= 0.1f) 
        {
            yield return null;
        }
    }
    
    private void Update()
    {
        if (!Active)
        {
            return;
        }
        
        if (CurrentTime < 1f)
        {
            transform.localScale = Vector3.one * ScaleNoise;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * RotationSinTime + ScaleNoiseConstant) * RotationSinPower);
            
            transform.position += new Vector3(MovementNoise, MovementSpeed.Evaluate(CurrentTime) + MovementNoise / 10, 0f) * Time.deltaTime;
            
            CurrentTime += 1f / TimeScale;
        }
        else
        {
            Destroy(gameObject);
        }
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

        ScaleNoise = Random.Range(1f - ScaleNoiseConstant, 1 + ScaleNoiseConstant);
        MovementNoise = Random.Range(-MovementNoiseConstant, MovementNoiseConstant);
        TimeScale += ScaleNoiseConstant;
        
        Active = true;
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

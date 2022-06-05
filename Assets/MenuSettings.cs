using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : MonoBehaviour
{
    public GameObject menu;

    [SerializeField] string category;
    [SerializeField] string difficulty;


    async void Start()
    {
        

    }
    public void SetCategory(string value)
    {
        category = value;
    }
    public void SetDifficulty(string value)
    {
        difficulty = value;
    }
}

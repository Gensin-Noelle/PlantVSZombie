using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance { get; private set; }
    private readonly Dictionary<Plant, Vector2> plantSet = new();

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //PeashooterShoot();
    }

    public void AddPlant(Plant plant, Vector2 index)
    {
        plantSet.Add(plant, index);
    }

    public void RemovePlant(Plant plant)
    {
        plantSet.Remove(plant);
    }

    public Dictionary<Plant, Vector2> GetPlantSet()
    {
        return plantSet;
    }

}

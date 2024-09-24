using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager Instance { get; private set; }
    public List<Plant> plantPrefabList;
    private Plant currentPlant;
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        FollowCursor();
    }

    public bool AddPlant(PlantType plantType)
    {
        if(currentPlant != null) return false; //当已经有植物时，返回false，即种植失败
        Plant plantPrefab = GetPlantPrefab(plantType);
        if (plantPrefab == null)
        {
            Debug.Log("要种植的植物:" + plantType.ToString() + "不存在植物预设体列表中,请先添加");
            return false;
        }
        currentPlant = Instantiate(plantPrefab);
        return true; //种植成功
    }

    private Plant GetPlantPrefab(PlantType plantType)
    {
        foreach (Plant plant in plantPrefabList)
        {
            if (plant.plantType == plantType) return plant;
        }
        return null;
    }

    //鼠标跟随
    private void FollowCursor()
    {
        if (currentPlant == null) return;

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPlant.transform.position = mouseWorldPosition;
    }

    public void OnCellClick(Cell cell)
    {
        if(currentPlant == null) return;
        // currentPlant.transform.position = cell.transform.position;
        Vector2 cellIndex = cell.AddPlant(currentPlant);
        if (cellIndex.x != 10) 
        {
            PlantManager.Instance.AddPlant(currentPlant, cellIndex);
            currentPlant = null; //如果种植成功，将当前植物设置为空
        }


    }
}

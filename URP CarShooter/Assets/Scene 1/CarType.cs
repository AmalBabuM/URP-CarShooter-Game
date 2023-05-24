using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarType : MonoBehaviour
{
    public int currentCarIndex=0;
    public GameObject[] carModels;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach(GameObject car in carModels)
        {
            car.SetActive(false);
        }
        carModels[currentCarIndex].SetActive(true);
    }

    
    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex++;
        if(currentCarIndex == carModels.Length)
        {
            currentCarIndex= 0;
        }
        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }
    public void ChangePrevious()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex--;
        if (currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length-1;
        }
        carModels[currentCarIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelection : MonoBehaviour
{
    public int currentGunIndex = 0;
    public GameObject[] gunModels;
    // Start is called before the first frame update
    void OnEnable()
    {
        GunButton.onLeftClick += ChangePrevious;
        GunButton.onRightClick += ChangeNext;
        currentGunIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        foreach (GameObject car in gunModels)
        {
            car.SetActive(false);
        }
        gunModels[currentGunIndex].SetActive(true);
    }
    private void OnDisable()
    {
        GunButton.onLeftClick -= ChangePrevious;
        GunButton.onRightClick -= ChangeNext;
    }


    public void ChangeNext()
    {
        gunModels[currentGunIndex].SetActive(false);
        currentGunIndex++;
        if (currentGunIndex == gunModels.Length)
        {
            currentGunIndex = 0;
        }
        gunModels[currentGunIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedGun", currentGunIndex);
    }
    public void ChangePrevious()
    {
        gunModels[currentGunIndex].SetActive(false);
        currentGunIndex--;
        if (currentGunIndex == -1)
        {
            currentGunIndex = gunModels.Length - 1;
        }
        gunModels[currentGunIndex].SetActive(true);
        PlayerPrefs.SetInt("SelectedGun", currentGunIndex);
    }
}

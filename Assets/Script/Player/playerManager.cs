using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    [Header("Energy Component")]
    public float maxEnergy;
    private float baseEnergy;
    public float useEnergy;
    public float regenEnergy;
    public bool energyHasGenerated;

    [Header("Energy UI Component")]
    public float dicreaseSpeed;
    public Image energyBar;
    public Image energyEffect;


    [Header("Reference")]
    playerMove playerMove;

    private void Awake()
    {
        playerMove = GetComponent<playerMove>();
    }

    void Start()
    {
        baseEnergy = maxEnergy;
    }

    void Update()
    {
        #region Energy
        DecreaseEnergy();
        IncreaseEnergy();
        EnergyUI();
        #endregion
    }

    void DecreaseEnergy()
    {
        if (playerMove.isSprint && maxEnergy >= 0)
        {
            maxEnergy -= useEnergy;
        }
    }

    void IncreaseEnergy()
    {
        //best style script
        if (!playerMove.isSprint && maxEnergy <= baseEnergy)
        {
            baseEnergy += regenEnergy * Time.deltaTime;
            energyHasGenerated = false;
            if (maxEnergy >= baseEnergy)
            {
                energyHasGenerated = true;
            }
        }
    }

    void EnergyUI()
    {
        energyBar.fillAmount = maxEnergy / baseEnergy;
        if (energyEffect.fillAmount > energyBar.fillAmount)
        {
            energyEffect.fillAmount -= dicreaseSpeed * Time.deltaTime;
        }
        else
        {
            energyEffect.fillAmount = energyBar.fillAmount;
        }
    }
}

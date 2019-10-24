using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour {
    [SerializeField] private float manaAmount;
    [SerializeField] private float maxManaAmount;
    [SerializeField] private float regenRate;


    private void Start() {
        manaAmount = maxManaAmount;
    }
    private void Update() {
        manaAmount += regenRate * Time.deltaTime;
        if (manaAmount >= maxManaAmount) {
            manaAmount = maxManaAmount;
        }
    }

    public float getManaAmount() {
        return manaAmount;
    }

    public bool tryToUseMana(float amount) {
        if ((manaAmount - amount) >= 0f) {
            manaAmount -= amount;
            return true;
        } else {
            return false;
        }
    }

    public bool replenishMana(float amount) {
        if (manaAmount >= maxManaAmount) {
            return false;
        } else {
            manaAmount += amount;
            if (manaAmount > maxManaAmount) {
                manaAmount = maxManaAmount;
            }
            return true;
        }
    }

    public float getMaxManaAmount() {
        return maxManaAmount;
    }

    public void setMaxMana(float maxManaAmount) {
        this.maxManaAmount = maxManaAmount;
    }

    public float getRegenRate() {
        return regenRate;
    }

    public void setRegenRate(float regenRate) {
        this.regenRate = regenRate;
    }
}

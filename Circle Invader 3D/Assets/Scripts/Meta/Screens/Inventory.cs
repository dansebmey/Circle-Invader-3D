﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : GmAwareObject
{
    [Range(1,5)] public int maxCapacity;
    [HideInInspector] public List<Powerup> carriedPowerups;
    
    private InventoryInterface _invInterface;

    private int _highlightedItemIndex;

    protected override void Awake()
    {
        base.Awake();
        _invInterface = FindObjectOfType<InventoryInterface>();
    }

    private void Start()
    {
        carriedPowerups = new List<Powerup>();
    }

    public bool AddPowerup(Powerup powerup)
    {
        if (carriedPowerups.Count < maxCapacity)
        {
            carriedPowerups.Add(powerup);
            _invInterface.UpdateItemSlots();
            return true;
        }

        return false;
    }

    public void SelectNextPowerup()
    {
        HighlightedItemIndex++;
    }

    public void SelectPreviousPowerup()
    {
        HighlightedItemIndex--;
    }

    public int HighlightedItemIndex
    {
        get => _highlightedItemIndex;
        set
        {
            if (value < 0)
            {
                value += maxCapacity;
            }
            else if (value >= maxCapacity)
            {
                value -= maxCapacity;
            }
            _highlightedItemIndex = value;

            _invInterface.HighlightItem(_highlightedItemIndex);
        }
    }

    public bool ConsumeSelectedItem()
    {
        if (carriedPowerups.Count == 0) return false;
        
        carriedPowerups[_highlightedItemIndex].OnConsume();
        carriedPowerups.Remove(carriedPowerups[_highlightedItemIndex]);
        _invInterface.UpdateItemSlots();
        return true;
    }
}
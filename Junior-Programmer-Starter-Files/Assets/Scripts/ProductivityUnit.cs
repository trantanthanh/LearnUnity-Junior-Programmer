using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    ResourcePile m_currentPile = null;
    public float productivityMultiplier = 2.0f;
    protected override void BuildingInRange()
    {
        if (m_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_currentPile = pile;
                m_currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }
}

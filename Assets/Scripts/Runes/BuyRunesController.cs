using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Runes
{
    public class BuyRunesController : MonoBehaviour
    {
        public InventoryData inventoryData;
        public RuneType[] runeTypes;
        public RuneRarity runeRarity;
        public int amountOfRunes;

        public void Buy()
        {
            if (amountOfRunes == 0) return;
            for (int i = 0; i < amountOfRunes; i++)
            {
                inventoryData.AddRune(GenerateRandomRune());
            }
        }
        RuneData GenerateRandomRune()
        {
            return new RuneData(RandomType(), runeRarity, 1);
        }
        RuneType RandomType()
        {
            return runeTypes[Random.Range(0, runeTypes.Length)];
        }
    }
}
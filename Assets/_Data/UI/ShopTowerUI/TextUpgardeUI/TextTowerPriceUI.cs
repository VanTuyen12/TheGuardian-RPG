using UnityEngine;

public class TextTowerPriceUI : TextAbstract
{

    public virtual void LoadPriceTower(int price ,string currency)
    {
        txtProUi.text = $"{price} {currency}";
    }
    
}

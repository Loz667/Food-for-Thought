using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerCollectedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(PlayerInteraction player)
    {
        if (!player.HasKitchenOject())
        {
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            OnPlayerCollectedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}

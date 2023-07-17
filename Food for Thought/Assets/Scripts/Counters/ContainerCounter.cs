using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerCollectedObject;

    [SerializeField] private KitchenObjectSO kitchenObject;
    
    public override void Interact(PlayerInteraction player)
    {
        if (!player.HasKitchenOject())
        {
            Transform kitchenObjectTransform = Instantiate(kitchenObject.objectPrefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerCollectedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}

using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObject;

    public override void Interact(PlayerInteraction player)
    {
        if (!HasKitchenOject())
        {
            if (player.HasKitchenOject())
            {
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {
            if (!player.HasKitchenOject())
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform counterTopPoint;
    private KitchenObject currentKitchenObject;

    public virtual void Interact(PlayerInteraction player) { }

    public Transform GetKitchenObjectPlacementTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject _kitchenObject)
    {
        this.currentKitchenObject = _kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return currentKitchenObject;
    }

    public void ClearKitchenObject()
    {
        currentKitchenObject = null;
    }

    public bool HasKitchenOject()
    {
        return currentKitchenObject != null;
    }
}

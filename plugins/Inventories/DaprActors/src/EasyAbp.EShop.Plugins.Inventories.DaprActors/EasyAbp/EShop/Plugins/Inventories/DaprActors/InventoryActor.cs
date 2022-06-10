using System.Threading.Tasks;
using Dapr;
using Dapr.Actors.Runtime;

namespace EasyAbp.EShop.Plugins.Inventories.DaprActors;

public class InventoryActor : Actor, IInventoryActor
{
    public InventoryActor(ActorHost host) : base(host)
    {
    }

    protected override async Task OnActivateAsync()
    {
        await StateManager.TryAddStateAsync(Id.GetId(), new InventoryStateModel());
    }

    public virtual async Task<InventoryStateModel> GetInventoryStateAsync()
    {
        return await StateManager.GetStateAsync<InventoryStateModel>(Id.GetId());
    }

    public virtual async Task IncreaseInventoryAsync(int quantity, bool decreaseSold)
    {
        var state = await GetInventoryStateAsync();

        InternalIncreaseInventory(state, quantity, decreaseSold);
    }

    public async Task ReduceInventoryAsync(int quantity, bool increaseSold)
    {
        var state = await GetInventoryStateAsync();

        InternalReduceInventory(state, quantity, increaseSold);
    }

    protected virtual void InternalIncreaseInventory(InventoryStateModel stateModel, int quantity, bool decreaseSold)
    {
        if (quantity < 0)
        {
            throw new DaprException("Quantity should not be less than 0.");
        }

        if (decreaseSold && stateModel.Sold - quantity < 0)
        {
            throw new DaprException("Target Sold cannot be less than 0.");
        }

        stateModel.Inventory = checked(stateModel.Inventory + quantity);

        if (decreaseSold)
        {
            stateModel.Sold -= quantity;
        }
    }

    protected virtual void InternalReduceInventory(InventoryStateModel stateModel, int quantity, bool increaseSold)
    {
        if (quantity < 0)
        {
            throw new DaprException("Quantity should not be less than 0.");
        }

        if (quantity > stateModel.Inventory)
        {
            throw new DaprException("Insufficient inventory.");
        }

        if (increaseSold)
        {
            stateModel.Sold = checked(stateModel.Sold + quantity);
        }

        stateModel.Inventory -= quantity;
    }
}
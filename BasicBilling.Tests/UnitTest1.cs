using BasicBilling.Services;
using BasicBilling.Mocks;

namespace BasicBilling.Tests;

public class UnitTest1
{
    [Fact]
    public async void BillingService_GetBillings_GetPendingBills()
    {
        var dbContext = await DataBaseContextMock.GetDBContext();
        var service = new BillingService(dbContext);
        var pendingBillings = (await service.GetBillings("Pending")).ToList();
        Assert.True(pendingBillings.Count > 0);
        foreach (var bill in pendingBillings)
        {
            Assert.Equal(bill.State, "Pending");
        }
    }
}
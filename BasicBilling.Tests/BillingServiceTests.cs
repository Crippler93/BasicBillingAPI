using BasicBilling.Services;
using BasicBilling.Mocks;
using BasicBilling.Data;

namespace BasicBilling.Tests;

public class BillingServiceTests
{
    private BillingService _service;

    public BillingServiceTests()
    {
        var dbContext = DataBaseContextMock.GetDBContext().GetAwaiter().GetResult();
        _service = new BillingService(dbContext);
    }

    [Fact]
    public async void BillingService_GetBillings_GetPendingBills()
    {
        var pendingBillings = (await _service.GetBillings("Pending")).ToList();
        Assert.True(pendingBillings.Count > 0);
        foreach (var bill in pendingBillings)
        {
            Assert.Equal(bill.State, "Pending");
        }
    }

    [Theory]
    [InlineData("ELECTRICITY")]
    [InlineData("WATER")]
    public async void BillingService_Search_ByCategory(string category)
    {
        var electricityBills = (await _service.Search(new SearchDTO(){ Category=category})).ToList();
        Assert.True(electricityBills.Count > 0);
        foreach (var bill in electricityBills)
        {
            Assert.Equal(bill.BillDetails.Category, category);
        }
    }

    [Fact]
    public async void BillingService_CreateBill_Success()
    {
        var newBill = await _service.CreateBill(new BillDTO{Category="TEST", Period=202211});
        Assert.Equal(newBill.Category, "TEST");
    }

    [Fact]
    public async void BillingService_CreateBill_Fail()
    {
        var newBill = await _service.CreateBill(new BillDTO{Category="TEST", Period=000000000});
        Assert.Equal(newBill, null);
    }
}
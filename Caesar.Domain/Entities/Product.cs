namespace Caesar.Domain.Entities;
using Interfaces;

public class Product : IAuditableEntity
{
    public long Id
    {
        get;
        set;
    }

    public string PriceId
    {
        get;
        set;
    }

    public bool? Paid
    {
        get;
        set;
    }

    public string StripeId
    {
        get;
        set;
    }

    public string CustomerStripeId
    {
        get;
        set;
    }

    public string? Description
    {
        get;
        set;
    }

    public DateTime CreatedAt
    {
        get;
        set;
    }

    public DateTime? LastUpdatedAt
    {
        get;
        set;
    }
}

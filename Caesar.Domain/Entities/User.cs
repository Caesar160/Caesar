﻿namespace Caesar.Domain.Entities;

using Interfaces;

public class User : IAuditableEntity
{
    public long Id
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }
    public string? Description
    {
        get;
        set;
    }

    public DateTime? DateOfBirth
    {
        get;
        set;
    }

    public string? Phone
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }

    public string CustomerStripeId
    {
        get;
        set;
    }

    public string? Role
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

    public virtual IList<Product>? Products
    {
        get;
        set;
    }
}

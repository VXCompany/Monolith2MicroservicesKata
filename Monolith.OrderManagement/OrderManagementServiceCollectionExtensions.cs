﻿using Microsoft.Extensions.DependencyInjection;
using Monolith.OrderManagement;

// Resharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class OrderManagementServiceCollectionExtensions
{
    public static void AddOrderManagement(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<CreateOrderUseCase>();
    }
}
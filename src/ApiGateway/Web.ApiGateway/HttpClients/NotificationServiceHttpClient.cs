﻿namespace Web.ApiGateway.HttpClients;

public class NotificationServiceHttpClient
{
    private readonly HttpClient _httpClient;

    public NotificationServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}
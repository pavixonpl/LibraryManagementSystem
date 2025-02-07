﻿using System.ComponentModel;
using System.Diagnostics;
using LibraryManagementSystem.Application.Services.Documents;
using LibraryManagementSystem.Infrastructure.Documents.Models;
using LibraryManagementSystem.Infrastructure.POCO;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Container = Microsoft.Azure.Cosmos.Container;

namespace LibraryManagementSystem.Infrastructure.Documents;

public class CosmosDbBookDocumentService : IBookDocumentService
{
    private readonly IOptions<CosmosOptions> _config;
    private readonly ILogger<CosmosDbBookDocumentService> _logger;

    public CosmosDbBookDocumentService(IOptions<CosmosOptions> config, ILogger<CosmosDbBookDocumentService> logger)
    {
        _config = config;
        _logger = logger;
    }
    public async Task UploadDocumentAsStream(Stream document, string name)
    {
        var model = Deserialize<UsedModel>(document);
        
        var timer = Stopwatch.StartNew();

        var client = new CosmosClient(_config.Value.ConnectionString);
        var container = client.GetContainer(_config.Value.DbName, _config.Value.CollectionName);

        model.Id = name;
        model.PartitionKey = string.Empty;
        await container.CreateItemAsync(model, new PartitionKey(string.Empty));

        timer.Stop();
        
        _logger.LogInformation($"Time to create item with creating connection: {timer.ElapsedMilliseconds}");
    }

    public static T Deserialize<T>(Stream s)
    {
        using (StreamReader reader = new StreamReader(s))
        using (JsonTextReader jsonReader = new JsonTextReader(reader))
        {
            JsonSerializer ser = new JsonSerializer();
            return ser.Deserialize<T>(jsonReader);
        }
    }

    //used for measurements
    private static async Task InvokeCreateItem(UsedModel model, Container container, int howManyTimes)
    {
        for (var i = 0; i < howManyTimes; i++)
        {
            var id = i.ToString();
            model.Id = Guid.NewGuid().ToString();
            model.PartitionKey = string.Empty;
            await container.CreateItemAsync(model, new PartitionKey(string.Empty));
        }
    }
}
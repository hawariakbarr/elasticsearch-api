using Elasticsearch.Net;
using ElasticsearchApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Elasticsearch
var url = builder.Configuration["Elasticsearch:Url"];
var username = builder.Configuration["Elasticsearch:Username"];
var password = builder.Configuration["Elasticsearch:Password"];
var defaultIndex = builder.Configuration["Elasticsearch:IndexName"];

var settings = new ConnectionSettings(new Uri(url))
    .BasicAuthentication(username, password)
    .DefaultIndex(defaultIndex)
    .ThrowExceptions();

var client = new ElasticClient(settings);

builder.Services.AddSingleton<IElasticClient>(client);
builder.Services.AddScoped<IElasticsearchService, ElasticsearchService>();

// Add logging
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

//app.UseAuthorization();

app.MapControllers();

app.Run();


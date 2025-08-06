// <copyright file="Program.cs" company="Tripath Logistics Pvt. Ltd.">
// Copyright (c) Tripath Logistics Pvt. Ltd.. All rights reserved.
// </copyright>

using AtGo2.DocumentService.Models.Configuration;
using AtGo2.DocumentService.Services;
using Microsoft.AspNetCore.Mvc.ViewEngines;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IFileHandlerFactory, FileHandlerFactory>();
builder.Services.Configure<DocumentHandlerConfiguration>(builder.Configuration.GetSection("DocumentHandlerConfiguration"));
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICompositeViewEngine, CompositeViewEngine>();
builder.Services.AddMvc();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();
app.Run();

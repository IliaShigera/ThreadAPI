// project usings

global using Thread.Api.Models;
global using Thread.Api.Start;
global using Thread.Api.Configuration.Extensions;
global using Thread.Modules.UserAccess.Infrastructure.Configuration;
global using Thread.Modules.UserAccess.Application.Contracts;
global using Thread.Modules.UserAccess.Application.Exceptions;
global using Thread.BuildingBlocks.Infrastructure.Configuration;
global using Thread.BuildingBlocks.Application.Exceptions;
global using Thread.BuildingBlocks.Domain.Exceptions;

// others
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Newtonsoft.Json;
global using Serilog;
global using Serilog.Core;
global using Serilog.Events;
global using Serilog.Formatting.Json;
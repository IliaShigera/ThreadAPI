// project usings

global using Thread.Modules.UserAccess.Application.Contracts;
global using Thread.Modules.UserAccess.Domain.UserRegistration;
global using Thread.Modules.UserAccess.Infrastructure.Domain;
global using Thread.Modules.UserAccess.Infrastructure.Persistence;
global using Thread.Modules.UserAccess.Infrastructure.Application;
global using Thread.Modules.UserAccess.Domain.Models;
global using Thread.Modules.UserAccess.Infrastructure.Configuration;
global using Thread.Modules.UserAccess.Application.Registration;

// others 
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Design;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using System.Reflection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using MediatR;
global using System.Security.Cryptography;
global using MailKit.Net.Smtp;
global using MimeKit;
global using MimeKit.Text;

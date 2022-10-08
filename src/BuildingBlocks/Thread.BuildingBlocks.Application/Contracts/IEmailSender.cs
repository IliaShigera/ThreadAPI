using Thread.BuildingBlocks.Application.Models;
using Thread.BuildingBlocks.Domain.Models;

namespace Thread.BuildingBlocks.Application.Contracts;

public interface IEmailSender
{
    Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
}
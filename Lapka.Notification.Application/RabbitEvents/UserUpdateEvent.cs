﻿using Convey.CQRS.Events;

namespace Lapka.Notification.Application.RabbitEvents;

public class UserUpdatedEvent : IEvent
{
    public Guid UserId { get; }
    public string Username { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }

    public UserUpdatedEvent(Guid userId, string username, string firstName, string lastName, string email)
    {
        UserId = userId;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}
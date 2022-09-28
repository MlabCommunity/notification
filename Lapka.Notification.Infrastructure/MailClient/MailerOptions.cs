﻿namespace Lapka.Notification.Infrastructure.MailClient;

internal class MailerOptions
{
    public string SenderName { get; set; }
    public string Server { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
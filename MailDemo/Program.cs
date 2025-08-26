using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;

var from = new MailboxAddress("Stuart", "stu@imorital.net");
var to = new MailboxAddress("Bob", "bob@imorital.net");

// Send a simple text email using MimeKit and MailKit

var message = new MimeMessage();
message.From.Add(from);
message.To.Add(to);

message.Subject = "Test email from MimeKit";

message.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
{
    Text = """
    This is a test email sent from MimeKit.

    The body here should just be in plain text.

    Let's hope it works!
    """
};

using var smtp = new SmtpClient();
await smtp.ConnectAsync("localhost", 1025);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);

Console.WriteLine("Simple Mail Sent!");

// Send a multi part email with an attachment
message = new MimeMessage();
message.From.Add(from);
message.To.Add(to);
message.Subject = "Test email with attachment from MimeKit";
var bodybuilder = new BodyBuilder();
bodybuilder.TextBody = "The body here should just be in plain text.";
bodybuilder.HtmlBody = "<p>The body here should be in <b>HTML</b>.</p>";
bodybuilder.Attachments.Add("attachment.txt");
message.Body = bodybuilder.ToMessageBody();

using var secondSmtp = new SmtpClient();
await secondSmtp.ConnectAsync("localhost", 1025);
await secondSmtp.SendAsync(message);
await secondSmtp.DisconnectAsync(true);

Console.WriteLine("Multi-Part Mail Sent!");

// Send an email with an embedded image
message = new MimeMessage();
message.From.Add(from);
message.To.Add(to);
message.Subject = "Test email with embedded image from MimeKit";
var builder = new BodyBuilder();
var image = builder.LinkedResources.Add("image.png");
image.ContentId = MimeUtils.GenerateMessageId();
builder.HtmlBody = string.Format("<p>This email contains an embedded image.</p><img src=\"cid:{0}\" alt=\"Image alt text\">", image.ContentId);
message.Body = builder.ToMessageBody();

using var thirdSmtp = new SmtpClient();
await thirdSmtp.ConnectAsync("localhost", 1025);
await thirdSmtp.SendAsync(message);
await thirdSmtp.DisconnectAsync(true);

Console.WriteLine("Mail with Embedded Image Sent!");

Console.WriteLine("*** Demo Finished ***");

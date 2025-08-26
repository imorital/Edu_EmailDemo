# Introduction

This is a small project to demonstrate how to send emails correctly using [MimeKit](https://github.com/jstedfast/MimeKit) 
and [MailKit](https://github.com/jstedfast/MailKit), based on a [YouTube video](https://youtu.be/1KrqMZNTvpY?si=42k7wbLpMLsTvOLM). 
I have also document the usage detaiuls on my wiki [here](https://imorital.co.uk/CSharp/Tips/Introduction-to-Sending-Email/), which 
should be used as the main source of information for what is going on here. This is just the implementation to demonstrate the concept.

The Demo is a simple console application that sends an email using SMTP.

## Build and Test

To build and test the project, you will need to have .NET SDK installed on your machine. You can download it from [here](https://dotnet.microsoft.com/download). The code uses .Net 8.0

To actually send the email we need to use a real SMTP server. You can use any SMTP server you have access to, but for this demo, I will use [Mailpit](https://mailpit.axllent.org).

To install tihs on Docker see [this page](https://hub.docker.com/r/axllent/mailpit), but baiscally I ran the following command:

```bash
docker run -d --name=mailpit --restart unless-stopped -p 8025:8025 -p 1025:1025 axllent/mailpit
```

With this running you can access the web interface at [http://localhost:8025](http://localhost:8025) and the SMTP server is running on `localhost:1025`.

Now we can run the project and our email should appear in the Mailpit web interface.


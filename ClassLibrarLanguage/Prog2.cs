


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

public interface IMobileServive
{
    void Execute();
}
public class SMSService : IMobileServive
{
    public void Execute()
    {
        Console.WriteLine("SMS service executing.");
    }
}

public interface IMailService
{
    void Execute();
}

public class EmailService : IMailService
{
    public void Execute()
    {
        Console.WriteLine("Email service Executing.");
    }
}

public class NotificationSender
{
    public IMobileServive ObjMobileSerivce = null;
    public IMailService ObjMailService = null;

    //injection through constructor  
    public NotificationSender(IMobileServive tmpService)
    {
        ObjMobileSerivce = tmpService;
    }
    //Injection through property  
    public IMailService SetMailService
    {
        set { ObjMailService = value; }
    }
    public void SendNotification()
    {
        ObjMobileSerivce.Execute();
        ObjMailService.Execute();
    }
}

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SMSService>().As<IMobileServive>();
            builder.RegisterType<EmailService>().As<IMailService>();
            var container = builder.Build();

            container.Resolve<IMobileServive>().Execute();
            container.Resolve<IMailService>().Execute();
            Console.ReadLine();
        }
    }
}  
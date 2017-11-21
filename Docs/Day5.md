# Day 5
## The Problem

> We would like to associate the **State** of the **NetworkService** to a **Description** in order to give the user a friendly text

## Step 1 - The Analysis

We decide to print a message on the screen everytime the NetworkService goes online and offline.
We decide that printing the message on the screen is a job for the PhoneUI, so we connect the two events of the NetworkService to a method of the PhoneUI that updates the screen with the State of the NetworkService.

## Step 2 - Writing the code

```
using PhoneNS.BusinessLogic;
using System;

namespace PhoneNS.UserInterface
{
    /// <summary>
    /// The User interface component of the Phone
    /// </summary>
    internal class PhoneUI
    {
        private PhoneBL logic;
        /// <summary>
        /// Initializes the User Interface
        /// </summary>
        /// <param name="logic">The Business Logic component to talk to</param>
        internal PhoneUI(PhoneBL logic)
        {
            this.logic = logic;
            this.logic.NetworkService.OnlineEvent += onNetworkEvent;
            this.logic.NetworkService.OfflineEvent += onNetworkEvent;
        }

        /// <summary>
        /// Updates the screen with the state of the network connection
        /// </summary>
        private void onNetworkEvent()
        {
            Console.WriteLine(this.logic.NetworkService.State);
            Console.ReadLine();
        }

        /// <summary>
        /// It starts the AppDrawer to show the list of available Apps 
        /// </summary>
        public void MainScreen() {
            Console.Clear();
            Console.WriteLine($"*****{logic.Brand} {logic.Model}*****");
            logic.AppDrawer.Start();
            Console.WriteLine("Bye.");
        }
    }
}
```

## Step 3 - Refactor 

The user tells us that instead of "Online" he would like to see "Connected to the Network".
We first change our code this way:

```
private void onNetworkEvent()
{
    if(logic.NetworkService.State==Phone.Services.NetworkState.Online)
        Console.WriteLine("Connected to the network");
    else
        Console.WriteLine(logic.NetworkService.State);
    Console.ReadLine();
}
```

It works but it's not very neat. What would happen if we need another place in the application where we want to print the same kind of messages? We would have to repeat this logic.
It would be better to link this **Description** directly on the **enumeration** itself and then retrieve this message everytime we need to print it.
Unfortunately Enumerations do not give us the chance to add a property to them.
We decide to use a custom made **Attribute**. 

We first create a simple **DescriptionAttribute** with one mandatory value that can be retrieved through a **Description** *property*

```
using System;

namespace Phone.Enums
{
    /// <summary>
    /// Description Metadata for a Field. Used for Enumerations.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class DescriptionAttribute : Attribute
    {
        readonly string description;

        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// A User friendly description
        /// </summary>
        public string Description
        {
            get { return description; }
        }
    }
}
```

We can now apply our attribute on any field we like:

```
public enum NetworkState {
    Offline,
    [Description("Connected to the network")]
    Online
}
``` 

In order to get the description we need to write a small *method* that uses **Reflection**. We decide to add it to our **PhoneUI** *class*

```
private string getDescription(Enum value)
{
    Type enumType = value.GetType();
    FieldInfo field = enumType.GetField(value.ToString());
    Attribute attribute = field.GetCustomAttribute(typeof(DescriptionAttribute));

    // return  
    return attribute == null ? value.ToString() : ((DescriptionAttribute)attribute).Description;
}
```

We can now update our **OnNetworkEvent** method as follows

```
/// <summary>
/// Updates the screen with the state of the network connection
/// </summary>
private void onNetworkEvent()
{
    Console.WriteLine(getDescription(logic.NetworkService.State));
    Console.ReadLine();
}
```

We realize that our method could come in handy on other parts of the application as well, so we decide to implement as an **Extension Method** of any **Enum**

```
public static class EnumsExtensions {
    /// <summary>
    /// Gets the Description Attribute Value eventually applied to an Enumeration
    /// </summary>
    /// <param name="value">The Enumeration field to which the Description has been applied to</param>
    /// <returns>The Description Attribute value applied to an Enumeration if present, the original value of the Enum field otherwise</returns>
    public static string GetDescription(this Enum value) {
        Type enumType = value.GetType();
        FieldInfo field = enumType.GetField(value.ToString());
        Attribute attribute = field.GetCustomAttribute(typeof(DescriptionAttribute));
        
        // return  
        return attribute==null ? value.ToString() : ((DescriptionAttribute)attribute).Description;
    }
}
```

The **PhoneUI** becomes

```
using Phone.Enums;
using PhoneNS.BusinessLogic;
using System;

namespace PhoneNS.UserInterface
{
    /// <summary>
    /// The User interface component of the Phone
    /// </summary>
    internal class PhoneUI
    {
        private PhoneBL logic;
        /// <summary>
        /// Initializes the User Interface
        /// </summary>
        /// <param name="logic">The Business Logic component to talk to</param>
        internal PhoneUI(PhoneBL logic)
        {
            this.logic = logic;
            this.logic.NetworkService.OnlineEvent += onNetworkEvent;
            this.logic.NetworkService.OfflineEvent += onNetworkEvent;
        }

        /// <summary>
        /// Updates the screen with the state of the network connection
        /// </summary>
        private void onNetworkEvent()
        {
            Console.WriteLine(logic.NetworkService.State.GetDescription());
            Console.ReadLine();
        }

        /// <summary>
        /// It starts the AppDrawer to show the list of available Apps 
        /// </summary>
        public void MainScreen() {
            Console.Clear();
            Console.WriteLine($"*****{logic.Brand} {logic.Model}*****");
            logic.AppDrawer.Start();
            Console.WriteLine("Bye.");
        }
    }
}
``` 
using System;
using System.Collections.Generic;

namespace TaskThree
{

    /// Задача - перепишите данный код так, чтобы он работал через коллекции C#, вместо конструкции switch


    public enum ActionType
    {
        Create,

        Read,

        Update,

        Delete
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<ActionType, Delegate> ActionMapping = new Dictionary<ActionType, Delegate>()
            {
                { ActionType.Create, new Action<ActionType>(CreateMethod) },
                { ActionType.Read, new Action<ActionType>(ReadMethod) },
                { ActionType.Update, new Action<ActionType>(UpdateMethod) },
                { ActionType.Delete, new Action<ActionType>(DeleteMethod) }
            };

            var type = ActionType.Read;
            ActionMapping[type].DynamicInvoke(type);
        }

        //!!! duplications below - ActionType is input parameter and ActionType can be inferred from function names. Probably we need 1 function with switch-case instead of 4  or just remove parameters
        private static void CreateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void ReadMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void UpdateMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }

        private static void DeleteMethod(ActionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
}

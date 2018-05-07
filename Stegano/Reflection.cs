using System;
using System.Collections.Generic;
using System.Linq;

namespace Stegano
{
    class Reflection
    {
        public static object CreateObjectByName(string name)
        {
            return Activator.CreateInstance(TypeByName(name));
        }

        public static string[] GetTypesNames(String parent)
        {
            IEnumerable<Type> blocks = Reflection.GetAllSubclassOf(Reflection.TypeByName(parent));
            string[] names = new string [blocks.Count<Type>()];
            int i = 0;
            foreach (var type in blocks)
            {
                names[i] = type.ToString();
                i++;
            }
            return names;
        }

        public static Type TypeByName(string name)
        {
            return Type.GetType(name);
        }

        public static IEnumerable<Type> GetAllSubclassOf(Type parent)
        {
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var t in a.GetTypes())
                {
                    if (t.IsSubclassOf(parent))
                    {
                        yield return t;
                    }
                }
            }
        }
    }
}

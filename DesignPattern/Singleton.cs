using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    /// <summary>
    /// 采用C# Static Constructor
    /// </summary>
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        
        static Singleton()
        {

        }

        private Singleton()
        {

        }

        public static Singleton Instance
        {
            get { return instance; }
        }
    }
}
